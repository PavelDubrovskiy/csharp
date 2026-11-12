using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.ZabbixIntegraion.Dto;
using Mfc.Health.Corner.ZabbixIntegration.Dto;
using Mfc.Health.Corner.ZabbixIntegration.Repositories.Interfases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Mfc.Health.Corner.ZabbixIntegration.Repositories.Implementations
{
    public class TriggersRepository : ITriggersRepository
    {
        //  private readonly zabbixserverContext db;
        private readonly IConfiguration _configuration;
        public TriggersRepository(IConfiguration configuration/*, zabbixserverContext context*/)
        {
            // db = context;
            _configuration = configuration;
        }


        public async Task<List<ZabbixTopTriggerDto>> GetTopTriggers()
        {
            try
            {
                await GetMfcCornerDeviceInfoDto(DateTime.Now.AddHours(-1), DateTime.Now, "61fe9ac2387c02457e9e3fc4");

                using (var db = new zabbixserverContext(_configuration))
                {
                    DateTime startCurrenntmonthDate = DateTime.Today.AddDays((DateTime.Today.Day) * -1);
                    int unixstartCurrenntmonthDate = (int)startCurrenntmonthDate.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
                    //var hostName = "mfc_corner_61fe9ac2387c02457e9e3fc4";
                    var hostPart = "mfc_corner_";

                    var query = from h in db.Hosts
                                join i in db.Items on h.Hostid equals i.Hostid
                                join f in db.Functions on i.Itemid equals f.Itemid
                                join t in db.Triggers on f.Triggerid equals t.Triggerid
                                join e in db.Events on t.Triggerid equals e.Objectid
                                where h.Host1.StartsWith(hostPart) &&
                                t.Priority >= 0 &&
                                e.Clock > unixstartCurrenntmonthDate
                                select new
                                {
                                    Host1 = h.Host1,
                                    Description = t.Description,
                                    Tid = t.Triggerid,
                                    Ex = e.Eventid
                                };

                    var topList = (await query.ToListAsync())
                        .GroupBy(x => x.Description)
                        .Select(x => new ZabbixTopTriggerDto
                        {
                            Text = x.Key,
                            Mfcs = x.Select(x => x.Host1).Distinct().ToList(),
                            Count = x.Select(x => x.Ex).Distinct().Count()
                        }).OrderByDescending(x => x.Count).ToList();

                    return topList;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<JournalEventsTime>> GetEventLogByDay(DateTime start, DateTime end, List<string> mfcCornerIds)
        {
            try
            {
                using (var db = new zabbixserverContext(_configuration))
                {
                   // DateTime startCurrenntmonthDate = DateTime.Today.AddDays(-1);
                    //DateTime start = DateTime.Today;
                    //DateTime end = DateTime.Today.AddHours(23).AddMinutes(59);
                    int unixStart = ConvertToUnixTime(start);
                    int unixEnd = ConvertToUnixTime(end);
                    //  int unixstartCurrenntmonthDate = (int)startCurrenntmonthDate.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
                    //var hostName = "mfc_corner_61fe9ac2387c02457e9e3fc4";
                    var host = $"mfc_corner_61fe9ac2387c02457e9e3fc4";
                    var hostPart = "mfc_corner_";
                    var query1 = from h in db.Hosts
                                 join i in db.Items on h.Hostid equals i.Hostid
                                 join f in db.Functions on i.Itemid equals f.Itemid
                                 join t in db.Triggers on f.Triggerid equals t.Triggerid
                                 join e in db.Events on t.Triggerid equals e.Objectid
                                 //join a in db.Alerts on e.Eventid equals a.Eventid
                                 where h.Host1.StartsWith(hostPart) &&
                                 t.Priority >= 1 &&
                                 e.Clock >= unixStart &&
                                 e.Clock <= unixEnd
                                 select new
                                 {
                                     name = e.Name,
                                     clock = e.Clock,
                                     Eid = e.Eventid,
                                     Priority = t.Priority,
                                     host = h.Host1
                                 };

                    var list = (await query1.ToListAsync())
                        .GroupBy(x => x.Eid)
                        .Select(x => new JournalEventsTime
                        {
                            Mfc = x.Select(x => x.host).FirstOrDefault(),
                            Text = x.Select(x => x.name).FirstOrDefault(),
                            DateTime = x.Select(x => new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(x.clock)).FirstOrDefault(),
                            Time = x.Select(x => new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(x.clock).ToString("H:mm")).FirstOrDefault(),
                            Type = x.Select(x => GetPriorityName(x.Priority)).FirstOrDefault()
                        }).Where(x => mfcCornerIds.Contains(x.Mfc.Replace(hostPart, ""))).OrderByDescending(x => x.DateTime).ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<JornalStatisticDto>> GetEventLogByPeriodFromHost(DateTime start, DateTime end, string mfcCornerId)
        {
            try
            {
                using (var db = new zabbixserverContext(_configuration))
                {
                    DateTime startCurrenntmonthDate = DateTime.Today.AddDays(-1);
                    //DateTime start = DateTime.Today;
                    //DateTime end = DateTime.Today.AddHours(23).AddMinutes(59);
                    int unixStart = ConvertToUnixTime(start);
                    int unixEnd = ConvertToUnixTime(end);
                    //  int unixstartCurrenntmonthDate = (int)startCurrenntmonthDate.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
                    //var hostName = "mfc_corner_61fe9ac2387c02457e9e3fc4";
                    var host = $"mfc_corner_{mfcCornerId}";
                    var hostPart = "mfc_corner_";
                    var query1 = from h in db.Hosts
                                 join i in db.Items on h.Hostid equals i.Hostid
                                 join f in db.Functions on i.Itemid equals f.Itemid
                                 join t in db.Triggers on f.Triggerid equals t.Triggerid
                                 join e in db.Events on t.Triggerid equals e.Objectid
                                 where h.Host1 == host &&
                                 t.Priority >= 0 &&
                                 e.Clock >= unixStart &&
                                 e.Clock <= unixEnd
                                 select new
                                 {
                                     clock = e.Clock,
                                     Eid = e.Eventid,
                                     Priority = t.Priority,
                                     host = h.Host1
                                 };

                    var list = (await query1.ToListAsync())
                        .GroupBy(x => x.Eid)
                        .Select(x => new JornalStatisticDto
                        {
                            Host = x.Select(x => x.host).FirstOrDefault(),
                            Clock = x.Select(x => new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(x.clock)).FirstOrDefault(),
                            Priority = x.Select(x => x.Priority ).FirstOrDefault(),
                        }).OrderByDescending(x => x.Clock).ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<MfcCornerDeviceInfoDto> GetMfcCornerDeviceInfoDto( DateTime start, DateTime end, string mfcCornerId)
        {
            try
            {
                using (var db = new zabbixserverContext(_configuration))
                {
                    int localTimeIndex = 3;
                    start = DateTime.Now.AddHours(-1).AddHours(-localTimeIndex);
                    end = DateTime.Now.AddHours(-localTimeIndex);
                    int unixStart = ConvertToUnixTime(start);
                    int unixEnd = ConvertToUnixTime(end);

                    var host = $"mfc_corner_{mfcCornerId}";
                    
                    var query1 = from h in db.Hosts
                                 join i in db.Items on h.Hostid equals i.Hostid
                                 join ht in db.HistoryTexts on i.Itemid equals ht.Itemid
                                 where h.Host1 == host &&
                                 ht.Clock >= unixStart &&
                                 ht.Clock<= unixEnd
                                 && ht.Value.StartsWith("{")

                                 select new
                                 {

                                     Ht = ht,
                                     Host = h.Host1
                                 };

                    var data = (await query1.ToListAsync());

                    var list =
                        data.Count()==0? new MfcCornerDeviceInfoDto {
                            Host = mfcCornerId, 
                            Data = new List<DeviceInfoWithTimeDto>() 
                        } :
                        data.GroupBy(x => x.Host)
                        .Select(x => new MfcCornerDeviceInfoDto
                        {
                            Host = x.Key.Replace("mfc_corner_",""),
                            Data = x.Select(x => new DeviceInfoWithTimeDto
                            {
                                DateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(x.Ht.Clock).AddHours(localTimeIndex),
                                DeviceStatusInfo = JsonConvert.DeserializeObject<DeviceStatusInfo>(x.Ht.Value)
                            }).ToList()
                        }).First()??null;

                    return list;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
           
        }     


        private int ConvertToUnixTime(DateTime date)
        {
            return (int)date.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }


        private string GetPriorityName(int index)
        {
            string result = "";

            switch (index)
            {
                case 3:
                    result = "info";
                    break;
                case 4:
                    result = "warning";
                    break;
                case 5:
                    result = "error";
                    break;
                default:
                    result = "info";
                    break;
            }
            return result;
        }




    }
}

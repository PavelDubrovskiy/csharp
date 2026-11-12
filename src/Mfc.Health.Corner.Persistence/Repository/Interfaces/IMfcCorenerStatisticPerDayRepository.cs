using Mfc.Health.Corner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Interfaces
{
    public interface IMfcCorenerStatisticPerDayRepository
    {
        public Task<MfcCorenerStatisticPerDay> CreateStatistic(MfcCorenerStatisticPerDay newMfcCorenerStatisticPerDay);
        public Task<MfcCorenerStatisticPerDay> UpdateStatistic(MfcCorenerStatisticPerDay newMfcCorenerStatisticPerDay);
        public Task<MfcCorenerStatisticPerDay> GetMfcCorenerStatisticPerDayById(string id);
        public Task<MfcCorenerStatisticPerDay> GetTodayStatistic(string MfcCornerId);
        public Task<List<MfcCorenerStatisticPerDay>> GetStatisticForPeriod(DateTime? start, DateTime? end, string mfcCornerId);
        public Task<List<MfcCorenerStatisticPerDay>> GetStatisticForPeriod(DateTime? start, DateTime? end, List<string> MfcCornerId);
        public Task UpdateAllStatisticMfcIds(string id);
        public Task<List<MfcCorenerStatisticPerDay>> GetAllStatisticForMfcById(string id);
    }
}

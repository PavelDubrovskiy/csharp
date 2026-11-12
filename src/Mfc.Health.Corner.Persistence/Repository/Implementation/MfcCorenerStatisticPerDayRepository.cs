using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Data;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Implementation
{
    public class MfcCorenerStatisticPerDayRepository : IMfcCorenerStatisticPerDayRepository
    {

        private readonly DbContext _context = null;

        public MfcCorenerStatisticPerDayRepository(IOptions<MongoDBConfig> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task<MfcCorenerStatisticPerDay> CreateStatistic(MfcCorenerStatisticPerDay newMfcCorenerStatisticPerDay)
        {
            await _context.MfcCorenerStatisticPerDays.InsertOneAsync(newMfcCorenerStatisticPerDay);
            return newMfcCorenerStatisticPerDay;
        }

        public async Task<List<MfcCorenerStatisticPerDay>> GetStatisticForPeriod(DateTime? start, DateTime? end, string mfcCornerId)
        {
            var filterBuilder = start == null || end == null ? Builders<MfcCorenerStatisticPerDay>.Filter.Where(x => x.MfcCornerId == mfcCornerId) :
                Builders<MfcCorenerStatisticPerDay>.Filter
             .Where(x => x.MfcCornerId == mfcCornerId && x.Date >= start && x.Date <= end);

            var statistic = await _context.MfcCorenerStatisticPerDays.Find(filterBuilder). SortBy(x => x.Date).ToListAsync();
            return statistic;
        }

        public async Task<List<MfcCorenerStatisticPerDay>> GetStatisticForPeriod(DateTime? start, DateTime? end, List<string> mfcCornerIds)
        {
            var filterBuilder = end != null && end == null ? Builders<MfcCorenerStatisticPerDay>.Filter.Empty :
                Builders<MfcCorenerStatisticPerDay>.Filter
             .Where(x => mfcCornerIds.Contains(x.MfcCornerId) && x.Date >= start && x.Date <= end);

            var statistic = await _context.MfcCorenerStatisticPerDays.Find(filterBuilder).SortBy(x => x.Date).ToListAsync();
            return statistic;
        }

        public async Task<MfcCorenerStatisticPerDay> GetTodayStatistic(string mfcCornerId)
        {
            DateTime start = DateTime.Today;
            DateTime end = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);
            var filterBuilder =  Builders<MfcCorenerStatisticPerDay>.Filter
                .Where( x =>x.MfcCornerId== mfcCornerId && x.Date >= start && x.Date <= end);
            var todayStatistic = await _context.MfcCorenerStatisticPerDays.Find(filterBuilder).FirstOrDefaultAsync();
            return todayStatistic;
        }

        public async Task UpdateAllStatisticMfcIds(string id)
        {
            var filter = Builders<MfcCorenerStatisticPerDay>.Filter.Empty;
            var update = Builders<MfcCorenerStatisticPerDay>.Update.Set(x => x.MfcCornerId, id);
            await _context.MfcCorenerStatisticPerDays.UpdateManyAsync(filter, update);
            await Task.Delay(TimeSpan.FromSeconds(3));
        }
        public async Task<List<MfcCorenerStatisticPerDay>> GetAllStatisticForMfcById(string id)
        {
            var filterBuilder = Builders<MfcCorenerStatisticPerDay>.Filter.Empty;
            var allStatistic = await _context.MfcCorenerStatisticPerDays
                .Find(filterBuilder).SortBy(x => x.Date).ToListAsync();
            return allStatistic;
        }

        public async Task<MfcCorenerStatisticPerDay> UpdateStatistic(MfcCorenerStatisticPerDay mfcCorenerStatisticPerDay)
        {
            await _context.MfcCorenerStatisticPerDays.ReplaceOneAsync(x => x.Id == mfcCorenerStatisticPerDay.Id, mfcCorenerStatisticPerDay);
            return mfcCorenerStatisticPerDay;
        }

        public async Task<MfcCorenerStatisticPerDay> GetMfcCorenerStatisticPerDayById(string id)
        {
            var mfcCorenerStatisticPerDay = await _context.MfcCorenerStatisticPerDays.Find(x => x.Id == id).FirstOrDefaultAsync();
            return mfcCorenerStatisticPerDay;
        }

    }
}

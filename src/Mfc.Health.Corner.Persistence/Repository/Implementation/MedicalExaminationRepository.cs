using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Data;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Implementation
{
    public class MedicalExaminationRepository : IMedicalExaminationRepository
    {
        private readonly DbContext _context = null;

        public MedicalExaminationRepository(IOptions<MongoDBConfig> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task<string> CreateMedicalExaminationAsync(UserMedicalExamination userMedicalExamination)
        {
            await _context.UserMedicalExaminations.InsertOneAsync(userMedicalExamination);
            return userMedicalExamination.Id;
        }

        public async Task<UserMedicalExamination> FindIncompleteMedicalExamination()
        {
            return await _context.UserMedicalExaminations.Find(x => x.IsCompleted == false).FirstOrDefaultAsync();
        }

        public Task<UserMedicalExamination> GetLastMedicalExamination()
        {
            return _context.UserMedicalExaminations.AsQueryable().
                 OrderByDescending(c => c.Id).FirstOrDefaultAsync();
        }
        public async Task<List<UserMedicalExamination>> GetLastTenExamination(string mfcCorrnerId)
        {
            var result = await _context.UserMedicalExaminations
                .Find(x => x.MfcCornerId == mfcCorrnerId)
                .SortByDescending(x => x.CreateDate)
                .Limit(10).ToListAsync();
            return result;
        }

        public async Task<UserMedicalExamination> GetLatest()
        {
            var filterBuilder = Builders<UserMedicalExamination>.Filter.Where(x => x.IsCompleted == false);

            return await _context.UserMedicalExaminations.Find(filterBuilder).FirstOrDefaultAsync();
        }

        public async Task SaveExaminationAsync(UserMedicalExamination userMedicalExamination)
        {
            await _context.UserMedicalExaminations.ReplaceOneAsync(x => x.Id == userMedicalExamination.Id, userMedicalExamination);
        }

        public async Task<long> GetAllExaminationCountForAllMfcCorner(DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            var filterBuilder = startDate != null && endDate == null ? Builders<UserMedicalExamination>.Filter.Empty :
               Builders<UserMedicalExamination>.Filter.Where(x => x.CreateDate >= startDate.Value.Date && x.CreateDate <= endDate.Value.Date);

            var allExaminationCount = await _context.UserMedicalExaminations.Find(filterBuilder).CountDocumentsAsync();
            return allExaminationCount;
        }
        public async Task<long> GetTodayExaminationCountForMfcCorner(string mfcCornerId)
        {
            var start = new DateTimeOffset(DateTime.Today, DateTimeOffset.Now.Offset);
            var end = start.AddDays(1).AddSeconds(-1);
            var filterBuilder = Builders<UserMedicalExamination>.Filter.Where(x => x.MfcCornerId == mfcCornerId &&
           x.CreateDate >= start &&
           x.CreateDate <= end);

            return await _context.UserMedicalExaminations.Find(filterBuilder).CountDocumentsAsync();
        }

        public async Task<long> GetAllExaminationCountForMfcCorner(string mfcCornerId, DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            var filterBuilder = startDate == null || endDate == null ?
                Builders<UserMedicalExamination>.Filter.Where(x => x.MfcCornerId == mfcCornerId) :
               Builders<UserMedicalExamination>.Filter.Where(x => x.MfcCornerId == mfcCornerId &&
                   x.CreateDate >= startDate.Value.Date && x.CreateDate <= endDate.Value.Date);

            var allExaminationCount = await _context.UserMedicalExaminations.Find(filterBuilder).CountDocumentsAsync();
            return allExaminationCount;
        }

        public async Task<List<UserMedicalExamination>> GetAnalyzerExaminationForMfcCorner(string mfcCornerId, DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            var filterBuilder = startDate == null || endDate == null ?
               Builders<UserMedicalExamination>.Filter.Where(
                   x => x.MfcCornerId == mfcCornerId && x.IsCompleted && x.Examination != null && x.Examination.Data.Result.Analyzer != null) :
              Builders<UserMedicalExamination>.Filter.Where(
                  x => x.MfcCornerId == mfcCornerId && x.IsCompleted && x.Examination != null && x.Examination.Data.Result.Analyzer != null &&
                  x.CreateDate >= startDate.Value.Date && x.CreateDate <= endDate.Value.Date);

            var allExamination = await _context.UserMedicalExaminations.Find(filterBuilder).ToListAsync();
            return allExamination;
        }

        public async Task<long> GetAnalyzerExaminationCountForMfcCorner(string mfcCornerId, DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            var filterBuilder = startDate == null || endDate == null ?
                Builders<UserMedicalExamination>.Filter.Where(
                    x => x.MfcCornerId == mfcCornerId && x.IsCompleted && x.Examination != null && x.Examination.Data.Result.Analyzer != null) :
               Builders<UserMedicalExamination>.Filter.Where(
                   x => x.MfcCornerId == mfcCornerId && x.IsCompleted && x.Examination != null && x.Examination.Data.Result.Analyzer != null &&
                   x.CreateDate >= startDate.Value.Date && x.CreateDate <= endDate.Value.Date);

            var datasQuoery = _context.UserMedicalExaminations.Find(filterBuilder);
            var analyzerExaminationCount = await datasQuoery.CountDocumentsAsync();
            return analyzerExaminationCount;
        }

        public async Task<long> GetBpbioExaminationCountForMfcCorner(string mfcCornerId, DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            var filterBuilder = startDate == null && endDate == null ?
                Builders<UserMedicalExamination>.Filter.Where(
                    x => x.MfcCornerId == mfcCornerId && x.IsCompleted && x.Examination != null && x.Examination.Data.Result.Bpbio != null) :
               Builders<UserMedicalExamination>.Filter.Where(
                   x => x.MfcCornerId == mfcCornerId && x.IsCompleted && x.Examination != null && x.Examination.Data.Result.Bpbio != null &&
                   x.CreateDate >= startDate.Value.Date && x.CreateDate <= endDate.Value.Date);

            var datasQuoery = _context.UserMedicalExaminations.Find(filterBuilder);
            var bpbioExaminationCount = await datasQuoery.CountDocumentsAsync();
            return bpbioExaminationCount;
        }

        public async Task<long> GetBsmExaminationCountForMfcCorner(string mfcCornerId, DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            var filterBuilder = startDate == null && endDate == null ?
                Builders<UserMedicalExamination>.Filter.Where(
                    x => x.MfcCornerId == mfcCornerId && x.IsCompleted && x.Examination != null && x.Examination.Data.Result.Bsm != null) :
               Builders<UserMedicalExamination>.Filter.Where(
                   x => x.MfcCornerId == mfcCornerId && x.IsCompleted && x.Examination != null && x.Examination.Data.Result.Bsm != null &&
                   x.CreateDate >= startDate.Value.Date && x.CreateDate <= endDate.Value.Date);

            var datasQuoery = _context.UserMedicalExaminations.Find(filterBuilder);
            var bsmExaminationCount = await datasQuoery.CountDocumentsAsync();
            return bsmExaminationCount;
        }

        public async Task<long> GetGazExaminationCountForMfcCorner(string mfcCornerId, DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            var filterBuilder = startDate == null && endDate == null ?
                Builders<UserMedicalExamination>.Filter.Where(
                    x => x.MfcCornerId == mfcCornerId && x.IsCompleted && x.Examination != null && x.Examination.Data.Result.Gaz != null) :
               Builders<UserMedicalExamination>.Filter.Where(
                   x => x.MfcCornerId == mfcCornerId && x.IsCompleted && x.Examination != null && x.Examination.Data.Result.Gaz != null &&
                   x.CreateDate >= startDate.Value.Date && x.CreateDate <= endDate.Value.Date);

            var datasQuoery = _context.UserMedicalExaminations.Find(filterBuilder);
            var gazExaminationCount = await datasQuoery.CountDocumentsAsync();
            return gazExaminationCount;
        }

        public async Task<long> GetPulseExaminationCountForMfcCorner(string mfcCornerId, DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            var filterBuilder = startDate == null && endDate == null ?
                Builders<UserMedicalExamination>.Filter.Where(
                    x => x.MfcCornerId == mfcCornerId && x.IsCompleted && x.Examination != null && x.Examination.Data.Result.Pulse != null) :
               Builders<UserMedicalExamination>.Filter.Where(
                   x => x.MfcCornerId == mfcCornerId && x.IsCompleted && x.Examination != null && x.Examination.Data.Result.Pulse != null &&
                   x.CreateDate >= startDate.Value.Date && x.CreateDate <= endDate.Value.Date);

            var datasQuoery = _context.UserMedicalExaminations.Find(filterBuilder);
            var pulseExaminationCount = await datasQuoery.CountDocumentsAsync();
            return pulseExaminationCount;
        }

        public async Task<long> GetAllExaminationCountForLastWeek()
        {
            var endDate = DateTimeOffset.Now;
            var startDate = endDate.AddDays(-7);
            var filterBuilder = Builders<UserMedicalExamination>.Filter.Where(
                x => x.CreateDate >= startDate &&
                x.CreateDate <= endDate && x.IsCompleted && x.Examination != null);

            var datasQuoery = _context.UserMedicalExaminations.Find(filterBuilder);
            var analyzerExaminationCount = await datasQuoery.CountDocumentsAsync();
            return analyzerExaminationCount;
        }

        public async Task<UserMedicalExamination> GetOldestMedicalExamination()
        {
            var filterBuilder = Builders<UserMedicalExamination>.Filter.Empty;
            var oldestMedicalExamination = await _context.UserMedicalExaminations.Find(filterBuilder).SortBy(x => x.CreateDate).Limit(1).FirstOrDefaultAsync();
            return oldestMedicalExamination;
        }

        public async Task<bool> LastExaminationResultShowed()
        {
            var filterBuilder = Builders<UserMedicalExamination>.Filter.Where(x => x.IsExaminationResultShowed == false);
            var count = await _context.UserMedicalExaminations.Find(filterBuilder).CountDocumentsAsync();
            return count == 0;
        }

        public async Task<UserMedicalExamination> GetNoShowedExamination()
        {
            var filterBuilder = Builders<UserMedicalExamination>.Filter.Where(x => x.IsExaminationResultShowed == false);
            return await _context.UserMedicalExaminations.Find(filterBuilder).FirstOrDefaultAsync();
        }

        public async Task<UserMedicalExamination> GetMedicalExaminationById(string id)
        {
            return await _context.UserMedicalExaminations.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<long> GetExaminationCountForDayOfWeek(string id, DayOfWeek dayOfWeek)
        {
            var filterBuilder = Builders<UserMedicalExamination>.Filter.Where( x => x.MfcCornerId == id);
            var datasQuoery = _context.UserMedicalExaminations.Find(filterBuilder);
            var analyzerExaminationCount = (await datasQuoery.ToListAsync()).FindAll(x => x.CreateDate.DayOfWeek == dayOfWeek)?.Count ?? 0;
            return analyzerExaminationCount;
        }

        public async Task<long> GetExaminationCountForHour(string id, int hour)
        {
            try
            {
                var filterBuilder = Builders<UserMedicalExamination>.Filter.Where(x => x.MfcCornerId == id);
                var datasQuoery = _context.UserMedicalExaminations.Find(filterBuilder);
                var examinations = await datasQuoery.ToListAsync();
                var elem = examinations.FindAll(x => x.CreateDate.DateTime.Hour == hour);
                return elem.Count;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateAllExaminationcMfcIds(string id)
        {
            var filter = Builders<UserMedicalExamination>.Filter.Empty;
            var update = Builders<UserMedicalExamination>.Update.Set(x => x.MfcCornerId, id);
            await _context.UserMedicalExaminations.UpdateManyAsync(filter, update);
            await Task.Delay(TimeSpan.FromSeconds(3));
        }

        public async Task<List<UserMedicalExamination>> GetAllExamsForMfcById(string id)
        {
            var filterBuilder = Builders<UserMedicalExamination>.Filter.Empty;
            var allStatistic = await _context.UserMedicalExaminations
                .Find(filterBuilder).ToListAsync();
            return allStatistic;
        }

        public async Task<long> GetExaminationCountForMonth(string id, int month)
        {
            var filterBuilder = Builders<UserMedicalExamination>.Filter.Where( x => x.MfcCornerId == id);
            var datasQuoery = _context.UserMedicalExaminations.Find(filterBuilder);
            var analyzerExaminationCount = (await datasQuoery.ToListAsync()).FindAll(x => x.CreateDate.Month == month)?.Count ?? 0;
            return analyzerExaminationCount;
        }

        public async Task<long> GetExaminationCountForYear(string id, int year)
        {
            var filterBuilder = Builders<UserMedicalExamination>.Filter.Where( x => x.MfcCornerId == id);
            var datasQuoery = _context.UserMedicalExaminations.Find(filterBuilder);
            var analyzerExaminationCount = (await datasQuoery.ToListAsync()).FindAll(x => x.CreateDate.Year == year)?.Count ?? 0;
            return analyzerExaminationCount;
        }

        public async Task DeleteMedicalExaminationById(string id)
        {
            await _context.UserMedicalExaminations.DeleteOneAsync(x => x.Id == id);
        }

        public async Task FinishAllExaminations()
        {
            try
            {
                var filter = Builders<UserMedicalExamination>.Filter
                    .Where(x=>x.IsExaminationResultShowed ==false);
                var update = Builders<UserMedicalExamination>.Update
                    .Set(x => x.IsExaminationResultShowed,true).Set(x => x.IsCompleted, true);
                var result = await _context.UserMedicalExaminations.UpdateManyAsync(filter, update);
            }
            catch
            {
                throw;
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mfc.Health.Corner.Domain.Models;

namespace Mfc.Health.Corner.Persistence.Repository.Interfaces
{
    public interface IMedicalExaminationRepository
    {
        Task<string> CreateMedicalExaminationAsync(UserMedicalExamination userMedicalExamination);
        Task SaveExaminationAsync(UserMedicalExamination userMedicalExamination);
        Task<UserMedicalExamination> FindIncompleteMedicalExamination();
        Task<UserMedicalExamination> GetLastMedicalExamination();
        Task<UserMedicalExamination> GetMedicalExaminationById(string id);
        Task DeleteMedicalExaminationById(string id);
        Task<UserMedicalExamination> GetLatest();
        Task<UserMedicalExamination> GetNoShowedExamination();
        Task<bool> LastExaminationResultShowed();        
        Task<long> GetAllExaminationCountForMfcCorner(string mfcCornerId, DateTimeOffset? startDate, DateTimeOffset? endDate);
        Task<UserMedicalExamination> GetOldestMedicalExamination();
        Task<long> GetTodayExaminationCountForMfcCorner(string mfcCornerId);
        Task<long> GetAllExaminationCountForAllMfcCorner(DateTimeOffset? startDate, DateTimeOffset? endDate);
        Task<long> GetAnalyzerExaminationCountForMfcCorner(string mfcCornerId, DateTimeOffset? startDate, DateTimeOffset? endDate);
        Task<long> GetBpbioExaminationCountForMfcCorner(string mfcCornerId, DateTimeOffset? startDate, DateTimeOffset? endDate);
        Task<long> GetBsmExaminationCountForMfcCorner(string mfcCornerId, DateTimeOffset? startDate, DateTimeOffset? endDate);
        Task<long> GetGazExaminationCountForMfcCorner(string mfcCornerId, DateTimeOffset? startDate, DateTimeOffset? endDate);
        Task<long> GetPulseExaminationCountForMfcCorner(string mfcCornerId, DateTimeOffset? startDate, DateTimeOffset? endDate);
        Task<long> GetAllExaminationCountForLastWeek();
        Task<long> GetExaminationCountForDayOfWeek(string id, DayOfWeek dayOfWeek);
        Task<long> GetExaminationCountForHour(string id, int hour);
        Task<long> GetExaminationCountForMonth(string id, int month);
        Task<long> GetExaminationCountForYear(string id, int year);
        Task<List<UserMedicalExamination>> GetLastTenExamination(string mfcCorrnerId);
        Task<List<UserMedicalExamination>> GetAnalyzerExaminationForMfcCorner(string mfcCornerId, DateTimeOffset? startDate, DateTimeOffset? endDate);
        Task FinishAllExaminations();
        Task UpdateAllExaminationcMfcIds(string id);
        Task<List<UserMedicalExamination>> GetAllExamsForMfcById(string id);
    }
}

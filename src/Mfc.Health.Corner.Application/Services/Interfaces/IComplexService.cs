using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Common;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Interfaces
{
    public interface IComplexService
    {
        Task<OperationResult<PagedCollection<ComplexDto>>> GetComplexList(int pageNumber, int pageSize, DateTime? startDate = null, DateTime? endDate = null);
        Task<MemoryStream> ExportComplexListToXlsAsync(string jwt, DateTime? startDate, DateTime? endDate);
    }
}

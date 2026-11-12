using Mfc.Health.Corner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Interfaces
{
    public interface IMfcSrpecialistCallRepository
    {
        Task<MfcSrpecialistCall> CreateMfcSrpecialistCall(MfcSrpecialistCall mfcSrpecialistCall);

        Task<MfcSrpecialistCall> GetMfcSrpecialistCallById(string id);

    }
}

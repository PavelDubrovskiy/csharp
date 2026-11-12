using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Common;

namespace Mfc.Health.Corner.Application.Services.Interfaces
{
    public interface IMedicalTestService
    {
        public Task<OperationResult> ProcessMedicalTests();

        public Task<OperationResult> IsShowedUpdate();

        public Task FinishExamination();
    }
}

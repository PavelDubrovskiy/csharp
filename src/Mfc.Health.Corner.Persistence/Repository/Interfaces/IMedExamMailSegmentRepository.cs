using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Interfaces
{
    public interface IMedExamMailSegmentRepository
    {
        Task<string> GetHTMLSegmentByNameAsync(string name);
    }
}

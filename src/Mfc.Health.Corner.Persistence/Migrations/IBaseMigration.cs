using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Migrations
{
    public interface IBaseMigration
    {
        Task Up();
        Task Down();
    }
}

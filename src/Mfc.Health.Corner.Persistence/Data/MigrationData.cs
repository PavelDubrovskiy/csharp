using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Data
{
    public class MigrationData
    {
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
    }
}

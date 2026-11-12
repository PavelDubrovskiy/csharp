using System.Collections.Generic;

namespace Mfc.Health.Corner.Common
{
    public class PagedCollection<T>
    {
        public long Total { get; set; }
        public List<T> Items { get; set; }
    }
}

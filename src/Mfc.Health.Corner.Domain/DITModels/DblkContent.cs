using System;

namespace Mfc.Health.Corner.Domain.DITModels
{
    public partial class DblkContent
    {
        public int Id { get; set; }
        public int Parent { get; set; }
        public string Name { get; set; }
        public DateTime Udate { get; set; }
        public string Path { get; set; }
        public string Preview { get; set; }
        public string Description { get; set; }
        public string Pic { get; set; }
        public string Dop { get; set; }
        public int Sort { get; set; }
        public bool Visible { get; set; }
        public int Author { get; set; }
        public DateTime Cdate { get; set; }
    }
}

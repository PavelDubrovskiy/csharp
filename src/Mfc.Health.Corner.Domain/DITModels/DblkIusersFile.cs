using System;

namespace Mfc.Health.Corner.Domain.DITModels
{
    public partial class DblkIusersFile
    {
        public uint Id { get; set; }
        public uint Iuser { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public DateTime Cdate { get; set; }
        public bool Defmodel { get; set; }
        public string Scanner { get; set; }
        public string Accuracy { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string Orderprint { get; set; }
    }
}

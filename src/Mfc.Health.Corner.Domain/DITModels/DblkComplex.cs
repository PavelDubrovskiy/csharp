using System;

namespace Mfc.Health.Corner.Domain.DITModels
{
    public partial class DblkComplex
    {
        public uint Id { get; set; }
        public int Parent { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Area { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Dop { get; set; }
        public int Iuser { get; set; }
        public bool Bsm { get; set; }
        public bool Bpbio { get; set; }
        public bool Analyzer { get; set; }
        public bool Pulse { get; set; }
        public bool Gaz { get; set; }
        public string Ip { get; set; }
        public string Token { get; set; }
        public int Author { get; set; }
        public DateTime Cdate { get; set; }
        public DateTime Ldate { get; set; }
        public string Status { get; set; }
        public string Expert { get; set; }
    }
}

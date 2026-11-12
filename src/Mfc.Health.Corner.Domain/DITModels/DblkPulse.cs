using System;

namespace Mfc.Health.Corner.Domain.DITModels
{
    public partial class DblkPulse
    {
        public int Id { get; set; }
        public int Iuser { get; set; }
        public int Complex { get; set; }
        public int Client { get; set; }
        public int Spo2 { get; set; }
        public int Pulse { get; set; }
        public string Data { get; set; }
        public DateTime Cdate { get; set; }
    }
}

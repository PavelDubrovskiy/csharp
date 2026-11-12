using System;

namespace Mfc.Health.Corner.Domain.DITModels
{
    public partial class DblkAnalyzer
    {
        public int Id { get; set; }
        public int Client { get; set; }
        public int Iuser { get; set; }
        public int Complex { get; set; }
        public string InBodyId { get; set; }
        public string EquipType { get; set; }
        public string EquipSerial { get; set; }
        public string InBodyData { get; set; }
        public string Data { get; set; }
        public DateTime Cdate { get; set; }
    }
}

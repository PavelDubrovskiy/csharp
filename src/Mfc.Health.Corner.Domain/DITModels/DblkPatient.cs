using System;

namespace Mfc.Health.Corner.Domain.DITModels
{
    public partial class DblkPatient
    {
        public int Id { get; set; }
        public int Iuser { get; set; }
        public int Client { get; set; }
        public int Complex { get; set; }
        public string OmsNumber { get; set; }
        public string Data { get; set; }
        public DateTime Cdate { get; set; }
    }
}

using System;

namespace Mfc.Health.Corner.Domain.DITModels
{
    public partial class DblkClient
    {
        public int Id { get; set; }
        public int Iuser { get; set; }
        public int Complex { get; set; }
        public string InBodyId { get; set; }
        public string Phone { get; set; }
        public string Oms { get; set; }
        public DateTime Birthdate { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Data { get; set; }
        public DateTime Cdate { get; set; }
        public string Status { get; set; }
    }
}

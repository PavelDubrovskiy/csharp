using System;

namespace Mfc.Health.Corner.Domain.DITModels
{
    public partial class DblkIusersApplication
    {
        public int Id { get; set; }
        public int Iuser { get; set; }
        public int Application { get; set; }
        public string Token { get; set; }
        public int ExpDate { get; set; }
        public string Ip { get; set; }
        public DateTime Cdate { get; set; }
    }
}

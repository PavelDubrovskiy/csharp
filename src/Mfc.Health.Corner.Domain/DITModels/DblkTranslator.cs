using System;

namespace Mfc.Health.Corner.Domain.DITModels
{
    public partial class DblkTranslator
    {
        public int Id { get; set; }
        public string Rus { get; set; }
        public string Eng { get; set; }
        public string Ger { get; set; }
        public DateTime Cdate { get; set; }
        public int Iuser { get; set; }
    }
}

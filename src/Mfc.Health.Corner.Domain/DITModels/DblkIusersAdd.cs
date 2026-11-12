using System;

namespace Mfc.Health.Corner.Domain.DITModels
{
    public partial class DblkIusersAdd
    {
        public int Id { get; set; }
        public int Iuser { get; set; }
        public string Name { get; set; }
        public string Svalue { get; set; }
        public float Fvalue { get; set; }
        public int Model { get; set; }
        public string Data { get; set; }
        public string Coords { get; set; }
        public DateTime Cdate { get; set; }
    }
}

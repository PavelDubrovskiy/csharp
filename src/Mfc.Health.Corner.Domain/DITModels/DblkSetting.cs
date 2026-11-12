using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.Domain.DITModels
{
    public partial class DblkSetting
    {
        public uint Id { get; set; }
        public int Parent { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Value { get; set; }
        public int Num { get; set; }
        public bool Visible { get; set; }
    }
}

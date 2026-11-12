using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class WidgetField
    {
        public ulong WidgetFieldid { get; set; }
        public ulong Widgetid { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public int ValueInt { get; set; }
        public string ValueStr { get; set; }
        public ulong? ValueGroupid { get; set; }
        public ulong? ValueHostid { get; set; }
        public ulong? ValueItemid { get; set; }
        public ulong? ValueGraphid { get; set; }
        public ulong? ValueSysmapid { get; set; }

        public virtual Graph ValueGraph { get; set; }
        public virtual Hstgrp ValueGroup { get; set; }
        public virtual Host ValueHost { get; set; }
        public virtual Item ValueItem { get; set; }
        public virtual Sysmap ValueSysmap { get; set; }
        public virtual Widget Widget { get; set; }
    }
}

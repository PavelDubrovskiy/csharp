using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Graph
    {
        public Graph()
        {
            GraphDiscoveryParentGraphs = new HashSet<GraphDiscovery>();
            GraphsItems = new HashSet<GraphsItem>();
            InverseTemplate = new HashSet<Graph>();
            WidgetFields = new HashSet<WidgetField>();
        }

        public ulong Graphid { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public double Yaxismin { get; set; }
        public double Yaxismax { get; set; }
        public ulong? Templateid { get; set; }
        public int ShowWorkPeriod { get; set; }
        public int ShowTriggers { get; set; }
        public int Graphtype { get; set; }
        public int ShowLegend { get; set; }
        public int Show3d { get; set; }
        public double PercentLeft { get; set; }
        public double PercentRight { get; set; }
        public int YminType { get; set; }
        public int YmaxType { get; set; }
        public ulong? YminItemid { get; set; }
        public ulong? YmaxItemid { get; set; }
        public int Flags { get; set; }
        public int Discover { get; set; }

        public virtual Graph Template { get; set; }
        public virtual Item YmaxItem { get; set; }
        public virtual Item YminItem { get; set; }
        public virtual GraphDiscovery GraphDiscoveryGraph { get; set; }
        public virtual ICollection<GraphDiscovery> GraphDiscoveryParentGraphs { get; set; }
        public virtual ICollection<GraphsItem> GraphsItems { get; set; }
        public virtual ICollection<Graph> InverseTemplate { get; set; }
        public virtual ICollection<WidgetField> WidgetFields { get; set; }
    }
}

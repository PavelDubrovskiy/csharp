using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Item
    {
        public Item()
        {
            ApplicationPrototypes = new HashSet<ApplicationPrototype>();
            Functions = new HashSet<Function>();
            GraphYmaxItems = new HashSet<Graph>();
            GraphYminItems = new HashSet<Graph>();
            GraphsItems = new HashSet<GraphsItem>();
            HostDiscoveries = new HashSet<HostDiscovery>();
            Httpstepitems = new HashSet<Httpstepitem>();
            Httptestitems = new HashSet<Httptestitem>();
            InverseMasterItem = new HashSet<Item>();
            InverseTemplate = new HashSet<Item>();
            ItemApplicationPrototypes = new HashSet<ItemApplicationPrototype>();
            ItemConditions = new HashSet<ItemCondition>();
            ItemDiscoveryItems = new HashSet<ItemDiscovery>();
            ItemDiscoveryParentItems = new HashSet<ItemDiscovery>();
            ItemParameters = new HashSet<ItemParameter>();
            ItemPreprocs = new HashSet<ItemPreproc>();
            ItemsApplications = new HashSet<ItemsApplication>();
            LldMacroPaths = new HashSet<LldMacroPath>();
            LldOverrides = new HashSet<LldOverride>();
            WidgetFields = new HashSet<WidgetField>();
        }

        public ulong Itemid { get; set; }
        public int Type { get; set; }
        public string SnmpOid { get; set; }
        public ulong Hostid { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Delay { get; set; }
        public string History { get; set; }
        public string Trends { get; set; }
        public int Status { get; set; }
        public int ValueType { get; set; }
        public string TrapperHosts { get; set; }
        public string Units { get; set; }
        public string Formula { get; set; }
        public string Logtimefmt { get; set; }
        public ulong? Templateid { get; set; }
        public ulong? Valuemapid { get; set; }
        public string Params { get; set; }
        public string IpmiSensor { get; set; }
        public int Authtype { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Publickey { get; set; }
        public string Privatekey { get; set; }
        public int Flags { get; set; }
        public ulong? Interfaceid { get; set; }
        public string Description { get; set; }
        public int InventoryLink { get; set; }
        public string Lifetime { get; set; }
        public int Evaltype { get; set; }
        public string JmxEndpoint { get; set; }
        public ulong? MasterItemid { get; set; }
        public string Timeout { get; set; }
        public string Url { get; set; }
        public string QueryFields { get; set; }
        public string Posts { get; set; }
        public string StatusCodes { get; set; }
        public int FollowRedirects { get; set; }
        public int PostType { get; set; }
        public string HttpProxy { get; set; }
        public string Headers { get; set; }
        public int RetrieveMode { get; set; }
        public int RequestMethod { get; set; }
        public int OutputFormat { get; set; }
        public string SslCertFile { get; set; }
        public string SslKeyFile { get; set; }
        public string SslKeyPassword { get; set; }
        public int VerifyPeer { get; set; }
        public int VerifyHost { get; set; }
        public int AllowTraps { get; set; }
        public int Discover { get; set; }

        public virtual Host Host { get; set; }
        public virtual Interface Interface { get; set; }
        public virtual Item MasterItem { get; set; }
        public virtual Item Template { get; set; }
        public virtual Valuemap Valuemap { get; set; }
        public virtual ItemRtdatum ItemRtdatum { get; set; }
        public virtual ICollection<ApplicationPrototype> ApplicationPrototypes { get; set; }
        public virtual ICollection<Function> Functions { get; set; }
        public virtual ICollection<Graph> GraphYmaxItems { get; set; }
        public virtual ICollection<Graph> GraphYminItems { get; set; }
        public virtual ICollection<GraphsItem> GraphsItems { get; set; }
        public virtual ICollection<HostDiscovery> HostDiscoveries { get; set; }
        public virtual ICollection<Httpstepitem> Httpstepitems { get; set; }
        public virtual ICollection<Httptestitem> Httptestitems { get; set; }
        public virtual ICollection<Item> InverseMasterItem { get; set; }
        public virtual ICollection<Item> InverseTemplate { get; set; }
        public virtual ICollection<ItemApplicationPrototype> ItemApplicationPrototypes { get; set; }
        public virtual ICollection<ItemCondition> ItemConditions { get; set; }
        public virtual ICollection<ItemDiscovery> ItemDiscoveryItems { get; set; }
        public virtual ICollection<ItemDiscovery> ItemDiscoveryParentItems { get; set; }
        public virtual ICollection<ItemParameter> ItemParameters { get; set; }
        public virtual ICollection<ItemPreproc> ItemPreprocs { get; set; }
        public virtual ICollection<ItemsApplication> ItemsApplications { get; set; }
        public virtual ICollection<LldMacroPath> LldMacroPaths { get; set; }
        public virtual ICollection<LldOverride> LldOverrides { get; set; }
        public virtual ICollection<WidgetField> WidgetFields { get; set; }
    }
}

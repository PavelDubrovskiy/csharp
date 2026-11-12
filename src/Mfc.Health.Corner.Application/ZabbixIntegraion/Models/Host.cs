using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Host
    {
        public Host()
        {
            Applications = new HashSet<Application>();
            AutoregHosts = new HashSet<AutoregHost>();
            Dashboards = new HashSet<Dashboard>();
            Drules = new HashSet<Drule>();
            GroupPrototypes = new HashSet<GroupPrototype>();
            HostDiscoveryParentHosts = new HashSet<HostDiscovery>();
            HostTags = new HashSet<HostTag>();
            Hostmacros = new HashSet<Hostmacro>();
            HostsGroups = new HashSet<HostsGroup>();
            HostsTemplateHosts = new HashSet<HostsTemplate>();
            HostsTemplateTemplates = new HashSet<HostsTemplate>();
            Httptests = new HashSet<Httptest>();
            Interfaces = new HashSet<Interface>();
            InverseProxyHost = new HashSet<Host>();
            InverseTemplate = new HashSet<Host>();
            Items = new HashSet<Item>();
            LldOverrideOptemplates = new HashSet<LldOverrideOptemplate>();
            MaintenancesHosts = new HashSet<MaintenancesHost>();
            OpcommandHsts = new HashSet<OpcommandHst>();
            Optemplates = new HashSet<Optemplate>();
            Tasks = new HashSet<Task>();
            WidgetFields = new HashSet<WidgetField>();
        }

        public ulong Hostid { get; set; }
        public ulong? ProxyHostid { get; set; }
        public string Host1 { get; set; }
        public int Status { get; set; }
        public int DisableUntil { get; set; }
        public string Error { get; set; }
        public int Available { get; set; }
        public int ErrorsFrom { get; set; }
        public int Lastaccess { get; set; }
        public int IpmiAuthtype { get; set; }
        public int IpmiPrivilege { get; set; }
        public string IpmiUsername { get; set; }
        public string IpmiPassword { get; set; }
        public int IpmiDisableUntil { get; set; }
        public int IpmiAvailable { get; set; }
        public int SnmpDisableUntil { get; set; }
        public int SnmpAvailable { get; set; }
        public ulong? Maintenanceid { get; set; }
        public int MaintenanceStatus { get; set; }
        public int MaintenanceType { get; set; }
        public int MaintenanceFrom { get; set; }
        public int IpmiErrorsFrom { get; set; }
        public int SnmpErrorsFrom { get; set; }
        public string IpmiError { get; set; }
        public string SnmpError { get; set; }
        public int JmxDisableUntil { get; set; }
        public int JmxAvailable { get; set; }
        public int JmxErrorsFrom { get; set; }
        public string JmxError { get; set; }
        public string Name { get; set; }
        public int Flags { get; set; }
        public ulong? Templateid { get; set; }
        public string Description { get; set; }
        public int TlsConnect { get; set; }
        public int TlsAccept { get; set; }
        public string TlsIssuer { get; set; }
        public string TlsSubject { get; set; }
        public string TlsPskIdentity { get; set; }
        public string TlsPsk { get; set; }
        public string ProxyAddress { get; set; }
        public int AutoCompress { get; set; }
        public int Discover { get; set; }
        public int CustomInterfaces { get; set; }

        public virtual Maintenance Maintenance { get; set; }
        public virtual Host ProxyHost { get; set; }
        public virtual Host Template { get; set; }
        public virtual HostDiscovery HostDiscoveryHostNavigation { get; set; }
        public virtual HostInventory HostInventory { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<AutoregHost> AutoregHosts { get; set; }
        public virtual ICollection<Dashboard> Dashboards { get; set; }
        public virtual ICollection<Drule> Drules { get; set; }
        public virtual ICollection<GroupPrototype> GroupPrototypes { get; set; }
        public virtual ICollection<HostDiscovery> HostDiscoveryParentHosts { get; set; }
        public virtual ICollection<HostTag> HostTags { get; set; }
        public virtual ICollection<Hostmacro> Hostmacros { get; set; }
        public virtual ICollection<HostsGroup> HostsGroups { get; set; }
        public virtual ICollection<HostsTemplate> HostsTemplateHosts { get; set; }
        public virtual ICollection<HostsTemplate> HostsTemplateTemplates { get; set; }
        public virtual ICollection<Httptest> Httptests { get; set; }
        public virtual ICollection<Interface> Interfaces { get; set; }
        public virtual ICollection<Host> InverseProxyHost { get; set; }
        public virtual ICollection<Host> InverseTemplate { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<LldOverrideOptemplate> LldOverrideOptemplates { get; set; }
        public virtual ICollection<MaintenancesHost> MaintenancesHosts { get; set; }
        public virtual ICollection<OpcommandHst> OpcommandHsts { get; set; }
        public virtual ICollection<Optemplate> Optemplates { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<WidgetField> WidgetFields { get; set; }
    }
}

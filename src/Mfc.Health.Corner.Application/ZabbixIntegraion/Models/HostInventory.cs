using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class HostInventory
    {
        public ulong Hostid { get; set; }
        public int InventoryMode { get; set; }
        public string Type { get; set; }
        public string TypeFull { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Os { get; set; }
        public string OsFull { get; set; }
        public string OsShort { get; set; }
        public string SerialnoA { get; set; }
        public string SerialnoB { get; set; }
        public string Tag { get; set; }
        public string AssetTag { get; set; }
        public string MacaddressA { get; set; }
        public string MacaddressB { get; set; }
        public string Hardware { get; set; }
        public string HardwareFull { get; set; }
        public string Software { get; set; }
        public string SoftwareFull { get; set; }
        public string SoftwareAppA { get; set; }
        public string SoftwareAppB { get; set; }
        public string SoftwareAppC { get; set; }
        public string SoftwareAppD { get; set; }
        public string SoftwareAppE { get; set; }
        public string Contact { get; set; }
        public string Location { get; set; }
        public string LocationLat { get; set; }
        public string LocationLon { get; set; }
        public string Notes { get; set; }
        public string Chassis { get; set; }
        public string Model { get; set; }
        public string HwArch { get; set; }
        public string Vendor { get; set; }
        public string ContractNumber { get; set; }
        public string InstallerName { get; set; }
        public string DeploymentStatus { get; set; }
        public string UrlA { get; set; }
        public string UrlB { get; set; }
        public string UrlC { get; set; }
        public string HostNetworks { get; set; }
        public string HostNetmask { get; set; }
        public string HostRouter { get; set; }
        public string OobIp { get; set; }
        public string OobNetmask { get; set; }
        public string OobRouter { get; set; }
        public string DateHwPurchase { get; set; }
        public string DateHwInstall { get; set; }
        public string DateHwExpiry { get; set; }
        public string DateHwDecomm { get; set; }
        public string SiteAddressA { get; set; }
        public string SiteAddressB { get; set; }
        public string SiteAddressC { get; set; }
        public string SiteCity { get; set; }
        public string SiteState { get; set; }
        public string SiteCountry { get; set; }
        public string SiteZip { get; set; }
        public string SiteRack { get; set; }
        public string SiteNotes { get; set; }
        public string Poc1Name { get; set; }
        public string Poc1Email { get; set; }
        public string Poc1PhoneA { get; set; }
        public string Poc1PhoneB { get; set; }
        public string Poc1Cell { get; set; }
        public string Poc1Screen { get; set; }
        public string Poc1Notes { get; set; }
        public string Poc2Name { get; set; }
        public string Poc2Email { get; set; }
        public string Poc2PhoneA { get; set; }
        public string Poc2PhoneB { get; set; }
        public string Poc2Cell { get; set; }
        public string Poc2Screen { get; set; }
        public string Poc2Notes { get; set; }

        public virtual Host Host { get; set; }
    }
}

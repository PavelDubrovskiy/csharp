using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Config
    {
        public ulong Configid { get; set; }
        public string WorkPeriod { get; set; }
        public ulong? AlertUsrgrpid { get; set; }
        public string DefaultTheme { get; set; }
        public int AuthenticationType { get; set; }
        public string LdapHost { get; set; }
        public int LdapPort { get; set; }
        public string LdapBaseDn { get; set; }
        public string LdapBindDn { get; set; }
        public string LdapBindPassword { get; set; }
        public string LdapSearchAttribute { get; set; }
        public ulong DiscoveryGroupid { get; set; }
        public int MaxInTable { get; set; }
        public int SearchLimit { get; set; }
        public string SeverityColor0 { get; set; }
        public string SeverityColor1 { get; set; }
        public string SeverityColor2 { get; set; }
        public string SeverityColor3 { get; set; }
        public string SeverityColor4 { get; set; }
        public string SeverityColor5 { get; set; }
        public string SeverityName0 { get; set; }
        public string SeverityName1 { get; set; }
        public string SeverityName2 { get; set; }
        public string SeverityName3 { get; set; }
        public string SeverityName4 { get; set; }
        public string SeverityName5 { get; set; }
        public string OkPeriod { get; set; }
        public string BlinkPeriod { get; set; }
        public string ProblemUnackColor { get; set; }
        public string ProblemAckColor { get; set; }
        public string OkUnackColor { get; set; }
        public string OkAckColor { get; set; }
        public int ProblemUnackStyle { get; set; }
        public int ProblemAckStyle { get; set; }
        public int OkUnackStyle { get; set; }
        public int OkAckStyle { get; set; }
        public int SnmptrapLogging { get; set; }
        public int ServerCheckInterval { get; set; }
        public int HkEventsMode { get; set; }
        public string HkEventsTrigger { get; set; }
        public string HkEventsInternal { get; set; }
        public string HkEventsDiscovery { get; set; }
        public string HkEventsAutoreg { get; set; }
        public int HkServicesMode { get; set; }
        public string HkServices { get; set; }
        public int HkAuditMode { get; set; }
        public string HkAudit { get; set; }
        public int HkSessionsMode { get; set; }
        public string HkSessions { get; set; }
        public int HkHistoryMode { get; set; }
        public int HkHistoryGlobal { get; set; }
        public string HkHistory { get; set; }
        public int HkTrendsMode { get; set; }
        public int HkTrendsGlobal { get; set; }
        public string HkTrends { get; set; }
        public int DefaultInventoryMode { get; set; }
        public int CustomColor { get; set; }
        public int HttpAuthEnabled { get; set; }
        public int HttpLoginForm { get; set; }
        public string HttpStripDomains { get; set; }
        public int HttpCaseSensitive { get; set; }
        public int LdapConfigured { get; set; }
        public int LdapCaseSensitive { get; set; }
        public string DbExtension { get; set; }
        public int AutoregTlsAccept { get; set; }
        public int CompressionStatus { get; set; }
        public int CompressionAvailability { get; set; }
        public string CompressOlder { get; set; }
        public string Instanceid { get; set; }
        public int SamlAuthEnabled { get; set; }
        public string SamlIdpEntityid { get; set; }
        public string SamlSsoUrl { get; set; }
        public string SamlSloUrl { get; set; }
        public string SamlUsernameAttribute { get; set; }
        public string SamlSpEntityid { get; set; }
        public string SamlNameidFormat { get; set; }
        public int SamlSignMessages { get; set; }
        public int SamlSignAssertions { get; set; }
        public int SamlSignAuthnRequests { get; set; }
        public int SamlSignLogoutRequests { get; set; }
        public int SamlSignLogoutResponses { get; set; }
        public int SamlEncryptNameid { get; set; }
        public int SamlEncryptAssertions { get; set; }
        public int SamlCaseSensitive { get; set; }
        public string DefaultLang { get; set; }
        public string DefaultTimezone { get; set; }
        public int LoginAttempts { get; set; }
        public string LoginBlock { get; set; }
        public int ShowTechnicalErrors { get; set; }
        public int ValidateUriSchemes { get; set; }
        public string UriValidSchemes { get; set; }
        public string XFrameOptions { get; set; }
        public int IframeSandboxingEnabled { get; set; }
        public string IframeSandboxingExceptions { get; set; }
        public int MaxOverviewTableSize { get; set; }
        public string HistoryPeriod { get; set; }
        public string PeriodDefault { get; set; }
        public string MaxPeriod { get; set; }
        public string SocketTimeout { get; set; }
        public string ConnectTimeout { get; set; }
        public string MediaTypeTestTimeout { get; set; }
        public string ScriptTimeout { get; set; }
        public string ItemTestTimeout { get; set; }
        public string SessionKey { get; set; }

        public virtual Usrgrp AlertUsrgrp { get; set; }
        public virtual Hstgrp DiscoveryGroup { get; set; }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class zabbixserverContext : DbContext
    {
        IConfiguration _configuration;
        public zabbixserverContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public zabbixserverContext(DbContextOptions<zabbixserverContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acknowledge> Acknowledges { get; set; }
        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<Alert> Alerts { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<ApplicationDiscovery> ApplicationDiscoveries { get; set; }
        public virtual DbSet<ApplicationPrototype> ApplicationPrototypes { get; set; }
        public virtual DbSet<ApplicationTemplate> ApplicationTemplates { get; set; }
        public virtual DbSet<Auditlog> Auditlogs { get; set; }
        public virtual DbSet<AuditlogDetail> AuditlogDetails { get; set; }
        public virtual DbSet<AutoregHost> AutoregHosts { get; set; }
        public virtual DbSet<Condition> Conditions { get; set; }
        public virtual DbSet<Config> Configs { get; set; }
        public virtual DbSet<ConfigAutoregTl> ConfigAutoregTls { get; set; }
        public virtual DbSet<CorrCondition> CorrConditions { get; set; }
        public virtual DbSet<CorrConditionGroup> CorrConditionGroups { get; set; }
        public virtual DbSet<CorrConditionTag> CorrConditionTags { get; set; }
        public virtual DbSet<CorrConditionTagpair> CorrConditionTagpairs { get; set; }
        public virtual DbSet<CorrConditionTagvalue> CorrConditionTagvalues { get; set; }
        public virtual DbSet<CorrOperation> CorrOperations { get; set; }
        public virtual DbSet<Correlation> Correlations { get; set; }
        public virtual DbSet<Dashboard> Dashboards { get; set; }
        public virtual DbSet<DashboardUser> DashboardUsers { get; set; }
        public virtual DbSet<DashboardUsrgrp> DashboardUsrgrps { get; set; }
        public virtual DbSet<Dbversion> Dbversions { get; set; }
        public virtual DbSet<Dcheck> Dchecks { get; set; }
        public virtual DbSet<Dhost> Dhosts { get; set; }
        public virtual DbSet<Drule> Drules { get; set; }
        public virtual DbSet<Dservice> Dservices { get; set; }
        public virtual DbSet<Escalation> Escalations { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventRecovery> EventRecoveries { get; set; }
        public virtual DbSet<EventSuppress> EventSuppresses { get; set; }
        public virtual DbSet<EventTag> EventTags { get; set; }
        public virtual DbSet<Expression> Expressions { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<Globalmacro> Globalmacros { get; set; }
        public virtual DbSet<Globalvar> Globalvars { get; set; }
        public virtual DbSet<Graph> Graphs { get; set; }
        public virtual DbSet<GraphDiscovery> GraphDiscoveries { get; set; }
        public virtual DbSet<GraphTheme> GraphThemes { get; set; }
        public virtual DbSet<GraphsItem> GraphsItems { get; set; }
        public virtual DbSet<GroupDiscovery> GroupDiscoveries { get; set; }
        public virtual DbSet<GroupPrototype> GroupPrototypes { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<HistoryLog> HistoryLogs { get; set; }
        public virtual DbSet<HistoryStr> HistoryStrs { get; set; }
        public virtual DbSet<HistoryText> HistoryTexts { get; set; }
        public virtual DbSet<HistoryUint> HistoryUints { get; set; }
        public virtual DbSet<Host> Hosts { get; set; }
        public virtual DbSet<HostDiscovery> HostDiscoveries { get; set; }
        public virtual DbSet<HostInventory> HostInventories { get; set; }
        public virtual DbSet<HostTag> HostTags { get; set; }
        public virtual DbSet<Hostmacro> Hostmacros { get; set; }
        public virtual DbSet<HostsGroup> HostsGroups { get; set; }
        public virtual DbSet<HostsTemplate> HostsTemplates { get; set; }
        public virtual DbSet<Housekeeper> Housekeepers { get; set; }
        public virtual DbSet<Hstgrp> Hstgrps { get; set; }
        public virtual DbSet<Httpstep> Httpsteps { get; set; }
        public virtual DbSet<HttpstepField> HttpstepFields { get; set; }
        public virtual DbSet<Httpstepitem> Httpstepitems { get; set; }
        public virtual DbSet<Httptest> Httptests { get; set; }
        public virtual DbSet<HttptestField> HttptestFields { get; set; }
        public virtual DbSet<Httptestitem> Httptestitems { get; set; }
        public virtual DbSet<IconMap> IconMaps { get; set; }
        public virtual DbSet<IconMapping> IconMappings { get; set; }
        public virtual DbSet<Id> Ids { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Interface> Interfaces { get; set; }
        public virtual DbSet<InterfaceDiscovery> InterfaceDiscoveries { get; set; }
        public virtual DbSet<InterfaceSnmp> InterfaceSnmps { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemApplicationPrototype> ItemApplicationPrototypes { get; set; }
        public virtual DbSet<ItemCondition> ItemConditions { get; set; }
        public virtual DbSet<ItemDiscovery> ItemDiscoveries { get; set; }
        public virtual DbSet<ItemParameter> ItemParameters { get; set; }
        public virtual DbSet<ItemPreproc> ItemPreprocs { get; set; }
        public virtual DbSet<ItemRtdatum> ItemRtdata { get; set; }
        public virtual DbSet<ItemsApplication> ItemsApplications { get; set; }
        public virtual DbSet<LldMacroPath> LldMacroPaths { get; set; }
        public virtual DbSet<LldOverride> LldOverrides { get; set; }
        public virtual DbSet<LldOverrideCondition> LldOverrideConditions { get; set; }
        public virtual DbSet<LldOverrideOpdiscover> LldOverrideOpdiscovers { get; set; }
        public virtual DbSet<LldOverrideOperation> LldOverrideOperations { get; set; }
        public virtual DbSet<LldOverrideOphistory> LldOverrideOphistories { get; set; }
        public virtual DbSet<LldOverrideOpinventory> LldOverrideOpinventories { get; set; }
        public virtual DbSet<LldOverrideOpperiod> LldOverrideOpperiods { get; set; }
        public virtual DbSet<LldOverrideOpseverity> LldOverrideOpseverities { get; set; }
        public virtual DbSet<LldOverrideOpstatus> LldOverrideOpstatuses { get; set; }
        public virtual DbSet<LldOverrideOptag> LldOverrideOptags { get; set; }
        public virtual DbSet<LldOverrideOptemplate> LldOverrideOptemplates { get; set; }
        public virtual DbSet<LldOverrideOptrend> LldOverrideOptrends { get; set; }
        public virtual DbSet<Maintenance> Maintenances { get; set; }
        public virtual DbSet<MaintenanceTag> MaintenanceTags { get; set; }
        public virtual DbSet<MaintenancesGroup> MaintenancesGroups { get; set; }
        public virtual DbSet<MaintenancesHost> MaintenancesHosts { get; set; }
        public virtual DbSet<MaintenancesWindow> MaintenancesWindows { get; set; }
        public virtual DbSet<Mapping> Mappings { get; set; }
        public virtual DbSet<MediaType> MediaTypes { get; set; }
        public virtual DbSet<MediaTypeMessage> MediaTypeMessages { get; set; }
        public virtual DbSet<MediaTypeParam> MediaTypeParams { get; set; }
        public virtual DbSet<Medium> Media { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Opcommand> Opcommands { get; set; }
        public virtual DbSet<OpcommandGrp> OpcommandGrps { get; set; }
        public virtual DbSet<OpcommandHst> OpcommandHsts { get; set; }
        public virtual DbSet<Opcondition> Opconditions { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Opgroup> Opgroups { get; set; }
        public virtual DbSet<Opinventory> Opinventories { get; set; }
        public virtual DbSet<Opmessage> Opmessages { get; set; }
        public virtual DbSet<OpmessageGrp> OpmessageGrps { get; set; }
        public virtual DbSet<OpmessageUsr> OpmessageUsrs { get; set; }
        public virtual DbSet<Optemplate> Optemplates { get; set; }
        public virtual DbSet<Problem> Problems { get; set; }
        public virtual DbSet<ProblemTag> ProblemTags { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<ProxyAutoregHost> ProxyAutoregHosts { get; set; }
        public virtual DbSet<ProxyDhistory> ProxyDhistories { get; set; }
        public virtual DbSet<ProxyHistory> ProxyHistories { get; set; }
        public virtual DbSet<Regexp> Regexps { get; set; }
        public virtual DbSet<Right> Rights { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleRule> RoleRules { get; set; }
        public virtual DbSet<Screen> Screens { get; set; }
        public virtual DbSet<ScreenUser> ScreenUsers { get; set; }
        public virtual DbSet<ScreenUsrgrp> ScreenUsrgrps { get; set; }
        public virtual DbSet<ScreensItem> ScreensItems { get; set; }
        public virtual DbSet<Script> Scripts { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceAlarm> ServiceAlarms { get; set; }
        public virtual DbSet<ServicesLink> ServicesLinks { get; set; }
        public virtual DbSet<ServicesTime> ServicesTimes { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<Slideshow> Slideshows { get; set; }
        public virtual DbSet<SlideshowUser> SlideshowUsers { get; set; }
        public virtual DbSet<SlideshowUsrgrp> SlideshowUsrgrps { get; set; }
        public virtual DbSet<Sysmap> Sysmaps { get; set; }
        public virtual DbSet<SysmapElementTrigger> SysmapElementTriggers { get; set; }
        public virtual DbSet<SysmapElementUrl> SysmapElementUrls { get; set; }
        public virtual DbSet<SysmapShape> SysmapShapes { get; set; }
        public virtual DbSet<SysmapUrl> SysmapUrls { get; set; }
        public virtual DbSet<SysmapUser> SysmapUsers { get; set; }
        public virtual DbSet<SysmapUsrgrp> SysmapUsrgrps { get; set; }
        public virtual DbSet<SysmapsElement> SysmapsElements { get; set; }
        public virtual DbSet<SysmapsLink> SysmapsLinks { get; set; }
        public virtual DbSet<SysmapsLinkTrigger> SysmapsLinkTriggers { get; set; }
        public virtual DbSet<TagFilter> TagFilters { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskAcknowledge> TaskAcknowledges { get; set; }
        public virtual DbSet<TaskCheckNow> TaskCheckNows { get; set; }
        public virtual DbSet<TaskCloseProblem> TaskCloseProblems { get; set; }
        public virtual DbSet<TaskDatum> TaskData { get; set; }
        public virtual DbSet<TaskRemoteCommand> TaskRemoteCommands { get; set; }
        public virtual DbSet<TaskRemoteCommandResult> TaskRemoteCommandResults { get; set; }
        public virtual DbSet<TaskResult> TaskResults { get; set; }
        public virtual DbSet<Timeperiod> Timeperiods { get; set; }
        public virtual DbSet<Trend> Trends { get; set; }
        public virtual DbSet<TrendsUint> TrendsUints { get; set; }
        public virtual DbSet<Trigger> Triggers { get; set; }
        public virtual DbSet<TriggerDepend> TriggerDepends { get; set; }
        public virtual DbSet<TriggerDiscovery> TriggerDiscoveries { get; set; }
        public virtual DbSet<TriggerQueue> TriggerQueues { get; set; }
        public virtual DbSet<TriggerTag> TriggerTags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersGroup> UsersGroups { get; set; }
        public virtual DbSet<Usrgrp> Usrgrps { get; set; }
        public virtual DbSet<Valuemap> Valuemaps { get; set; }
        public virtual DbSet<Widget> Widgets { get; set; }
        public virtual DbSet<WidgetField> WidgetFields { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(_configuration.GetConnectionString("ZabbixConnectionString"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.28-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_bin");

            modelBuilder.Entity<Acknowledge>(entity =>
            {
                entity.ToTable("acknowledges");

                entity.HasIndex(e => e.Userid, "acknowledges_1");

                entity.HasIndex(e => e.Eventid, "acknowledges_2");

                entity.HasIndex(e => e.Clock, "acknowledges_3");

                entity.Property(e => e.Acknowledgeid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("acknowledgeid");

                entity.Property(e => e.Action)
                    .HasColumnType("int(11)")
                    .HasColumnName("action");

                entity.Property(e => e.Clock)
                    .HasColumnType("int(11)")
                    .HasColumnName("clock");

                entity.Property(e => e.Eventid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("eventid");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("message")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NewSeverity)
                    .HasColumnType("int(11)")
                    .HasColumnName("new_severity");

                entity.Property(e => e.OldSeverity)
                    .HasColumnType("int(11)")
                    .HasColumnName("old_severity");

                entity.Property(e => e.Userid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("userid");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Acknowledges)
                    .HasForeignKey(d => d.Eventid)
                    .HasConstraintName("c_acknowledges_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Acknowledges)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("c_acknowledges_1");
            });

            modelBuilder.Entity<Action>(entity =>
            {
                entity.ToTable("actions");

                entity.HasIndex(e => new { e.Eventsource, e.Status }, "actions_1");

                entity.HasIndex(e => e.Name, "actions_2")
                    .IsUnique();

                entity.Property(e => e.Actionid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("actionid");

                entity.Property(e => e.EscPeriod)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("esc_period")
                    .HasDefaultValueSql("'1h'");

                entity.Property(e => e.Evaltype)
                    .HasColumnType("int(11)")
                    .HasColumnName("evaltype");

                entity.Property(e => e.Eventsource)
                    .HasColumnType("int(11)")
                    .HasColumnName("eventsource");

                entity.Property(e => e.Formula)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("formula")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PauseSuppressed)
                    .HasColumnType("int(11)")
                    .HasColumnName("pause_suppressed")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Alert>(entity =>
            {
                entity.ToTable("alerts");

                entity.HasIndex(e => e.Actionid, "alerts_1");

                entity.HasIndex(e => e.Clock, "alerts_2");

                entity.HasIndex(e => e.Eventid, "alerts_3");

                entity.HasIndex(e => e.Status, "alerts_4");

                entity.HasIndex(e => e.Mediatypeid, "alerts_5");

                entity.HasIndex(e => e.Userid, "alerts_6");

                entity.HasIndex(e => e.PEventid, "alerts_7");

                entity.HasIndex(e => e.Acknowledgeid, "c_alerts_6");

                entity.Property(e => e.Alertid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("alertid");

                entity.Property(e => e.Acknowledgeid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("acknowledgeid");

                entity.Property(e => e.Actionid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("actionid");

                entity.Property(e => e.Alerttype)
                    .HasColumnType("int(11)")
                    .HasColumnName("alerttype");

                entity.Property(e => e.Clock)
                    .HasColumnType("int(11)")
                    .HasColumnName("clock");

                entity.Property(e => e.Error)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("error")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.EscStep)
                    .HasColumnType("int(11)")
                    .HasColumnName("esc_step");

                entity.Property(e => e.Eventid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("eventid");

                entity.Property(e => e.Mediatypeid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("mediatypeid");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("message");

                entity.Property(e => e.PEventid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("p_eventid");

                entity.Property(e => e.Parameters)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("parameters");

                entity.Property(e => e.Retries)
                    .HasColumnType("int(11)")
                    .HasColumnName("retries");

                entity.Property(e => e.Sendto)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("sendto")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("subject")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Userid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("userid");

                entity.HasOne(d => d.Acknowledge)
                    .WithMany(p => p.Alerts)
                    .HasForeignKey(d => d.Acknowledgeid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_alerts_6");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.Alerts)
                    .HasForeignKey(d => d.Actionid)
                    .HasConstraintName("c_alerts_1");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.AlertEvents)
                    .HasForeignKey(d => d.Eventid)
                    .HasConstraintName("c_alerts_2");

                entity.HasOne(d => d.Mediatype)
                    .WithMany(p => p.Alerts)
                    .HasForeignKey(d => d.Mediatypeid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_alerts_4");

                entity.HasOne(d => d.PEvent)
                    .WithMany(p => p.AlertPEvents)
                    .HasForeignKey(d => d.PEventid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_alerts_5");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Alerts)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_alerts_3");
            });

            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("applications");

                entity.HasIndex(e => new { e.Hostid, e.Name }, "applications_2")
                    .IsUnique();

                entity.Property(e => e.Applicationid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("applicationid");

                entity.Property(e => e.Flags)
                    .HasColumnType("int(11)")
                    .HasColumnName("flags");

                entity.Property(e => e.Hostid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("hostid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Host)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.Hostid)
                    .HasConstraintName("c_applications_1");
            });

            modelBuilder.Entity<ApplicationDiscovery>(entity =>
            {
                entity.ToTable("application_discovery");

                entity.HasIndex(e => e.Applicationid, "application_discovery_1");

                entity.HasIndex(e => e.ApplicationPrototypeid, "application_discovery_2");

                entity.Property(e => e.ApplicationDiscoveryid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("application_discoveryid");

                entity.Property(e => e.ApplicationPrototypeid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("application_prototypeid");

                entity.Property(e => e.Applicationid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("applicationid");

                entity.Property(e => e.Lastcheck)
                    .HasColumnType("int(11)")
                    .HasColumnName("lastcheck");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TsDelete)
                    .HasColumnType("int(11)")
                    .HasColumnName("ts_delete");

                entity.HasOne(d => d.ApplicationPrototype)
                    .WithMany(p => p.ApplicationDiscoveries)
                    .HasForeignKey(d => d.ApplicationPrototypeid)
                    .HasConstraintName("c_application_discovery_2");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.ApplicationDiscoveries)
                    .HasForeignKey(d => d.Applicationid)
                    .HasConstraintName("c_application_discovery_1");
            });

            modelBuilder.Entity<ApplicationPrototype>(entity =>
            {
                entity.ToTable("application_prototype");

                entity.HasIndex(e => e.Itemid, "application_prototype_1");

                entity.HasIndex(e => e.Templateid, "application_prototype_2");

                entity.Property(e => e.ApplicationPrototypeid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("application_prototypeid");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Templateid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("templateid");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ApplicationPrototypes)
                    .HasForeignKey(d => d.Itemid)
                    .HasConstraintName("c_application_prototype_1");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.InverseTemplate)
                    .HasForeignKey(d => d.Templateid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_application_prototype_2");
            });

            modelBuilder.Entity<ApplicationTemplate>(entity =>
            {
                entity.ToTable("application_template");

                entity.HasIndex(e => new { e.Applicationid, e.Templateid }, "application_template_1")
                    .IsUnique();

                entity.HasIndex(e => e.Templateid, "application_template_2");

                entity.Property(e => e.ApplicationTemplateid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("application_templateid");

                entity.Property(e => e.Applicationid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("applicationid");

                entity.Property(e => e.Templateid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("templateid");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.ApplicationTemplateApplications)
                    .HasForeignKey(d => d.Applicationid)
                    .HasConstraintName("c_application_template_1");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.ApplicationTemplateTemplates)
                    .HasForeignKey(d => d.Templateid)
                    .HasConstraintName("c_application_template_2");
            });

            modelBuilder.Entity<Auditlog>(entity =>
            {
                entity.HasKey(e => e.Auditid)
                    .HasName("PRIMARY");

                entity.ToTable("auditlog");

                entity.HasIndex(e => new { e.Userid, e.Clock }, "auditlog_1");

                entity.HasIndex(e => e.Clock, "auditlog_2");

                entity.HasIndex(e => new { e.Resourcetype, e.Resourceid }, "auditlog_3");

                entity.Property(e => e.Auditid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("auditid");

                entity.Property(e => e.Action)
                    .HasColumnType("int(11)")
                    .HasColumnName("action");

                entity.Property(e => e.Clock)
                    .HasColumnType("int(11)")
                    .HasColumnName("clock");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(39)
                    .HasColumnName("ip")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("note")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Resourceid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("resourceid");

                entity.Property(e => e.Resourcename)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("resourcename")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Resourcetype)
                    .HasColumnType("int(11)")
                    .HasColumnName("resourcetype");

                entity.Property(e => e.Userid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Auditlogs)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("c_auditlog_1");
            });

            modelBuilder.Entity<AuditlogDetail>(entity =>
            {
                entity.HasKey(e => e.Auditdetailid)
                    .HasName("PRIMARY");

                entity.ToTable("auditlog_details");

                entity.HasIndex(e => e.Auditid, "auditlog_details_1");

                entity.Property(e => e.Auditdetailid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("auditdetailid");

                entity.Property(e => e.Auditid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("auditid");

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("field_name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Newvalue)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("newvalue");

                entity.Property(e => e.Oldvalue)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("oldvalue");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("table_name")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Audit)
                    .WithMany(p => p.AuditlogDetails)
                    .HasForeignKey(d => d.Auditid)
                    .HasConstraintName("c_auditlog_details_1");
            });

            modelBuilder.Entity<AutoregHost>(entity =>
            {
                entity.ToTable("autoreg_host");

                entity.HasIndex(e => e.Host, "autoreg_host_1");

                entity.HasIndex(e => e.ProxyHostid, "autoreg_host_2");

                entity.Property(e => e.AutoregHostid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("autoreg_hostid");

                entity.Property(e => e.Flags)
                    .HasColumnType("int(11)")
                    .HasColumnName("flags");

                entity.Property(e => e.Host)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("host")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.HostMetadata)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("host_metadata")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ListenDns)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("listen_dns")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ListenIp)
                    .IsRequired()
                    .HasMaxLength(39)
                    .HasColumnName("listen_ip")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ListenPort)
                    .HasColumnType("int(11)")
                    .HasColumnName("listen_port");

                entity.Property(e => e.ProxyHostid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("proxy_hostid");

                entity.Property(e => e.TlsAccepted)
                    .HasColumnType("int(11)")
                    .HasColumnName("tls_accepted")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.ProxyHost)
                    .WithMany(p => p.AutoregHosts)
                    .HasForeignKey(d => d.ProxyHostid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_autoreg_host_1");
            });

            modelBuilder.Entity<Condition>(entity =>
            {
                entity.ToTable("conditions");

                entity.HasIndex(e => e.Actionid, "conditions_1");

                entity.Property(e => e.Conditionid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("conditionid");

                entity.Property(e => e.Actionid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("actionid");

                entity.Property(e => e.Conditiontype)
                    .HasColumnType("int(11)")
                    .HasColumnName("conditiontype");

                entity.Property(e => e.Operator)
                    .HasColumnType("int(11)")
                    .HasColumnName("operator");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Value2)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("value2")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.Conditions)
                    .HasForeignKey(d => d.Actionid)
                    .HasConstraintName("c_conditions_1");
            });

            modelBuilder.Entity<Config>(entity =>
            {
                entity.ToTable("config");

                entity.HasIndex(e => e.AlertUsrgrpid, "config_1");

                entity.HasIndex(e => e.DiscoveryGroupid, "config_2");

                entity.Property(e => e.Configid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("configid");

                entity.Property(e => e.AlertUsrgrpid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("alert_usrgrpid");

                entity.Property(e => e.AuthenticationType)
                    .HasColumnType("int(11)")
                    .HasColumnName("authentication_type");

                entity.Property(e => e.AutoregTlsAccept)
                    .HasColumnType("int(11)")
                    .HasColumnName("autoreg_tls_accept")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.BlinkPeriod)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("blink_period")
                    .HasDefaultValueSql("'2m'");

                entity.Property(e => e.CompressOlder)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("compress_older")
                    .HasDefaultValueSql("'7d'");

                entity.Property(e => e.CompressionAvailability)
                    .HasColumnType("int(11)")
                    .HasColumnName("compression_availability");

                entity.Property(e => e.CompressionStatus)
                    .HasColumnType("int(11)")
                    .HasColumnName("compression_status");

                entity.Property(e => e.ConnectTimeout)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("connect_timeout")
                    .HasDefaultValueSql("'3s'");

                entity.Property(e => e.CustomColor)
                    .HasColumnType("int(11)")
                    .HasColumnName("custom_color");

                entity.Property(e => e.DbExtension)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("db_extension")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.DefaultInventoryMode)
                    .HasColumnType("int(11)")
                    .HasColumnName("default_inventory_mode")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.DefaultLang)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("default_lang")
                    .HasDefaultValueSql("'en_GB'");

                entity.Property(e => e.DefaultTheme)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("default_theme")
                    .HasDefaultValueSql("'blue-theme'");

                entity.Property(e => e.DefaultTimezone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("default_timezone")
                    .HasDefaultValueSql("'system'");

                entity.Property(e => e.DiscoveryGroupid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("discovery_groupid");

                entity.Property(e => e.HistoryPeriod)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("history_period")
                    .HasDefaultValueSql("'24h'");

                entity.Property(e => e.HkAudit)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("hk_audit")
                    .HasDefaultValueSql("'365d'");

                entity.Property(e => e.HkAuditMode)
                    .HasColumnType("int(11)")
                    .HasColumnName("hk_audit_mode")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.HkEventsAutoreg)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("hk_events_autoreg")
                    .HasDefaultValueSql("'1d'");

                entity.Property(e => e.HkEventsDiscovery)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("hk_events_discovery")
                    .HasDefaultValueSql("'1d'");

                entity.Property(e => e.HkEventsInternal)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("hk_events_internal")
                    .HasDefaultValueSql("'1d'");

                entity.Property(e => e.HkEventsMode)
                    .HasColumnType("int(11)")
                    .HasColumnName("hk_events_mode")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.HkEventsTrigger)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("hk_events_trigger")
                    .HasDefaultValueSql("'365d'");

                entity.Property(e => e.HkHistory)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("hk_history")
                    .HasDefaultValueSql("'90d'");

                entity.Property(e => e.HkHistoryGlobal)
                    .HasColumnType("int(11)")
                    .HasColumnName("hk_history_global");

                entity.Property(e => e.HkHistoryMode)
                    .HasColumnType("int(11)")
                    .HasColumnName("hk_history_mode")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.HkServices)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("hk_services")
                    .HasDefaultValueSql("'365d'");

                entity.Property(e => e.HkServicesMode)
                    .HasColumnType("int(11)")
                    .HasColumnName("hk_services_mode")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.HkSessions)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("hk_sessions")
                    .HasDefaultValueSql("'365d'");

                entity.Property(e => e.HkSessionsMode)
                    .HasColumnType("int(11)")
                    .HasColumnName("hk_sessions_mode")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.HkTrends)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("hk_trends")
                    .HasDefaultValueSql("'365d'");

                entity.Property(e => e.HkTrendsGlobal)
                    .HasColumnType("int(11)")
                    .HasColumnName("hk_trends_global");

                entity.Property(e => e.HkTrendsMode)
                    .HasColumnType("int(11)")
                    .HasColumnName("hk_trends_mode")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.HttpAuthEnabled)
                    .HasColumnType("int(11)")
                    .HasColumnName("http_auth_enabled");

                entity.Property(e => e.HttpCaseSensitive)
                    .HasColumnType("int(11)")
                    .HasColumnName("http_case_sensitive")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.HttpLoginForm)
                    .HasColumnType("int(11)")
                    .HasColumnName("http_login_form");

                entity.Property(e => e.HttpStripDomains)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("http_strip_domains")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.IframeSandboxingEnabled)
                    .HasColumnType("int(11)")
                    .HasColumnName("iframe_sandboxing_enabled")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IframeSandboxingExceptions)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("iframe_sandboxing_exceptions")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Instanceid)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("instanceid")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ItemTestTimeout)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("item_test_timeout")
                    .HasDefaultValueSql("'60s'");

                entity.Property(e => e.LdapBaseDn)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("ldap_base_dn")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LdapBindDn)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("ldap_bind_dn")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LdapBindPassword)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("ldap_bind_password")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LdapCaseSensitive)
                    .HasColumnType("int(11)")
                    .HasColumnName("ldap_case_sensitive")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LdapConfigured)
                    .HasColumnType("int(11)")
                    .HasColumnName("ldap_configured");

                entity.Property(e => e.LdapHost)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("ldap_host")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LdapPort)
                    .HasColumnType("int(11)")
                    .HasColumnName("ldap_port")
                    .HasDefaultValueSql("'389'");

                entity.Property(e => e.LdapSearchAttribute)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("ldap_search_attribute")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LoginAttempts)
                    .HasColumnType("int(11)")
                    .HasColumnName("login_attempts")
                    .HasDefaultValueSql("'5'");

                entity.Property(e => e.LoginBlock)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("login_block")
                    .HasDefaultValueSql("'30s'");

                entity.Property(e => e.MaxInTable)
                    .HasColumnType("int(11)")
                    .HasColumnName("max_in_table")
                    .HasDefaultValueSql("'50'");

                entity.Property(e => e.MaxOverviewTableSize)
                    .HasColumnType("int(11)")
                    .HasColumnName("max_overview_table_size")
                    .HasDefaultValueSql("'50'");

                entity.Property(e => e.MaxPeriod)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("max_period")
                    .HasDefaultValueSql("'2y'");

                entity.Property(e => e.MediaTypeTestTimeout)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("media_type_test_timeout")
                    .HasDefaultValueSql("'65s'");

                entity.Property(e => e.OkAckColor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("ok_ack_color")
                    .HasDefaultValueSql("'009900'");

                entity.Property(e => e.OkAckStyle)
                    .HasColumnType("int(11)")
                    .HasColumnName("ok_ack_style")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.OkPeriod)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("ok_period")
                    .HasDefaultValueSql("'5m'");

                entity.Property(e => e.OkUnackColor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("ok_unack_color")
                    .HasDefaultValueSql("'009900'");

                entity.Property(e => e.OkUnackStyle)
                    .HasColumnType("int(11)")
                    .HasColumnName("ok_unack_style")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.PeriodDefault)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("period_default")
                    .HasDefaultValueSql("'1h'");

                entity.Property(e => e.ProblemAckColor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("problem_ack_color")
                    .HasDefaultValueSql("'CC0000'");

                entity.Property(e => e.ProblemAckStyle)
                    .HasColumnType("int(11)")
                    .HasColumnName("problem_ack_style")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ProblemUnackColor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("problem_unack_color")
                    .HasDefaultValueSql("'CC0000'");

                entity.Property(e => e.ProblemUnackStyle)
                    .HasColumnType("int(11)")
                    .HasColumnName("problem_unack_style")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.SamlAuthEnabled)
                    .HasColumnType("int(11)")
                    .HasColumnName("saml_auth_enabled");

                entity.Property(e => e.SamlCaseSensitive)
                    .HasColumnType("int(11)")
                    .HasColumnName("saml_case_sensitive");

                entity.Property(e => e.SamlEncryptAssertions)
                    .HasColumnType("int(11)")
                    .HasColumnName("saml_encrypt_assertions");

                entity.Property(e => e.SamlEncryptNameid)
                    .HasColumnType("int(11)")
                    .HasColumnName("saml_encrypt_nameid");

                entity.Property(e => e.SamlIdpEntityid)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("saml_idp_entityid")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SamlNameidFormat)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("saml_nameid_format")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SamlSignAssertions)
                    .HasColumnType("int(11)")
                    .HasColumnName("saml_sign_assertions");

                entity.Property(e => e.SamlSignAuthnRequests)
                    .HasColumnType("int(11)")
                    .HasColumnName("saml_sign_authn_requests");

                entity.Property(e => e.SamlSignLogoutRequests)
                    .HasColumnType("int(11)")
                    .HasColumnName("saml_sign_logout_requests");

                entity.Property(e => e.SamlSignLogoutResponses)
                    .HasColumnType("int(11)")
                    .HasColumnName("saml_sign_logout_responses");

                entity.Property(e => e.SamlSignMessages)
                    .HasColumnType("int(11)")
                    .HasColumnName("saml_sign_messages");

                entity.Property(e => e.SamlSloUrl)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("saml_slo_url")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SamlSpEntityid)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("saml_sp_entityid")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SamlSsoUrl)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("saml_sso_url")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SamlUsernameAttribute)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("saml_username_attribute")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ScriptTimeout)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("script_timeout")
                    .HasDefaultValueSql("'60s'");

                entity.Property(e => e.SearchLimit)
                    .HasColumnType("int(11)")
                    .HasColumnName("search_limit")
                    .HasDefaultValueSql("'1000'");

                entity.Property(e => e.ServerCheckInterval)
                    .HasColumnType("int(11)")
                    .HasColumnName("server_check_interval")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.SessionKey)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("session_key")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SeverityColor0)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("severity_color_0")
                    .HasDefaultValueSql("'97AAB3'");

                entity.Property(e => e.SeverityColor1)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("severity_color_1")
                    .HasDefaultValueSql("'7499FF'");

                entity.Property(e => e.SeverityColor2)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("severity_color_2")
                    .HasDefaultValueSql("'FFC859'");

                entity.Property(e => e.SeverityColor3)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("severity_color_3")
                    .HasDefaultValueSql("'FFA059'");

                entity.Property(e => e.SeverityColor4)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("severity_color_4")
                    .HasDefaultValueSql("'E97659'");

                entity.Property(e => e.SeverityColor5)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("severity_color_5")
                    .HasDefaultValueSql("'E45959'");

                entity.Property(e => e.SeverityName0)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("severity_name_0")
                    .HasDefaultValueSql("'Not classified'");

                entity.Property(e => e.SeverityName1)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("severity_name_1")
                    .HasDefaultValueSql("'Information'");

                entity.Property(e => e.SeverityName2)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("severity_name_2")
                    .HasDefaultValueSql("'Warning'");

                entity.Property(e => e.SeverityName3)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("severity_name_3")
                    .HasDefaultValueSql("'Average'");

                entity.Property(e => e.SeverityName4)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("severity_name_4")
                    .HasDefaultValueSql("'High'");

                entity.Property(e => e.SeverityName5)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("severity_name_5")
                    .HasDefaultValueSql("'Disaster'");

                entity.Property(e => e.ShowTechnicalErrors)
                    .HasColumnType("int(11)")
                    .HasColumnName("show_technical_errors");

                entity.Property(e => e.SnmptrapLogging)
                    .HasColumnType("int(11)")
                    .HasColumnName("snmptrap_logging")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.SocketTimeout)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("socket_timeout")
                    .HasDefaultValueSql("'3s'");

                entity.Property(e => e.UriValidSchemes)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("uri_valid_schemes")
                    .HasDefaultValueSql("'http,https,ftp,file,mailto,tel,ssh'");

                entity.Property(e => e.ValidateUriSchemes)
                    .HasColumnType("int(11)")
                    .HasColumnName("validate_uri_schemes")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.WorkPeriod)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("work_period")
                    .HasDefaultValueSql("'1-5,09:00-18:00'");

                entity.Property(e => e.XFrameOptions)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("x_frame_options")
                    .HasDefaultValueSql("'SAMEORIGIN'");

                entity.HasOne(d => d.AlertUsrgrp)
                    .WithMany(p => p.Configs)
                    .HasForeignKey(d => d.AlertUsrgrpid)
                    .HasConstraintName("c_config_1");

                entity.HasOne(d => d.DiscoveryGroup)
                    .WithMany(p => p.Configs)
                    .HasForeignKey(d => d.DiscoveryGroupid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("c_config_2");
            });

            modelBuilder.Entity<ConfigAutoregTl>(entity =>
            {
                entity.HasKey(e => e.AutoregTlsid)
                    .HasName("PRIMARY");

                entity.ToTable("config_autoreg_tls");

                entity.HasIndex(e => e.TlsPskIdentity, "config_autoreg_tls_1")
                    .IsUnique();

                entity.Property(e => e.AutoregTlsid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("autoreg_tlsid");

                entity.Property(e => e.TlsPsk)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("tls_psk")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TlsPskIdentity)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("tls_psk_identity")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<CorrCondition>(entity =>
            {
                entity.ToTable("corr_condition");

                entity.HasIndex(e => e.Correlationid, "corr_condition_1");

                entity.Property(e => e.CorrConditionid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("corr_conditionid");

                entity.Property(e => e.Correlationid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("correlationid");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.HasOne(d => d.Correlation)
                    .WithMany(p => p.CorrConditions)
                    .HasForeignKey(d => d.Correlationid)
                    .HasConstraintName("c_corr_condition_1");
            });

            modelBuilder.Entity<CorrConditionGroup>(entity =>
            {
                entity.HasKey(e => e.CorrConditionid)
                    .HasName("PRIMARY");

                entity.ToTable("corr_condition_group");

                entity.HasIndex(e => e.Groupid, "corr_condition_group_1");

                entity.Property(e => e.CorrConditionid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("corr_conditionid");

                entity.Property(e => e.Groupid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("groupid");

                entity.Property(e => e.Operator)
                    .HasColumnType("int(11)")
                    .HasColumnName("operator");

                entity.HasOne(d => d.CorrCondition)
                    .WithOne(p => p.CorrConditionGroup)
                    .HasForeignKey<CorrConditionGroup>(d => d.CorrConditionid)
                    .HasConstraintName("c_corr_condition_group_1");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.CorrConditionGroups)
                    .HasForeignKey(d => d.Groupid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("c_corr_condition_group_2");
            });

            modelBuilder.Entity<CorrConditionTag>(entity =>
            {
                entity.HasKey(e => e.CorrConditionid)
                    .HasName("PRIMARY");

                entity.ToTable("corr_condition_tag");

                entity.Property(e => e.CorrConditionid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("corr_conditionid");

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("tag")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.CorrCondition)
                    .WithOne(p => p.CorrConditionTag)
                    .HasForeignKey<CorrConditionTag>(d => d.CorrConditionid)
                    .HasConstraintName("c_corr_condition_tag_1");
            });

            modelBuilder.Entity<CorrConditionTagpair>(entity =>
            {
                entity.HasKey(e => e.CorrConditionid)
                    .HasName("PRIMARY");

                entity.ToTable("corr_condition_tagpair");

                entity.Property(e => e.CorrConditionid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("corr_conditionid");

                entity.Property(e => e.Newtag)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("newtag")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Oldtag)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("oldtag")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.CorrCondition)
                    .WithOne(p => p.CorrConditionTagpair)
                    .HasForeignKey<CorrConditionTagpair>(d => d.CorrConditionid)
                    .HasConstraintName("c_corr_condition_tagpair_1");
            });

            modelBuilder.Entity<CorrConditionTagvalue>(entity =>
            {
                entity.HasKey(e => e.CorrConditionid)
                    .HasName("PRIMARY");

                entity.ToTable("corr_condition_tagvalue");

                entity.Property(e => e.CorrConditionid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("corr_conditionid");

                entity.Property(e => e.Operator)
                    .HasColumnType("int(11)")
                    .HasColumnName("operator");

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("tag")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.CorrCondition)
                    .WithOne(p => p.CorrConditionTagvalue)
                    .HasForeignKey<CorrConditionTagvalue>(d => d.CorrConditionid)
                    .HasConstraintName("c_corr_condition_tagvalue_1");
            });

            modelBuilder.Entity<CorrOperation>(entity =>
            {
                entity.ToTable("corr_operation");

                entity.HasIndex(e => e.Correlationid, "corr_operation_1");

                entity.Property(e => e.CorrOperationid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("corr_operationid");

                entity.Property(e => e.Correlationid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("correlationid");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.HasOne(d => d.Correlation)
                    .WithMany(p => p.CorrOperations)
                    .HasForeignKey(d => d.Correlationid)
                    .HasConstraintName("c_corr_operation_1");
            });

            modelBuilder.Entity<Correlation>(entity =>
            {
                entity.ToTable("correlation");

                entity.HasIndex(e => e.Status, "correlation_1");

                entity.HasIndex(e => e.Name, "correlation_2")
                    .IsUnique();

                entity.Property(e => e.Correlationid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("correlationid");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Evaltype)
                    .HasColumnType("int(11)")
                    .HasColumnName("evaltype");

                entity.Property(e => e.Formula)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("formula")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Dashboard>(entity =>
            {
                entity.ToTable("dashboard");

                entity.HasIndex(e => e.Userid, "dashboard_1");

                entity.HasIndex(e => e.Templateid, "dashboard_2");

                entity.Property(e => e.Dashboardid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("dashboardid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Private)
                    .HasColumnType("int(11)")
                    .HasColumnName("private")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Templateid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("templateid");

                entity.Property(e => e.Userid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("userid");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Dashboards)
                    .HasForeignKey(d => d.Templateid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_dashboard_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Dashboards)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("c_dashboard_1");
            });

            modelBuilder.Entity<DashboardUser>(entity =>
            {
                entity.ToTable("dashboard_user");

                entity.HasIndex(e => e.Userid, "c_dashboard_user_2");

                entity.HasIndex(e => new { e.Dashboardid, e.Userid }, "dashboard_user_1")
                    .IsUnique();

                entity.Property(e => e.DashboardUserid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("dashboard_userid");

                entity.Property(e => e.Dashboardid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("dashboardid");

                entity.Property(e => e.Permission)
                    .HasColumnType("int(11)")
                    .HasColumnName("permission")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.Userid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("userid");

                entity.HasOne(d => d.Dashboard)
                    .WithMany(p => p.DashboardUsers)
                    .HasForeignKey(d => d.Dashboardid)
                    .HasConstraintName("c_dashboard_user_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DashboardUsers)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("c_dashboard_user_2");
            });

            modelBuilder.Entity<DashboardUsrgrp>(entity =>
            {
                entity.ToTable("dashboard_usrgrp");

                entity.HasIndex(e => e.Usrgrpid, "c_dashboard_usrgrp_2");

                entity.HasIndex(e => new { e.Dashboardid, e.Usrgrpid }, "dashboard_usrgrp_1")
                    .IsUnique();

                entity.Property(e => e.DashboardUsrgrpid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("dashboard_usrgrpid");

                entity.Property(e => e.Dashboardid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("dashboardid");

                entity.Property(e => e.Permission)
                    .HasColumnType("int(11)")
                    .HasColumnName("permission")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.Usrgrpid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("usrgrpid");

                entity.HasOne(d => d.Dashboard)
                    .WithMany(p => p.DashboardUsrgrps)
                    .HasForeignKey(d => d.Dashboardid)
                    .HasConstraintName("c_dashboard_usrgrp_1");

                entity.HasOne(d => d.Usrgrp)
                    .WithMany(p => p.DashboardUsrgrps)
                    .HasForeignKey(d => d.Usrgrpid)
                    .HasConstraintName("c_dashboard_usrgrp_2");
            });

            modelBuilder.Entity<Dbversion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dbversion");

                entity.Property(e => e.Mandatory)
                    .HasColumnType("int(11)")
                    .HasColumnName("mandatory");

                entity.Property(e => e.Optional)
                    .HasColumnType("int(11)")
                    .HasColumnName("optional");
            });

            modelBuilder.Entity<Dcheck>(entity =>
            {
                entity.ToTable("dchecks");

                entity.HasIndex(e => new { e.Druleid, e.HostSource, e.NameSource }, "dchecks_1");

                entity.Property(e => e.Dcheckid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("dcheckid");

                entity.Property(e => e.Druleid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("druleid");

                entity.Property(e => e.HostSource)
                    .HasColumnType("int(11)")
                    .HasColumnName("host_source")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("key_")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NameSource)
                    .HasColumnType("int(11)")
                    .HasColumnName("name_source");

                entity.Property(e => e.Ports)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("ports")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SnmpCommunity)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("snmp_community")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Snmpv3Authpassphrase)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("snmpv3_authpassphrase")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Snmpv3Authprotocol)
                    .HasColumnType("int(11)")
                    .HasColumnName("snmpv3_authprotocol");

                entity.Property(e => e.Snmpv3Contextname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("snmpv3_contextname")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Snmpv3Privpassphrase)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("snmpv3_privpassphrase")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Snmpv3Privprotocol)
                    .HasColumnType("int(11)")
                    .HasColumnName("snmpv3_privprotocol");

                entity.Property(e => e.Snmpv3Securitylevel)
                    .HasColumnType("int(11)")
                    .HasColumnName("snmpv3_securitylevel");

                entity.Property(e => e.Snmpv3Securityname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("snmpv3_securityname")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.Property(e => e.Uniq)
                    .HasColumnType("int(11)")
                    .HasColumnName("uniq");

                entity.HasOne(d => d.Drule)
                    .WithMany(p => p.Dchecks)
                    .HasForeignKey(d => d.Druleid)
                    .HasConstraintName("c_dchecks_1");
            });

            modelBuilder.Entity<Dhost>(entity =>
            {
                entity.ToTable("dhosts");

                entity.HasIndex(e => e.Druleid, "dhosts_1");

                entity.Property(e => e.Dhostid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("dhostid");

                entity.Property(e => e.Druleid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("druleid");

                entity.Property(e => e.Lastdown)
                    .HasColumnType("int(11)")
                    .HasColumnName("lastdown");

                entity.Property(e => e.Lastup)
                    .HasColumnType("int(11)")
                    .HasColumnName("lastup");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.HasOne(d => d.Drule)
                    .WithMany(p => p.Dhosts)
                    .HasForeignKey(d => d.Druleid)
                    .HasConstraintName("c_dhosts_1");
            });

            modelBuilder.Entity<Drule>(entity =>
            {
                entity.ToTable("drules");

                entity.HasIndex(e => e.ProxyHostid, "drules_1");

                entity.HasIndex(e => e.Name, "drules_2")
                    .IsUnique();

                entity.Property(e => e.Druleid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("druleid");

                entity.Property(e => e.Delay)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("delay")
                    .HasDefaultValueSql("'1h'");

                entity.Property(e => e.Iprange)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("iprange")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Nextcheck)
                    .HasColumnType("int(11)")
                    .HasColumnName("nextcheck");

                entity.Property(e => e.ProxyHostid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("proxy_hostid");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.HasOne(d => d.ProxyHost)
                    .WithMany(p => p.Drules)
                    .HasForeignKey(d => d.ProxyHostid)
                    .HasConstraintName("c_drules_1");
            });

            modelBuilder.Entity<Dservice>(entity =>
            {
                entity.ToTable("dservices");

                entity.HasIndex(e => new { e.Dcheckid, e.Ip, e.Port }, "dservices_1")
                    .IsUnique();

                entity.HasIndex(e => e.Dhostid, "dservices_2");

                entity.Property(e => e.Dserviceid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("dserviceid");

                entity.Property(e => e.Dcheckid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("dcheckid");

                entity.Property(e => e.Dhostid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("dhostid");

                entity.Property(e => e.Dns)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("dns")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(39)
                    .HasColumnName("ip")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Lastdown)
                    .HasColumnType("int(11)")
                    .HasColumnName("lastdown");

                entity.Property(e => e.Lastup)
                    .HasColumnType("int(11)")
                    .HasColumnName("lastup");

                entity.Property(e => e.Port)
                    .HasColumnType("int(11)")
                    .HasColumnName("port");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Dcheck)
                    .WithMany(p => p.Dservices)
                    .HasForeignKey(d => d.Dcheckid)
                    .HasConstraintName("c_dservices_2");

                entity.HasOne(d => d.Dhost)
                    .WithMany(p => p.Dservices)
                    .HasForeignKey(d => d.Dhostid)
                    .HasConstraintName("c_dservices_1");
            });

            modelBuilder.Entity<Escalation>(entity =>
            {
                entity.ToTable("escalations");

                entity.HasIndex(e => new { e.Triggerid, e.Itemid, e.Escalationid }, "escalations_1")
                    .IsUnique();

                entity.HasIndex(e => e.Eventid, "escalations_2");

                entity.HasIndex(e => e.Nextcheck, "escalations_3");

                entity.Property(e => e.Escalationid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("escalationid");

                entity.Property(e => e.Acknowledgeid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("acknowledgeid");

                entity.Property(e => e.Actionid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("actionid");

                entity.Property(e => e.EscStep)
                    .HasColumnType("int(11)")
                    .HasColumnName("esc_step");

                entity.Property(e => e.Eventid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("eventid");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.Property(e => e.Nextcheck)
                    .HasColumnType("int(11)")
                    .HasColumnName("nextcheck");

                entity.Property(e => e.REventid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("r_eventid");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.Property(e => e.Triggerid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("triggerid");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("events");

                entity.HasIndex(e => new { e.Source, e.Object, e.Objectid, e.Clock }, "events_1");

                entity.HasIndex(e => new { e.Source, e.Object, e.Clock }, "events_2");

                entity.Property(e => e.Eventid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("eventid");

                entity.Property(e => e.Acknowledged)
                    .HasColumnType("int(11)")
                    .HasColumnName("acknowledged");

                entity.Property(e => e.Clock)
                    .HasColumnType("int(11)")
                    .HasColumnName("clock");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Ns)
                    .HasColumnType("int(11)")
                    .HasColumnName("ns");

                entity.Property(e => e.Object)
                    .HasColumnType("int(11)")
                    .HasColumnName("object");

                entity.Property(e => e.Objectid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("objectid");

                entity.Property(e => e.Severity)
                    .HasColumnType("int(11)")
                    .HasColumnName("severity");

                entity.Property(e => e.Source)
                    .HasColumnType("int(11)")
                    .HasColumnName("source");

                entity.Property(e => e.Value)
                    .HasColumnType("int(11)")
                    .HasColumnName("value");
            });

            modelBuilder.Entity<EventRecovery>(entity =>
            {
                entity.HasKey(e => e.Eventid)
                    .HasName("PRIMARY");

                entity.ToTable("event_recovery");

                entity.HasIndex(e => e.REventid, "event_recovery_1");

                entity.HasIndex(e => e.CEventid, "event_recovery_2");

                entity.Property(e => e.Eventid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("eventid");

                entity.Property(e => e.CEventid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("c_eventid");

                entity.Property(e => e.Correlationid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("correlationid");

                entity.Property(e => e.REventid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("r_eventid");

                entity.Property(e => e.Userid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("userid");

                entity.HasOne(d => d.CEvent)
                    .WithMany(p => p.EventRecoveryCEvents)
                    .HasForeignKey(d => d.CEventid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_event_recovery_3");

                entity.HasOne(d => d.Event)
                    .WithOne(p => p.EventRecoveryEvent)
                    .HasForeignKey<EventRecovery>(d => d.Eventid)
                    .HasConstraintName("c_event_recovery_1");

                entity.HasOne(d => d.REvent)
                    .WithMany(p => p.EventRecoveryREvents)
                    .HasForeignKey(d => d.REventid)
                    .HasConstraintName("c_event_recovery_2");
            });

            modelBuilder.Entity<EventSuppress>(entity =>
            {
                entity.ToTable("event_suppress");

                entity.HasIndex(e => new { e.Eventid, e.Maintenanceid }, "event_suppress_1")
                    .IsUnique();

                entity.HasIndex(e => e.SuppressUntil, "event_suppress_2");

                entity.HasIndex(e => e.Maintenanceid, "event_suppress_3");

                entity.Property(e => e.EventSuppressid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("event_suppressid");

                entity.Property(e => e.Eventid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("eventid");

                entity.Property(e => e.Maintenanceid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("maintenanceid");

                entity.Property(e => e.SuppressUntil)
                    .HasColumnType("int(11)")
                    .HasColumnName("suppress_until");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventSuppresses)
                    .HasForeignKey(d => d.Eventid)
                    .HasConstraintName("c_event_suppress_1");

                entity.HasOne(d => d.Maintenance)
                    .WithMany(p => p.EventSuppresses)
                    .HasForeignKey(d => d.Maintenanceid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_event_suppress_2");
            });

            modelBuilder.Entity<EventTag>(entity =>
            {
                entity.ToTable("event_tag");

                entity.HasIndex(e => e.Eventid, "event_tag_1");

                entity.Property(e => e.Eventtagid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("eventtagid");

                entity.Property(e => e.Eventid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("eventid");

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("tag")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventTags)
                    .HasForeignKey(d => d.Eventid)
                    .HasConstraintName("c_event_tag_1");
            });

            modelBuilder.Entity<Expression>(entity =>
            {
                entity.ToTable("expressions");

                entity.HasIndex(e => e.Regexpid, "expressions_1");

                entity.Property(e => e.Expressionid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("expressionid");

                entity.Property(e => e.CaseSensitive)
                    .HasColumnType("int(11)")
                    .HasColumnName("case_sensitive");

                entity.Property(e => e.ExpDelimiter)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("exp_delimiter")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Expression1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("expression")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ExpressionType)
                    .HasColumnType("int(11)")
                    .HasColumnName("expression_type");

                entity.Property(e => e.Regexpid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("regexpid");

                entity.HasOne(d => d.Regexp)
                    .WithMany(p => p.Expressions)
                    .HasForeignKey(d => d.Regexpid)
                    .HasConstraintName("c_expressions_1");
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.ToTable("functions");

                entity.HasIndex(e => e.Triggerid, "functions_1");

                entity.HasIndex(e => new { e.Itemid, e.Name, e.Parameter }, "functions_2");

                entity.Property(e => e.Functionid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("functionid");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Parameter)
                    .IsRequired()
                    .HasColumnName("parameter")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Triggerid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("triggerid");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Functions)
                    .HasForeignKey(d => d.Itemid)
                    .HasConstraintName("c_functions_1");

                entity.HasOne(d => d.Trigger)
                    .WithMany(p => p.Functions)
                    .HasForeignKey(d => d.Triggerid)
                    .HasConstraintName("c_functions_2");
            });

            modelBuilder.Entity<Globalmacro>(entity =>
            {
                entity.ToTable("globalmacro");

                entity.HasIndex(e => e.Macro, "globalmacro_1")
                    .IsUnique();

                entity.Property(e => e.Globalmacroid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("globalmacroid");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Macro)
                    .IsRequired()
                    .HasColumnName("macro")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Globalvar>(entity =>
            {
                entity.ToTable("globalvars");

                entity.Property(e => e.Globalvarid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("globalvarid");

                entity.Property(e => e.SnmpLastsize)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("snmp_lastsize");
            });

            modelBuilder.Entity<Graph>(entity =>
            {
                entity.ToTable("graphs");

                entity.HasIndex(e => e.Name, "graphs_1");

                entity.HasIndex(e => e.Templateid, "graphs_2");

                entity.HasIndex(e => e.YminItemid, "graphs_3");

                entity.HasIndex(e => e.YmaxItemid, "graphs_4");

                entity.Property(e => e.Graphid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("graphid");

                entity.Property(e => e.Discover)
                    .HasColumnType("int(11)")
                    .HasColumnName("discover");

                entity.Property(e => e.Flags)
                    .HasColumnType("int(11)")
                    .HasColumnName("flags");

                entity.Property(e => e.Graphtype)
                    .HasColumnType("int(11)")
                    .HasColumnName("graphtype");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height")
                    .HasDefaultValueSql("'200'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PercentLeft).HasColumnName("percent_left");

                entity.Property(e => e.PercentRight).HasColumnName("percent_right");

                entity.Property(e => e.Show3d)
                    .HasColumnType("int(11)")
                    .HasColumnName("show_3d");

                entity.Property(e => e.ShowLegend)
                    .HasColumnType("int(11)")
                    .HasColumnName("show_legend")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ShowTriggers)
                    .HasColumnType("int(11)")
                    .HasColumnName("show_triggers")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ShowWorkPeriod)
                    .HasColumnType("int(11)")
                    .HasColumnName("show_work_period")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Templateid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("templateid");

                entity.Property(e => e.Width)
                    .HasColumnType("int(11)")
                    .HasColumnName("width")
                    .HasDefaultValueSql("'900'");

                entity.Property(e => e.Yaxismax)
                    .HasColumnName("yaxismax")
                    .HasDefaultValueSql("'100'");

                entity.Property(e => e.Yaxismin).HasColumnName("yaxismin");

                entity.Property(e => e.YmaxItemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("ymax_itemid");

                entity.Property(e => e.YmaxType)
                    .HasColumnType("int(11)")
                    .HasColumnName("ymax_type");

                entity.Property(e => e.YminItemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("ymin_itemid");

                entity.Property(e => e.YminType)
                    .HasColumnType("int(11)")
                    .HasColumnName("ymin_type");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.InverseTemplate)
                    .HasForeignKey(d => d.Templateid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_graphs_1");

                entity.HasOne(d => d.YmaxItem)
                    .WithMany(p => p.GraphYmaxItems)
                    .HasForeignKey(d => d.YmaxItemid)
                    .HasConstraintName("c_graphs_3");

                entity.HasOne(d => d.YminItem)
                    .WithMany(p => p.GraphYminItems)
                    .HasForeignKey(d => d.YminItemid)
                    .HasConstraintName("c_graphs_2");
            });

            modelBuilder.Entity<GraphDiscovery>(entity =>
            {
                entity.HasKey(e => e.Graphid)
                    .HasName("PRIMARY");

                entity.ToTable("graph_discovery");

                entity.HasIndex(e => e.ParentGraphid, "graph_discovery_1");

                entity.Property(e => e.Graphid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("graphid");

                entity.Property(e => e.Lastcheck)
                    .HasColumnType("int(11)")
                    .HasColumnName("lastcheck");

                entity.Property(e => e.ParentGraphid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("parent_graphid");

                entity.Property(e => e.TsDelete)
                    .HasColumnType("int(11)")
                    .HasColumnName("ts_delete");

                entity.HasOne(d => d.Graph)
                    .WithOne(p => p.GraphDiscoveryGraph)
                    .HasForeignKey<GraphDiscovery>(d => d.Graphid)
                    .HasConstraintName("c_graph_discovery_1");

                entity.HasOne(d => d.ParentGraph)
                    .WithMany(p => p.GraphDiscoveryParentGraphs)
                    .HasForeignKey(d => d.ParentGraphid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("c_graph_discovery_2");
            });

            modelBuilder.Entity<GraphTheme>(entity =>
            {
                entity.ToTable("graph_theme");

                entity.HasIndex(e => e.Theme, "graph_theme_1")
                    .IsUnique();

                entity.Property(e => e.Graphthemeid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("graphthemeid");

                entity.Property(e => e.Backgroundcolor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("backgroundcolor")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Colorpalette)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("colorpalette")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Graphcolor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("graphcolor")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Gridbordercolor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("gridbordercolor")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Gridcolor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("gridcolor")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Highlightcolor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("highlightcolor")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Leftpercentilecolor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("leftpercentilecolor")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Maingridcolor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("maingridcolor")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Nonworktimecolor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("nonworktimecolor")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Rightpercentilecolor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("rightpercentilecolor")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Textcolor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("textcolor")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Theme)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("theme")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<GraphsItem>(entity =>
            {
                entity.HasKey(e => e.Gitemid)
                    .HasName("PRIMARY");

                entity.ToTable("graphs_items");

                entity.HasIndex(e => e.Itemid, "graphs_items_1");

                entity.HasIndex(e => e.Graphid, "graphs_items_2");

                entity.Property(e => e.Gitemid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("gitemid");

                entity.Property(e => e.CalcFnc)
                    .HasColumnType("int(11)")
                    .HasColumnName("calc_fnc")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("color")
                    .HasDefaultValueSql("'009600'");

                entity.Property(e => e.Drawtype)
                    .HasColumnType("int(11)")
                    .HasColumnName("drawtype");

                entity.Property(e => e.Graphid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("graphid");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.Property(e => e.Sortorder)
                    .HasColumnType("int(11)")
                    .HasColumnName("sortorder");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.Property(e => e.Yaxisside)
                    .HasColumnType("int(11)")
                    .HasColumnName("yaxisside");

                entity.HasOne(d => d.Graph)
                    .WithMany(p => p.GraphsItems)
                    .HasForeignKey(d => d.Graphid)
                    .HasConstraintName("c_graphs_items_1");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.GraphsItems)
                    .HasForeignKey(d => d.Itemid)
                    .HasConstraintName("c_graphs_items_2");
            });

            modelBuilder.Entity<GroupDiscovery>(entity =>
            {
                entity.HasKey(e => e.Groupid)
                    .HasName("PRIMARY");

                entity.ToTable("group_discovery");

                entity.HasIndex(e => e.ParentGroupPrototypeid, "c_group_discovery_2");

                entity.Property(e => e.Groupid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("groupid");

                entity.Property(e => e.Lastcheck)
                    .HasColumnType("int(11)")
                    .HasColumnName("lastcheck");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ParentGroupPrototypeid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("parent_group_prototypeid");

                entity.Property(e => e.TsDelete)
                    .HasColumnType("int(11)")
                    .HasColumnName("ts_delete");

                entity.HasOne(d => d.Group)
                    .WithOne(p => p.GroupDiscovery)
                    .HasForeignKey<GroupDiscovery>(d => d.Groupid)
                    .HasConstraintName("c_group_discovery_1");

                entity.HasOne(d => d.ParentGroupPrototype)
                    .WithMany(p => p.GroupDiscoveries)
                    .HasForeignKey(d => d.ParentGroupPrototypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("c_group_discovery_2");
            });

            modelBuilder.Entity<GroupPrototype>(entity =>
            {
                entity.ToTable("group_prototype");

                entity.HasIndex(e => e.Groupid, "c_group_prototype_2");

                entity.HasIndex(e => e.Templateid, "c_group_prototype_3");

                entity.HasIndex(e => e.Hostid, "group_prototype_1");

                entity.Property(e => e.GroupPrototypeid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("group_prototypeid");

                entity.Property(e => e.Groupid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("groupid");

                entity.Property(e => e.Hostid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("hostid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Templateid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("templateid");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupPrototypes)
                    .HasForeignKey(d => d.Groupid)
                    .HasConstraintName("c_group_prototype_2");

                entity.HasOne(d => d.Host)
                    .WithMany(p => p.GroupPrototypes)
                    .HasForeignKey(d => d.Hostid)
                    .HasConstraintName("c_group_prototype_1");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.InverseTemplate)
                    .HasForeignKey(d => d.Templateid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_group_prototype_3");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("history");

                entity.HasIndex(e => new { e.Itemid, e.Clock }, "history_1");

                entity.Property(e => e.Clock)
                    .HasColumnType("int(11)")
                    .HasColumnName("clock");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.Property(e => e.Ns)
                    .HasColumnType("int(11)")
                    .HasColumnName("ns");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<HistoryLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("history_log");

                entity.HasIndex(e => new { e.Itemid, e.Clock }, "history_log_1");

                entity.Property(e => e.Clock)
                    .HasColumnType("int(11)")
                    .HasColumnName("clock");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.Property(e => e.Logeventid)
                    .HasColumnType("int(11)")
                    .HasColumnName("logeventid");

                entity.Property(e => e.Ns)
                    .HasColumnType("int(11)")
                    .HasColumnName("ns");

                entity.Property(e => e.Severity)
                    .HasColumnType("int(11)")
                    .HasColumnName("severity");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("source")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("int(11)")
                    .HasColumnName("timestamp");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("value");
            });

            modelBuilder.Entity<HistoryStr>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("history_str");

                entity.HasIndex(e => new { e.Itemid, e.Clock }, "history_str_1");

                entity.Property(e => e.Clock)
                    .HasColumnType("int(11)")
                    .HasColumnName("clock");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.Property(e => e.Ns)
                    .HasColumnType("int(11)")
                    .HasColumnName("ns");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<HistoryText>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("history_text");

                entity.HasIndex(e => new { e.Itemid, e.Clock }, "history_text_1");

                entity.Property(e => e.Clock)
                    .HasColumnType("int(11)")
                    .HasColumnName("clock");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.Property(e => e.Ns)
                    .HasColumnType("int(11)")
                    .HasColumnName("ns");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("value");
            });

            modelBuilder.Entity<HistoryUint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("history_uint");

                entity.HasIndex(e => new { e.Itemid, e.Clock }, "history_uint_1");

                entity.Property(e => e.Clock)
                    .HasColumnType("int(11)")
                    .HasColumnName("clock");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.Property(e => e.Ns)
                    .HasColumnType("int(11)")
                    .HasColumnName("ns");

                entity.Property(e => e.Value)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Host>(entity =>
            {
                entity.ToTable("hosts");

                entity.HasIndex(e => e.Templateid, "c_hosts_3");

                entity.HasIndex(e => e.Host1, "hosts_1");

                entity.HasIndex(e => e.Status, "hosts_2");

                entity.HasIndex(e => e.ProxyHostid, "hosts_3");

                entity.HasIndex(e => e.Name, "hosts_4");

                entity.HasIndex(e => e.Maintenanceid, "hosts_5");

                entity.Property(e => e.Hostid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("hostid");

                entity.Property(e => e.AutoCompress)
                    .HasColumnType("int(11)")
                    .HasColumnName("auto_compress")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Available)
                    .HasColumnType("int(11)")
                    .HasColumnName("available");

                entity.Property(e => e.CustomInterfaces)
                    .HasColumnType("int(11)")
                    .HasColumnName("custom_interfaces");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.DisableUntil)
                    .HasColumnType("int(11)")
                    .HasColumnName("disable_until");

                entity.Property(e => e.Discover)
                    .HasColumnType("int(11)")
                    .HasColumnName("discover");

                entity.Property(e => e.Error)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("error")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ErrorsFrom)
                    .HasColumnType("int(11)")
                    .HasColumnName("errors_from");

                entity.Property(e => e.Flags)
                    .HasColumnType("int(11)")
                    .HasColumnName("flags");

                entity.Property(e => e.Host1)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("host")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.IpmiAuthtype)
                    .HasColumnType("int(11)")
                    .HasColumnName("ipmi_authtype")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.IpmiAvailable)
                    .HasColumnType("int(11)")
                    .HasColumnName("ipmi_available");

                entity.Property(e => e.IpmiDisableUntil)
                    .HasColumnType("int(11)")
                    .HasColumnName("ipmi_disable_until");

                entity.Property(e => e.IpmiError)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("ipmi_error")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.IpmiErrorsFrom)
                    .HasColumnType("int(11)")
                    .HasColumnName("ipmi_errors_from");

                entity.Property(e => e.IpmiPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("ipmi_password")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.IpmiPrivilege)
                    .HasColumnType("int(11)")
                    .HasColumnName("ipmi_privilege")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.IpmiUsername)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("ipmi_username")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.JmxAvailable)
                    .HasColumnType("int(11)")
                    .HasColumnName("jmx_available");

                entity.Property(e => e.JmxDisableUntil)
                    .HasColumnType("int(11)")
                    .HasColumnName("jmx_disable_until");

                entity.Property(e => e.JmxError)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("jmx_error")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.JmxErrorsFrom)
                    .HasColumnType("int(11)")
                    .HasColumnName("jmx_errors_from");

                entity.Property(e => e.Lastaccess)
                    .HasColumnType("int(11)")
                    .HasColumnName("lastaccess");

                entity.Property(e => e.MaintenanceFrom)
                    .HasColumnType("int(11)")
                    .HasColumnName("maintenance_from");

                entity.Property(e => e.MaintenanceStatus)
                    .HasColumnType("int(11)")
                    .HasColumnName("maintenance_status");

                entity.Property(e => e.MaintenanceType)
                    .HasColumnType("int(11)")
                    .HasColumnName("maintenance_type");

                entity.Property(e => e.Maintenanceid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("maintenanceid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ProxyAddress)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("proxy_address")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ProxyHostid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("proxy_hostid");

                entity.Property(e => e.SnmpAvailable)
                    .HasColumnType("int(11)")
                    .HasColumnName("snmp_available");

                entity.Property(e => e.SnmpDisableUntil)
                    .HasColumnType("int(11)")
                    .HasColumnName("snmp_disable_until");

                entity.Property(e => e.SnmpError)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("snmp_error")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SnmpErrorsFrom)
                    .HasColumnType("int(11)")
                    .HasColumnName("snmp_errors_from");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.Property(e => e.Templateid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("templateid");

                entity.Property(e => e.TlsAccept)
                    .HasColumnType("int(11)")
                    .HasColumnName("tls_accept")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TlsConnect)
                    .HasColumnType("int(11)")
                    .HasColumnName("tls_connect")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TlsIssuer)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("tls_issuer")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TlsPsk)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("tls_psk")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TlsPskIdentity)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("tls_psk_identity")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TlsSubject)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("tls_subject")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Maintenance)
                    .WithMany(p => p.Hosts)
                    .HasForeignKey(d => d.Maintenanceid)
                    .HasConstraintName("c_hosts_2");

                entity.HasOne(d => d.ProxyHost)
                    .WithMany(p => p.InverseProxyHost)
                    .HasForeignKey(d => d.ProxyHostid)
                    .HasConstraintName("c_hosts_1");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.InverseTemplate)
                    .HasForeignKey(d => d.Templateid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_hosts_3");
            });

            modelBuilder.Entity<HostDiscovery>(entity =>
            {
                entity.HasKey(e => e.Hostid)
                    .HasName("PRIMARY");

                entity.ToTable("host_discovery");

                entity.HasIndex(e => e.ParentHostid, "c_host_discovery_2");

                entity.HasIndex(e => e.ParentItemid, "c_host_discovery_3");

                entity.Property(e => e.Hostid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("hostid");

                entity.Property(e => e.Host)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("host")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Lastcheck)
                    .HasColumnType("int(11)")
                    .HasColumnName("lastcheck");

                entity.Property(e => e.ParentHostid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("parent_hostid");

                entity.Property(e => e.ParentItemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("parent_itemid");

                entity.Property(e => e.TsDelete)
                    .HasColumnType("int(11)")
                    .HasColumnName("ts_delete");

                entity.HasOne(d => d.HostNavigation)
                    .WithOne(p => p.HostDiscoveryHostNavigation)
                    .HasForeignKey<HostDiscovery>(d => d.Hostid)
                    .HasConstraintName("c_host_discovery_1");

                entity.HasOne(d => d.ParentHost)
                    .WithMany(p => p.HostDiscoveryParentHosts)
                    .HasForeignKey(d => d.ParentHostid)
                    .HasConstraintName("c_host_discovery_2");

                entity.HasOne(d => d.ParentItem)
                    .WithMany(p => p.HostDiscoveries)
                    .HasForeignKey(d => d.ParentItemid)
                    .HasConstraintName("c_host_discovery_3");
            });

            modelBuilder.Entity<HostInventory>(entity =>
            {
                entity.HasKey(e => e.Hostid)
                    .HasName("PRIMARY");

                entity.ToTable("host_inventory");

                entity.Property(e => e.Hostid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("hostid");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("alias")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.AssetTag)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("asset_tag")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Chassis)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("chassis")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("contact");

                entity.Property(e => e.ContractNumber)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("contract_number")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.DateHwDecomm)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("date_hw_decomm")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.DateHwExpiry)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("date_hw_expiry")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.DateHwInstall)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("date_hw_install")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.DateHwPurchase)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("date_hw_purchase")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.DeploymentStatus)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("deployment_status")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Hardware)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("hardware")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.HardwareFull)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("hardware_full");

                entity.Property(e => e.HostNetmask)
                    .IsRequired()
                    .HasMaxLength(39)
                    .HasColumnName("host_netmask")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.HostNetworks)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("host_networks");

                entity.Property(e => e.HostRouter)
                    .IsRequired()
                    .HasMaxLength(39)
                    .HasColumnName("host_router")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.HwArch)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("hw_arch")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.InstallerName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("installer_name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.InventoryMode)
                    .HasColumnType("int(11)")
                    .HasColumnName("inventory_mode");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("location");

                entity.Property(e => e.LocationLat)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("location_lat")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LocationLon)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("location_lon")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MacaddressA)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("macaddress_a")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MacaddressB)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("macaddress_b")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("model")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("notes");

                entity.Property(e => e.OobIp)
                    .IsRequired()
                    .HasMaxLength(39)
                    .HasColumnName("oob_ip")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.OobNetmask)
                    .IsRequired()
                    .HasMaxLength(39)
                    .HasColumnName("oob_netmask")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.OobRouter)
                    .IsRequired()
                    .HasMaxLength(39)
                    .HasColumnName("oob_router")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Os)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("os")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.OsFull)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("os_full")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.OsShort)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("os_short")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Poc1Cell)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("poc_1_cell")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Poc1Email)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("poc_1_email")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Poc1Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("poc_1_name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Poc1Notes)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("poc_1_notes");

                entity.Property(e => e.Poc1PhoneA)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("poc_1_phone_a")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Poc1PhoneB)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("poc_1_phone_b")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Poc1Screen)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("poc_1_screen")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Poc2Cell)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("poc_2_cell")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Poc2Email)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("poc_2_email")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Poc2Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("poc_2_name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Poc2Notes)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("poc_2_notes");

                entity.Property(e => e.Poc2PhoneA)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("poc_2_phone_a")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Poc2PhoneB)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("poc_2_phone_b")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Poc2Screen)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("poc_2_screen")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SerialnoA)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("serialno_a")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SerialnoB)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("serialno_b")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SiteAddressA)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("site_address_a")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SiteAddressB)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("site_address_b")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SiteAddressC)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("site_address_c")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SiteCity)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("site_city")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SiteCountry)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("site_country")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SiteNotes)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("site_notes");

                entity.Property(e => e.SiteRack)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("site_rack")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SiteState)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("site_state")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SiteZip)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("site_zip")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Software)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("software")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SoftwareAppA)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("software_app_a")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SoftwareAppB)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("software_app_b")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SoftwareAppC)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("software_app_c")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SoftwareAppD)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("software_app_d")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SoftwareAppE)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("software_app_e")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SoftwareFull)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("software_full");

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("tag")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("type")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TypeFull)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("type_full")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UrlA)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("url_a")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UrlB)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("url_b")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UrlC)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("url_c")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Vendor)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("vendor")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Host)
                    .WithOne(p => p.HostInventory)
                    .HasForeignKey<HostInventory>(d => d.Hostid)
                    .HasConstraintName("c_host_inventory_1");
            });

            modelBuilder.Entity<HostTag>(entity =>
            {
                entity.ToTable("host_tag");

                entity.HasIndex(e => e.Hostid, "host_tag_1");

                entity.Property(e => e.Hosttagid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("hosttagid");

                entity.Property(e => e.Hostid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("hostid");

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("tag")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Host)
                    .WithMany(p => p.HostTags)
                    .HasForeignKey(d => d.Hostid)
                    .HasConstraintName("c_host_tag_1");
            });

            modelBuilder.Entity<Hostmacro>(entity =>
            {
                entity.ToTable("hostmacro");

                entity.HasIndex(e => new { e.Hostid, e.Macro }, "hostmacro_1")
                    .IsUnique();

                entity.Property(e => e.Hostmacroid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("hostmacroid");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Hostid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("hostid");

                entity.Property(e => e.Macro)
                    .IsRequired()
                    .HasColumnName("macro")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Host)
                    .WithMany(p => p.Hostmacros)
                    .HasForeignKey(d => d.Hostid)
                    .HasConstraintName("c_hostmacro_1");
            });

            modelBuilder.Entity<HostsGroup>(entity =>
            {
                entity.HasKey(e => e.Hostgroupid)
                    .HasName("PRIMARY");

                entity.ToTable("hosts_groups");

                entity.HasIndex(e => new { e.Hostid, e.Groupid }, "hosts_groups_1")
                    .IsUnique();

                entity.HasIndex(e => e.Groupid, "hosts_groups_2");

                entity.Property(e => e.Hostgroupid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("hostgroupid");

                entity.Property(e => e.Groupid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("groupid");

                entity.Property(e => e.Hostid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("hostid");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.HostsGroups)
                    .HasForeignKey(d => d.Groupid)
                    .HasConstraintName("c_hosts_groups_2");

                entity.HasOne(d => d.Host)
                    .WithMany(p => p.HostsGroups)
                    .HasForeignKey(d => d.Hostid)
                    .HasConstraintName("c_hosts_groups_1");
            });

            modelBuilder.Entity<HostsTemplate>(entity =>
            {
                entity.HasKey(e => e.Hosttemplateid)
                    .HasName("PRIMARY");

                entity.ToTable("hosts_templates");

                entity.HasIndex(e => new { e.Hostid, e.Templateid }, "hosts_templates_1")
                    .IsUnique();

                entity.HasIndex(e => e.Templateid, "hosts_templates_2");

                entity.Property(e => e.Hosttemplateid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("hosttemplateid");

                entity.Property(e => e.Hostid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("hostid");

                entity.Property(e => e.Templateid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("templateid");

                entity.HasOne(d => d.Host)
                    .WithMany(p => p.HostsTemplateHosts)
                    .HasForeignKey(d => d.Hostid)
                    .HasConstraintName("c_hosts_templates_1");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.HostsTemplateTemplates)
                    .HasForeignKey(d => d.Templateid)
                    .HasConstraintName("c_hosts_templates_2");
            });

            modelBuilder.Entity<Housekeeper>(entity =>
            {
                entity.ToTable("housekeeper");

                entity.Property(e => e.Housekeeperid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("housekeeperid");

                entity.Property(e => e.Field)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("field")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Tablename)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("tablename")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Value)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Hstgrp>(entity =>
            {
                entity.HasKey(e => e.Groupid)
                    .HasName("PRIMARY");

                entity.ToTable("hstgrp");

                entity.HasIndex(e => e.Name, "hstgrp_1");

                entity.Property(e => e.Groupid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("groupid");

                entity.Property(e => e.Flags)
                    .HasColumnType("int(11)")
                    .HasColumnName("flags");

                entity.Property(e => e.Internal)
                    .HasColumnType("int(11)")
                    .HasColumnName("internal");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Httpstep>(entity =>
            {
                entity.ToTable("httpstep");

                entity.HasIndex(e => e.Httptestid, "httpstep_1");

                entity.Property(e => e.Httpstepid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("httpstepid");

                entity.Property(e => e.FollowRedirects)
                    .HasColumnType("int(11)")
                    .HasColumnName("follow_redirects")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Httptestid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("httptestid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.No)
                    .HasColumnType("int(11)")
                    .HasColumnName("no");

                entity.Property(e => e.PostType)
                    .HasColumnType("int(11)")
                    .HasColumnName("post_type");

                entity.Property(e => e.Posts)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("posts");

                entity.Property(e => e.Required)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("required")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.RetrieveMode)
                    .HasColumnType("int(11)")
                    .HasColumnName("retrieve_mode");

                entity.Property(e => e.StatusCodes)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("status_codes")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Timeout)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("timeout")
                    .HasDefaultValueSql("'15s'");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("url")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Httptest)
                    .WithMany(p => p.Httpsteps)
                    .HasForeignKey(d => d.Httptestid)
                    .HasConstraintName("c_httpstep_1");
            });

            modelBuilder.Entity<HttpstepField>(entity =>
            {
                entity.ToTable("httpstep_field");

                entity.HasIndex(e => e.Httpstepid, "httpstep_field_1");

                entity.Property(e => e.HttpstepFieldid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("httpstep_fieldid");

                entity.Property(e => e.Httpstepid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("httpstepid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("value");

                entity.HasOne(d => d.Httpstep)
                    .WithMany(p => p.HttpstepFields)
                    .HasForeignKey(d => d.Httpstepid)
                    .HasConstraintName("c_httpstep_field_1");
            });

            modelBuilder.Entity<Httpstepitem>(entity =>
            {
                entity.ToTable("httpstepitem");

                entity.HasIndex(e => new { e.Httpstepid, e.Itemid }, "httpstepitem_1")
                    .IsUnique();

                entity.HasIndex(e => e.Itemid, "httpstepitem_2");

                entity.Property(e => e.Httpstepitemid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("httpstepitemid");

                entity.Property(e => e.Httpstepid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("httpstepid");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.HasOne(d => d.Httpstep)
                    .WithMany(p => p.Httpstepitems)
                    .HasForeignKey(d => d.Httpstepid)
                    .HasConstraintName("c_httpstepitem_1");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Httpstepitems)
                    .HasForeignKey(d => d.Itemid)
                    .HasConstraintName("c_httpstepitem_2");
            });

            modelBuilder.Entity<Httptest>(entity =>
            {
                entity.ToTable("httptest");

                entity.HasIndex(e => e.Applicationid, "httptest_1");

                entity.HasIndex(e => new { e.Hostid, e.Name }, "httptest_2")
                    .IsUnique();

                entity.HasIndex(e => e.Status, "httptest_3");

                entity.HasIndex(e => e.Templateid, "httptest_4");

                entity.Property(e => e.Httptestid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("httptestid");

                entity.Property(e => e.Agent)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("agent")
                    .HasDefaultValueSql("'Zabbix'");

                entity.Property(e => e.Applicationid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("applicationid");

                entity.Property(e => e.Authentication)
                    .HasColumnType("int(11)")
                    .HasColumnName("authentication");

                entity.Property(e => e.Delay)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("delay")
                    .HasDefaultValueSql("'1m'");

                entity.Property(e => e.Hostid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("hostid");

                entity.Property(e => e.HttpPassword)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("http_password")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.HttpProxy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("http_proxy")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.HttpUser)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("http_user")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Nextcheck)
                    .HasColumnType("int(11)")
                    .HasColumnName("nextcheck");

                entity.Property(e => e.Retries)
                    .HasColumnType("int(11)")
                    .HasColumnName("retries")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.SslCertFile)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("ssl_cert_file")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SslKeyFile)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("ssl_key_file")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SslKeyPassword)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("ssl_key_password")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.Property(e => e.Templateid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("templateid");

                entity.Property(e => e.VerifyHost)
                    .HasColumnType("int(11)")
                    .HasColumnName("verify_host");

                entity.Property(e => e.VerifyPeer)
                    .HasColumnType("int(11)")
                    .HasColumnName("verify_peer");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Httptests)
                    .HasForeignKey(d => d.Applicationid)
                    .HasConstraintName("c_httptest_1");

                entity.HasOne(d => d.Host)
                    .WithMany(p => p.Httptests)
                    .HasForeignKey(d => d.Hostid)
                    .HasConstraintName("c_httptest_2");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.InverseTemplate)
                    .HasForeignKey(d => d.Templateid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_httptest_3");
            });

            modelBuilder.Entity<HttptestField>(entity =>
            {
                entity.ToTable("httptest_field");

                entity.HasIndex(e => e.Httptestid, "httptest_field_1");

                entity.Property(e => e.HttptestFieldid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("httptest_fieldid");

                entity.Property(e => e.Httptestid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("httptestid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("value");

                entity.HasOne(d => d.Httptest)
                    .WithMany(p => p.HttptestFields)
                    .HasForeignKey(d => d.Httptestid)
                    .HasConstraintName("c_httptest_field_1");
            });

            modelBuilder.Entity<Httptestitem>(entity =>
            {
                entity.ToTable("httptestitem");

                entity.HasIndex(e => new { e.Httptestid, e.Itemid }, "httptestitem_1")
                    .IsUnique();

                entity.HasIndex(e => e.Itemid, "httptestitem_2");

                entity.Property(e => e.Httptestitemid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("httptestitemid");

                entity.Property(e => e.Httptestid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("httptestid");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.HasOne(d => d.Httptest)
                    .WithMany(p => p.Httptestitems)
                    .HasForeignKey(d => d.Httptestid)
                    .HasConstraintName("c_httptestitem_1");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Httptestitems)
                    .HasForeignKey(d => d.Itemid)
                    .HasConstraintName("c_httptestitem_2");
            });

            modelBuilder.Entity<IconMap>(entity =>
            {
                entity.ToTable("icon_map");

                entity.HasIndex(e => e.Name, "icon_map_1")
                    .IsUnique();

                entity.HasIndex(e => e.DefaultIconid, "icon_map_2");

                entity.Property(e => e.Iconmapid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("iconmapid");

                entity.Property(e => e.DefaultIconid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("default_iconid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.DefaultIcon)
                    .WithMany(p => p.IconMaps)
                    .HasForeignKey(d => d.DefaultIconid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("c_icon_map_1");
            });

            modelBuilder.Entity<IconMapping>(entity =>
            {
                entity.ToTable("icon_mapping");

                entity.HasIndex(e => e.Iconmapid, "icon_mapping_1");

                entity.HasIndex(e => e.Iconid, "icon_mapping_2");

                entity.Property(e => e.Iconmappingid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("iconmappingid");

                entity.Property(e => e.Expression)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("expression")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Iconid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("iconid");

                entity.Property(e => e.Iconmapid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("iconmapid");

                entity.Property(e => e.InventoryLink)
                    .HasColumnType("int(11)")
                    .HasColumnName("inventory_link");

                entity.Property(e => e.Sortorder)
                    .HasColumnType("int(11)")
                    .HasColumnName("sortorder");

                entity.HasOne(d => d.Icon)
                    .WithMany(p => p.IconMappings)
                    .HasForeignKey(d => d.Iconid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("c_icon_mapping_2");

                entity.HasOne(d => d.Iconmap)
                    .WithMany(p => p.IconMappings)
                    .HasForeignKey(d => d.Iconmapid)
                    .HasConstraintName("c_icon_mapping_1");
            });

            modelBuilder.Entity<Id>(entity =>
            {
                entity.HasKey(e => new { e.TableName, e.FieldName })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("ids");

                entity.Property(e => e.TableName)
                    .HasMaxLength(64)
                    .HasColumnName("table_name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.FieldName)
                    .HasMaxLength(64)
                    .HasColumnName("field_name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Nextid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("nextid");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("images");

                entity.HasIndex(e => e.Name, "images_1")
                    .IsUnique();

                entity.Property(e => e.Imageid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("imageid");

                entity.Property(e => e.Image1)
                    .IsRequired()
                    .HasColumnName("image");

                entity.Property(e => e.Imagetype)
                    .HasColumnType("int(11)")
                    .HasColumnName("imagetype");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Interface>(entity =>
            {
                entity.ToTable("interface");

                entity.HasIndex(e => new { e.Hostid, e.Type }, "interface_1");

                entity.HasIndex(e => new { e.Ip, e.Dns }, "interface_2");

                entity.Property(e => e.Interfaceid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("interfaceid");

                entity.Property(e => e.Dns)
                    .IsRequired()
                    .HasColumnName("dns")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Hostid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("hostid");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("ip")
                    .HasDefaultValueSql("'127.0.0.1'");

                entity.Property(e => e.Main)
                    .HasColumnType("int(11)")
                    .HasColumnName("main");

                entity.Property(e => e.Port)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("port")
                    .HasDefaultValueSql("'10050'");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Useip)
                    .HasColumnType("int(11)")
                    .HasColumnName("useip")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.Host)
                    .WithMany(p => p.Interfaces)
                    .HasForeignKey(d => d.Hostid)
                    .HasConstraintName("c_interface_1");
            });

            modelBuilder.Entity<InterfaceDiscovery>(entity =>
            {
                entity.HasKey(e => e.Interfaceid)
                    .HasName("PRIMARY");

                entity.ToTable("interface_discovery");

                entity.HasIndex(e => e.ParentInterfaceid, "c_interface_discovery_2");

                entity.Property(e => e.Interfaceid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("interfaceid");

                entity.Property(e => e.ParentInterfaceid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("parent_interfaceid");

                entity.HasOne(d => d.Interface)
                    .WithOne(p => p.InterfaceDiscoveryInterface)
                    .HasForeignKey<InterfaceDiscovery>(d => d.Interfaceid)
                    .HasConstraintName("c_interface_discovery_1");

                entity.HasOne(d => d.ParentInterface)
                    .WithMany(p => p.InterfaceDiscoveryParentInterfaces)
                    .HasForeignKey(d => d.ParentInterfaceid)
                    .HasConstraintName("c_interface_discovery_2");
            });

            modelBuilder.Entity<InterfaceSnmp>(entity =>
            {
                entity.HasKey(e => e.Interfaceid)
                    .HasName("PRIMARY");

                entity.ToTable("interface_snmp");

                entity.Property(e => e.Interfaceid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("interfaceid");

                entity.Property(e => e.Authpassphrase)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("authpassphrase")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Authprotocol)
                    .HasColumnType("int(11)")
                    .HasColumnName("authprotocol");

                entity.Property(e => e.Bulk)
                    .HasColumnType("int(11)")
                    .HasColumnName("bulk")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Community)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("community")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Contextname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("contextname")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Privpassphrase)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("privpassphrase")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Privprotocol)
                    .HasColumnType("int(11)")
                    .HasColumnName("privprotocol");

                entity.Property(e => e.Securitylevel)
                    .HasColumnType("int(11)")
                    .HasColumnName("securitylevel");

                entity.Property(e => e.Securityname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("securityname")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Version)
                    .HasColumnType("int(11)")
                    .HasColumnName("version")
                    .HasDefaultValueSql("'2'");

                entity.HasOne(d => d.Interface)
                    .WithOne(p => p.InterfaceSnmp)
                    .HasForeignKey<InterfaceSnmp>(d => d.Interfaceid)
                    .HasConstraintName("c_interface_snmp_1");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("items");

                entity.HasIndex(e => new { e.Hostid, e.Key }, "items_1")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 1021 });

                entity.HasIndex(e => e.Status, "items_3");

                entity.HasIndex(e => e.Templateid, "items_4");

                entity.HasIndex(e => e.Valuemapid, "items_5");

                entity.HasIndex(e => e.Interfaceid, "items_6");

                entity.HasIndex(e => e.MasterItemid, "items_7");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("itemid");

                entity.Property(e => e.AllowTraps)
                    .HasColumnType("int(11)")
                    .HasColumnName("allow_traps");

                entity.Property(e => e.Authtype)
                    .HasColumnType("int(11)")
                    .HasColumnName("authtype");

                entity.Property(e => e.Delay)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("delay")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Discover)
                    .HasColumnType("int(11)")
                    .HasColumnName("discover");

                entity.Property(e => e.Evaltype)
                    .HasColumnType("int(11)")
                    .HasColumnName("evaltype");

                entity.Property(e => e.Flags)
                    .HasColumnType("int(11)")
                    .HasColumnName("flags");

                entity.Property(e => e.FollowRedirects)
                    .HasColumnType("int(11)")
                    .HasColumnName("follow_redirects")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Formula)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("formula")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Headers)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("headers");

                entity.Property(e => e.History)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("history")
                    .HasDefaultValueSql("'90d'");

                entity.Property(e => e.Hostid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("hostid");

                entity.Property(e => e.HttpProxy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("http_proxy")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Interfaceid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("interfaceid");

                entity.Property(e => e.InventoryLink)
                    .HasColumnType("int(11)")
                    .HasColumnName("inventory_link");

                entity.Property(e => e.IpmiSensor)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("ipmi_sensor")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.JmxEndpoint)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("jmx_endpoint")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("key_")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Lifetime)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("lifetime")
                    .HasDefaultValueSql("'30d'");

                entity.Property(e => e.Logtimefmt)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("logtimefmt")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MasterItemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("master_itemid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.OutputFormat)
                    .HasColumnType("int(11)")
                    .HasColumnName("output_format");

                entity.Property(e => e.Params)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("params");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("password")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PostType)
                    .HasColumnType("int(11)")
                    .HasColumnName("post_type");

                entity.Property(e => e.Posts)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("posts");

                entity.Property(e => e.Privatekey)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("privatekey")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Publickey)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("publickey")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.QueryFields)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("query_fields")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.RequestMethod)
                    .HasColumnType("int(11)")
                    .HasColumnName("request_method");

                entity.Property(e => e.RetrieveMode)
                    .HasColumnType("int(11)")
                    .HasColumnName("retrieve_mode");

                entity.Property(e => e.SnmpOid)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("snmp_oid")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SslCertFile)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("ssl_cert_file")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SslKeyFile)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("ssl_key_file")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SslKeyPassword)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("ssl_key_password")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.Property(e => e.StatusCodes)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("status_codes")
                    .HasDefaultValueSql("'200'");

                entity.Property(e => e.Templateid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("templateid");

                entity.Property(e => e.Timeout)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("timeout")
                    .HasDefaultValueSql("'3s'");

                entity.Property(e => e.TrapperHosts)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("trapper_hosts")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Trends)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("trends")
                    .HasDefaultValueSql("'365d'");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.Property(e => e.Units)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("units")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("url")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("username")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ValueType)
                    .HasColumnType("int(11)")
                    .HasColumnName("value_type");

                entity.Property(e => e.Valuemapid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("valuemapid");

                entity.Property(e => e.VerifyHost)
                    .HasColumnType("int(11)")
                    .HasColumnName("verify_host");

                entity.Property(e => e.VerifyPeer)
                    .HasColumnType("int(11)")
                    .HasColumnName("verify_peer");

                entity.HasOne(d => d.Host)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Hostid)
                    .HasConstraintName("c_items_1");

                entity.HasOne(d => d.Interface)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Interfaceid)
                    .HasConstraintName("c_items_4");

                entity.HasOne(d => d.MasterItem)
                    .WithMany(p => p.InverseMasterItem)
                    .HasForeignKey(d => d.MasterItemid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_items_5");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.InverseTemplate)
                    .HasForeignKey(d => d.Templateid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_items_2");

                entity.HasOne(d => d.Valuemap)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Valuemapid)
                    .HasConstraintName("c_items_3");
            });

            modelBuilder.Entity<ItemApplicationPrototype>(entity =>
            {
                entity.ToTable("item_application_prototype");

                entity.HasIndex(e => new { e.ApplicationPrototypeid, e.Itemid }, "item_application_prototype_1")
                    .IsUnique();

                entity.HasIndex(e => e.Itemid, "item_application_prototype_2");

                entity.Property(e => e.ItemApplicationPrototypeid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("item_application_prototypeid");

                entity.Property(e => e.ApplicationPrototypeid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("application_prototypeid");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.HasOne(d => d.ApplicationPrototype)
                    .WithMany(p => p.ItemApplicationPrototypes)
                    .HasForeignKey(d => d.ApplicationPrototypeid)
                    .HasConstraintName("c_item_application_prototype_1");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemApplicationPrototypes)
                    .HasForeignKey(d => d.Itemid)
                    .HasConstraintName("c_item_application_prototype_2");
            });

            modelBuilder.Entity<ItemCondition>(entity =>
            {
                entity.ToTable("item_condition");

                entity.HasIndex(e => e.Itemid, "item_condition_1");

                entity.Property(e => e.ItemConditionid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("item_conditionid");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.Property(e => e.Macro)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("macro")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Operator)
                    .HasColumnType("int(11)")
                    .HasColumnName("operator")
                    .HasDefaultValueSql("'8'");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemConditions)
                    .HasForeignKey(d => d.Itemid)
                    .HasConstraintName("c_item_condition_1");
            });

            modelBuilder.Entity<ItemDiscovery>(entity =>
            {
                entity.ToTable("item_discovery");

                entity.HasIndex(e => new { e.Itemid, e.ParentItemid }, "item_discovery_1")
                    .IsUnique();

                entity.HasIndex(e => e.ParentItemid, "item_discovery_2");

                entity.Property(e => e.Itemdiscoveryid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("itemdiscoveryid");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("key_")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Lastcheck)
                    .HasColumnType("int(11)")
                    .HasColumnName("lastcheck");

                entity.Property(e => e.ParentItemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("parent_itemid");

                entity.Property(e => e.TsDelete)
                    .HasColumnType("int(11)")
                    .HasColumnName("ts_delete");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemDiscoveryItems)
                    .HasForeignKey(d => d.Itemid)
                    .HasConstraintName("c_item_discovery_1");

                entity.HasOne(d => d.ParentItem)
                    .WithMany(p => p.ItemDiscoveryParentItems)
                    .HasForeignKey(d => d.ParentItemid)
                    .HasConstraintName("c_item_discovery_2");
            });

            modelBuilder.Entity<ItemParameter>(entity =>
            {
                entity.ToTable("item_parameter");

                entity.HasIndex(e => e.Itemid, "item_parameter_1");

                entity.Property(e => e.ItemParameterid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("item_parameterid");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemParameters)
                    .HasForeignKey(d => d.Itemid)
                    .HasConstraintName("c_item_parameter_1");
            });

            modelBuilder.Entity<ItemPreproc>(entity =>
            {
                entity.ToTable("item_preproc");

                entity.HasIndex(e => new { e.Itemid, e.Step }, "item_preproc_1");

                entity.Property(e => e.ItemPreprocid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("item_preprocid");

                entity.Property(e => e.ErrorHandler)
                    .HasColumnType("int(11)")
                    .HasColumnName("error_handler");

                entity.Property(e => e.ErrorHandlerParams)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("error_handler_params")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.Property(e => e.Params)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("params");

                entity.Property(e => e.Step)
                    .HasColumnType("int(11)")
                    .HasColumnName("step");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemPreprocs)
                    .HasForeignKey(d => d.Itemid)
                    .HasConstraintName("c_item_preproc_1");
            });

            modelBuilder.Entity<ItemRtdatum>(entity =>
            {
                entity.HasKey(e => e.Itemid)
                    .HasName("PRIMARY");

                entity.ToTable("item_rtdata");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("itemid");

                entity.Property(e => e.Error)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("error")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Lastlogsize)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("lastlogsize");

                entity.Property(e => e.Mtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("mtime");

                entity.Property(e => e.State)
                    .HasColumnType("int(11)")
                    .HasColumnName("state");

                entity.HasOne(d => d.Item)
                    .WithOne(p => p.ItemRtdatum)
                    .HasForeignKey<ItemRtdatum>(d => d.Itemid)
                    .HasConstraintName("c_item_rtdata_1");
            });

            modelBuilder.Entity<ItemsApplication>(entity =>
            {
                entity.HasKey(e => e.Itemappid)
                    .HasName("PRIMARY");

                entity.ToTable("items_applications");

                entity.HasIndex(e => new { e.Applicationid, e.Itemid }, "items_applications_1")
                    .IsUnique();

                entity.HasIndex(e => e.Itemid, "items_applications_2");

                entity.Property(e => e.Itemappid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("itemappid");

                entity.Property(e => e.Applicationid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("applicationid");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.ItemsApplications)
                    .HasForeignKey(d => d.Applicationid)
                    .HasConstraintName("c_items_applications_1");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemsApplications)
                    .HasForeignKey(d => d.Itemid)
                    .HasConstraintName("c_items_applications_2");
            });

            modelBuilder.Entity<LldMacroPath>(entity =>
            {
                entity.ToTable("lld_macro_path");

                entity.HasIndex(e => new { e.Itemid, e.LldMacro }, "lld_macro_path_1")
                    .IsUnique();

                entity.Property(e => e.LldMacroPathid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("lld_macro_pathid");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.Property(e => e.LldMacro)
                    .IsRequired()
                    .HasColumnName("lld_macro")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("path")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.LldMacroPaths)
                    .HasForeignKey(d => d.Itemid)
                    .HasConstraintName("c_lld_macro_path_1");
            });

            modelBuilder.Entity<LldOverride>(entity =>
            {
                entity.ToTable("lld_override");

                entity.HasIndex(e => new { e.Itemid, e.Name }, "lld_override_1")
                    .IsUnique();

                entity.Property(e => e.LldOverrideid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("lld_overrideid");

                entity.Property(e => e.Evaltype)
                    .HasColumnType("int(11)")
                    .HasColumnName("evaltype");

                entity.Property(e => e.Formula)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("formula")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Step)
                    .HasColumnType("int(11)")
                    .HasColumnName("step");

                entity.Property(e => e.Stop)
                    .HasColumnType("int(11)")
                    .HasColumnName("stop");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.LldOverrides)
                    .HasForeignKey(d => d.Itemid)
                    .HasConstraintName("c_lld_override_1");
            });

            modelBuilder.Entity<LldOverrideCondition>(entity =>
            {
                entity.ToTable("lld_override_condition");

                entity.HasIndex(e => e.LldOverrideid, "lld_override_condition_1");

                entity.Property(e => e.LldOverrideConditionid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("lld_override_conditionid");

                entity.Property(e => e.LldOverrideid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("lld_overrideid");

                entity.Property(e => e.Macro)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("macro")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Operator)
                    .HasColumnType("int(11)")
                    .HasColumnName("operator")
                    .HasDefaultValueSql("'8'");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.LldOverride)
                    .WithMany(p => p.LldOverrideConditions)
                    .HasForeignKey(d => d.LldOverrideid)
                    .HasConstraintName("c_lld_override_condition_1");
            });

            modelBuilder.Entity<LldOverrideOpdiscover>(entity =>
            {
                entity.HasKey(e => e.LldOverrideOperationid)
                    .HasName("PRIMARY");

                entity.ToTable("lld_override_opdiscover");

                entity.Property(e => e.LldOverrideOperationid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("lld_override_operationid");

                entity.Property(e => e.Discover)
                    .HasColumnType("int(11)")
                    .HasColumnName("discover");

                entity.HasOne(d => d.LldOverrideOperation)
                    .WithOne(p => p.LldOverrideOpdiscover)
                    .HasForeignKey<LldOverrideOpdiscover>(d => d.LldOverrideOperationid)
                    .HasConstraintName("c_lld_override_opdiscover_1");
            });

            modelBuilder.Entity<LldOverrideOperation>(entity =>
            {
                entity.ToTable("lld_override_operation");

                entity.HasIndex(e => e.LldOverrideid, "lld_override_operation_1");

                entity.Property(e => e.LldOverrideOperationid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("lld_override_operationid");

                entity.Property(e => e.LldOverrideid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("lld_overrideid");

                entity.Property(e => e.Operationobject)
                    .HasColumnType("int(11)")
                    .HasColumnName("operationobject");

                entity.Property(e => e.Operator)
                    .HasColumnType("int(11)")
                    .HasColumnName("operator");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.LldOverride)
                    .WithMany(p => p.LldOverrideOperations)
                    .HasForeignKey(d => d.LldOverrideid)
                    .HasConstraintName("c_lld_override_operation_1");
            });

            modelBuilder.Entity<LldOverrideOphistory>(entity =>
            {
                entity.HasKey(e => e.LldOverrideOperationid)
                    .HasName("PRIMARY");

                entity.ToTable("lld_override_ophistory");

                entity.Property(e => e.LldOverrideOperationid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("lld_override_operationid");

                entity.Property(e => e.History)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("history")
                    .HasDefaultValueSql("'90d'");

                entity.HasOne(d => d.LldOverrideOperation)
                    .WithOne(p => p.LldOverrideOphistory)
                    .HasForeignKey<LldOverrideOphistory>(d => d.LldOverrideOperationid)
                    .HasConstraintName("c_lld_override_ophistory_1");
            });

            modelBuilder.Entity<LldOverrideOpinventory>(entity =>
            {
                entity.HasKey(e => e.LldOverrideOperationid)
                    .HasName("PRIMARY");

                entity.ToTable("lld_override_opinventory");

                entity.Property(e => e.LldOverrideOperationid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("lld_override_operationid");

                entity.Property(e => e.InventoryMode)
                    .HasColumnType("int(11)")
                    .HasColumnName("inventory_mode");

                entity.HasOne(d => d.LldOverrideOperation)
                    .WithOne(p => p.LldOverrideOpinventory)
                    .HasForeignKey<LldOverrideOpinventory>(d => d.LldOverrideOperationid)
                    .HasConstraintName("c_lld_override_opinventory_1");
            });

            modelBuilder.Entity<LldOverrideOpperiod>(entity =>
            {
                entity.HasKey(e => e.LldOverrideOperationid)
                    .HasName("PRIMARY");

                entity.ToTable("lld_override_opperiod");

                entity.Property(e => e.LldOverrideOperationid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("lld_override_operationid");

                entity.Property(e => e.Delay)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("delay")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.LldOverrideOperation)
                    .WithOne(p => p.LldOverrideOpperiod)
                    .HasForeignKey<LldOverrideOpperiod>(d => d.LldOverrideOperationid)
                    .HasConstraintName("c_lld_override_opperiod_1");
            });

            modelBuilder.Entity<LldOverrideOpseverity>(entity =>
            {
                entity.HasKey(e => e.LldOverrideOperationid)
                    .HasName("PRIMARY");

                entity.ToTable("lld_override_opseverity");

                entity.Property(e => e.LldOverrideOperationid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("lld_override_operationid");

                entity.Property(e => e.Severity)
                    .HasColumnType("int(11)")
                    .HasColumnName("severity");

                entity.HasOne(d => d.LldOverrideOperation)
                    .WithOne(p => p.LldOverrideOpseverity)
                    .HasForeignKey<LldOverrideOpseverity>(d => d.LldOverrideOperationid)
                    .HasConstraintName("c_lld_override_opseverity_1");
            });

            modelBuilder.Entity<LldOverrideOpstatus>(entity =>
            {
                entity.HasKey(e => e.LldOverrideOperationid)
                    .HasName("PRIMARY");

                entity.ToTable("lld_override_opstatus");

                entity.Property(e => e.LldOverrideOperationid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("lld_override_operationid");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.HasOne(d => d.LldOverrideOperation)
                    .WithOne(p => p.LldOverrideOpstatus)
                    .HasForeignKey<LldOverrideOpstatus>(d => d.LldOverrideOperationid)
                    .HasConstraintName("c_lld_override_opstatus_1");
            });

            modelBuilder.Entity<LldOverrideOptag>(entity =>
            {
                entity.ToTable("lld_override_optag");

                entity.HasIndex(e => e.LldOverrideOperationid, "lld_override_optag_1");

                entity.Property(e => e.LldOverrideOptagid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("lld_override_optagid");

                entity.Property(e => e.LldOverrideOperationid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("lld_override_operationid");

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("tag")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.LldOverrideOperation)
                    .WithMany(p => p.LldOverrideOptags)
                    .HasForeignKey(d => d.LldOverrideOperationid)
                    .HasConstraintName("c_lld_override_optag_1");
            });

            modelBuilder.Entity<LldOverrideOptemplate>(entity =>
            {
                entity.ToTable("lld_override_optemplate");

                entity.HasIndex(e => new { e.LldOverrideOperationid, e.Templateid }, "lld_override_optemplate_1")
                    .IsUnique();

                entity.HasIndex(e => e.Templateid, "lld_override_optemplate_2");

                entity.Property(e => e.LldOverrideOptemplateid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("lld_override_optemplateid");

                entity.Property(e => e.LldOverrideOperationid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("lld_override_operationid");

                entity.Property(e => e.Templateid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("templateid");

                entity.HasOne(d => d.LldOverrideOperation)
                    .WithMany(p => p.LldOverrideOptemplates)
                    .HasForeignKey(d => d.LldOverrideOperationid)
                    .HasConstraintName("c_lld_override_optemplate_1");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.LldOverrideOptemplates)
                    .HasForeignKey(d => d.Templateid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("c_lld_override_optemplate_2");
            });

            modelBuilder.Entity<LldOverrideOptrend>(entity =>
            {
                entity.HasKey(e => e.LldOverrideOperationid)
                    .HasName("PRIMARY");

                entity.ToTable("lld_override_optrends");

                entity.Property(e => e.LldOverrideOperationid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("lld_override_operationid");

                entity.Property(e => e.Trends)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("trends")
                    .HasDefaultValueSql("'365d'");

                entity.HasOne(d => d.LldOverrideOperation)
                    .WithOne(p => p.LldOverrideOptrend)
                    .HasForeignKey<LldOverrideOptrend>(d => d.LldOverrideOperationid)
                    .HasConstraintName("c_lld_override_optrends_1");
            });

            modelBuilder.Entity<Maintenance>(entity =>
            {
                entity.ToTable("maintenances");

                entity.HasIndex(e => new { e.ActiveSince, e.ActiveTill }, "maintenances_1");

                entity.HasIndex(e => e.Name, "maintenances_2")
                    .IsUnique();

                entity.Property(e => e.Maintenanceid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("maintenanceid");

                entity.Property(e => e.ActiveSince)
                    .HasColumnType("int(11)")
                    .HasColumnName("active_since");

                entity.Property(e => e.ActiveTill)
                    .HasColumnType("int(11)")
                    .HasColumnName("active_till");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.MaintenanceType)
                    .HasColumnType("int(11)")
                    .HasColumnName("maintenance_type");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TagsEvaltype)
                    .HasColumnType("int(11)")
                    .HasColumnName("tags_evaltype");
            });

            modelBuilder.Entity<MaintenanceTag>(entity =>
            {
                entity.ToTable("maintenance_tag");

                entity.HasIndex(e => e.Maintenanceid, "maintenance_tag_1");

                entity.Property(e => e.Maintenancetagid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("maintenancetagid");

                entity.Property(e => e.Maintenanceid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("maintenanceid");

                entity.Property(e => e.Operator)
                    .HasColumnType("int(11)")
                    .HasColumnName("operator")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("tag")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Maintenance)
                    .WithMany(p => p.MaintenanceTags)
                    .HasForeignKey(d => d.Maintenanceid)
                    .HasConstraintName("c_maintenance_tag_1");
            });

            modelBuilder.Entity<MaintenancesGroup>(entity =>
            {
                entity.HasKey(e => e.MaintenanceGroupid)
                    .HasName("PRIMARY");

                entity.ToTable("maintenances_groups");

                entity.HasIndex(e => new { e.Maintenanceid, e.Groupid }, "maintenances_groups_1")
                    .IsUnique();

                entity.HasIndex(e => e.Groupid, "maintenances_groups_2");

                entity.Property(e => e.MaintenanceGroupid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("maintenance_groupid");

                entity.Property(e => e.Groupid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("groupid");

                entity.Property(e => e.Maintenanceid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("maintenanceid");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.MaintenancesGroups)
                    .HasForeignKey(d => d.Groupid)
                    .HasConstraintName("c_maintenances_groups_2");

                entity.HasOne(d => d.Maintenance)
                    .WithMany(p => p.MaintenancesGroups)
                    .HasForeignKey(d => d.Maintenanceid)
                    .HasConstraintName("c_maintenances_groups_1");
            });

            modelBuilder.Entity<MaintenancesHost>(entity =>
            {
                entity.HasKey(e => e.MaintenanceHostid)
                    .HasName("PRIMARY");

                entity.ToTable("maintenances_hosts");

                entity.HasIndex(e => new { e.Maintenanceid, e.Hostid }, "maintenances_hosts_1")
                    .IsUnique();

                entity.HasIndex(e => e.Hostid, "maintenances_hosts_2");

                entity.Property(e => e.MaintenanceHostid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("maintenance_hostid");

                entity.Property(e => e.Hostid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("hostid");

                entity.Property(e => e.Maintenanceid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("maintenanceid");

                entity.HasOne(d => d.Host)
                    .WithMany(p => p.MaintenancesHosts)
                    .HasForeignKey(d => d.Hostid)
                    .HasConstraintName("c_maintenances_hosts_2");

                entity.HasOne(d => d.Maintenance)
                    .WithMany(p => p.MaintenancesHosts)
                    .HasForeignKey(d => d.Maintenanceid)
                    .HasConstraintName("c_maintenances_hosts_1");
            });

            modelBuilder.Entity<MaintenancesWindow>(entity =>
            {
                entity.HasKey(e => e.MaintenanceTimeperiodid)
                    .HasName("PRIMARY");

                entity.ToTable("maintenances_windows");

                entity.HasIndex(e => new { e.Maintenanceid, e.Timeperiodid }, "maintenances_windows_1")
                    .IsUnique();

                entity.HasIndex(e => e.Timeperiodid, "maintenances_windows_2");

                entity.Property(e => e.MaintenanceTimeperiodid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("maintenance_timeperiodid");

                entity.Property(e => e.Maintenanceid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("maintenanceid");

                entity.Property(e => e.Timeperiodid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("timeperiodid");

                entity.HasOne(d => d.Maintenance)
                    .WithMany(p => p.MaintenancesWindows)
                    .HasForeignKey(d => d.Maintenanceid)
                    .HasConstraintName("c_maintenances_windows_1");

                entity.HasOne(d => d.Timeperiod)
                    .WithMany(p => p.MaintenancesWindows)
                    .HasForeignKey(d => d.Timeperiodid)
                    .HasConstraintName("c_maintenances_windows_2");
            });

            modelBuilder.Entity<Mapping>(entity =>
            {
                entity.ToTable("mappings");

                entity.HasIndex(e => e.Valuemapid, "mappings_1");

                entity.Property(e => e.Mappingid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("mappingid");

                entity.Property(e => e.Newvalue)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("newvalue")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Valuemapid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("valuemapid");

                entity.HasOne(d => d.Valuemap)
                    .WithMany(p => p.Mappings)
                    .HasForeignKey(d => d.Valuemapid)
                    .HasConstraintName("c_mappings_1");
            });

            modelBuilder.Entity<MediaType>(entity =>
            {
                entity.ToTable("media_type");

                entity.HasIndex(e => e.Name, "media_type_1")
                    .IsUnique();

                entity.Property(e => e.Mediatypeid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("mediatypeid");

                entity.Property(e => e.AttemptInterval)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("attempt_interval")
                    .HasDefaultValueSql("'10s'");

                entity.Property(e => e.ContentType)
                    .HasColumnType("int(11)")
                    .HasColumnName("content_type")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.EventMenuName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("event_menu_name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.EventMenuUrl)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("event_menu_url")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ExecParams)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("exec_params")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ExecPath)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("exec_path")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GsmModem)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("gsm_modem")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Maxattempts)
                    .HasColumnType("int(11)")
                    .HasColumnName("maxattempts")
                    .HasDefaultValueSql("'3'");

                entity.Property(e => e.Maxsessions)
                    .HasColumnType("int(11)")
                    .HasColumnName("maxsessions")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Passwd)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("passwd")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ProcessTags)
                    .HasColumnType("int(11)")
                    .HasColumnName("process_tags");

                entity.Property(e => e.Script)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("script");

                entity.Property(e => e.ShowEventMenu)
                    .HasColumnType("int(11)")
                    .HasColumnName("show_event_menu");

                entity.Property(e => e.SmtpAuthentication)
                    .HasColumnType("int(11)")
                    .HasColumnName("smtp_authentication");

                entity.Property(e => e.SmtpEmail)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("smtp_email")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SmtpHelo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("smtp_helo")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SmtpPort)
                    .HasColumnType("int(11)")
                    .HasColumnName("smtp_port")
                    .HasDefaultValueSql("'25'");

                entity.Property(e => e.SmtpSecurity)
                    .HasColumnType("int(11)")
                    .HasColumnName("smtp_security");

                entity.Property(e => e.SmtpServer)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("smtp_server")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SmtpVerifyHost)
                    .HasColumnType("int(11)")
                    .HasColumnName("smtp_verify_host");

                entity.Property(e => e.SmtpVerifyPeer)
                    .HasColumnType("int(11)")
                    .HasColumnName("smtp_verify_peer");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.Property(e => e.Timeout)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("timeout")
                    .HasDefaultValueSql("'30s'");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("username")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<MediaTypeMessage>(entity =>
            {
                entity.ToTable("media_type_message");

                entity.HasIndex(e => new { e.Mediatypeid, e.Eventsource, e.Recovery }, "media_type_message_1")
                    .IsUnique();

                entity.Property(e => e.MediatypeMessageid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("mediatype_messageid");

                entity.Property(e => e.Eventsource)
                    .HasColumnType("int(11)")
                    .HasColumnName("eventsource");

                entity.Property(e => e.Mediatypeid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("mediatypeid");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("message");

                entity.Property(e => e.Recovery)
                    .HasColumnType("int(11)")
                    .HasColumnName("recovery");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("subject")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Mediatype)
                    .WithMany(p => p.MediaTypeMessages)
                    .HasForeignKey(d => d.Mediatypeid)
                    .HasConstraintName("c_media_type_message_1");
            });

            modelBuilder.Entity<MediaTypeParam>(entity =>
            {
                entity.ToTable("media_type_param");

                entity.HasIndex(e => e.Mediatypeid, "media_type_param_1");

                entity.Property(e => e.MediatypeParamid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("mediatype_paramid");

                entity.Property(e => e.Mediatypeid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("mediatypeid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Mediatype)
                    .WithMany(p => p.MediaTypeParams)
                    .HasForeignKey(d => d.Mediatypeid)
                    .HasConstraintName("c_media_type_param_1");
            });

            modelBuilder.Entity<Medium>(entity =>
            {
                entity.HasKey(e => e.Mediaid)
                    .HasName("PRIMARY");

                entity.ToTable("media");

                entity.HasIndex(e => e.Userid, "media_1");

                entity.HasIndex(e => e.Mediatypeid, "media_2");

                entity.Property(e => e.Mediaid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("mediaid");

                entity.Property(e => e.Active)
                    .HasColumnType("int(11)")
                    .HasColumnName("active");

                entity.Property(e => e.Mediatypeid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("mediatypeid");

                entity.Property(e => e.Period)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("period")
                    .HasDefaultValueSql("'1-7,00:00-24:00'");

                entity.Property(e => e.Sendto)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("sendto")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Severity)
                    .HasColumnType("int(11)")
                    .HasColumnName("severity")
                    .HasDefaultValueSql("'63'");

                entity.Property(e => e.Userid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("userid");

                entity.HasOne(d => d.Mediatype)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.Mediatypeid)
                    .HasConstraintName("c_media_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("c_media_1");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => e.Moduleid)
                    .HasName("PRIMARY");

                entity.ToTable("module");

                entity.Property(e => e.Moduleid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("moduleid");

                entity.Property(e => e.Config)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("config");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("id")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.RelativePath)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("relative_path")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Opcommand>(entity =>
            {
                entity.HasKey(e => e.Operationid)
                    .HasName("PRIMARY");

                entity.ToTable("opcommand");

                entity.HasIndex(e => e.Scriptid, "opcommand_1");

                entity.Property(e => e.Operationid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("operationid");

                entity.Property(e => e.Authtype)
                    .HasColumnType("int(11)")
                    .HasColumnName("authtype");

                entity.Property(e => e.Command)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("command");

                entity.Property(e => e.ExecuteOn)
                    .HasColumnType("int(11)")
                    .HasColumnName("execute_on");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("password")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Port)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("port")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Privatekey)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("privatekey")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Publickey)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("publickey")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Scriptid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("scriptid");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("username")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Operation)
                    .WithOne(p => p.Opcommand)
                    .HasForeignKey<Opcommand>(d => d.Operationid)
                    .HasConstraintName("c_opcommand_1");

                entity.HasOne(d => d.Script)
                    .WithMany(p => p.Opcommands)
                    .HasForeignKey(d => d.Scriptid)
                    .HasConstraintName("c_opcommand_2");
            });

            modelBuilder.Entity<OpcommandGrp>(entity =>
            {
                entity.ToTable("opcommand_grp");

                entity.HasIndex(e => e.Operationid, "opcommand_grp_1");

                entity.HasIndex(e => e.Groupid, "opcommand_grp_2");

                entity.Property(e => e.OpcommandGrpid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("opcommand_grpid");

                entity.Property(e => e.Groupid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("groupid");

                entity.Property(e => e.Operationid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("operationid");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.OpcommandGrps)
                    .HasForeignKey(d => d.Groupid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("c_opcommand_grp_2");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.OpcommandGrps)
                    .HasForeignKey(d => d.Operationid)
                    .HasConstraintName("c_opcommand_grp_1");
            });

            modelBuilder.Entity<OpcommandHst>(entity =>
            {
                entity.ToTable("opcommand_hst");

                entity.HasIndex(e => e.Operationid, "opcommand_hst_1");

                entity.HasIndex(e => e.Hostid, "opcommand_hst_2");

                entity.Property(e => e.OpcommandHstid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("opcommand_hstid");

                entity.Property(e => e.Hostid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("hostid");

                entity.Property(e => e.Operationid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("operationid");

                entity.HasOne(d => d.Host)
                    .WithMany(p => p.OpcommandHsts)
                    .HasForeignKey(d => d.Hostid)
                    .HasConstraintName("c_opcommand_hst_2");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.OpcommandHsts)
                    .HasForeignKey(d => d.Operationid)
                    .HasConstraintName("c_opcommand_hst_1");
            });

            modelBuilder.Entity<Opcondition>(entity =>
            {
                entity.ToTable("opconditions");

                entity.HasIndex(e => e.Operationid, "opconditions_1");

                entity.Property(e => e.Opconditionid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("opconditionid");

                entity.Property(e => e.Conditiontype)
                    .HasColumnType("int(11)")
                    .HasColumnName("conditiontype");

                entity.Property(e => e.Operationid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("operationid");

                entity.Property(e => e.Operator)
                    .HasColumnType("int(11)")
                    .HasColumnName("operator");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.Opconditions)
                    .HasForeignKey(d => d.Operationid)
                    .HasConstraintName("c_opconditions_1");
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.ToTable("operations");

                entity.HasIndex(e => e.Actionid, "operations_1");

                entity.Property(e => e.Operationid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("operationid");

                entity.Property(e => e.Actionid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("actionid");

                entity.Property(e => e.EscPeriod)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("esc_period")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.EscStepFrom)
                    .HasColumnType("int(11)")
                    .HasColumnName("esc_step_from")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.EscStepTo)
                    .HasColumnType("int(11)")
                    .HasColumnName("esc_step_to")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Evaltype)
                    .HasColumnType("int(11)")
                    .HasColumnName("evaltype");

                entity.Property(e => e.Operationtype)
                    .HasColumnType("int(11)")
                    .HasColumnName("operationtype");

                entity.Property(e => e.Recovery)
                    .HasColumnType("int(11)")
                    .HasColumnName("recovery");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.Actionid)
                    .HasConstraintName("c_operations_1");
            });

            modelBuilder.Entity<Opgroup>(entity =>
            {
                entity.ToTable("opgroup");

                entity.HasIndex(e => new { e.Operationid, e.Groupid }, "opgroup_1")
                    .IsUnique();

                entity.HasIndex(e => e.Groupid, "opgroup_2");

                entity.Property(e => e.Opgroupid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("opgroupid");

                entity.Property(e => e.Groupid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("groupid");

                entity.Property(e => e.Operationid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("operationid");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Opgroups)
                    .HasForeignKey(d => d.Groupid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("c_opgroup_2");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.Opgroups)
                    .HasForeignKey(d => d.Operationid)
                    .HasConstraintName("c_opgroup_1");
            });

            modelBuilder.Entity<Opinventory>(entity =>
            {
                entity.HasKey(e => e.Operationid)
                    .HasName("PRIMARY");

                entity.ToTable("opinventory");

                entity.Property(e => e.Operationid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("operationid");

                entity.Property(e => e.InventoryMode)
                    .HasColumnType("int(11)")
                    .HasColumnName("inventory_mode");

                entity.HasOne(d => d.Operation)
                    .WithOne(p => p.Opinventory)
                    .HasForeignKey<Opinventory>(d => d.Operationid)
                    .HasConstraintName("c_opinventory_1");
            });

            modelBuilder.Entity<Opmessage>(entity =>
            {
                entity.HasKey(e => e.Operationid)
                    .HasName("PRIMARY");

                entity.ToTable("opmessage");

                entity.HasIndex(e => e.Mediatypeid, "opmessage_1");

                entity.Property(e => e.Operationid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("operationid");

                entity.Property(e => e.DefaultMsg)
                    .HasColumnType("int(11)")
                    .HasColumnName("default_msg")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Mediatypeid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("mediatypeid");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("message");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("subject")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Mediatype)
                    .WithMany(p => p.Opmessages)
                    .HasForeignKey(d => d.Mediatypeid)
                    .HasConstraintName("c_opmessage_2");

                entity.HasOne(d => d.Operation)
                    .WithOne(p => p.Opmessage)
                    .HasForeignKey<Opmessage>(d => d.Operationid)
                    .HasConstraintName("c_opmessage_1");
            });

            modelBuilder.Entity<OpmessageGrp>(entity =>
            {
                entity.ToTable("opmessage_grp");

                entity.HasIndex(e => new { e.Operationid, e.Usrgrpid }, "opmessage_grp_1")
                    .IsUnique();

                entity.HasIndex(e => e.Usrgrpid, "opmessage_grp_2");

                entity.Property(e => e.OpmessageGrpid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("opmessage_grpid");

                entity.Property(e => e.Operationid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("operationid");

                entity.Property(e => e.Usrgrpid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("usrgrpid");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.OpmessageGrps)
                    .HasForeignKey(d => d.Operationid)
                    .HasConstraintName("c_opmessage_grp_1");

                entity.HasOne(d => d.Usrgrp)
                    .WithMany(p => p.OpmessageGrps)
                    .HasForeignKey(d => d.Usrgrpid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("c_opmessage_grp_2");
            });

            modelBuilder.Entity<OpmessageUsr>(entity =>
            {
                entity.ToTable("opmessage_usr");

                entity.HasIndex(e => new { e.Operationid, e.Userid }, "opmessage_usr_1")
                    .IsUnique();

                entity.HasIndex(e => e.Userid, "opmessage_usr_2");

                entity.Property(e => e.OpmessageUsrid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("opmessage_usrid");

                entity.Property(e => e.Operationid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("operationid");

                entity.Property(e => e.Userid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("userid");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.OpmessageUsrs)
                    .HasForeignKey(d => d.Operationid)
                    .HasConstraintName("c_opmessage_usr_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OpmessageUsrs)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("c_opmessage_usr_2");
            });

            modelBuilder.Entity<Optemplate>(entity =>
            {
                entity.ToTable("optemplate");

                entity.HasIndex(e => new { e.Operationid, e.Templateid }, "optemplate_1")
                    .IsUnique();

                entity.HasIndex(e => e.Templateid, "optemplate_2");

                entity.Property(e => e.Optemplateid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("optemplateid");

                entity.Property(e => e.Operationid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("operationid");

                entity.Property(e => e.Templateid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("templateid");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.Optemplates)
                    .HasForeignKey(d => d.Operationid)
                    .HasConstraintName("c_optemplate_1");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Optemplates)
                    .HasForeignKey(d => d.Templateid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("c_optemplate_2");
            });

            modelBuilder.Entity<Problem>(entity =>
            {
                entity.HasKey(e => e.Eventid)
                    .HasName("PRIMARY");

                entity.ToTable("problem");

                entity.HasIndex(e => new { e.Source, e.Object, e.Objectid }, "problem_1");

                entity.HasIndex(e => e.RClock, "problem_2");

                entity.HasIndex(e => e.REventid, "problem_3");

                entity.Property(e => e.Eventid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("eventid");

                entity.Property(e => e.Acknowledged)
                    .HasColumnType("int(11)")
                    .HasColumnName("acknowledged");

                entity.Property(e => e.Clock)
                    .HasColumnType("int(11)")
                    .HasColumnName("clock");

                entity.Property(e => e.Correlationid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("correlationid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Ns)
                    .HasColumnType("int(11)")
                    .HasColumnName("ns");

                entity.Property(e => e.Object)
                    .HasColumnType("int(11)")
                    .HasColumnName("object");

                entity.Property(e => e.Objectid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("objectid");

                entity.Property(e => e.RClock)
                    .HasColumnType("int(11)")
                    .HasColumnName("r_clock");

                entity.Property(e => e.REventid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("r_eventid");

                entity.Property(e => e.RNs)
                    .HasColumnType("int(11)")
                    .HasColumnName("r_ns");

                entity.Property(e => e.Severity)
                    .HasColumnType("int(11)")
                    .HasColumnName("severity");

                entity.Property(e => e.Source)
                    .HasColumnType("int(11)")
                    .HasColumnName("source");

                entity.Property(e => e.Userid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("userid");

                entity.HasOne(d => d.Event)
                    .WithOne(p => p.ProblemEvent)
                    .HasForeignKey<Problem>(d => d.Eventid)
                    .HasConstraintName("c_problem_1");

                entity.HasOne(d => d.REvent)
                    .WithMany(p => p.ProblemREvents)
                    .HasForeignKey(d => d.REventid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_problem_2");
            });

            modelBuilder.Entity<ProblemTag>(entity =>
            {
                entity.ToTable("problem_tag");

                entity.HasIndex(e => new { e.Eventid, e.Tag, e.Value }, "problem_tag_1");

                entity.Property(e => e.Problemtagid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("problemtagid");

                entity.Property(e => e.Eventid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("eventid");

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasColumnName("tag")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.ProblemTags)
                    .HasForeignKey(d => d.Eventid)
                    .HasConstraintName("c_problem_tag_1");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("profiles");

                entity.HasIndex(e => new { e.Userid, e.Idx, e.Idx2 }, "profiles_1");

                entity.HasIndex(e => new { e.Userid, e.Profileid }, "profiles_2");

                entity.Property(e => e.Profileid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("profileid");

                entity.Property(e => e.Idx)
                    .IsRequired()
                    .HasMaxLength(96)
                    .HasColumnName("idx")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Idx2)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("idx2");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(96)
                    .HasColumnName("source")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.Property(e => e.Userid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("userid");

                entity.Property(e => e.ValueId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("value_id");

                entity.Property(e => e.ValueInt)
                    .HasColumnType("int(11)")
                    .HasColumnName("value_int");

                entity.Property(e => e.ValueStr)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("value_str");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("c_profiles_1");
            });

            modelBuilder.Entity<ProxyAutoregHost>(entity =>
            {
                entity.ToTable("proxy_autoreg_host");

                entity.HasIndex(e => e.Clock, "proxy_autoreg_host_1");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Clock)
                    .HasColumnType("int(11)")
                    .HasColumnName("clock");

                entity.Property(e => e.Flags)
                    .HasColumnType("int(11)")
                    .HasColumnName("flags");

                entity.Property(e => e.Host)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("host")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.HostMetadata)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("host_metadata")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ListenDns)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("listen_dns")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ListenIp)
                    .IsRequired()
                    .HasMaxLength(39)
                    .HasColumnName("listen_ip")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ListenPort)
                    .HasColumnType("int(11)")
                    .HasColumnName("listen_port");

                entity.Property(e => e.TlsAccepted)
                    .HasColumnType("int(11)")
                    .HasColumnName("tls_accepted")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<ProxyDhistory>(entity =>
            {
                entity.ToTable("proxy_dhistory");

                entity.HasIndex(e => e.Clock, "proxy_dhistory_1");

                entity.HasIndex(e => e.Druleid, "proxy_dhistory_2");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Clock)
                    .HasColumnType("int(11)")
                    .HasColumnName("clock");

                entity.Property(e => e.Dcheckid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("dcheckid");

                entity.Property(e => e.Dns)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("dns")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Druleid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("druleid");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(39)
                    .HasColumnName("ip")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Port)
                    .HasColumnType("int(11)")
                    .HasColumnName("port");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ProxyHistory>(entity =>
            {
                entity.ToTable("proxy_history");

                entity.HasIndex(e => e.Clock, "proxy_history_1");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Clock)
                    .HasColumnType("int(11)")
                    .HasColumnName("clock");

                entity.Property(e => e.Flags)
                    .HasColumnType("int(11)")
                    .HasColumnName("flags");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.Property(e => e.Lastlogsize)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("lastlogsize");

                entity.Property(e => e.Logeventid)
                    .HasColumnType("int(11)")
                    .HasColumnName("logeventid");

                entity.Property(e => e.Mtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("mtime");

                entity.Property(e => e.Ns)
                    .HasColumnType("int(11)")
                    .HasColumnName("ns");

                entity.Property(e => e.Severity)
                    .HasColumnType("int(11)")
                    .HasColumnName("severity");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("source")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.State)
                    .HasColumnType("int(11)")
                    .HasColumnName("state");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("int(11)")
                    .HasColumnName("timestamp");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");

                entity.Property(e => e.WriteClock)
                    .HasColumnType("int(11)")
                    .HasColumnName("write_clock");
            });

            modelBuilder.Entity<Regexp>(entity =>
            {
                entity.ToTable("regexps");

                entity.HasIndex(e => e.Name, "regexps_1")
                    .IsUnique();

                entity.Property(e => e.Regexpid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("regexpid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TestString)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("test_string");
            });

            modelBuilder.Entity<Right>(entity =>
            {
                entity.HasKey(e => e.Rightid)
                    .HasName("PRIMARY");

                entity.ToTable("rights");

                entity.HasIndex(e => e.Groupid, "rights_1");

                entity.HasIndex(e => e.Id, "rights_2");

                entity.Property(e => e.Rightid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("rightid");

                entity.Property(e => e.Groupid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("groupid");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Permission)
                    .HasColumnType("int(11)")
                    .HasColumnName("permission");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Rights)
                    .HasForeignKey(d => d.Groupid)
                    .HasConstraintName("c_rights_1");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Rights)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("c_rights_2");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.HasIndex(e => e.Name, "role_1")
                    .IsUnique();

                entity.Property(e => e.Roleid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("roleid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Readonly)
                    .HasColumnType("int(11)")
                    .HasColumnName("readonly");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");
            });

            modelBuilder.Entity<RoleRule>(entity =>
            {
                entity.ToTable("role_rule");

                entity.HasIndex(e => e.Roleid, "role_rule_1");

                entity.HasIndex(e => e.ValueModuleid, "role_rule_2");

                entity.Property(e => e.RoleRuleid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("role_ruleid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Roleid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("roleid");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.Property(e => e.ValueInt)
                    .HasColumnType("int(11)")
                    .HasColumnName("value_int");

                entity.Property(e => e.ValueModuleid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("value_moduleid");

                entity.Property(e => e.ValueStr)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("value_str")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleRules)
                    .HasForeignKey(d => d.Roleid)
                    .HasConstraintName("c_role_rule_1");

                entity.HasOne(d => d.ValueModule)
                    .WithMany(p => p.RoleRules)
                    .HasForeignKey(d => d.ValueModuleid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_role_rule_2");
            });

            modelBuilder.Entity<Screen>(entity =>
            {
                entity.ToTable("screens");

                entity.HasIndex(e => e.Userid, "screens_1");

                entity.Property(e => e.Screenid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("screenid");

                entity.Property(e => e.Hsize)
                    .HasColumnType("int(11)")
                    .HasColumnName("hsize")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Private)
                    .HasColumnType("int(11)")
                    .HasColumnName("private")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Userid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("userid");

                entity.Property(e => e.Vsize)
                    .HasColumnType("int(11)")
                    .HasColumnName("vsize")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Screens)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("c_screens_3");
            });

            modelBuilder.Entity<ScreenUser>(entity =>
            {
                entity.ToTable("screen_user");

                entity.HasIndex(e => e.Userid, "c_screen_user_2");

                entity.HasIndex(e => new { e.Screenid, e.Userid }, "screen_user_1")
                    .IsUnique();

                entity.Property(e => e.Screenuserid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("screenuserid");

                entity.Property(e => e.Permission)
                    .HasColumnType("int(11)")
                    .HasColumnName("permission")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.Screenid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("screenid");

                entity.Property(e => e.Userid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("userid");

                entity.HasOne(d => d.Screen)
                    .WithMany(p => p.ScreenUsers)
                    .HasForeignKey(d => d.Screenid)
                    .HasConstraintName("c_screen_user_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ScreenUsers)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("c_screen_user_2");
            });

            modelBuilder.Entity<ScreenUsrgrp>(entity =>
            {
                entity.ToTable("screen_usrgrp");

                entity.HasIndex(e => e.Usrgrpid, "c_screen_usrgrp_2");

                entity.HasIndex(e => new { e.Screenid, e.Usrgrpid }, "screen_usrgrp_1")
                    .IsUnique();

                entity.Property(e => e.Screenusrgrpid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("screenusrgrpid");

                entity.Property(e => e.Permission)
                    .HasColumnType("int(11)")
                    .HasColumnName("permission")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.Screenid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("screenid");

                entity.Property(e => e.Usrgrpid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("usrgrpid");

                entity.HasOne(d => d.Screen)
                    .WithMany(p => p.ScreenUsrgrps)
                    .HasForeignKey(d => d.Screenid)
                    .HasConstraintName("c_screen_usrgrp_1");

                entity.HasOne(d => d.Usrgrp)
                    .WithMany(p => p.ScreenUsrgrps)
                    .HasForeignKey(d => d.Usrgrpid)
                    .HasConstraintName("c_screen_usrgrp_2");
            });

            modelBuilder.Entity<ScreensItem>(entity =>
            {
                entity.HasKey(e => e.Screenitemid)
                    .HasName("PRIMARY");

                entity.ToTable("screens_items");

                entity.HasIndex(e => e.Screenid, "screens_items_1");

                entity.Property(e => e.Screenitemid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("screenitemid");

                entity.Property(e => e.Application)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("application")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Colspan)
                    .HasColumnType("int(11)")
                    .HasColumnName("colspan")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Dynamic)
                    .HasColumnType("int(11)")
                    .HasColumnName("dynamic");

                entity.Property(e => e.Elements)
                    .HasColumnType("int(11)")
                    .HasColumnName("elements")
                    .HasDefaultValueSql("'25'");

                entity.Property(e => e.Halign)
                    .HasColumnType("int(11)")
                    .HasColumnName("halign");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height")
                    .HasDefaultValueSql("'200'");

                entity.Property(e => e.MaxColumns)
                    .HasColumnType("int(11)")
                    .HasColumnName("max_columns")
                    .HasDefaultValueSql("'3'");

                entity.Property(e => e.Resourceid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("resourceid");

                entity.Property(e => e.Resourcetype)
                    .HasColumnType("int(11)")
                    .HasColumnName("resourcetype");

                entity.Property(e => e.Rowspan)
                    .HasColumnType("int(11)")
                    .HasColumnName("rowspan")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Screenid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("screenid");

                entity.Property(e => e.SortTriggers)
                    .HasColumnType("int(11)")
                    .HasColumnName("sort_triggers");

                entity.Property(e => e.Style)
                    .HasColumnType("int(11)")
                    .HasColumnName("style");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("url")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Valign)
                    .HasColumnType("int(11)")
                    .HasColumnName("valign");

                entity.Property(e => e.Width)
                    .HasColumnType("int(11)")
                    .HasColumnName("width")
                    .HasDefaultValueSql("'320'");

                entity.Property(e => e.X)
                    .HasColumnType("int(11)")
                    .HasColumnName("x");

                entity.Property(e => e.Y)
                    .HasColumnType("int(11)")
                    .HasColumnName("y");

                entity.HasOne(d => d.Screen)
                    .WithMany(p => p.ScreensItems)
                    .HasForeignKey(d => d.Screenid)
                    .HasConstraintName("c_screens_items_1");
            });

            modelBuilder.Entity<Script>(entity =>
            {
                entity.ToTable("scripts");

                entity.HasIndex(e => e.Usrgrpid, "scripts_1");

                entity.HasIndex(e => e.Groupid, "scripts_2");

                entity.HasIndex(e => e.Name, "scripts_3")
                    .IsUnique();

                entity.Property(e => e.Scriptid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("scriptid");

                entity.Property(e => e.Command)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("command")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Confirmation)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("confirmation")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.ExecuteOn)
                    .HasColumnType("int(11)")
                    .HasColumnName("execute_on")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.Groupid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("groupid");

                entity.Property(e => e.HostAccess)
                    .HasColumnType("int(11)")
                    .HasColumnName("host_access")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.Property(e => e.Usrgrpid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("usrgrpid");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Scripts)
                    .HasForeignKey(d => d.Groupid)
                    .HasConstraintName("c_scripts_2");

                entity.HasOne(d => d.Usrgrp)
                    .WithMany(p => p.Scripts)
                    .HasForeignKey(d => d.Usrgrpid)
                    .HasConstraintName("c_scripts_1");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("services");

                entity.HasIndex(e => e.Triggerid, "services_1");

                entity.Property(e => e.Serviceid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("serviceid");

                entity.Property(e => e.Algorithm)
                    .HasColumnType("int(11)")
                    .HasColumnName("algorithm");

                entity.Property(e => e.Goodsla)
                    .HasColumnName("goodsla")
                    .HasDefaultValueSql("'99.9'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Showsla)
                    .HasColumnType("int(11)")
                    .HasColumnName("showsla");

                entity.Property(e => e.Sortorder)
                    .HasColumnType("int(11)")
                    .HasColumnName("sortorder");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.Property(e => e.Triggerid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("triggerid");

                entity.HasOne(d => d.Trigger)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.Triggerid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_services_1");
            });

            modelBuilder.Entity<ServiceAlarm>(entity =>
            {
                entity.ToTable("service_alarms");

                entity.HasIndex(e => new { e.Serviceid, e.Clock }, "service_alarms_1");

                entity.HasIndex(e => e.Clock, "service_alarms_2");

                entity.Property(e => e.Servicealarmid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("servicealarmid");

                entity.Property(e => e.Clock)
                    .HasColumnType("int(11)")
                    .HasColumnName("clock");

                entity.Property(e => e.Serviceid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("serviceid");

                entity.Property(e => e.Value)
                    .HasColumnType("int(11)")
                    .HasColumnName("value");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceAlarms)
                    .HasForeignKey(d => d.Serviceid)
                    .HasConstraintName("c_service_alarms_1");
            });

            modelBuilder.Entity<ServicesLink>(entity =>
            {
                entity.HasKey(e => e.Linkid)
                    .HasName("PRIMARY");

                entity.ToTable("services_links");

                entity.HasIndex(e => e.Servicedownid, "services_links_1");

                entity.HasIndex(e => new { e.Serviceupid, e.Servicedownid }, "services_links_2")
                    .IsUnique();

                entity.Property(e => e.Linkid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("linkid");

                entity.Property(e => e.Servicedownid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("servicedownid");

                entity.Property(e => e.Serviceupid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("serviceupid");

                entity.Property(e => e.Soft)
                    .HasColumnType("int(11)")
                    .HasColumnName("soft");

                entity.HasOne(d => d.Servicedown)
                    .WithMany(p => p.ServicesLinkServicedowns)
                    .HasForeignKey(d => d.Servicedownid)
                    .HasConstraintName("c_services_links_2");

                entity.HasOne(d => d.Serviceup)
                    .WithMany(p => p.ServicesLinkServiceups)
                    .HasForeignKey(d => d.Serviceupid)
                    .HasConstraintName("c_services_links_1");
            });

            modelBuilder.Entity<ServicesTime>(entity =>
            {
                entity.HasKey(e => e.Timeid)
                    .HasName("PRIMARY");

                entity.ToTable("services_times");

                entity.HasIndex(e => new { e.Serviceid, e.Type, e.TsFrom, e.TsTo }, "services_times_1");

                entity.Property(e => e.Timeid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("timeid");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("note")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Serviceid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("serviceid");

                entity.Property(e => e.TsFrom)
                    .HasColumnType("int(11)")
                    .HasColumnName("ts_from");

                entity.Property(e => e.TsTo)
                    .HasColumnType("int(11)")
                    .HasColumnName("ts_to");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServicesTimes)
                    .HasForeignKey(d => d.Serviceid)
                    .HasConstraintName("c_services_times_1");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("sessions");

                entity.HasIndex(e => new { e.Userid, e.Status, e.Lastaccess }, "sessions_1");

                entity.Property(e => e.Sessionid)
                    .HasMaxLength(32)
                    .HasColumnName("sessionid")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Lastaccess)
                    .HasColumnType("int(11)")
                    .HasColumnName("lastaccess");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.Property(e => e.Userid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("c_sessions_1");
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.ToTable("slides");

                entity.HasIndex(e => e.Slideshowid, "slides_1");

                entity.HasIndex(e => e.Screenid, "slides_2");

                entity.Property(e => e.Slideid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("slideid");

                entity.Property(e => e.Delay)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("delay")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Screenid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("screenid");

                entity.Property(e => e.Slideshowid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("slideshowid");

                entity.Property(e => e.Step)
                    .HasColumnType("int(11)")
                    .HasColumnName("step");

                entity.HasOne(d => d.Screen)
                    .WithMany(p => p.Slides)
                    .HasForeignKey(d => d.Screenid)
                    .HasConstraintName("c_slides_2");

                entity.HasOne(d => d.Slideshow)
                    .WithMany(p => p.Slides)
                    .HasForeignKey(d => d.Slideshowid)
                    .HasConstraintName("c_slides_1");
            });

            modelBuilder.Entity<Slideshow>(entity =>
            {
                entity.ToTable("slideshows");

                entity.HasIndex(e => e.Userid, "c_slideshows_3");

                entity.HasIndex(e => e.Name, "slideshows_1")
                    .IsUnique();

                entity.Property(e => e.Slideshowid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("slideshowid");

                entity.Property(e => e.Delay)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("delay")
                    .HasDefaultValueSql("'30s'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Private)
                    .HasColumnType("int(11)")
                    .HasColumnName("private")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Userid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Slideshows)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("c_slideshows_3");
            });

            modelBuilder.Entity<SlideshowUser>(entity =>
            {
                entity.ToTable("slideshow_user");

                entity.HasIndex(e => e.Userid, "c_slideshow_user_2");

                entity.HasIndex(e => new { e.Slideshowid, e.Userid }, "slideshow_user_1")
                    .IsUnique();

                entity.Property(e => e.Slideshowuserid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("slideshowuserid");

                entity.Property(e => e.Permission)
                    .HasColumnType("int(11)")
                    .HasColumnName("permission")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.Slideshowid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("slideshowid");

                entity.Property(e => e.Userid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("userid");

                entity.HasOne(d => d.Slideshow)
                    .WithMany(p => p.SlideshowUsers)
                    .HasForeignKey(d => d.Slideshowid)
                    .HasConstraintName("c_slideshow_user_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SlideshowUsers)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("c_slideshow_user_2");
            });

            modelBuilder.Entity<SlideshowUsrgrp>(entity =>
            {
                entity.ToTable("slideshow_usrgrp");

                entity.HasIndex(e => e.Usrgrpid, "c_slideshow_usrgrp_2");

                entity.HasIndex(e => new { e.Slideshowid, e.Usrgrpid }, "slideshow_usrgrp_1")
                    .IsUnique();

                entity.Property(e => e.Slideshowusrgrpid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("slideshowusrgrpid");

                entity.Property(e => e.Permission)
                    .HasColumnType("int(11)")
                    .HasColumnName("permission")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.Slideshowid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("slideshowid");

                entity.Property(e => e.Usrgrpid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("usrgrpid");

                entity.HasOne(d => d.Slideshow)
                    .WithMany(p => p.SlideshowUsrgrps)
                    .HasForeignKey(d => d.Slideshowid)
                    .HasConstraintName("c_slideshow_usrgrp_1");

                entity.HasOne(d => d.Usrgrp)
                    .WithMany(p => p.SlideshowUsrgrps)
                    .HasForeignKey(d => d.Usrgrpid)
                    .HasConstraintName("c_slideshow_usrgrp_2");
            });

            modelBuilder.Entity<Sysmap>(entity =>
            {
                entity.ToTable("sysmaps");

                entity.HasIndex(e => e.Userid, "c_sysmaps_3");

                entity.HasIndex(e => e.Name, "sysmaps_1")
                    .IsUnique();

                entity.HasIndex(e => e.Backgroundid, "sysmaps_2");

                entity.HasIndex(e => e.Iconmapid, "sysmaps_3");

                entity.Property(e => e.Sysmapid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("sysmapid");

                entity.Property(e => e.Backgroundid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("backgroundid");

                entity.Property(e => e.ExpandMacros)
                    .HasColumnType("int(11)")
                    .HasColumnName("expand_macros");

                entity.Property(e => e.Expandproblem)
                    .HasColumnType("int(11)")
                    .HasColumnName("expandproblem")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.GridAlign)
                    .HasColumnType("int(11)")
                    .HasColumnName("grid_align")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.GridShow)
                    .HasColumnType("int(11)")
                    .HasColumnName("grid_show")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.GridSize)
                    .HasColumnType("int(11)")
                    .HasColumnName("grid_size")
                    .HasDefaultValueSql("'50'");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height")
                    .HasDefaultValueSql("'400'");

                entity.Property(e => e.Highlight)
                    .HasColumnType("int(11)")
                    .HasColumnName("highlight")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Iconmapid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("iconmapid");

                entity.Property(e => e.LabelFormat)
                    .HasColumnType("int(11)")
                    .HasColumnName("label_format");

                entity.Property(e => e.LabelLocation)
                    .HasColumnType("int(11)")
                    .HasColumnName("label_location");

                entity.Property(e => e.LabelStringHost)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("label_string_host")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LabelStringHostgroup)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("label_string_hostgroup")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LabelStringImage)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("label_string_image")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LabelStringMap)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("label_string_map")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LabelStringTrigger)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("label_string_trigger")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LabelType)
                    .HasColumnType("int(11)")
                    .HasColumnName("label_type")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.LabelTypeHost)
                    .HasColumnType("int(11)")
                    .HasColumnName("label_type_host")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.LabelTypeHostgroup)
                    .HasColumnType("int(11)")
                    .HasColumnName("label_type_hostgroup")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.LabelTypeImage)
                    .HasColumnType("int(11)")
                    .HasColumnName("label_type_image")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.LabelTypeMap)
                    .HasColumnType("int(11)")
                    .HasColumnName("label_type_map")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.LabelTypeTrigger)
                    .HasColumnType("int(11)")
                    .HasColumnName("label_type_trigger")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.Markelements)
                    .HasColumnType("int(11)")
                    .HasColumnName("markelements");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Private)
                    .HasColumnType("int(11)")
                    .HasColumnName("private")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.SeverityMin)
                    .HasColumnType("int(11)")
                    .HasColumnName("severity_min");

                entity.Property(e => e.ShowSuppressed)
                    .HasColumnType("int(11)")
                    .HasColumnName("show_suppressed");

                entity.Property(e => e.ShowUnack)
                    .HasColumnType("int(11)")
                    .HasColumnName("show_unack");

                entity.Property(e => e.Userid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("userid");

                entity.Property(e => e.Width)
                    .HasColumnType("int(11)")
                    .HasColumnName("width")
                    .HasDefaultValueSql("'600'");

                entity.HasOne(d => d.Background)
                    .WithMany(p => p.Sysmaps)
                    .HasForeignKey(d => d.Backgroundid)
                    .HasConstraintName("c_sysmaps_1");

                entity.HasOne(d => d.Iconmap)
                    .WithMany(p => p.Sysmaps)
                    .HasForeignKey(d => d.Iconmapid)
                    .HasConstraintName("c_sysmaps_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sysmaps)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("c_sysmaps_3");
            });

            modelBuilder.Entity<SysmapElementTrigger>(entity =>
            {
                entity.HasKey(e => e.SelementTriggerid)
                    .HasName("PRIMARY");

                entity.ToTable("sysmap_element_trigger");

                entity.HasIndex(e => e.Triggerid, "c_sysmap_element_trigger_2");

                entity.HasIndex(e => new { e.Selementid, e.Triggerid }, "sysmap_element_trigger_1")
                    .IsUnique();

                entity.Property(e => e.SelementTriggerid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("selement_triggerid");

                entity.Property(e => e.Selementid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("selementid");

                entity.Property(e => e.Triggerid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("triggerid");

                entity.HasOne(d => d.Selement)
                    .WithMany(p => p.SysmapElementTriggers)
                    .HasForeignKey(d => d.Selementid)
                    .HasConstraintName("c_sysmap_element_trigger_1");

                entity.HasOne(d => d.Trigger)
                    .WithMany(p => p.SysmapElementTriggers)
                    .HasForeignKey(d => d.Triggerid)
                    .HasConstraintName("c_sysmap_element_trigger_2");
            });

            modelBuilder.Entity<SysmapElementUrl>(entity =>
            {
                entity.ToTable("sysmap_element_url");

                entity.HasIndex(e => new { e.Selementid, e.Name }, "sysmap_element_url_1")
                    .IsUnique();

                entity.Property(e => e.Sysmapelementurlid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("sysmapelementurlid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Selementid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("selementid");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("url")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Selement)
                    .WithMany(p => p.SysmapElementUrls)
                    .HasForeignKey(d => d.Selementid)
                    .HasConstraintName("c_sysmap_element_url_1");
            });

            modelBuilder.Entity<SysmapShape>(entity =>
            {
                entity.ToTable("sysmap_shape");

                entity.HasIndex(e => e.Sysmapid, "sysmap_shape_1");

                entity.Property(e => e.SysmapShapeid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("sysmap_shapeid");

                entity.Property(e => e.BackgroundColor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("background_color")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.BorderColor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("border_color")
                    .HasDefaultValueSql("'000000'");

                entity.Property(e => e.BorderType)
                    .HasColumnType("int(11)")
                    .HasColumnName("border_type");

                entity.Property(e => e.BorderWidth)
                    .HasColumnType("int(11)")
                    .HasColumnName("border_width")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Font)
                    .HasColumnType("int(11)")
                    .HasColumnName("font")
                    .HasDefaultValueSql("'9'");

                entity.Property(e => e.FontColor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("font_color")
                    .HasDefaultValueSql("'000000'");

                entity.Property(e => e.FontSize)
                    .HasColumnType("int(11)")
                    .HasColumnName("font_size")
                    .HasDefaultValueSql("'11'");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height")
                    .HasDefaultValueSql("'200'");

                entity.Property(e => e.Sysmapid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("sysmapid");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("text");

                entity.Property(e => e.TextHalign)
                    .HasColumnType("int(11)")
                    .HasColumnName("text_halign");

                entity.Property(e => e.TextValign)
                    .HasColumnType("int(11)")
                    .HasColumnName("text_valign");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.Property(e => e.Width)
                    .HasColumnType("int(11)")
                    .HasColumnName("width")
                    .HasDefaultValueSql("'200'");

                entity.Property(e => e.X)
                    .HasColumnType("int(11)")
                    .HasColumnName("x");

                entity.Property(e => e.Y)
                    .HasColumnType("int(11)")
                    .HasColumnName("y");

                entity.Property(e => e.Zindex)
                    .HasColumnType("int(11)")
                    .HasColumnName("zindex");

                entity.HasOne(d => d.Sysmap)
                    .WithMany(p => p.SysmapShapes)
                    .HasForeignKey(d => d.Sysmapid)
                    .HasConstraintName("c_sysmap_shape_1");
            });

            modelBuilder.Entity<SysmapUrl>(entity =>
            {
                entity.ToTable("sysmap_url");

                entity.HasIndex(e => new { e.Sysmapid, e.Name }, "sysmap_url_1")
                    .IsUnique();

                entity.Property(e => e.Sysmapurlid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("sysmapurlid");

                entity.Property(e => e.Elementtype)
                    .HasColumnType("int(11)")
                    .HasColumnName("elementtype");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Sysmapid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("sysmapid");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("url")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Sysmap)
                    .WithMany(p => p.SysmapUrls)
                    .HasForeignKey(d => d.Sysmapid)
                    .HasConstraintName("c_sysmap_url_1");
            });

            modelBuilder.Entity<SysmapUser>(entity =>
            {
                entity.ToTable("sysmap_user");

                entity.HasIndex(e => e.Userid, "c_sysmap_user_2");

                entity.HasIndex(e => new { e.Sysmapid, e.Userid }, "sysmap_user_1")
                    .IsUnique();

                entity.Property(e => e.Sysmapuserid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("sysmapuserid");

                entity.Property(e => e.Permission)
                    .HasColumnType("int(11)")
                    .HasColumnName("permission")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.Sysmapid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("sysmapid");

                entity.Property(e => e.Userid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("userid");

                entity.HasOne(d => d.Sysmap)
                    .WithMany(p => p.SysmapUsers)
                    .HasForeignKey(d => d.Sysmapid)
                    .HasConstraintName("c_sysmap_user_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SysmapUsers)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("c_sysmap_user_2");
            });

            modelBuilder.Entity<SysmapUsrgrp>(entity =>
            {
                entity.ToTable("sysmap_usrgrp");

                entity.HasIndex(e => e.Usrgrpid, "c_sysmap_usrgrp_2");

                entity.HasIndex(e => new { e.Sysmapid, e.Usrgrpid }, "sysmap_usrgrp_1")
                    .IsUnique();

                entity.Property(e => e.Sysmapusrgrpid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("sysmapusrgrpid");

                entity.Property(e => e.Permission)
                    .HasColumnType("int(11)")
                    .HasColumnName("permission")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.Sysmapid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("sysmapid");

                entity.Property(e => e.Usrgrpid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("usrgrpid");

                entity.HasOne(d => d.Sysmap)
                    .WithMany(p => p.SysmapUsrgrps)
                    .HasForeignKey(d => d.Sysmapid)
                    .HasConstraintName("c_sysmap_usrgrp_1");

                entity.HasOne(d => d.Usrgrp)
                    .WithMany(p => p.SysmapUsrgrps)
                    .HasForeignKey(d => d.Usrgrpid)
                    .HasConstraintName("c_sysmap_usrgrp_2");
            });

            modelBuilder.Entity<SysmapsElement>(entity =>
            {
                entity.HasKey(e => e.Selementid)
                    .HasName("PRIMARY");

                entity.ToTable("sysmaps_elements");

                entity.HasIndex(e => e.Sysmapid, "sysmaps_elements_1");

                entity.HasIndex(e => e.IconidOff, "sysmaps_elements_2");

                entity.HasIndex(e => e.IconidOn, "sysmaps_elements_3");

                entity.HasIndex(e => e.IconidDisabled, "sysmaps_elements_4");

                entity.HasIndex(e => e.IconidMaintenance, "sysmaps_elements_5");

                entity.Property(e => e.Selementid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("selementid");

                entity.Property(e => e.Application)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("application")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Areatype)
                    .HasColumnType("int(11)")
                    .HasColumnName("areatype");

                entity.Property(e => e.Elementid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("elementid");

                entity.Property(e => e.Elementsubtype)
                    .HasColumnType("int(11)")
                    .HasColumnName("elementsubtype");

                entity.Property(e => e.Elementtype)
                    .HasColumnType("int(11)")
                    .HasColumnName("elementtype");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height")
                    .HasDefaultValueSql("'200'");

                entity.Property(e => e.IconidDisabled)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("iconid_disabled");

                entity.Property(e => e.IconidMaintenance)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("iconid_maintenance");

                entity.Property(e => e.IconidOff)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("iconid_off");

                entity.Property(e => e.IconidOn)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("iconid_on");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("label")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LabelLocation)
                    .HasColumnType("int(11)")
                    .HasColumnName("label_location")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.Sysmapid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("sysmapid");

                entity.Property(e => e.UseIconmap)
                    .HasColumnType("int(11)")
                    .HasColumnName("use_iconmap")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Viewtype)
                    .HasColumnType("int(11)")
                    .HasColumnName("viewtype");

                entity.Property(e => e.Width)
                    .HasColumnType("int(11)")
                    .HasColumnName("width")
                    .HasDefaultValueSql("'200'");

                entity.Property(e => e.X)
                    .HasColumnType("int(11)")
                    .HasColumnName("x");

                entity.Property(e => e.Y)
                    .HasColumnType("int(11)")
                    .HasColumnName("y");

                entity.HasOne(d => d.IconidDisabledNavigation)
                    .WithMany(p => p.SysmapsElementIconidDisabledNavigations)
                    .HasForeignKey(d => d.IconidDisabled)
                    .HasConstraintName("c_sysmaps_elements_4");

                entity.HasOne(d => d.IconidMaintenanceNavigation)
                    .WithMany(p => p.SysmapsElementIconidMaintenanceNavigations)
                    .HasForeignKey(d => d.IconidMaintenance)
                    .HasConstraintName("c_sysmaps_elements_5");

                entity.HasOne(d => d.IconidOffNavigation)
                    .WithMany(p => p.SysmapsElementIconidOffNavigations)
                    .HasForeignKey(d => d.IconidOff)
                    .HasConstraintName("c_sysmaps_elements_2");

                entity.HasOne(d => d.IconidOnNavigation)
                    .WithMany(p => p.SysmapsElementIconidOnNavigations)
                    .HasForeignKey(d => d.IconidOn)
                    .HasConstraintName("c_sysmaps_elements_3");

                entity.HasOne(d => d.Sysmap)
                    .WithMany(p => p.SysmapsElements)
                    .HasForeignKey(d => d.Sysmapid)
                    .HasConstraintName("c_sysmaps_elements_1");
            });

            modelBuilder.Entity<SysmapsLink>(entity =>
            {
                entity.HasKey(e => e.Linkid)
                    .HasName("PRIMARY");

                entity.ToTable("sysmaps_links");

                entity.HasIndex(e => e.Sysmapid, "sysmaps_links_1");

                entity.HasIndex(e => e.Selementid1, "sysmaps_links_2");

                entity.HasIndex(e => e.Selementid2, "sysmaps_links_3");

                entity.Property(e => e.Linkid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("linkid");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("color")
                    .HasDefaultValueSql("'000000'");

                entity.Property(e => e.Drawtype)
                    .HasColumnType("int(11)")
                    .HasColumnName("drawtype");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("label")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Selementid1)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("selementid1");

                entity.Property(e => e.Selementid2)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("selementid2");

                entity.Property(e => e.Sysmapid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("sysmapid");

                entity.HasOne(d => d.Selementid1Navigation)
                    .WithMany(p => p.SysmapsLinkSelementid1Navigations)
                    .HasForeignKey(d => d.Selementid1)
                    .HasConstraintName("c_sysmaps_links_2");

                entity.HasOne(d => d.Selementid2Navigation)
                    .WithMany(p => p.SysmapsLinkSelementid2Navigations)
                    .HasForeignKey(d => d.Selementid2)
                    .HasConstraintName("c_sysmaps_links_3");

                entity.HasOne(d => d.Sysmap)
                    .WithMany(p => p.SysmapsLinks)
                    .HasForeignKey(d => d.Sysmapid)
                    .HasConstraintName("c_sysmaps_links_1");
            });

            modelBuilder.Entity<SysmapsLinkTrigger>(entity =>
            {
                entity.HasKey(e => e.Linktriggerid)
                    .HasName("PRIMARY");

                entity.ToTable("sysmaps_link_triggers");

                entity.HasIndex(e => new { e.Linkid, e.Triggerid }, "sysmaps_link_triggers_1")
                    .IsUnique();

                entity.HasIndex(e => e.Triggerid, "sysmaps_link_triggers_2");

                entity.Property(e => e.Linktriggerid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("linktriggerid");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("color")
                    .HasDefaultValueSql("'000000'");

                entity.Property(e => e.Drawtype)
                    .HasColumnType("int(11)")
                    .HasColumnName("drawtype");

                entity.Property(e => e.Linkid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("linkid");

                entity.Property(e => e.Triggerid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("triggerid");

                entity.HasOne(d => d.Link)
                    .WithMany(p => p.SysmapsLinkTriggers)
                    .HasForeignKey(d => d.Linkid)
                    .HasConstraintName("c_sysmaps_link_triggers_1");

                entity.HasOne(d => d.Trigger)
                    .WithMany(p => p.SysmapsLinkTriggers)
                    .HasForeignKey(d => d.Triggerid)
                    .HasConstraintName("c_sysmaps_link_triggers_2");
            });

            modelBuilder.Entity<TagFilter>(entity =>
            {
                entity.ToTable("tag_filter");

                entity.HasIndex(e => e.Usrgrpid, "c_tag_filter_1");

                entity.HasIndex(e => e.Groupid, "c_tag_filter_2");

                entity.Property(e => e.TagFilterid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("tag_filterid");

                entity.Property(e => e.Groupid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("groupid");

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("tag")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Usrgrpid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("usrgrpid");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TagFilters)
                    .HasForeignKey(d => d.Groupid)
                    .HasConstraintName("c_tag_filter_2");

                entity.HasOne(d => d.Usrgrp)
                    .WithMany(p => p.TagFilters)
                    .HasForeignKey(d => d.Usrgrpid)
                    .HasConstraintName("c_tag_filter_1");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("task");

                entity.HasIndex(e => e.ProxyHostid, "c_task_1");

                entity.HasIndex(e => new { e.Status, e.ProxyHostid }, "task_1");

                entity.Property(e => e.Taskid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("taskid");

                entity.Property(e => e.Clock)
                    .HasColumnType("int(11)")
                    .HasColumnName("clock");

                entity.Property(e => e.ProxyHostid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("proxy_hostid");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.Property(e => e.Ttl)
                    .HasColumnType("int(11)")
                    .HasColumnName("ttl");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.HasOne(d => d.ProxyHost)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.ProxyHostid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_task_1");
            });

            modelBuilder.Entity<TaskAcknowledge>(entity =>
            {
                entity.HasKey(e => e.Taskid)
                    .HasName("PRIMARY");

                entity.ToTable("task_acknowledge");

                entity.Property(e => e.Taskid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("taskid");

                entity.Property(e => e.Acknowledgeid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("acknowledgeid");

                entity.HasOne(d => d.Task)
                    .WithOne(p => p.TaskAcknowledge)
                    .HasForeignKey<TaskAcknowledge>(d => d.Taskid)
                    .HasConstraintName("c_task_acknowledge_1");
            });

            modelBuilder.Entity<TaskCheckNow>(entity =>
            {
                entity.HasKey(e => e.Taskid)
                    .HasName("PRIMARY");

                entity.ToTable("task_check_now");

                entity.Property(e => e.Taskid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("taskid");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.HasOne(d => d.Task)
                    .WithOne(p => p.TaskCheckNow)
                    .HasForeignKey<TaskCheckNow>(d => d.Taskid)
                    .HasConstraintName("c_task_check_now_1");
            });

            modelBuilder.Entity<TaskCloseProblem>(entity =>
            {
                entity.HasKey(e => e.Taskid)
                    .HasName("PRIMARY");

                entity.ToTable("task_close_problem");

                entity.Property(e => e.Taskid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("taskid");

                entity.Property(e => e.Acknowledgeid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("acknowledgeid");

                entity.HasOne(d => d.Task)
                    .WithOne(p => p.TaskCloseProblem)
                    .HasForeignKey<TaskCloseProblem>(d => d.Taskid)
                    .HasConstraintName("c_task_close_problem_1");
            });

            modelBuilder.Entity<TaskDatum>(entity =>
            {
                entity.HasKey(e => e.Taskid)
                    .HasName("PRIMARY");

                entity.ToTable("task_data");

                entity.Property(e => e.Taskid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("taskid");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("data");

                entity.Property(e => e.ParentTaskid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("parent_taskid");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.HasOne(d => d.Task)
                    .WithOne(p => p.TaskDatum)
                    .HasForeignKey<TaskDatum>(d => d.Taskid)
                    .HasConstraintName("c_task_data_1");
            });

            modelBuilder.Entity<TaskRemoteCommand>(entity =>
            {
                entity.HasKey(e => e.Taskid)
                    .HasName("PRIMARY");

                entity.ToTable("task_remote_command");

                entity.Property(e => e.Taskid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("taskid");

                entity.Property(e => e.Alertid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("alertid");

                entity.Property(e => e.Authtype)
                    .HasColumnType("int(11)")
                    .HasColumnName("authtype");

                entity.Property(e => e.Command)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("command");

                entity.Property(e => e.CommandType)
                    .HasColumnType("int(11)")
                    .HasColumnName("command_type");

                entity.Property(e => e.ExecuteOn)
                    .HasColumnType("int(11)")
                    .HasColumnName("execute_on");

                entity.Property(e => e.Hostid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("hostid");

                entity.Property(e => e.ParentTaskid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("parent_taskid");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("password")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Port)
                    .HasColumnType("int(11)")
                    .HasColumnName("port");

                entity.Property(e => e.Privatekey)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("privatekey")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Publickey)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("publickey")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("username")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Task)
                    .WithOne(p => p.TaskRemoteCommand)
                    .HasForeignKey<TaskRemoteCommand>(d => d.Taskid)
                    .HasConstraintName("c_task_remote_command_1");
            });

            modelBuilder.Entity<TaskRemoteCommandResult>(entity =>
            {
                entity.HasKey(e => e.Taskid)
                    .HasName("PRIMARY");

                entity.ToTable("task_remote_command_result");

                entity.Property(e => e.Taskid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("taskid");

                entity.Property(e => e.Info)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("info");

                entity.Property(e => e.ParentTaskid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("parent_taskid");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.HasOne(d => d.Task)
                    .WithOne(p => p.TaskRemoteCommandResult)
                    .HasForeignKey<TaskRemoteCommandResult>(d => d.Taskid)
                    .HasConstraintName("c_task_remote_command_result_1");
            });

            modelBuilder.Entity<TaskResult>(entity =>
            {
                entity.HasKey(e => e.Taskid)
                    .HasName("PRIMARY");

                entity.ToTable("task_result");

                entity.HasIndex(e => e.ParentTaskid, "task_result_1");

                entity.Property(e => e.Taskid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("taskid");

                entity.Property(e => e.Info)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("info");

                entity.Property(e => e.ParentTaskid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("parent_taskid");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.HasOne(d => d.Task)
                    .WithOne(p => p.TaskResult)
                    .HasForeignKey<TaskResult>(d => d.Taskid)
                    .HasConstraintName("c_task_result_1");
            });

            modelBuilder.Entity<Timeperiod>(entity =>
            {
                entity.ToTable("timeperiods");

                entity.Property(e => e.Timeperiodid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("timeperiodid");

                entity.Property(e => e.Day)
                    .HasColumnType("int(11)")
                    .HasColumnName("day");

                entity.Property(e => e.Dayofweek)
                    .HasColumnType("int(11)")
                    .HasColumnName("dayofweek");

                entity.Property(e => e.Every)
                    .HasColumnType("int(11)")
                    .HasColumnName("every")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Month)
                    .HasColumnType("int(11)")
                    .HasColumnName("month");

                entity.Property(e => e.Period)
                    .HasColumnType("int(11)")
                    .HasColumnName("period");

                entity.Property(e => e.StartDate)
                    .HasColumnType("int(11)")
                    .HasColumnName("start_date");

                entity.Property(e => e.StartTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("start_time");

                entity.Property(e => e.TimeperiodType)
                    .HasColumnType("int(11)")
                    .HasColumnName("timeperiod_type");
            });

            modelBuilder.Entity<Trend>(entity =>
            {
                entity.HasKey(e => new { e.Itemid, e.Clock })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("trends");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.Property(e => e.Clock)
                    .HasColumnType("int(11)")
                    .HasColumnName("clock");

                entity.Property(e => e.Num)
                    .HasColumnType("int(11)")
                    .HasColumnName("num");

                entity.Property(e => e.ValueAvg).HasColumnName("value_avg");

                entity.Property(e => e.ValueMax).HasColumnName("value_max");

                entity.Property(e => e.ValueMin).HasColumnName("value_min");
            });

            modelBuilder.Entity<TrendsUint>(entity =>
            {
                entity.HasKey(e => new { e.Itemid, e.Clock })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("trends_uint");

                entity.Property(e => e.Itemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("itemid");

                entity.Property(e => e.Clock)
                    .HasColumnType("int(11)")
                    .HasColumnName("clock");

                entity.Property(e => e.Num)
                    .HasColumnType("int(11)")
                    .HasColumnName("num");

                entity.Property(e => e.ValueAvg)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("value_avg");

                entity.Property(e => e.ValueMax)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("value_max");

                entity.Property(e => e.ValueMin)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("value_min");
            });

            modelBuilder.Entity<Trigger>(entity =>
            {
                entity.ToTable("triggers");

                entity.HasIndex(e => e.Status, "triggers_1");

                entity.HasIndex(e => new { e.Value, e.Lastchange }, "triggers_2");

                entity.HasIndex(e => e.Templateid, "triggers_3");

                entity.Property(e => e.Triggerid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("triggerid");

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("comments");

                entity.Property(e => e.CorrelationMode)
                    .HasColumnType("int(11)")
                    .HasColumnName("correlation_mode");

                entity.Property(e => e.CorrelationTag)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("correlation_tag")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("description")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Discover)
                    .HasColumnType("int(11)")
                    .HasColumnName("discover");

                entity.Property(e => e.Error)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("error")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("event_name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Expression)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("expression")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Flags)
                    .HasColumnType("int(11)")
                    .HasColumnName("flags");

                entity.Property(e => e.Lastchange)
                    .HasColumnType("int(11)")
                    .HasColumnName("lastchange");

                entity.Property(e => e.ManualClose)
                    .HasColumnType("int(11)")
                    .HasColumnName("manual_close");

                entity.Property(e => e.Opdata)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("opdata")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Priority)
                    .HasColumnType("int(11)")
                    .HasColumnName("priority");

                entity.Property(e => e.RecoveryExpression)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("recovery_expression")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.RecoveryMode)
                    .HasColumnType("int(11)")
                    .HasColumnName("recovery_mode");

                entity.Property(e => e.State)
                    .HasColumnType("int(11)")
                    .HasColumnName("state");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.Property(e => e.Templateid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("templateid");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("url")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Value)
                    .HasColumnType("int(11)")
                    .HasColumnName("value");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.InverseTemplate)
                    .HasForeignKey(d => d.Templateid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_triggers_1");
            });

            modelBuilder.Entity<TriggerDepend>(entity =>
            {
                entity.HasKey(e => e.Triggerdepid)
                    .HasName("PRIMARY");

                entity.ToTable("trigger_depends");

                entity.HasIndex(e => new { e.TriggeridDown, e.TriggeridUp }, "trigger_depends_1")
                    .IsUnique();

                entity.HasIndex(e => e.TriggeridUp, "trigger_depends_2");

                entity.Property(e => e.Triggerdepid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("triggerdepid");

                entity.Property(e => e.TriggeridDown)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("triggerid_down");

                entity.Property(e => e.TriggeridUp)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("triggerid_up");

                entity.HasOne(d => d.TriggeridDownNavigation)
                    .WithMany(p => p.TriggerDependTriggeridDownNavigations)
                    .HasForeignKey(d => d.TriggeridDown)
                    .HasConstraintName("c_trigger_depends_1");

                entity.HasOne(d => d.TriggeridUpNavigation)
                    .WithMany(p => p.TriggerDependTriggeridUpNavigations)
                    .HasForeignKey(d => d.TriggeridUp)
                    .HasConstraintName("c_trigger_depends_2");
            });

            modelBuilder.Entity<TriggerDiscovery>(entity =>
            {
                entity.HasKey(e => e.Triggerid)
                    .HasName("PRIMARY");

                entity.ToTable("trigger_discovery");

                entity.HasIndex(e => e.ParentTriggerid, "trigger_discovery_1");

                entity.Property(e => e.Triggerid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("triggerid");

                entity.Property(e => e.Lastcheck)
                    .HasColumnType("int(11)")
                    .HasColumnName("lastcheck");

                entity.Property(e => e.ParentTriggerid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("parent_triggerid");

                entity.Property(e => e.TsDelete)
                    .HasColumnType("int(11)")
                    .HasColumnName("ts_delete");

                entity.HasOne(d => d.ParentTrigger)
                    .WithMany(p => p.TriggerDiscoveryParentTriggers)
                    .HasForeignKey(d => d.ParentTriggerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("c_trigger_discovery_2");

                entity.HasOne(d => d.Trigger)
                    .WithOne(p => p.TriggerDiscoveryTrigger)
                    .HasForeignKey<TriggerDiscovery>(d => d.Triggerid)
                    .HasConstraintName("c_trigger_discovery_1");
            });

            modelBuilder.Entity<TriggerQueue>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("trigger_queue");

                entity.Property(e => e.Clock)
                    .HasColumnType("int(11)")
                    .HasColumnName("clock");

                entity.Property(e => e.Ns)
                    .HasColumnType("int(11)")
                    .HasColumnName("ns");

                entity.Property(e => e.Objectid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("objectid");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");
            });

            modelBuilder.Entity<TriggerTag>(entity =>
            {
                entity.ToTable("trigger_tag");

                entity.HasIndex(e => e.Triggerid, "trigger_tag_1");

                entity.Property(e => e.Triggertagid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("triggertagid");

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("tag")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Triggerid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("triggerid");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Trigger)
                    .WithMany(p => p.TriggerTags)
                    .HasForeignKey(d => d.Triggerid)
                    .HasConstraintName("c_trigger_tag_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Roleid, "c_users_1");

                entity.HasIndex(e => e.Alias, "users_1")
                    .IsUnique();

                entity.Property(e => e.Userid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("userid");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("alias")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.AttemptClock)
                    .HasColumnType("int(11)")
                    .HasColumnName("attempt_clock");

                entity.Property(e => e.AttemptFailed)
                    .HasColumnType("int(11)")
                    .HasColumnName("attempt_failed");

                entity.Property(e => e.AttemptIp)
                    .IsRequired()
                    .HasMaxLength(39)
                    .HasColumnName("attempt_ip")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Autologin)
                    .HasColumnType("int(11)")
                    .HasColumnName("autologin");

                entity.Property(e => e.Autologout)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("autologout")
                    .HasDefaultValueSql("'15m'");

                entity.Property(e => e.Lang)
                    .IsRequired()
                    .HasMaxLength(7)
                    .HasColumnName("lang")
                    .HasDefaultValueSql("'default'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Passwd)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("passwd")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Refresh)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("refresh")
                    .HasDefaultValueSql("'30s'");

                entity.Property(e => e.Roleid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("roleid");

                entity.Property(e => e.RowsPerPage)
                    .HasColumnType("int(11)")
                    .HasColumnName("rows_per_page")
                    .HasDefaultValueSql("'50'");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("surname")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Theme)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("theme")
                    .HasDefaultValueSql("'default'");

                entity.Property(e => e.Timezone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("timezone")
                    .HasDefaultValueSql("'default'");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("url")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Roleid)
                    .HasConstraintName("c_users_1");
            });

            modelBuilder.Entity<UsersGroup>(entity =>
            {
                entity.ToTable("users_groups");

                entity.HasIndex(e => new { e.Usrgrpid, e.Userid }, "users_groups_1")
                    .IsUnique();

                entity.HasIndex(e => e.Userid, "users_groups_2");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Userid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("userid");

                entity.Property(e => e.Usrgrpid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("usrgrpid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersGroups)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("c_users_groups_2");

                entity.HasOne(d => d.Usrgrp)
                    .WithMany(p => p.UsersGroups)
                    .HasForeignKey(d => d.Usrgrpid)
                    .HasConstraintName("c_users_groups_1");
            });

            modelBuilder.Entity<Usrgrp>(entity =>
            {
                entity.ToTable("usrgrp");

                entity.HasIndex(e => e.Name, "usrgrp_1")
                    .IsUnique();

                entity.Property(e => e.Usrgrpid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("usrgrpid");

                entity.Property(e => e.DebugMode)
                    .HasColumnType("int(11)")
                    .HasColumnName("debug_mode");

                entity.Property(e => e.GuiAccess)
                    .HasColumnType("int(11)")
                    .HasColumnName("gui_access");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UsersStatus)
                    .HasColumnType("int(11)")
                    .HasColumnName("users_status");
            });

            modelBuilder.Entity<Valuemap>(entity =>
            {
                entity.ToTable("valuemaps");

                entity.HasIndex(e => e.Name, "valuemaps_1")
                    .IsUnique();

                entity.Property(e => e.Valuemapid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("valuemapid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Widget>(entity =>
            {
                entity.ToTable("widget");

                entity.HasIndex(e => e.Dashboardid, "widget_1");

                entity.Property(e => e.Widgetid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("widgetid");

                entity.Property(e => e.Dashboardid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("dashboardid");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("type")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ViewMode)
                    .HasColumnType("int(11)")
                    .HasColumnName("view_mode");

                entity.Property(e => e.Width)
                    .HasColumnType("int(11)")
                    .HasColumnName("width")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.X)
                    .HasColumnType("int(11)")
                    .HasColumnName("x");

                entity.Property(e => e.Y)
                    .HasColumnType("int(11)")
                    .HasColumnName("y");

                entity.HasOne(d => d.Dashboard)
                    .WithMany(p => p.Widgets)
                    .HasForeignKey(d => d.Dashboardid)
                    .HasConstraintName("c_widget_1");
            });

            modelBuilder.Entity<WidgetField>(entity =>
            {
                entity.ToTable("widget_field");

                entity.HasIndex(e => e.Widgetid, "widget_field_1");

                entity.HasIndex(e => e.ValueGroupid, "widget_field_2");

                entity.HasIndex(e => e.ValueHostid, "widget_field_3");

                entity.HasIndex(e => e.ValueItemid, "widget_field_4");

                entity.HasIndex(e => e.ValueGraphid, "widget_field_5");

                entity.HasIndex(e => e.ValueSysmapid, "widget_field_6");

                entity.Property(e => e.WidgetFieldid)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("widget_fieldid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.Property(e => e.ValueGraphid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("value_graphid");

                entity.Property(e => e.ValueGroupid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("value_groupid");

                entity.Property(e => e.ValueHostid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("value_hostid");

                entity.Property(e => e.ValueInt)
                    .HasColumnType("int(11)")
                    .HasColumnName("value_int");

                entity.Property(e => e.ValueItemid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("value_itemid");

                entity.Property(e => e.ValueStr)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("value_str")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ValueSysmapid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("value_sysmapid");

                entity.Property(e => e.Widgetid)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("widgetid");

                entity.HasOne(d => d.ValueGraph)
                    .WithMany(p => p.WidgetFields)
                    .HasForeignKey(d => d.ValueGraphid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_widget_field_5");

                entity.HasOne(d => d.ValueGroup)
                    .WithMany(p => p.WidgetFields)
                    .HasForeignKey(d => d.ValueGroupid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_widget_field_2");

                entity.HasOne(d => d.ValueHost)
                    .WithMany(p => p.WidgetFields)
                    .HasForeignKey(d => d.ValueHostid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_widget_field_3");

                entity.HasOne(d => d.ValueItem)
                    .WithMany(p => p.WidgetFields)
                    .HasForeignKey(d => d.ValueItemid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_widget_field_4");

                entity.HasOne(d => d.ValueSysmap)
                    .WithMany(p => p.WidgetFields)
                    .HasForeignKey(d => d.ValueSysmapid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("c_widget_field_6");

                entity.HasOne(d => d.Widget)
                    .WithMany(p => p.WidgetFields)
                    .HasForeignKey(d => d.Widgetid)
                    .HasConstraintName("c_widget_field_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

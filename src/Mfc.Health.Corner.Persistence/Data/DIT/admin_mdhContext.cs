using System;
using Mfc.Health.Corner.Domain.DITModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace Mfc.Health.Corner.Persistence.Data.DIT
{
    public partial class admin_mdhContext : Microsoft.EntityFrameworkCore.DbContext
    {
        IConfiguration _configuration;
        public admin_mdhContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public admin_mdhContext(DbContextOptions<admin_mdhContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DblkAnalyzer> DblkAnalyzers { get; set; }
        public virtual DbSet<DblkBpbio> DblkBpbios { get; set; }
        public virtual DbSet<DblkClient> DblkClients { get; set; }
        public virtual DbSet<DblkComplex> DblkComplices { get; set; }
        public virtual DbSet<DblkContent> DblkContents { get; set; }
        public virtual DbSet<DblkError> DblkErrors { get; set; }
        public virtual DbSet<DblkGaz> DblkGazs { get; set; }
        public virtual DbSet<DblkIgroup> DblkIgroups { get; set; }
        public virtual DbSet<DblkIuser> DblkIusers { get; set; }
        public virtual DbSet<DblkIusersAdd> DblkIusersAdds { get; set; }
        public virtual DbSet<DblkIusersApplication> DblkIusersApplications { get; set; }
        public virtual DbSet<DblkIusersField> DblkIusersFields { get; set; }
        public virtual DbSet<DblkIusersFile> DblkIusersFiles { get; set; }
        public virtual DbSet<DblkIusersHasComplex> DblkIusersHasComplices { get; set; }
        public virtual DbSet<DblkLang> DblkLangs { get; set; }
        public virtual DbSet<DblkPatient> DblkPatients { get; set; }
        public virtual DbSet<DblkPulse> DblkPulses { get; set; }
        public virtual DbSet<DblkRedirect> DblkRedirects { get; set; }
        public virtual DbSet<DblkReference> DblkReferences { get; set; }
        public virtual DbSet<DblkSetting> DblkSettings { get; set; }
        public virtual DbSet<DblkSite> DblkSites { get; set; }
        public virtual DbSet<DblkStat> DblkStats { get; set; }
        public virtual DbSet<DblkTranslator> DblkTranslators { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(_configuration.GetConnectionString("DITConnectionString"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.28-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<DblkAnalyzer>(entity =>
            {
                entity.ToTable("dblk_analyzer");

                entity.HasIndex(e => new { e.Iuser, e.InBodyId, e.EquipSerial }, "iuser");

                entity.HasIndex(e => e.Iuser, "iuser_2");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("cdate");

                entity.Property(e => e.Client)
                    .HasColumnType("int(11)")
                    .HasColumnName("client");

                entity.Property(e => e.Complex)
                    .HasColumnType("int(11)")
                    .HasColumnName("complex");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("data");

                entity.Property(e => e.EquipSerial)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Equip_Serial");

                entity.Property(e => e.EquipType)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.InBodyData)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.InBodyId)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Iuser)
                    .HasColumnType("int(11)")
                    .HasColumnName("iuser");
            });

            modelBuilder.Entity<DblkBpbio>(entity =>
            {
                entity.ToTable("dblk_bpbio");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("cdate");

                entity.Property(e => e.Client)
                    .HasColumnType("int(11)")
                    .HasColumnName("client");

                entity.Property(e => e.Complex)
                    .HasColumnType("int(11)")
                    .HasColumnName("complex");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("data");

                entity.Property(e => e.Diastolic)
                    .HasColumnType("int(11)")
                    .HasColumnName("diastolic");

                entity.Property(e => e.Iuser)
                    .HasColumnType("int(11)")
                    .HasColumnName("iuser");

                entity.Property(e => e.Pulse)
                    .HasColumnType("int(11)")
                    .HasColumnName("pulse");

                entity.Property(e => e.Results)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("results");

                entity.Property(e => e.Systolic)
                    .HasColumnType("int(11)")
                    .HasColumnName("systolic");
            });

            modelBuilder.Entity<DblkClient>(entity =>
            {
                entity.ToTable("dblk_clients");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Age)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("age");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("cdate");

                entity.Property(e => e.Complex)
                    .HasColumnType("int(11)")
                    .HasColumnName("complex");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("data");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("gender");

                entity.Property(e => e.InBodyId)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Iuser)
                    .HasColumnType("int(11)")
                    .HasColumnName("iuser");

                entity.Property(e => e.Oms)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("oms");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("phone");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<DblkComplex>(entity =>
            {
                entity.ToTable("dblk_complex");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.Analyzer).HasColumnName("ANALYZER");

                entity.Property(e => e.Area)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("area");

                entity.Property(e => e.Author)
                    .HasColumnType("int(11)")
                    .HasColumnName("author");

                entity.Property(e => e.Bpbio).HasColumnName("BPBIO");

                entity.Property(e => e.Bsm).HasColumnName("BSM");

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("cdate");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Dop)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dop");

                entity.Property(e => e.Expert)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("expert");

                entity.Property(e => e.Gaz).HasColumnName("GAZ");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("ip");

                entity.Property(e => e.Iuser)
                    .HasColumnType("int(11)")
                    .HasColumnName("iuser");

                entity.Property(e => e.Latitude)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("latitude");

                entity.Property(e => e.Ldate)
                    .HasColumnType("datetime")
                    .HasColumnName("ldate");

                entity.Property(e => e.Longitude)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("longitude");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Parent)
                    .HasColumnType("int(11)")
                    .HasColumnName("parent");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("path");

                entity.Property(e => e.Pulse).HasColumnName("PULSE");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("status");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("token");
            });

            modelBuilder.Entity<DblkContent>(entity =>
            {
                entity.ToTable("dblk_content");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Author)
                    .HasColumnType("int(11)")
                    .HasColumnName("author");

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("cdate");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Dop)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("dop");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Parent)
                    .HasColumnType("int(11)")
                    .HasColumnName("parent");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("path");

                entity.Property(e => e.Pic)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("pic");

                entity.Property(e => e.Preview)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("preview");

                entity.Property(e => e.Sort)
                    .HasColumnType("int(11)")
                    .HasColumnName("sort");

                entity.Property(e => e.Udate)
                    .HasColumnType("date")
                    .HasColumnName("udate");

                entity.Property(e => e.Visible).HasColumnName("visible");
            });

            modelBuilder.Entity<DblkError>(entity =>
            {
                entity.ToTable("dblk_errors");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Analyzer).HasColumnName("analyzer");

                entity.Property(e => e.Bpbio).HasColumnName("bpbio");

                entity.Property(e => e.Bsm).HasColumnName("bsm");

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("cdate");

                entity.Property(e => e.Complex)
                    .HasColumnType("int(11)")
                    .HasColumnName("complex");

                entity.Property(e => e.Device).HasColumnName("device");

                entity.Property(e => e.Fdate)
                    .HasColumnType("datetime")
                    .HasColumnName("fdate");

                entity.Property(e => e.Gaz).HasColumnName("gaz");

                entity.Property(e => e.Pulse).HasColumnName("pulse");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<DblkGaz>(entity =>
            {
                entity.ToTable("dblk_gaz");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("cdate");

                entity.Property(e => e.Client)
                    .HasColumnType("int(11)")
                    .HasColumnName("client");

                entity.Property(e => e.Cohb)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("cohb");

                entity.Property(e => e.Complex)
                    .HasColumnType("int(11)")
                    .HasColumnName("complex");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("data");

                entity.Property(e => e.Iuser)
                    .HasColumnType("int(11)")
                    .HasColumnName("iuser");

                entity.Property(e => e.Ppmco)
                    .HasColumnType("int(11)")
                    .HasColumnName("ppmco");
            });

            modelBuilder.Entity<DblkIgroup>(entity =>
            {
                entity.ToTable("dblk_igroups");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("path");
            });

            modelBuilder.Entity<DblkIuser>(entity =>
            {
                entity.ToTable("dblk_iusers");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Author)
                    .HasColumnType("int(11)")
                    .HasColumnName("author");

                entity.Property(e => e.Avatar)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("avatar");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("cdate");

                entity.Property(e => e.Changepasstoken)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("changepasstoken");

                entity.Property(e => e.Edate)
                    .HasColumnType("datetime")
                    .HasColumnName("edate");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Expdate)
                    .HasColumnType("datetime")
                    .HasColumnName("expdate");

                entity.Property(e => e.Fb)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fb");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("gender");

                entity.Property(e => e.Go)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("go");

                entity.Property(e => e.Igroup)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("igroup");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("ip");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("language");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.Property(e => e.Ldate)
                    .HasColumnType("datetime")
                    .HasColumnName("ldate");

                entity.Property(e => e.Li)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("li");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("login");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("pass");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("phone");

                entity.Property(e => e.Removed).HasColumnName("removed");

                entity.Property(e => e.Scanner)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("scanner");

                entity.Property(e => e.Secondname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("secondname");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("token");

                entity.Property(e => e.Tw)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tw");

                entity.Property(e => e.Visible).HasColumnName("visible");

                entity.Property(e => e.Vk)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("vk");

                entity.Property(e => e.Ya)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ya");
            });

            modelBuilder.Entity<DblkIusersAdd>(entity =>
            {
                entity.ToTable("dblk_iusers_adds");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Cdate)
                    .HasColumnType("date")
                    .HasColumnName("cdate");

                entity.Property(e => e.Coords)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("coords");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnType("mediumtext")
                    .HasColumnName("data");

                entity.Property(e => e.Fvalue).HasColumnName("fvalue");

                entity.Property(e => e.Iuser)
                    .HasColumnType("int(11)")
                    .HasColumnName("iuser");

                entity.Property(e => e.Model)
                    .HasColumnType("int(11)")
                    .HasColumnName("model");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Svalue)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("svalue");
            });

            modelBuilder.Entity<DblkIusersApplication>(entity =>
            {
                entity.ToTable("dblk_iusers_application");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Application)
                    .HasColumnType("int(11)")
                    .HasColumnName("application");

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("cdate");

                entity.Property(e => e.ExpDate)
                    .HasColumnType("int(11)")
                    .HasColumnName("exp_date");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("ip");

                entity.Property(e => e.Iuser)
                    .HasColumnType("int(11)")
                    .HasColumnName("iuser");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("token");
            });

            modelBuilder.Entity<DblkIusersField>(entity =>
            {
                entity.ToTable("dblk_iusers_fields");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Iuser)
                    .HasColumnType("int(11)")
                    .HasColumnName("iuser");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("path");
            });

            modelBuilder.Entity<DblkIusersFile>(entity =>
            {
                entity.ToTable("dblk_iusers_files");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Accuracy)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("accuracy");

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("cdate");

                entity.Property(e => e.Defmodel).HasColumnName("defmodel");

                entity.Property(e => e.Height)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("height");

                entity.Property(e => e.Iuser)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("iuser");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Orderprint)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("orderprint");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("path");

                entity.Property(e => e.Scanner)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("scanner");

                entity.Property(e => e.Weight)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("weight");
            });

            modelBuilder.Entity<DblkIusersHasComplex>(entity =>
            {
                entity.ToTable("dblk_iusers_has_complex");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Complex)
                    .HasColumnType("int(11)")
                    .HasColumnName("complex");

                entity.Property(e => e.Iuser)
                    .HasColumnType("int(11)")
                    .HasColumnName("iuser");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("role");
            });

            modelBuilder.Entity<DblkLang>(entity =>
            {
                entity.ToTable("dblk_lang");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<DblkPatient>(entity =>
            {
                entity.ToTable("dblk_patient");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("cdate");

                entity.Property(e => e.Client)
                    .HasColumnType("int(11)")
                    .HasColumnName("client");

                entity.Property(e => e.Complex)
                    .HasColumnType("int(11)")
                    .HasColumnName("complex");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("data");

                entity.Property(e => e.Iuser)
                    .HasColumnType("int(11)")
                    .HasColumnName("iuser");

                entity.Property(e => e.OmsNumber)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("omsNumber");
            });

            modelBuilder.Entity<DblkPulse>(entity =>
            {
                entity.ToTable("dblk_pulse");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("cdate");

                entity.Property(e => e.Client)
                    .HasColumnType("int(11)")
                    .HasColumnName("client");

                entity.Property(e => e.Complex)
                    .HasColumnType("int(11)")
                    .HasColumnName("complex");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("data");

                entity.Property(e => e.Iuser)
                    .HasColumnType("int(11)")
                    .HasColumnName("iuser");

                entity.Property(e => e.Pulse)
                    .HasColumnType("int(11)")
                    .HasColumnName("pulse");

                entity.Property(e => e.Spo2)
                    .HasColumnType("int(11)")
                    .HasColumnName("spo2");
            });

            modelBuilder.Entity<DblkRedirect>(entity =>
            {
                entity.ToTable("dblk_redirects");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Valfrom)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("valfrom");

                entity.Property(e => e.Valto)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("valto");
            });

            modelBuilder.Entity<DblkReference>(entity =>
            {
                entity.ToTable("dblk_reference");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Num)
                    .HasColumnType("int(11)")
                    .HasColumnName("num");

                entity.Property(e => e.Parent)
                    .HasColumnType("int(11)")
                    .HasColumnName("parent");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("path");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("type");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("value");

                entity.Property(e => e.Visible).HasColumnName("visible");
            });

            modelBuilder.Entity<DblkSetting>(entity =>
            {
                entity.ToTable("dblk_settings");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Num)
                    .HasColumnType("int(11)")
                    .HasColumnName("num");

                entity.Property(e => e.Parent)
                    .HasColumnType("int(11)")
                    .HasColumnName("parent");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("path");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("value");

                entity.Property(e => e.Visible).HasColumnName("visible");
            });

            modelBuilder.Entity<DblkSite>(entity =>
            {
                entity.ToTable("dblk_sites");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("domain");

                entity.Property(e => e.Lang)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("lang")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Parent)
                    .HasColumnType("int(11)")
                    .HasColumnName("parent");
            });

            modelBuilder.Entity<DblkStat>(entity =>
            {
                entity.ToTable("dblk_stats");

                entity.HasIndex(e => new { e.Complex, e.Cdate }, "complex");

                entity.HasIndex(e => e.Id, "id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("int(11)")
                    .HasColumnName("amount");

                entity.Property(e => e.Analyzer)
                    .HasColumnType("int(11)")
                    .HasColumnName("analyzer");

                entity.Property(e => e.Bpbio)
                    .HasColumnType("int(11)")
                    .HasColumnName("bpbio");

                entity.Property(e => e.Bsm)
                    .HasColumnType("int(11)")
                    .HasColumnName("bsm");

                entity.Property(e => e.Cdate)
                    .HasColumnType("date")
                    .HasColumnName("cdate");

                entity.Property(e => e.Complex)
                    .HasColumnType("int(11)")
                    .HasColumnName("complex");

                entity.Property(e => e.Gaz)
                    .HasColumnType("int(11)")
                    .HasColumnName("gaz");

                entity.Property(e => e.Oms)
                    .HasColumnType("int(11)")
                    .HasColumnName("oms");

                entity.Property(e => e.Patient)
                    .HasColumnType("int(11)")
                    .HasColumnName("patient");

                entity.Property(e => e.Pulse)
                    .HasColumnType("int(11)")
                    .HasColumnName("pulse");
            });

            modelBuilder.Entity<DblkTranslator>(entity =>
            {
                entity.ToTable("dblk_translator");

                entity.UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("cdate");

                entity.Property(e => e.Eng)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("eng");

                entity.Property(e => e.Ger)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("ger");

                entity.Property(e => e.Iuser)
                    .HasColumnType("int(11)")
                    .HasColumnName("iuser");

                entity.Property(e => e.Rus)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("rus");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

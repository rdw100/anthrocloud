using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AnthroCloud.Data.Models
{
    public partial class AnthroCloudContext : DbContext
    {
        public AnthroCloudContext()
        {
        }

        public AnthroCloudContext(DbContextOptions<AnthroCloudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BmiforAge> BmiforAge { get; set; }
        public virtual DbSet<HcforAge> HcforAge { get; set; }
        public virtual DbSet<LengthHeightForAge> LengthHeightForAge { get; set; }
        public virtual DbSet<MuacforAge> MuacforAge { get; set; }
        public virtual DbSet<SsfforAge> SsfforAge { get; set; }
        public virtual DbSet<TsfforAge> TsfforAge { get; set; }
        public virtual DbSet<WeightForAge> WeightForAge { get; set; }
        public virtual DbSet<WeightForHeight> WeightForHeight { get; set; }
        public virtual DbSet<WeightForLength> WeightForLength { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:anthrocloudsql.database.windows.net,1433;Initial Catalog=AnthroCloud;Persist Security Info=False;User ID=rudy;Password=W0rld0nF1r3;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BmiforAge>(entity =>
            {
                entity.HasKey(e => new { e.AgeInDays, e.Sex })
                    .HasName("PK_CompositePK_BMIForAge")
                    .IsClustered(false);

                entity.ToTable("BMIForAge");

                entity.Property(e => e.L).HasColumnType("decimal(5, 4)");

                entity.Property(e => e.M).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.P15).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P3).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P50).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P85).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P97).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.S).HasColumnType("decimal(6, 5)");

                entity.Property(e => e.Sd0)
                    .HasColumnName("SD0")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd1)
                    .HasColumnName("SD1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd1neg)
                    .HasColumnName("SD1neg")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd2)
                    .HasColumnName("SD2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd2neg)
                    .HasColumnName("SD2neg")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd3)
                    .HasColumnName("SD3")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd3neg)
                    .HasColumnName("SD3neg")
                    .HasColumnType("decimal(6, 3)");
            });

            modelBuilder.Entity<HcforAge>(entity =>
            {
                entity.HasKey(e => new { e.AgeInDays, e.Sex })
                    .HasName("PK_CompositePK_HCForAge")
                    .IsClustered(false);

                entity.ToTable("HCForAge");

                entity.Property(e => e.M).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.P15).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P3).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P50).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P85).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P97).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.S).HasColumnType("decimal(6, 5)");

                entity.Property(e => e.Sd0)
                    .HasColumnName("SD0")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd1)
                    .HasColumnName("SD1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd1neg)
                    .HasColumnName("SD1neg")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd2)
                    .HasColumnName("SD2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd2neg)
                    .HasColumnName("SD2neg")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd3)
                    .HasColumnName("SD3")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd3neg)
                    .HasColumnName("SD3neg")
                    .HasColumnType("decimal(6, 3)");
            });

            modelBuilder.Entity<LengthHeightForAge>(entity =>
            {
                entity.HasKey(e => new { e.AgeInDays, e.Sex })
                    .HasName("PK_CompositePK_LengthHeightForAge")
                    .IsClustered(false);

                entity.Property(e => e.M).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.P15).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P3).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P50).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P85).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P97).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.S).HasColumnType("decimal(6, 5)");

                entity.Property(e => e.Sd0)
                    .HasColumnName("SD0")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd2)
                    .HasColumnName("SD2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd2neg)
                    .HasColumnName("SD2neg")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd3)
                    .HasColumnName("SD3")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd3neg)
                    .HasColumnName("SD3neg")
                    .HasColumnType("decimal(6, 3)");
            });

            modelBuilder.Entity<MuacforAge>(entity =>
            {
                entity.HasKey(e => new { e.AgeInDays, e.Sex })
                    .HasName("PK_CompositePK_MUACForAge")
                    .IsClustered(false);

                entity.ToTable("MUACForAge");

                entity.Property(e => e.L).HasColumnType("decimal(5, 4)");

                entity.Property(e => e.M).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.P15).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P3).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P50).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P85).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P97).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.S).HasColumnType("decimal(6, 5)");

                entity.Property(e => e.Sd0)
                    .HasColumnName("SD0")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd1)
                    .HasColumnName("SD1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd1neg)
                    .HasColumnName("SD1neg")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd2)
                    .HasColumnName("SD2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd2neg)
                    .HasColumnName("SD2neg")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd3)
                    .HasColumnName("SD3")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd3neg)
                    .HasColumnName("SD3neg")
                    .HasColumnType("decimal(6, 3)");
            });

            modelBuilder.Entity<SsfforAge>(entity =>
            {
                entity.HasKey(e => new { e.AgeInDays, e.Sex })
                    .HasName("PK_Composite_PK_SSFForAge")
                    .IsClustered(false);

                entity.ToTable("SSFForAge");

                entity.Property(e => e.L).HasColumnType("decimal(5, 4)");

                entity.Property(e => e.M).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.P15).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P3).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P50).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P85).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P97).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.S).HasColumnType("decimal(6, 5)");

                entity.Property(e => e.Sd0)
                    .HasColumnName("SD0")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd1)
                    .HasColumnName("SD1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd1neg)
                    .HasColumnName("SD1neg")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd2)
                    .HasColumnName("SD2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd2neg)
                    .HasColumnName("SD2neg")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd3)
                    .HasColumnName("SD3")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd3neg)
                    .HasColumnName("SD3neg")
                    .HasColumnType("decimal(6, 3)");
            });

            modelBuilder.Entity<TsfforAge>(entity =>
            {
                entity.HasKey(e => new { e.AgeInDays, e.Sex })
                    .HasName("PK_CompositePK_TSFForAge")
                    .IsClustered(false);

                entity.ToTable("TSFForAge");

                entity.Property(e => e.L).HasColumnType("decimal(5, 4)");

                entity.Property(e => e.M).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.P15).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P3).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P50).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P85).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P97).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.S).HasColumnType("decimal(6, 5)");

                entity.Property(e => e.Sd0)
                    .HasColumnName("SD0")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd1)
                    .HasColumnName("SD1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd1neg)
                    .HasColumnName("SD1neg")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd2)
                    .HasColumnName("SD2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd2neg)
                    .HasColumnName("SD2neg")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd3)
                    .HasColumnName("SD3")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd3neg)
                    .HasColumnName("SD3neg")
                    .HasColumnType("decimal(6, 3)");
            });

            modelBuilder.Entity<WeightForAge>(entity =>
            {
                entity.HasKey(e => new { e.AgeInDays, e.Sex })
                    .HasName("PK_CompositePK_WeightForAge")
                    .IsClustered(false);

                entity.Property(e => e.L).HasColumnType("decimal(5, 4)");

                entity.Property(e => e.M).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.P15).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P3).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P50).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P85).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P97).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.S).HasColumnType("decimal(6, 5)");

                entity.Property(e => e.Sd0)
                    .HasColumnName("SD0")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd2)
                    .HasColumnName("SD2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd2neg)
                    .HasColumnName("SD2neg")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd3)
                    .HasColumnName("SD3")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd3neg)
                    .HasColumnName("SD3neg")
                    .HasColumnType("decimal(6, 3)");
            });

            modelBuilder.Entity<WeightForHeight>(entity =>
            {
                entity.HasKey(e => new { e.Sex, e.HeightInCm })
                    .HasName("PK_CompositePK_WeightForHeight")
                    .IsClustered(false);

                entity.Property(e => e.HeightInCm)
                    .HasColumnName("HeightInCM")
                    .HasColumnType("decimal(4, 1)");

                entity.Property(e => e.L).HasColumnType("decimal(5, 4)");

                entity.Property(e => e.M).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.P15).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P3).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P50).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P85).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P97).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.S).HasColumnType("decimal(6, 5)");

                entity.Property(e => e.Sd0)
                    .HasColumnName("SD0")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd1)
                    .HasColumnName("SD1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd1neg)
                    .HasColumnName("SD1neg")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd2)
                    .HasColumnName("SD2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd2neg)
                    .HasColumnName("SD2neg")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd3)
                    .HasColumnName("SD3")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd3neg)
                    .HasColumnName("SD3neg")
                    .HasColumnType("decimal(6, 3)");
            });

            modelBuilder.Entity<WeightForLength>(entity =>
            {
                entity.HasKey(e => new { e.Sex, e.LengthInCm })
                    .HasName("PK_CompositePK_WeightForLength")
                    .IsClustered(false);

                entity.Property(e => e.LengthInCm)
                    .HasColumnName("LengthInCM")
                    .HasColumnType("decimal(4, 1)");

                entity.Property(e => e.L).HasColumnType("decimal(5, 4)");

                entity.Property(e => e.M).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.P15).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P3).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P50).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P85).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.P97).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.S).HasColumnType("decimal(6, 5)");

                entity.Property(e => e.Sd0)
                    .HasColumnName("SD0")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd1)
                    .HasColumnName("SD1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd1neg)
                    .HasColumnName("SD1neg")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd2)
                    .HasColumnName("SD2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd2neg)
                    .HasColumnName("SD2neg")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd3)
                    .HasColumnName("SD3")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Sd3neg)
                    .HasColumnName("SD3neg")
                    .HasColumnType("decimal(6, 3)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using Microsoft.EntityFrameworkCore;
using System;

namespace AnthroCloud.Entities
{
    public class AssessmentContext : DbContext
    {
        public AssessmentContext()
        {
        }

        public AssessmentContext(DbContextOptions<AssessmentContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Measure> Measures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AnthroCloudDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.HasIndex(e => e.PatientId, "IX_Visits_PatientId");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.PatientId);
            });

            modelBuilder.Entity<Measure>()
                .HasKey(m => new { m.MeasureId, m.Name });

            modelBuilder.Entity<Visit>()
                .HasOne(p => p.Patient)
                .WithMany(v => v.Visits);

            modelBuilder.Entity<Visit>()
                .HasMany(m => m.Measures);

            modelBuilder.Entity<Patient>()
                .HasData(
                    new Patient()
                    {
                        PatientId = 1,
                        FirstName = "John",
                        LastName = "Smith",
                        DateOfBirth = DateTime.Today.AddYears(-1),
                        Sex = Sexes.Male
                    },
                    new Patient()
                    {
                        PatientId = 2,
                        FirstName = "Juana",
                        LastName = "Diaz",
                        DateOfBirth = DateTime.Today.AddYears(-2),
                        Sex = Sexes.Female
                    }
                );

            modelBuilder.Entity<Visit>()
                .HasData(
                    new Visit()
                    {
                        VisitId = 1,
                        PatientId = 1,
                        Weight = 16,
                        LengthHeight = 18,
                        DateOfVisit = DateTime.Today.AddMonths(-9),
                        Oedema = OedemaTypes.No,
                        Measured = MeasurementTypes.Recumbent,
                        HeadCircumference = 38.90,
                        MUAC = 11.2,
                        TricepsSkinFold = 5.5,
                        SubscapularSkinFold = 4.6
                    },
                    new Visit()
                    {
                        VisitId = 2,
                        PatientId = 1,
                        Weight = 20,
                        LengthHeight = 23,
                        DateOfVisit = DateTime.Today.AddMonths(-3),
                        Oedema = OedemaTypes.Yes,
                        Measured = MeasurementTypes.Recumbent,
                        HeadCircumference = 40.3,
                        MUAC = 11.4,
                        TricepsSkinFold = 5.2,
                        SubscapularSkinFold = 4.4
                    },
                    new Visit()
                    {
                        VisitId = 3,
                        PatientId = 2,
                        Weight = 26,
                        LengthHeight = 25,
                        DateOfVisit = DateTime.Today.AddMonths(-12),
                        Oedema = OedemaTypes.No,
                        Measured = MeasurementTypes.Recumbent,
                        HeadCircumference = 41.6,
                        MUAC = 11.5,
                        TricepsSkinFold = 4.8,
                        SubscapularSkinFold = 4.1
                    },
                    new Visit()
                    {
                        VisitId = 4,
                        PatientId = 2,
                        Weight = 32,
                        LengthHeight = 28,
                        DateOfVisit = DateTime.Today.AddMonths(-18),
                        Oedema = OedemaTypes.No,
                        Measured = MeasurementTypes.Recumbent,
                        HeadCircumference = 42.7,
                        MUAC = 11.6,
                        TricepsSkinFold = 4.5,
                        SubscapularSkinFold = 3.9
                    }
                );
        }
    }
}

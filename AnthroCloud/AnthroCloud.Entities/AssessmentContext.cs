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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasMany(c => c.Visits)
                .WithOne(e => e.Patient)
                .OnDelete(DeleteBehavior.Cascade);

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
                    },
                    new Visit()
                    {
                        VisitId = 2,
                        PatientId = 1,
                        Weight = 20,
                        LengthHeight = 23,
                        DateOfVisit = DateTime.Today.AddMonths(-3),
                    }, 
                    new Visit()
                    {
                        VisitId = 3,
                        PatientId = 2,
                        Weight = 26,
                        LengthHeight = 25,
                        DateOfVisit = DateTime.Today.AddMonths(-12),
                    },
                    new Visit()
                    {
                        VisitId = 4,
                        PatientId = 2,
                        Weight = 32,
                        LengthHeight = 28,
                        DateOfVisit = DateTime.Today.AddMonths(-18),
                    }
                );
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visit> Visits { get; set; }
    }

    public class Animal
    {
        
    }
}

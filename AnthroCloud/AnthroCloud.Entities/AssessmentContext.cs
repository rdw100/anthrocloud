using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required, EnumDataType(typeof(Sexes))]
        public Sexes Sex { get; set; } = Sexes.Female;

        [Required]
        [DisplayName("Birth Date")]
        [CheckPresentDateRange]
        public DateTime DateOfBirth { get; set; } = DateTime.Today.AddYears(-1);

        public ICollection<Visit> Visits { get; set; } = new List<Visit>();
    }

    public class Visit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VisitId { get; set; }

        public int PatientId { get; set; }

        [Required]
        [DisplayName("Weight (kg)")]
        [Range(.9, 58, ErrorMessage = "Weight must be between .9 and 58.")]
        public double Weight { get; set; } = 9.00;

        [Required]
        [DisplayName("Length/height (cm)")]
        [Range(45.0, 120.0, ErrorMessage = "Weight must be between 45.0 and 120.0.")]
        public double LengthHeight { get; set; } = 73.00;

        [Required]
        [DisplayName("Visit Date")]
        [CheckFutureDateRange]
        public DateTime DateOfVisit { get; set; } = DateTime.Today;

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
    }
}

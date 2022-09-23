using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Emit;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

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

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnthroCloud.Entities
{
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

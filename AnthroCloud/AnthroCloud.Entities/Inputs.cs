using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnthroCloud.Entities
{
    /// <summary>
    /// Represents all calculator inputs necessary for computed statistics.
    /// </summary>
    public class Inputs
    {
        [Required]
        [DisplayName("Birth Date")]
        [CheckPresentDateRange]
        public DateTime DateOfBirth { get; set; } = DateTime.Today.AddYears(-1);

        [Required]
        [DisplayName("Visit Date")]
        [CheckFutureDateRange]
        public DateTime DateOfVisit { get; set; } = DateTime.Today;

        [Required]
        [DisplayName("Weight (kg)")]
        [Range(.9, 58, ErrorMessage = "Weight must be between .9 and 58.")]
        public double Weight { get; set; } = 9.00;

        [Required]
        [DisplayName("Length/height (cm)")]
        [Range(45.0, 120.0, ErrorMessage = "Weight must be between 45.0 and 120.0.")]
        public double LengthHeight { get; set; } = 73.00;

        [Required, EnumDataType(typeof(Sexes))]
        public Sexes Sex { get; set; } = Sexes.Female;

        [Required]
        [DisplayName("Head Circumference (cm)")]
        public double HeadCircumference { get; set; } = 45.00;

        [Required]
        [DisplayName("MUAC (cm)")]
        public double MUAC { get; set; } = 15.00;

        [Required]
        [DisplayName("Triceps skinfold (mm)")]
        public double TricepsSkinFold { get; set; } = 8.00;

        [Required]
        [DisplayName("Subscapular skinfold (mm)")]
        public double SubscapularSkinFold { get; set; } = 7.00;

        [Required, EnumDataType(typeof(OedemaTypes))]
        public OedemaTypes Oedema { get; set; } = OedemaTypes.No;

        public MeasurementTypes Measured { get; set; } = MeasurementTypes.Recumbent;
    }
}

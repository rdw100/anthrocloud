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
        public DateTime DateOfBirth { get; set; } = DateTime.Today.AddYears(-1);

        [Required]
        [DisplayName("Visit Date")]
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

        public bool Oedema { get; set; } = false;
        public Age Age { get; set; }
        public string AgeString { get; set; } = "11mo";
        public byte AgeInMonths { get; set; } = 12;
        public byte AgeInYears { get; set; } = 0;
        public double BMI { get; set; } = 16.9;
    }
}

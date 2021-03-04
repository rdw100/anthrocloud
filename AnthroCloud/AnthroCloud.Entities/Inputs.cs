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

        public double LengthHeightAdjusted 
        {            
            get
            {
                double adjusted = 0.0;

                if (LengthHeight > 0.0)
                {
                    adjusted = AdjustMeasured(LengthHeight, Measured);
                }

                return adjusted;
            }
        }

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

        public MeasuredType Measured { get; set; } = MeasuredType.Recumbent;

        public Age Age { get; set; }
        public string AgeString { get; set; } = "11mo";
        public byte AgeInMonths { get; set; } = 12;
        public byte AgeInYears { get; set; } = 0;
        public double BMI { get; set; } = 16.9;

        public double AdjustMeasured(double LengthHeight, MeasuredType Measured)
        {
            double adjusted = LengthHeight;

            if (AgeInYears < 2 && Measured == MeasuredType.Standing)
            {
                adjusted += .7;
            }
            else if (AgeInYears > 2 && Measured == MeasuredType.Recumbent)
            {
                adjusted += .7;
            }

            return adjusted;
        }
    }
}

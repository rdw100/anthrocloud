using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AnthroCloud.Business;
using AnthroCloud.Entities;

namespace AnthroCloud.UI.Blazor.Components
{
    public class FormViewModel
    {
        public FormViewModel()
        {
            FormInputs = new Inputs();
            FormOutputs = new Outputs();
        }

        //[Required]
        //[DisplayName("Birth Date")]
        //public DateTime DateOfBirth { get; set; } = DateTime.Today.AddYears(-1);

        //[Required]
        //[DisplayName("Visit Date")]
        //public DateTime DateOfVisit { get; set; } = DateTime.Today;

        //[Required]
        //[DisplayName("Weight (kg)")]
        //[Range(.9, 58, ErrorMessage = "Weight must be between .9 and 58.")]
        //public double Weight { get; set; } = 9.00;

        //[Required]
        //[DisplayName("Length/height (cm)")]
        //[Range(45.0, 120.0, ErrorMessage = "Weight must be between 45.0 and 120.0.")]
        //public double LengthHeight { get; set; } = 73.00;

        //[Required, EnumDataType(typeof(Sexes))]
        //public Sexes Sex { get; set; } = Sexes.Female;

        //[Required]
        //[DisplayName("Head Circumference (cm)")]
        //public double HeadCircumference { get; set; } = 45.00;

        //[Required]
        //[DisplayName("MUAC (cm)")]
        //public double MUAC { get; set; } = 15.00;

        //[Required]
        //[DisplayName("Triceps skinfold (mm)")]
        //public double TricepsSkinFold { get; set; } = 8.00;

        //[Required]
        //[DisplayName("Subscapular skinfold (mm)")]
        //public double SubscapularSkinFold { get; set; } = 7.00;


        public Inputs FormInputs { get; set; }
        public Outputs FormOutputs { get; set; }
        //public double BMI { get; set; } = 16.9;
        public double WfaPercentile { get; set; } = 51.9;
        public double WfaZscore { get; set; } = 0.05;
        public double MuacPercentile { get; set; } = 74.3;
        public double MuacZscore { get; set; } = 0.65;
        public double WflPercentile { get; set; } = 61.4;
        public double WflZscore { get; set; } = 0.29;
        public double WfhPercentile { get; set; }
        public double WfhZscore { get; set; }
        public double TsfPercentile { get; set; } = 49.9;
        public double TsfZscore { get; set; } = 0.00;
        public double SsfPercentile { get; set; } = 65.0;
        public double SsfZscore { get; set; } = 0.38;
        public double LfaPercentile { get; set; } = 34.8;
        public double LfaZscore { get; set; } = -0.39;
        public double BfaPercentile { get; set; } = 64.1;
        public double BfaZscore { get; set; } = 0.36;
        public double HcaPercentile { get; set; } = 53.1;
        public double HcaZscore { get; set; } = 0.08;
        public double HfaPercentile { get; set; } = 53.1;
        public double HfaZscore { get; set; } = 0.08;
    }
}

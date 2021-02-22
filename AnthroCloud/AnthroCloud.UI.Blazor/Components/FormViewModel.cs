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
            DateTime today = DateTime.Today;
            DateOfBirth = today.AddYears(-1);
            DateOfVisit = DateTime.Today;
            // Sex = 2;
            Weight = 9.00;
            Height = 73.00;
            AgeString = "11mo";
            AgeInMonths = 12;
            AgeInYears = 0;
            BMI = 16.9;
            HeadCircumference = 45.00;
            MUAC = 15.00;
            TricepsSkinFold = 8.00;
            SubscapularSkinFold = 7.00;
            //WflPercentile = 61.4;
            //WflZscore = 0.29;
            //WfaPercentile = 51.9;
            //WfaZscore = 0.05;
            //LfaPercentile = 34.8;
            //LfaZscore = -0.39;
            //BfaPercentile = 64.1;
            //BfaZscore = 0.36;
            //HcaPercentile = 53.1;
            //HcaZscore = 0.08;
            //MuacPercentile = 74.3;
            //MuacZscore = 0.65;
            //TsfPercentile = 49.9;
            //TsfZscore = 0.00;
            //SsfPercentile = 65.0;
            //SsfZscore = 0.38;
            //Oedema = false;
        }

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
        public double Height { get; set; } = 73.00;

        [Required, EnumDataType(typeof(Sexes))]
        public Sexes Sex { get; set; } = Sexes.Female;

        public Age Age { get; set; } //Todo: Move Age to Entities

        public string AgeString { get; set;}

        public byte AgeInMonths { get; set; } = 12;

        public byte AgeInYears { get; set; } = 0;

        public double BMI { get; set; }

        public double WfaPercentile { get; set; } //= 51.9;
        public double WfaZscore { get; set; } //= 0.05;
        public double HeadCircumference { get; set; } = 45.00;
        public double MUAC { get; set; } = 15.00;
        public double TricepsSkinFold { get; set; } = 8.00;
        public double SubscapularSkinFold { get; set; } = 7.00;
        //[Required]
        //[StringLength(10, ErrorMessage = "Name is too long.")]
        //public string Name { get; set; }
    }

    public class AnthroStatistics
    {
        public double WflPercentile { get; set; } = 61.4;
        public double WflZscore { get; set; } = 0.29;
        public double WfaPercentile { get; set; } = 51.9;
        public double WfaZscore { get; set; } = 0.05;
        public double LfaPercentile { get; set; } = 34.8;
        public double LfaZscore { get; set; } = -0.39;
        public double BfaPercentile { get; set; } = 64.1;
        public double BfaZscore { get; set; } = 0.36;
        public double HcaPercentile { get; set; } = 53.1;
        public double HcaZscore { get; set; } = 0.08;
        public double MuacPercentile { get; set; } = 74.3;
        public double MuacZscore { get; set; } = 0.65;
        public double TsfPercentile { get; set; } = 49.9;
        public double TsfZscore { get; set; } = 0.00;
        public double SsfPercentile { get; set; } = 65.0;
        public double SsfZscore { get; set; } = 0.38;
        public double WfhPercentile { get; set; }
        public double WfhZscore { get; set; }
        public double HfaPercentile { get; set; } = 53.1;
        public double HfaZscore { get; set; } = 0.08;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnthroCloud.UI.Web.Models
{
    public class FormViewModel
    {
        public FormViewModel()
        {
            DateTime today = DateTime.Today;
            DateOfBirth = today.AddYears(-1);
            DateOfVisit = DateTime.Today;
            Sex = 2;
            Weight = 9.00;
            LengthHeight = 73.00;
            Age = "11mo";
            AgeInMonths = 12;
            AgeInYears = 0;
            BMI = 16.9;
            HeadCircumference = 45.00;
            MUAC = 15.00;
            TricepsSkinFold = 8.00;
            SubscapularSkinFold = 7.00;
            WflPercentile = 61.4;
            WflZscore = 0.29;
            WfaPercentile = 51.9;
            WfaZscore = 0.05;
            LfaPercentile = 34.8;
            LfaZscore = -0.39;
            BfaPercentile = 64.1;
            BfaZscore = 0.36;
            HcaPercentile = 53.1;
            HcaZscore = 0.08;
            MuacPercentile = 74.3;
            MuacZscore = 0.65;
            TsfPercentile = 49.9;
            TsfZscore = 0.00;
            SsfPercentile = 65.0;
            SsfZscore = 0.38;
            Oedema = false;
        }

        [DisplayName("Birth Date")]
        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfVisit { get; set; }

        public byte Sex { get; set; }

        public Boolean Oedema { get; set; } 

        [DisplayName("Weight (kg)")]
        public double Weight { get; set; }

        [DisplayName("Length/height (cm)")]
        public double LengthHeight { get; set; }

        [DisplayName("Head circumference (cm)")]
        public double HeadCircumference { get; set; }

        [DisplayName("MUAC (cm)")]
        public double MUAC { get; set; }

        [DisplayName("Triceps skinfold (mm)")]
        public double TricepsSkinFold { get; set; }

        [DisplayName("Subscapular skinfold (mm)")]
        public double SubscapularSkinFold { get; set; }
        
        public double BMI { get; set; }

        public string Age { get; set; }
        public string AgeInDays { get; set; }
        public byte AgeInMonths { get; set; }

        public byte AgeInYears { get; set; }

        public double WfhPercentile { get; set; }
        public double WfhZscore { get; set; }
        public double WflPercentile { get; set; }
        public double WflZscore { get; set; }
        public double WfaPercentile { get; set; }
        public double WfaZscore { get; set; }
        public double LfaPercentile { get; set; }
        public double LfaZscore { get; set; }
        public double BfaPercentile { get; set; }
        public double BfaZscore { get; set; }
        public double HfaPercentile { get; set; }
        public double HfaZscore { get; set; }
        public double HcaPercentile { get; set; }
        public double HcaZscore { get; set; }
        public double MuacPercentile { get; set; }
        public double MuacZscore { get; set; }
        public double TsfPercentile { get; set; }
        public double TsfZscore { get; set; }
        public double SsfPercentile { get; set; }
        public double SsfZscore { get; set; }
    }
}

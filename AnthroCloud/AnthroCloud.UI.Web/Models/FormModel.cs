using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AnthroCloud.UI.Web.Models
{
    public class FormModel
    {
        [DisplayName("Birth Date")]
        public string DateOfBirth { get; set; }

        [DisplayName("Visit Date")]
        public string DateOfVisit { get; set; }

        public byte Sex { get; set; }

        [DisplayName("Weight (kg)")]
        public double Weight { get; set; }

        [DisplayName("Length/height (cm)")]
        public double Height { get; set; }

        [DisplayName("Head circumference (cm)")]
        public decimal HC { get; set; }

        [DisplayName("MUAC (cm)")]
        public double MUAC { get; set; }

        [DisplayName("Triceps skinfold (mm)")]
        public double TSF { get; set; }

        [DisplayName("Subscapular skinfold (mm)")]
        public double SSF { get; set; }
        
        public double BMI { get; set; }

        public string Age { get; set; }

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

using System.Text.Json.Serialization;

namespace AnthroCloud.Entities
{
    /// <summary>
    /// Represents all calculator outputs from computed statistics.
    /// </summary>
    public class Outputs
    {
        private double LengthHeightAdjusted = 73.00;
        public AgeView Age { get; set; } = new();
        public double Bmi { get; set; } = 16.9;
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
        public double GetLengthHeightAdjusted()
        {
            return LengthHeightAdjusted;
        }

        public double SetLengthHeightAdjusted(int AgeInYears, double LengthHeight, MeasurementTypes Measured)
        {
            double adjusted = LengthHeight;

            if (AgeInYears < 2 && Measured == MeasurementTypes.Standing)
            {
                adjusted += .7;
            }
            else if (AgeInYears > 2 && Measured == MeasurementTypes.Recumbent)
            {
                adjusted += .7;
            }

            LengthHeightAdjusted = adjusted;

            return LengthHeightAdjusted;
        }
    }

    public class AgeView
    {
        private string ageString;

        public string AgeString
        {
            get
            {
                if (Years < 1)
                {
                    ageString = string.Format("{0}mo", Months);
                }
                else
                {
                    ageString = string.Format("{0}yr {1}mo ({2}mo)", Years, Months, TotalMonths);
                }

                return ageString;
            }

            set 
            { 
                ageString = value; 
            }
        }

        /// <summary>
        /// Age in remaining days.
        /// </summary>
        [JsonPropertyName("days")]
        public int Days { get; set; } = 365;

        /// <summary>
        /// Age in remaining months.
        /// </summary>
        [JsonPropertyName("months")]
        public int Months { get; set; } = 11;
        
        /// <summary>
        /// Age in years.
        /// </summary>
        [JsonPropertyName("years")]        
        public int Years { get; set; } = 0;

        /// <summary>
        /// Age in total days.
        /// </summary>
        [JsonPropertyName("totalDays")]
        public int TotalDays { get; set; }

        /// <summary>
        /// Age in total months.
        /// </summary>
        [JsonPropertyName("totalMonths")]
        public int TotalMonths { get; set; }
    }
}
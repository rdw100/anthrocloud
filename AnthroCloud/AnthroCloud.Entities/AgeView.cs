using System.Text.Json.Serialization;

namespace AnthroCloud.Entities
{
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
        public int Days { get; set; } = 0;

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
        public int TotalDays { get; set; } = 365;

        /// <summary>
        /// Age in total months.
        /// </summary>
        [JsonPropertyName("totalMonths")]
        public int TotalMonths { get; set; } = 11;
    }
}
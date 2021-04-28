using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnthroCloud.Business
{
    /// <summary>
    /// Calculates the age by instatiation of the Age object using birth and visit dates.
    /// </summary>
    public class Age
    {
        public Age() { }

        /// <summary>
        /// Creates a new instance of the age object setting birth and visit dates.
        /// </summary>
        /// <param name="birth">The date of birth</param>
        /// <param name="visit">The date of visit</param>
        public Age(DateTime birth, DateTime visit)
        {
            _ = Calculate(birth, visit);
        }

        /// <summary>
        /// Age in years.
        /// </summary>
        [JsonPropertyName("years")]
        public int Years { get; set; }

        /// <summary>
        /// Age in remaining months.
        /// </summary>
        [JsonPropertyName("months")]
        public int Months { get; set; }

        /// <summary>
        /// Age in remaining days.
        /// </summary>
        [JsonPropertyName("days")]
        public int Days { get; set; }

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

        /// <summary>
        /// Operation returns a calculated Age object.
        /// </summary>
        /// <param name="birth">The date of birth</param>
        /// <param name="visit">The date of visit</param>
        /// <returns>Returns a calculated Age object</returns>
        public async Task<Age> Calculate(DateTime birth, DateTime visit)
        {
            await Task.FromResult<Age>(CalculateAge(birth, visit));
            return this;
        }

        /// <summary>
        /// Calculates the Year, Month, Day, TotalDays, and Total Months from birth date and visit date.
        /// </summary>
        /// <param name="birth">The date of birth</param>
        /// <param name="visit">The date of visit</param>
        private Age CalculateAge(DateTime birth, DateTime visit)
        {
            //visit = visit.AddDays(-1);

            if ((visit.Year - birth.Year) > 0 ||
                (((visit.Year - birth.Year) == 0) && ((birth.Month < visit.Month) ||
                  ((birth.Month == visit.Month) && (birth.Day <= visit.Day)))))
            {
                TotalDays = (visit - birth).Days;
                TotalMonths = (visit.Month - birth.Month) + 12 * (visit.Year - birth.Year);

                int daysInBirthMonth = DateTime.DaysInMonth(birth.Year, birth.Month);

                int daysRemaining = visit.Day + (daysInBirthMonth - birth.Day);

                if (visit.Month > birth.Month)
                {
                    Years = visit.Year - birth.Year;
                    Months = visit.Month - (birth.Month + 1) + Math.Abs(daysRemaining / daysInBirthMonth);
                    Days = (daysRemaining % daysInBirthMonth + daysInBirthMonth) % daysInBirthMonth;
                }
                else if (visit.Month == birth.Month)
                {
                    if (visit.Day >= birth.Day)
                    {
                        Years = visit.Year - birth.Year;
                        Months = 0;
                        Days = visit.Day - birth.Day;
                    }
                    else
                    {
                        Years = (visit.Year - 1) - birth.Year;
                        Months = 11;
                        Days = DateTime.DaysInMonth(birth.Year, birth.Month) - (birth.Day - visit.Day);
                        TotalDays -= 1;
                        TotalMonths -= 1;
                    }
                }
                else
                {
                    Years = (visit.Year - 1) - birth.Year;
                    Months = visit.Month + (11 - birth.Month) + Math.Abs(daysRemaining / daysInBirthMonth);
                    Days = (daysRemaining % daysInBirthMonth + daysInBirthMonth) % daysInBirthMonth;
                }
            }
            else
            {
                throw new ArgumentException("Birthday date must be earlier than current date");
            }

            return this;
        }

        /// <summary>
        /// Writes a human readable string in either Months or Year-Month (TotalMonths) format.
        /// </summary>
        /// <returns>Returns a string in either Months or Year-Month (TotalMonths) format.</returns>
        public string ToReadableString()
        {
            string ageString;

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

        /// <summary>
        /// Writes string of age in total days.
        /// </summary>
        /// <returns>Returns age in total days.</returns>
        public string ToDaysString()
        {
            string ageString;

            ageString = string.Format("{0}", TotalDays);

            return ageString;
        }
        /// <summary>
        /// Writes string of age in total months.
        /// </summary>
        /// <returns>Returns age in total months.</returns>
        public string ToMonthsString()
        {
            string ageString;

            ageString = string.Format("{0}", TotalMonths);

            return ageString;
        }

        /// <summary>
        /// Writes string of age in years.
        /// </summary>
        /// <returns>Returns age in years.</returns>
         public string ToYearsString()
        {
            string yearString;

            yearString = string.Format("{0}", Years);

            return yearString;
        }
    }
}
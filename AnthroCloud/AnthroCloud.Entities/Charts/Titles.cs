namespace AnthroCloud.Entities.Charts
{
    /// <summary>
    /// Represents the title text labels drawn on hAxis (X-axis) and vAxis (Y-axis) gridlines.
    /// </summary>
    public class Titles
    {
        /// <summary>
        /// The text for the X-axis title.
        /// </summary>
        public string HAxisTitle { get; set; }

        /// <summary>
        /// The text for the Y-axis title.
        /// </summary>
        public string VAxisTitle { get; set; }

        /// <summary>
        /// Gets the text for the X-axis title.
        /// </summary>
        /// <param name="growth">The growth chart measure.</param>
        /// <returns>Returns a string for X-axis title.</returns>
        public static string GetHaxisTitle(GrowthTypes growth)
        {
            string title = string.Empty;

            switch (growth)
            {
                case GrowthTypes.BFA:
                case GrowthTypes.HCA:
                case GrowthTypes.LHFA:
                case GrowthTypes.MUAC:
                case GrowthTypes.SSF:
                case GrowthTypes.TSF:
                case GrowthTypes.WFA:
                    title = "Age (months)";
                    break;
                case (GrowthTypes.WFL):
                    title = "Length (cm)";
                    break;
                case (GrowthTypes.WFH):
                    title = "Height (cm)";
                    break;
            }
            return title;
        }

        /// <summary>
        /// Gets the text for the Y-axis title.
        /// </summary>
        /// <param name="growth">The growth chart measure.</param>
        /// <returns>Returns a string for Y-axis title.</returns>
        public static string GetVaxisTitles(GrowthTypes growth)
        {
            string title = string.Empty;

            switch (growth)
            {
                case GrowthTypes.BFA:
                    title = "Body mass index";
                    break;
                case GrowthTypes.HCA:
                    title = "Head circumference (cm)";
                    break;
                case GrowthTypes.LHFA:
                    title = "Length/height (cm)";
                    break;
                case GrowthTypes.MUAC:
                    title = "MUAC (cm)";
                    break;
                case GrowthTypes.SSF:
                    title = "Subscapular skinfold (MM)";
                    break;
                case GrowthTypes.TSF:
                    title = "Triceps skinfold (MM)";
                    break;
                case GrowthTypes.WFA:
                case (GrowthTypes.WFL):
                case (GrowthTypes.WFH):
                    title = "Weight (kg)";
                    break;
            }
            return title;
        }
    }
}

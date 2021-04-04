namespace AnthroCloud.Entities.Charts
{
    /// <summary>
    /// Represents the title text labels drawn on hAxis (X-axis) and vAxis (Y-axis) gridlines.
    /// </summary>
    public class ChartSubTitles
    {
        /// <summary>
        /// The text for the chart title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets the text for chart title.
        /// </summary>
        /// <param name="growth">The growth chart measure.</param>
        /// <returns>Returns a string for X-axis title.</returns>
        public static string GetTitle(GraphTypes graph, GrowthTypes growth)
        {
            string title = string.Empty;

            switch (graph)
            {
                case GraphTypes.PValue:
                    switch (growth)
                    {
                        case GrowthTypes.BFA:
                            title = "Birth to 5 Years (Percentile)";
                            break;
                        case GrowthTypes.HCA:
                            title = "Birth to 5 Years (Percentile)";
                            break;
                        case GrowthTypes.LHFA:
                            title = "Birth to 5 Years (Percentile)";
                            break;
                        case GrowthTypes.MUAC:
                            title = "Birth to 5 Years (Percentile)";
                            break;
                        case GrowthTypes.SSF:
                            title = "Birth to 5 Years (Percentile)";
                            break;
                        case GrowthTypes.TSF:
                            title = "Birth to 5 Years (Percentile)";
                            break;
                        case GrowthTypes.WFA:
                            title = "Birth to 5 Years (Percentile)";
                            break;
                        case (GrowthTypes.WFL):
                            title = "Birth to 5 Years (Percentile)";
                            break;
                        case (GrowthTypes.WFH):
                            title = "Birth to 5 Years (Percentile)";
                            break;
                    }
                    break;
                case GraphTypes.ZScore:
                    switch (growth)
                    {
                        case GrowthTypes.BFA:
                            title = "Birth to 5 Years (Z-scores)";
                            break;
                        case GrowthTypes.HCA:
                            title = "Birth to 5 Years (Z-scores)";
                            break;
                        case GrowthTypes.LHFA:
                            title = "Birth to 5 Years (Z-scores)";
                            break;
                        case GrowthTypes.MUAC:
                            title = "Birth to 5 Years (Z-scores)";
                            break;
                        case GrowthTypes.SSF:
                            title = "Birth to 5 Years (Z-scores)";
                            break;
                        case GrowthTypes.TSF:
                            title = "Birth to 5 Years (Z-scores)";
                            break;
                        case GrowthTypes.WFA:
                            title = "Birth to 5 Years (Z-scores)";
                            break;
                        case (GrowthTypes.WFL):
                            title = "Birth to 5 Years (Z-scores)";
                            break;
                        case (GrowthTypes.WFH):
                            title = "Birth to 5 Years (Z-scores)";
                            break;
                    }
                    break;
            }
            return title;
        }
    }
}

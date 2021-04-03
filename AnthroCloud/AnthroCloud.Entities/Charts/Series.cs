using System;
using System.Collections.Generic;

namespace AnthroCloud.Entities.Charts
{
    /// <summary>
    /// Represents an array of objects each describing the format of the corresponding series in the line chart. 
    /// </summary>
    public class Series
    {
        /// <summary>
        /// The color to use for this series. Specify a valid HTML color string.
        /// </summary>
        public string color { get; set; }

        /// <summary>
        /// A boolean value, where true means that the series should have a legend entry,
        /// and false means that it should not. Default is true.
        /// </summary>
        public Boolean visibleInLegend { get; set; }

        /// <summary>
        /// The line series line type.
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// Overrides the global pointSize value for this series.
        /// </summary>
        public int pointSize { get; set; }

        /// <summary>
        /// Copies the elements of the List<Series> to a new array.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="growth"></param>
        /// <returns>Returns an array containing copies of the elements of the List<Series>.</returns>
        public static Series[] GetSeries(GraphTypes graph, GrowthTypes growth) 
        {
            List<Series> series = new();
            switch (graph)
            {
                case (GraphTypes.PValue):
                    switch (growth)
                    {
                        case GrowthTypes.BFA:
                        case GrowthTypes.HCA:
                        case GrowthTypes.LHFA:
                        case GrowthTypes.MUAC:
                        case GrowthTypes.SSF:
                        case GrowthTypes.TSF:
                        case GrowthTypes.WFA:
                        case (GrowthTypes.WFL):
                        case (GrowthTypes.WFH):
                            series.Add(new Series { color = "#e10808", visibleInLegend = true, type = "linear", pointSize = 0 });
                            series.Add(new Series { color = "#ffd700", visibleInLegend = true, type = "linear", pointSize = 0 });
                            series.Add(new Series { color = "#0c8d00", visibleInLegend = true, type = "linear", pointSize = 0 });
                            series.Add(new Series { color = "#ffd700", visibleInLegend = true, type = "linear", pointSize = 0 });
                            series.Add(new Series { color = "#e10808", visibleInLegend = true, type = "linear", pointSize = 0 });
                            series.Add(new Series { color = "blue", visibleInLegend = false, type = "scatter", pointSize = 20 });
                            break;
                    }
                    break;
                case (GraphTypes.ZScore):
                    switch (growth)
                    {
                        case GrowthTypes.BFA:
                        case GrowthTypes.HCA:
                        case GrowthTypes.MUAC:
                        case GrowthTypes.SSF:
                        case GrowthTypes.TSF:
                        case (GrowthTypes.WFL):
                        case (GrowthTypes.WFH):
                            series.Add(new Series { color = "#000000", visibleInLegend = true, type = "linear", pointSize = 0 });
                            series.Add(new Series { color = "#e10808", visibleInLegend = true, type = "linear", pointSize = 0 });
                            series.Add(new Series { color = "#ffd700", visibleInLegend = true, type = "linear", pointSize = 0 });
                            series.Add(new Series { color = "#0c8d00", visibleInLegend = true, type = "linear", pointSize = 0 });
                            series.Add(new Series { color = "#ffd700", visibleInLegend = true, type = "linear", pointSize = 0 });
                            series.Add(new Series { color = "#e10808", visibleInLegend = true, type = "linear", pointSize = 0 });
                            series.Add(new Series { color = "#000000", visibleInLegend = true, type = "linear", pointSize = 0 });
                            series.Add(new Series { color = "blue", visibleInLegend = false, type = "scatter", pointSize = 20 });
                            break;
                        case GrowthTypes.LHFA:
                        case GrowthTypes.WFA:
                            series.Add(new Series { color = "#000000", visibleInLegend = true, type = "linear", pointSize = 0 });
                            series.Add(new Series { color = "#e10808", visibleInLegend = true, type = "linear", pointSize = 0 });
                            series.Add(new Series { color = "#0c8d00", visibleInLegend = true, type = "linear", pointSize = 0 });
                            series.Add(new Series { color = "#e10808", visibleInLegend = true, type = "linear", pointSize = 0 });
                            series.Add(new Series { color = "#000000", visibleInLegend = true, type = "linear", pointSize = 0 });
                            series.Add(new Series { color = "blue", visibleInLegend = false, type = "scatter", pointSize = 20 });
                            break;
                    }
                    break;
            }

            // Gets items from Series list
            Series[] array = series.ToArray();
            return array;
        }
    }
}

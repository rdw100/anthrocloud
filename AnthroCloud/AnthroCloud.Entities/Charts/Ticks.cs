namespace AnthroCloud.Entities.Charts
{
    /// <summary>
    /// Represents values drawn on hAxis and vAxis gridlines.
    /// </summary>
    public class Ticks
    {
        /// <summary>
        /// Replaces the automatically generated X-axis ticks with the specified array.
        /// </summary>
        public int[] HAxis { get; set; }

        /// <summary>
        /// Replaces the automatically generated Y-axis ticks with the specified array.
        /// </summary>
        public int[] VAxis { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="growth"></param>
        /// <returns>Returns an integer array of X-axis ticks.</returns>
        public static int[] GetHaxisTicks(GraphTypes graph, GrowthTypes growth)
        {
            int[] ticks = System.Array.Empty<int>();
            switch (graph)
            {
                case (GraphTypes.PValue):
                    switch (growth)
                    {
                        case GrowthTypes.BFA:
                            ticks = new[] { 0, 12, 24, 36, 48, 60 };
                            break;
                        case GrowthTypes.HCA:
                            ticks = new[] { 0, 12, 24, 36, 48, 60 };
                            break;
                        case GrowthTypes.LHFA:
                            ticks = new[] { 0, 12, 24, 36, 48, 60 };
                            break;
                        case GrowthTypes.MUAC:
                            ticks = new[] { 0, 12, 24, 36, 48, 60 };
                            break;
                        case GrowthTypes.SSF:
                            ticks = new[] { 12, 24, 36, 48, 60 };
                            break;
                        case GrowthTypes.TSF:
                            ticks = new[] { 12, 24, 36, 48, 60 };
                            break;
                        case GrowthTypes.WFA:
                            ticks = new[] { 0, 12, 24, 36, 48, 60 };
                            break;
                        case (GrowthTypes.WFL):
                            ticks = new[] { 50, 60, 70, 80, 90, 100, 110 };
                            break;
                        case (GrowthTypes.WFH):
                            ticks = new[] { 70, 80, 90, 100, 110, 120 };
                            break;
                    }
                    break;
                case (GraphTypes.ZScore):
                    switch (growth)
                    {
                        case GrowthTypes.BFA:
                            ticks = new[] { 0, 12, 24, 36, 48, 60 };
                            break;
                        case GrowthTypes.HCA:
                            ticks = new[] { 0, 12, 24, 36, 48, 60 };
                            break;
                        case GrowthTypes.MUAC:
                            ticks = new[] { 0, 12, 24, 36, 48, 60 };
                            break;
                        case GrowthTypes.SSF:
                            ticks = new[] { 12, 24, 36, 48, 60 };
                            break;
                        case GrowthTypes.TSF:
                            ticks = new[] { 12, 24, 36, 48, 60 };
                            break;
                        case (GrowthTypes.WFL):
                            ticks = new[] { 50, 60, 70, 80, 90, 100, 110 };
                            break;
                        case (GrowthTypes.WFH):
                            ticks = new[] { 70, 80, 90, 100, 110, 120 };
                            break;
                        case GrowthTypes.LHFA:
                            ticks = new[] { 0, 12, 24, 36, 48, 60 };
                            break;
                        case GrowthTypes.WFA:
                            ticks = new[] { 0, 12, 24, 36, 48, 60 };
                            break;
                    }
                    break;
            }
            return ticks;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="growth"></param>
        /// <returns>Returns an integer array of Y-axis ticks.</returns>
        public static int[] GetVaxisTicks(GraphTypes graph, GrowthTypes growth)
        {
            int[] ticks = System.Array.Empty<int>();
            switch (graph)
            {
                case (GraphTypes.PValue):
                    switch (growth)
                    {
                        case GrowthTypes.BFA:
                            ticks = new[] { 8, 10, 12, 14, 16, 18, 20, 22, 24 };
                            break;
                        case GrowthTypes.HCA:
                            ticks = new[] { 28, 30, 32, 34, 36, 38, 40, 42, 44, 46, 48, 50, 52, 54};
                            break;
                        case GrowthTypes.LHFA:
                            ticks = new[] { 40, 50, 60, 70, 80, 90, 100, 110, 120 };
                            break;
                        case GrowthTypes.MUAC:
                            ticks = new[] { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
                            break;
                        case GrowthTypes.SSF:
                            ticks = new[] { 3, 4, 5, 6, 7, 8, 9, 10, 11 };
                            break;
                        case GrowthTypes.TSF:
                            ticks = new[] { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
                            break;
                        case GrowthTypes.WFA:
                            ticks = new[] { 0, 5, 10, 15, 20, 25, 30 };
                            break;
                        case (GrowthTypes.WFL):
                            ticks = new[] { 0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26 };
                            break;
                        case (GrowthTypes.WFH):
                            ticks = new[] { 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28 };
                            break;
                    }
                    break;
                case (GraphTypes.ZScore):
                    switch (growth)
                    {
                        case GrowthTypes.BFA:
                            ticks = new[] { 8, 10, 12, 14, 16, 18, 20, 22, 24 };
                            break;
                        case GrowthTypes.HCA:
                            ticks = new[] { 28, 30, 32, 34, 36, 38, 40, 42, 44, 46, 48, 50, 52, 54 };
                            break;
                        case GrowthTypes.MUAC:
                            ticks = new[] { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
                            break;
                        case GrowthTypes.SSF:
                            ticks = new[] { 4, 6, 8, 10, 12, 14, 16, 18 };
                            break;
                        case GrowthTypes.TSF:
                            ticks = new[] { 4, 6, 8, 10, 12, 14, 16, 18, 20 };
                            break;
                        case (GrowthTypes.WFL):
                            ticks = new[] { 0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26 };
                            break;
                        case (GrowthTypes.WFH):
                            ticks = new[] { 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32};
                            break;
                        case GrowthTypes.LHFA:
                            ticks = new[] { 40, 50, 60, 70, 80, 90, 100, 110, 120 };
                            break;
                        case GrowthTypes.WFA:
                            ticks = new[] { 0, 5, 10, 15, 20, 25, 30 };
                            break;
                    }
                    break;
            }
            return ticks;
        }
    }
}

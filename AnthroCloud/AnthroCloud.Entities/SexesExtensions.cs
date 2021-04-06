namespace AnthroCloud.Entities
{
    /// <summary>
    /// Extends Sexes Enumeration a adding methods without modifying the original type.
    /// </summary>
    public static class SexesExtensions
    {
       /// <summary>
       /// Provides a stats library value for sex.
       /// </summary>
       /// <param name="sex">The named constant specified for Sex.</param>
       /// <returns>Returns a stats library value for sex.</returns>
       /// <remarks>Stats library uses either 0 or 1.</remarks>
        public static byte ToStatsValue(this Sexes sex)
        {
            return sex switch
            {
                Sexes.Male => 0,
                Sexes.Female => 1,
                _ => 0,
            };
        }

        /// <summary>
        /// Provides a chard library value for sex.
        /// </summary>
        /// <param name="sex">The named constant specified for Sex.</param>
        /// <returns>Returns a chart library value for sex.</returns>
        /// <remarks>WHO datasets uses either 1 or 2.</remarks>
        public static byte ToChartValue(this Sexes sex)
        {
            return sex switch
            {
                Sexes.Male => 1,
                Sexes.Female => 2,
                _ => 0,
            };
        }
    }
}
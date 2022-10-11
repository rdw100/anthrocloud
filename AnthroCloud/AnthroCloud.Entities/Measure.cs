using AnthroCloud.Entities.Charts;

namespace AnthroCloud.Entities
{
    public class Measure
    {
        public GrowthTypes Name { get; set; }
        public double Percentile { get; set; }
        public double Zscore { get; set; }
    }
}

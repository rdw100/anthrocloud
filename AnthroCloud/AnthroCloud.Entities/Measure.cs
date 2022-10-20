using AnthroCloud.Entities.Charts;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AnthroCloud.Entities
{
    public class Measure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MeasureId { get; set; }
        [Key]
        [Required, EnumDataType(typeof(GrowthTypes))]
        public GrowthTypes Name { get; set; } = GrowthTypes.BFA;
        [ForeignKey("VisitId")]
        public int VisitId { get; set; }
        public double Percentile { get; set; }
        public double Zscore { get; set; }
    }
}

using System.Collections.Generic;

namespace AnthroCloud.Entities.Charts
{
    public class ChartDataTable
    {
        public List<Col> cols { get; set; }
        public List<Row> rows { get; set; }

        public List<Col> GetCols(GraphTypes graph, GrowthTypes growth)
        {
            List<Col> cols = new List<Col>();

            switch (graph)
            {
                case (GraphTypes.PValue):
                    switch (growth)
                    {
                        case (GrowthTypes.WFL):
                            cols = new List<Col>()
                            {
                                new Col { id = "lengthincm", label = "Lengthincm", type = "number" },
                                new Col { id = "p3", label = "P3", type = "number" },
                                new Col { id = "p15", label = "P15", type = "number" },
                                new Col { id = "p50", label = "P50", type = "number" },
                                new Col { id = "p85", label = "P85", type = "number" },
                                new Col { id = "p97", label = "P97", type = "number" },
                                new Col { id = "score", label = "Score", type = "number" },
                            };
                            break;
                        case (GrowthTypes.WFH):
                            cols = new List<Col>()
                            {
                                new Col { id = "heightincm", label = "Hengthincm", type = "number" },
                                new Col { id = "p3", label = "P3", type = "number" },
                                new Col { id = "p15", label = "P15", type = "number" },
                                new Col { id = "p50", label = "P50", type = "number" },
                                new Col { id = "p85", label = "P85", type = "number" },
                                new Col { id = "p97", label = "P97", type = "number" },
                                new Col { id = "score", label = "Score", type = "number" },
                            };
                            break;
                        case GrowthTypes.BFA:
                        case GrowthTypes.HCA:
                        case GrowthTypes.LHFA:
                        case GrowthTypes.MUAC:
                        case GrowthTypes.SSF:
                        case GrowthTypes.TSF:
                        case GrowthTypes.WFA:
                            cols = new List<Col>()
                            {
                                new Col { id = "month", label = "Month", type = "number" },
                                new Col { id = "p3", label = "P3", type = "number" },
                                new Col { id = "p15", label = "P15", type = "number" },
                                new Col { id = "p50", label = "P50", type = "number" },
                                new Col { id = "p85", label = "P85", type = "number" },
                                new Col { id = "p97", label = "P97", type = "number" },
                                new Col { id = "score", label = "Score", type = "number" },
                            };
                            break;
                    }
                    break;
                case (GraphTypes.ZScore):
                    switch (growth)
                    {
                        case (GrowthTypes.WFL):
                            cols = new List<Col>()
                            {
                                new Col { id = "lengthincm", label = "Lengthincm", type = "number" },
                                new Col { id = "sd3neg", label = "-3SD", type = "number" },
                                new Col { id = "sd2neg", label = "-2SD", type = "number" },
                                new Col { id = "sd1neg", label = "-1SD", type = "number" },
                                new Col { id = "sd0", label = "Median", type = "number" },
                                new Col { id = "sd1", label = "+1SD", type = "number" },
                                new Col { id = "sd2", label = "+2SD", type = "number" },
                                new Col { id = "sd3", label = "+3SD", type = "number" },
                                new Col { id = "score", label = "Score", type = "number" },
                            };
                            break;
                        case (GrowthTypes.WFH):
                            cols = new List<Col>()
                            {
                                new Col { id = "heightincm", label = "Hengthincm", type = "number" },
                                new Col { id = "sd3neg", label = "-3SD", type = "number" },
                                new Col { id = "sd2neg", label = "-2SD", type = "number" },
                                new Col { id = "sd1neg", label = "-1SD", type = "number" },
                                new Col { id = "sd0", label = "Median", type = "number" },
                                new Col { id = "sd1", label = "+1SD", type = "number" },
                                new Col { id = "sd2", label = "+2SD", type = "number" },
                                new Col { id = "sd3", label = "+3SD", type = "number" },
                                new Col { id = "score", label = "Score", type = "number" },
                            };
                            break;
                        case GrowthTypes.BFA:
                        case GrowthTypes.HCA:
                        case GrowthTypes.MUAC:
                        case GrowthTypes.SSF:
                        case GrowthTypes.TSF:
                            cols = new List<Col>()
                            {
                                new Col { id = "month", label = "Month", type = "number" },
                                new Col { id = "sd3neg", label = "-3SD", type = "number" },
                                new Col { id = "sd2neg", label = "-2SD", type = "number" },
                                new Col { id = "sd1neg", label = "-1SD", type = "number" },
                                new Col { id = "sd0", label = "Median", type = "number" },
                                new Col { id = "sd1", label = "+1SD", type = "number" },
                                new Col { id = "sd2", label = "+2SD", type = "number" },
                                new Col { id = "sd3", label = "+3SD", type = "number" },
                                new Col { id = "score", label = "Score", type = "number" },
                            };
                            break;
                        case GrowthTypes.LHFA:
                        case GrowthTypes.WFA:
                            cols = new List<Col>()
                            {
                                new Col { id = "month", label = "Month", type = "number" },
                                new Col { id = "sd3neg", label = "-3SD", type = "number" },
                                new Col { id = "sd2neg", label = "-2SD", type = "number" },
                                new Col { id = "sd0", label = "Median", type = "number" },
                                new Col { id = "sd2", label = "+2SD", type = "number" },
                                new Col { id = "sd3", label = "+3SD", type = "number" },
                                new Col { id = "score", label = "Score", type = "number" },
                            };
                            break;
                    }
                    break;
            }

            return cols;
        }

        public List<Row> GetWflRows(GraphTypes graph, GrowthTypes growth, List<WeightForLength> newList)
        {
            List<Row> rows = new();
            foreach (var item in newList)
            {
                rows.Add(new Row
                {
                    c = new List<Cell>()
                    {
                        new Cell { v = item.Lengthincm },
                        new Cell { v = item.P3 },
                        new Cell { v = item.P15 },
                        new Cell { v = item.P50 },
                        new Cell { v = item.P85 },
                        new Cell { v = item.P97 },
                        new Cell { v = item.Score }
                    }
                });
            }
            return rows;
        }

        public List<Row> GetRows(GraphTypes graph, GrowthTypes growth, List<dynamic> newList)
        {
            List<Row> rows = new List<Row>();

            switch (graph)
            {
                case (GraphTypes.PValue):
                    switch (growth)
                    {
                        case (GrowthTypes.WFL):

                            foreach (var item in newList)
                            {
                                rows.Add(new Row
                                {
                                    c = new List<Cell>()
                                    {
                                        new Cell { v = item.Lengthincm },
                                        new Cell { v = item.P3 },
                                        new Cell { v = item.P15 },
                                        new Cell { v = item.P50 },
                                        new Cell { v = item.P85 },
                                        new Cell { v = item.P97 },
                                        new Cell { v = item.Score }
                                    }
                                });
                            }
                            break;
                        case (GrowthTypes.WFH):
                            foreach (var item in newList)
                            {
                                rows.Add(new Row
                                {
                                    c = new List<Cell>()
                                    {
                                        new Cell { v = item.heightincm },
                                        new Cell { v = item.P3 },
                                        new Cell { v = item.P15 },
                                        new Cell { v = item.P50 },
                                        new Cell { v = item.P85 },
                                        new Cell { v = item.P97 },
                                        new Cell { v = item.Score }
                                    }
                                });
                            }
                            break;
                        case GrowthTypes.BFA:
                        case GrowthTypes.HCA:
                        case GrowthTypes.LHFA:
                        case GrowthTypes.MUAC:
                        case GrowthTypes.SSF:
                        case GrowthTypes.TSF:
                        case GrowthTypes.WFA:
                            foreach (var item in newList)
                            {
                                rows.Add(new Row
                                {
                                    c = new List<Cell>()
                                    {
                                        new Cell { v = item.Month },
                                        new Cell { v = item.P3 },
                                        new Cell { v = item.P15 },
                                        new Cell { v = item.P50 },
                                        new Cell { v = item.P85 },
                                        new Cell { v = item.P97 },
                                        new Cell { v = item.Score }
                                    }
                                });
                            }
                            break;
                    }
                    break;
                case (GraphTypes.ZScore):
                    switch (growth)
                    {
                        case (GrowthTypes.WFL):
                            foreach (var item in newList)
                            {
                                rows.Add(new Row
                                {
                                    c = new List<Cell>()
                                    {
                                        new Cell { v = item.Lengthincm },
                                        new Cell { v = item.Sd3neg },
                                        new Cell { v = item.Sd2neg },
                                        new Cell { v = item.Sd1neg },
                                        new Cell { v = item.Sd0 },
                                        new Cell { v = item.Sd1 },
                                        new Cell { v = item.Sd2 },
                                        new Cell { v = item.Sd3 },
                                        new Cell { v = item.Score }
                                    }
                                });
                            }
                            break;
                        case (GrowthTypes.WFH):
                            foreach (var item in newList)
                            {
                                rows.Add(new Row
                                {
                                    c = new List<Cell>()
                                    {
                                        new Cell { v = item.Hengthincm },
                                        new Cell { v = item.Sd3neg },
                                        new Cell { v = item.Sd2neg },
                                        new Cell { v = item.Sd1neg },
                                        new Cell { v = item.Sd0 },
                                        new Cell { v = item.Sd1 },
                                        new Cell { v = item.Sd2 },
                                        new Cell { v = item.Sd3 },
                                        new Cell { v = item.Score }
                                    }
                                });
                            }
                            break;
                        case GrowthTypes.BFA:
                        case GrowthTypes.HCA:
                        case GrowthTypes.MUAC:
                        case GrowthTypes.SSF:
                        case GrowthTypes.TSF:
                            foreach (var item in newList)
                            {
                                rows.Add(new Row
                                {
                                    c = new List<Cell>()
                                    {
                                        new Cell { v = item.Month },
                                        new Cell { v = item.Sd3neg },
                                        new Cell { v = item.Sd2neg },
                                        new Cell { v = item.Sd1neg },
                                        new Cell { v = item.Sd0 },
                                        new Cell { v = item.Sd1 },
                                        new Cell { v = item.Sd2 },
                                        new Cell { v = item.Sd3 },
                                        new Cell { v = item.Score }
                                    }
                                });
                            }
                            break;
                        case GrowthTypes.LHFA:
                        case GrowthTypes.WFA:
                            foreach (var item in newList)
                            {
                                rows.Add(new Row
                                {
                                    c = new List<Cell>()
                                    {
                                        new Cell { v = item.Month },
                                        new Cell { v = item.Sd3neg },
                                        new Cell { v = item.Sd2neg },
                                        new Cell { v = item.Sd0 },
                                        new Cell { v = item.Sd2 },
                                        new Cell { v = item.Sd3 },
                                        new Cell { v = item.Score }
                                    }
                                });
                            }
                            break;
                    }
                    break;
            }
            return rows;
        }
    }

    public class Col
    {
        public string id { get; set; }
        public string label { get; set; }
        public string type { get; set; }
    }

    public class Cell
    {
        public dynamic v { get; set; }
        //public object f { get; set; }
    }

    public class Row
    {
        public List<Cell> c { get; set; }
    }
}

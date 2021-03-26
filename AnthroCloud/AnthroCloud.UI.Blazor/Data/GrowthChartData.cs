using System.Collections.Generic;
using System.Text.Json;

namespace AnthroCloud.UI.Blazor.Data
{
    public class GrowthChartData
    {
        public string GetData()
        {
            var chart = new DataTable
            {
                cols = new List<Col>
                {
                    new Col { id = "year", label = "Year", type = "string" },
                    new Col { id = "sales", label = "Sales", type = "number" },
                    new Col { id = "expenses", label = "Expenses", type = "number" }
                },
                rows = new List<Row>
                {
                    new Row
                    {
                        c = new List<C>
                        {
                            new C { v = "2017" },
                            new C { v = 1000 },
                            new C { v = 400 }
                        }
                    },
                    new Row
                    {
                        c = new List<C>
                        {
                            new C { v = "2018" },
                            new C { v = 1170 },
                            new C { v = 460 }
                        }
                    },
                    new Row
                    {
                        c = new List<C>
                        {
                            new C { v = "2019" },
                            new C { v = 660 },
                            new C { v = 1120 }
                        }
                    }
                }
            };

            string jsonString = JsonSerializer.Serialize(chart);

            return jsonString;
        }

        public class DataTable
        {
            public List<Col> cols { get; set; }
            public List<Row> rows { get; set; }
        }

        public class Col
        {
            public string id { get; set; }
            public string label { get; set; }
            public string type { get; set; }
        }

        public class C
        {
            public dynamic v { get; set; }
            //public object f { get; set; }
        }

        public class Row
        {
            public List<C> c { get; set; }
        }
    }
}

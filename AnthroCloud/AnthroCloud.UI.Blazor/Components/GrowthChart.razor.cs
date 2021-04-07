using AnthroCloud.Entities;
using AnthroCloud.Entities.Charts;
using AnthroCloud.UI.Blazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Components
{
    public class GrowthChartBase : ComponentBase
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Inject]
        public IChartService ChartService { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public string SubTitle { get; set; }

        [Parameter]
        public GraphTypes Graph { get; set; }

        [Parameter]
        public GrowthTypes Growth { get; set; }
        
        [Parameter]
        public Sexes Sex { get; set; }

        [Parameter]
        public double X { get; set; }

        [Parameter]
        public double Y { get; set; }

        public string Gdata { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var data = await GetChartData(Sex.ToChartValue(), X, Y, Graph);
            
            var options = new
            {
                Title = SubTitle = ChartSubTitles.GetTitle(Graph, Growth),
                Width = 550,
                height = 350,
                hAxis = new { Title = Titles.GetHaxisTitle(Growth), Ticks = Ticks.GetHaxisTicks(Graph, Growth) },
                vAxis = new { Title = Titles.GetVaxisTitles(Growth), Ticks = Ticks.GetVaxisTicks(Graph, Growth) },
                Legend = new
                {
                    Display = true,
                    Position = "right"
                },
                CurveType = "Function",
                series = Series.GetSeries(Graph, Growth),
                Annotations = new {
                    Style = "line", 
                    Color = "#d3d3d3",
                    TextStyle = new
                    {
                        Color = "#d3d3d3",
                        Opacity = 0.5,
                        Stem = new
                        {
                            Color = "#d3d3d3",
                            Opacity = 0.5,
                        }
                    }
                }
            };

            await JsRuntime.InvokeAsync<Task>("drawChart", data, options);
        }

        public async Task<string> GetChartData(byte id, double x, double y, GraphTypes z)
        {
            string data = string.Empty;
            switch(Growth)
            {
                case GrowthTypes.BFA:
                    data = await ChartService.GetBfa(id, (byte)x, y, z);
                    break;
                case GrowthTypes.HCA:
                    data = await ChartService.GetHcfa(id, (byte)x, y, z);
                    break;
                case GrowthTypes.LHFA:
                    data = await ChartService.GetLhfa(id, (byte)x, y, z);
                    break;
                case GrowthTypes.MUAC:
                    data = await ChartService.GetMuac(id, (byte)x, y, z);
                    break;
                case GrowthTypes.SSF:
                    data = await ChartService.GetSsfa(id, (byte)x, y, z);
                    break;
                case GrowthTypes.TSF:
                    data = await ChartService.GetTsfa(id, (byte)x, y, z);
                    break;
                case GrowthTypes.WFA:
                    data = await ChartService.GetWfa(id, (byte)x, y, z);
                    break;
                case GrowthTypes.WFH:
                    data = await ChartService.GetWfh(id, x, y, z);
                    break;
                case GrowthTypes.WFL:
                    data = await ChartService.GetWfl(id, x, y, z);
                    break;
            }

            return data;
        }
    }
}
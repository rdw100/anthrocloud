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
        public string Title { get; set; }

        [Parameter]
        public GraphTypes Graph { get; set; }

        [Parameter]
        public GrowthTypes Growth { get; set; }

        public string Gdata { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            Gdata = await GetChartData(1, 73, 9, Graph);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                var data = Gdata;
                var options = new
                {
                    Title = Title,//"Birth to 5 Years (Percentile)","Birth to 5 Years (Z-scores)"
                    Width = 650,
                    height = 500,
                    hAxis = new { Title = "Weight (kg)", ViewWindow = new { min = 45, max = 110 }, Ticks = Ticks.GetHaxisTicks(Graph, Growth) },
                    vAxis = new { Title = "Length (cm)", Ticks = Ticks.GetVaxisTicks(Graph, Growth)},
                    Legend = new
                    {
                        Display = true,
                        Position = "bottom"
                    },
                    CurveType = "Function",
                    series = Series.GetSeries(Graph, Growth)
                };

                await JsRuntime.InvokeAsync<Task>("drawChart", data, options);
            }
        }

        public async Task<string> GetChartData(byte id, double x, double y, GraphTypes z)
        {
            string data = await ChartService.GetAllWFLJson(id, x, y, z);
            return data;
        }
    }
}
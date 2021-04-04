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

        public string Gdata { get; set; }

        protected override async Task OnInitializedAsync() // OnAfterRenderAsync(bool firstRender)
        {
            var data = await GetChartData(1, 73, 9, Graph); //Gdata;
            
            var options = new
            {
                Title = SubTitle = ChartSubTitles.GetTitle(Graph, Growth),//"Birth to 5 Years (Percentile)","Birth to 5 Years (Z-scores)"
                Width = 650,
                height = 500,
                hAxis = new { Title = Titles.GetHaxisTitle(Growth), Ticks = Ticks.GetHaxisTicks(Graph, Growth) },
                vAxis = new { Title = Titles.GetVaxisTitles(Growth), Ticks = Ticks.GetVaxisTicks(Graph, Growth) },
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

        public async Task<string> GetChartData(byte id, double x, double y, GraphTypes z)
        {
            string data = await ChartService.GetAllWFLJson(id, x, y, z);
            return data;
        }
    }
}
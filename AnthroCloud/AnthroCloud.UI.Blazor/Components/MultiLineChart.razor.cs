using AnthroCloud.UI.Blazor.Services;
using AnthroCloud.Entities.Charts;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Components
{
    /// <summary>
    /// Represents a Blazor Chart component that calls JavaScript 
    /// from C# by injecting the IJSRuntime service.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase" />
    public class MultiLineChartBase : ComponentBase
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Inject]
        public IChartService ChartService { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public GraphTypes Graph { get; set; }

        public string Gdata { get; set; } 

        protected override async Task OnParametersSetAsync()
        {
            Gdata = await GetChartData(1, 73, 9);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                var data = Gdata;
                var options = new
                {
                    Title = "Birth to 5 Years (Percentile)",
                    Width = 900,
                    height = 500,
                    hAxis = new { Title = "Weight (kg)", ViewWindow = new { min = 45, max = 110}, Ticks = new[] { 50, 60, 70, 80, 90, 100, 110 } },
                    vAxis = new { Title = "Length (cm)", Ticks = new[] { 0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26 } },
                    Legend = new
                    {
                        Display = true,
                        Position = "bottom"
                    },
                    CurveType = "Function",
                    series = new[] {
                        new { color = "#e10808", visibleInLegend = true, type = "linear", pointSize = 0 } ,
                        new { color = "#ffd700", visibleInLegend = true, type = "linear", pointSize = 0 } ,
                        new { color = "#0c8d00", visibleInLegend = true, type = "linear", pointSize = 0 } ,
                        new { color = "#ffd700", visibleInLegend = true, type = "linear", pointSize = 0 } ,
                        new { color = "#e10808", visibleInLegend = true, type = "linear", pointSize = 0 } ,
                        new { color = "blue", visibleInLegend = false, type = "scatter", pointSize = 20 }
                    }
                };

                await JsRuntime.InvokeAsync<Task>("drawChart", data, options);
            }
        }

        public async Task<string> GetChartData(byte id, double x, double y)
        {
            string data = await ChartService.GetAllWFLJson(id, x, y, GraphTypes.PValue);
            return data;
        }
    }    
}
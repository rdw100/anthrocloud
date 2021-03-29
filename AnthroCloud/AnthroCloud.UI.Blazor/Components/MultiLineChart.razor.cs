using AnthroCloud.Entities;
using AnthroCloud.UI.Blazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Text.Json;
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

        public string Gdata { get; set; } 

        protected override async Task OnParametersSetAsync()
        {
            Gdata = await GetChartData(1, 73, 9);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                //var gChart = new Data.GrowthChartData();
                //var data = GetChartData(1, 73, 9);
                //var data = gChart.GetData();
                var data = Gdata;
                var options = new
                {
                    Title = "Birth to 5 Years (Percentile)",
                    Width = 900,
                    height = 500,
                    hAxis = new { Title = "Weight (kg)" },//, ViewWindow = new { min = 45, max = 110}, Ticks = new[] { 50, 60, 70, 80, 90, 100, 110 } },
                    vAxis = new { Title = "Length (cm)" },// Ticks = new[] { 0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26 } },
                    //HAxis = new[]
                    //    {
                    //        new {
                    //            ScaleLabel = new { Display = true, labelString = "Length (cm)" },
                    //            //ViewWindow = new { min = 45, max = 110},
                    //            Ticks = new { AutoSkip = false, BeginAtZero = false, StepSize = 10, SuggestedMax = 110, SuggestMin = 45 }
                    //        }
                    //    },
                    Legend = new
                    {
                        Display = true,
                        Position = "left",
                        Labels = new
                        {
                            fontColor = "rgb(255, 99, 132)"
                        }
                    },
                    CurveType = "Function",
                    PointsVisible = true,
                    series = new[] {
                        new { color = "#e10808", visibleInLegend = false, type = "linear", pointSize = 5 } ,
                        new { color = "#ffd700", visibleInLegend = false, type = "linear", pointSize = 5 } ,
                        new { color = "#0c8d00", visibleInLegend = false, type = "linear", pointSize = 5 } ,
                        new { color = "#ffd700", visibleInLegend = false, type = "linear", pointSize = 5 } ,
                        new { color = "#e10808", visibleInLegend = false, type = "linear", pointSize = 5 } ,
                        new { color = "blue", visibleInLegend = false, type = "scatter", pointSize = 20 }
                    }
            };

                await JsRuntime.InvokeAsync<Task>("drawChart", data, options);
            }
        }

        public async Task<string> GetChartData(byte id, double x, double y)
        {
            string data;
            data = await ChartService.GetAllWFLJson(id, x, y);

            //var result = JsonSerializer.Serialize(data);
            return data;
        }
    }    
}
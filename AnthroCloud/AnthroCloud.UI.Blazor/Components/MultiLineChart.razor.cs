using AnthroCloud.UI.Blazor.Services;
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

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var gChart = new Data.GrowthChartData();
            var data = gChart.GetData();
            var options = new
            {
                Title = "Title",
                Width = 900,
                height = 500,
                VAxis = new
                {
                    Title = "Dollars ($)"
                    //new {
                    //    ScaleLabel = new { Display = true, labelString = "Weight (kg)" },
                    //    Ticks = new { BeginAtZero = true, StepSize = 2, SuggestedMax = 26, SuggestMin = 0 }
                    //}
                },
                HAxis = new
                {
                    Title = "Years"
                    //new {
                    //    ScaleLabel = new { Display = true, labelString = "Length (cm)" },
                    //    ViewWindow = new { min = 45, max = 110},
                    //    Ticks = new { AutoSkip = false, BeginAtZero = false, StepSize = 10, SuggestedMax = 110, SuggestMin = 45 }
                    //}
                },
                Legend = new
                {
                    Display = true,
                    Position = "left",
                    Labels = new
                    {
                        fontColor = "rgb(255, 99, 132)"
                    }
                },
                Colors = new[] { "#0000ff", "#00ff00" },
                CurveType = "Function"
            };

            await JsRuntime.InvokeAsync<Task>("drawChart", data, options);
        }
    }
}
using AnthroCloud.Entities;
using AnthroCloud.UI.Blazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Components
{
    /// <summary>
    /// Represents a Blazor Chart component that calls JavaScript 
    /// from C# by injecting the IJSRuntime service.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase" />
    public class LineChartBase : ComponentBase
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public IChartService ChartService { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public ChartTypes Types { get; set; }

        [Parameter]
        public string[] Data { get; set; }

        [Parameter]
        public string[] BackgroundColor { get; set; }

        [Parameter]
        public string[] BorderColor { get; set; } = new[] { "rgb(255, 99, 132)" };

        [Parameter]
        public int BorderWidthNum { get; set; } = 0;

        [Parameter]
        public string[] Labels { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string DatasetTitle { get; set; } = "My First Dataset";

        readonly DataItem[] myData = new DataItem[] {
            new DataItem
            {
                X = 2.75,
                Y = 50
            },
            new DataItem
            {
                X = 5.5,
                Y = 60
            },
            new DataItem
            {
                X = 7,
                Y = 70
            },
            new DataItem
            {
                X = 9,
                Y = 80
            },
            new DataItem
            {
                X = 11,
                Y = 90
            },
            new DataItem
            {
                X = 12.5,
                Y = 100
            },
            new DataItem
            {
                X = 15,
                Y = 110
            }
        };

        /// <summary>
        /// Instantiates the Chart class with all configurable options.
        /// Method invoked after each time the component has been rendered. Note that the component does
        /// not automatically re-render after the completion of any returned <see cref="T:System.Threading.Tasks.Task" />, because
        /// that would cause an infinite render loop.
        /// </summary>
        /// <param name="firstRender">Set to <c>true</c> if this is the first time <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)" /> has been invoked
        /// on this component instance; otherwise <c>false</c>.</param>
        /// <remarks>
        /// The <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)" /> and <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync(System.Boolean)" /> lifecycle methods
        /// are useful for performing interop, or interacting with values received from <c>@ref</c>.
        /// Use the <paramref name="firstRender" /> parameter to ensure that initialization work is only performed
        /// once.
        /// https://www.chartjs.org/docs/latest/axes/cartesian/linear.html#linear-cartesian-axis
        /// </remarks>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            // TODO:  Original LineChartController call returns
            // JsonResult to JS manipulated data array
            List<WeightForLength> chartData = await ChartService.GetAllWFL(1, 73, 9);

            var config = new
            {
                Type = Types.ToString().ToLower(),
                Options = new
                {
                    Responsive = true,
                    Title = new
                    {
                        Display = true,
                        Text = "Birth to 5 Years (Percentile)"
                    },
                    Scales = new
                    {
                        YAxes = new[]
                        {
                            new {
                                ScaleLabel = new { Display = true, labelString = "Weight (kg)" },
                                Ticks = new { BeginAtZero = true, StepSize = 2, SuggestedMax = 26, SuggestMin = 0 }
                            }
                        },
                        XAxes = new[]
                        {
                            new {
                                ScaleLabel = new { Display = true, labelString = "Length (cm)" }
                            }
                        }
                    },
                    Legend = new
                    {
                        Display = true,
                        Position = "right",
                        Labels = new
                        {
                            fontColor = "rgb(255, 99, 132)"
                        }
                    },
                    Series = new[]
                    {
                        new {Color = "#e10808" }
                    }
                },
                Data = new
                {
                    Datasets = new[]
                    {
                    new {
                            Data = myData,
                            // BackgroundColor = BackgroundColor,
                            BorderColor = BorderColor,
                            BorderWidth = BorderWidthNum,
                            Label = DatasetTitle,
                            fill = false
                    }
                },
                    Labels = Labels
                }
            };

            // Inject the IJSRuntime abstraction into a class (.cs)
            await JSRuntime.InvokeVoidAsync("setup", Id, config);
        }
    }

    class DataItem
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}

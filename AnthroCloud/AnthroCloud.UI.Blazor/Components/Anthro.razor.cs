using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using AnthroCloud.UI.Blazor.Services;

namespace AnthroCloud.UI.Blazor.Components
{
    public class AnthroBase : ComponentBase
    {
        [Inject]
        public IAnthroService AnthroService { get; set; }

        public double BMI { get; set; }

        [Parameter]
        public double Weight { get; set; } = 9.00;

        [Parameter]
        public double Height { get; set; } = 73.00;

        public async Task<double> CalculateBMI()
        {
            BMI = await AnthroService.GetBMI(Weight, Height);
            return BMI;
        }
    }
}

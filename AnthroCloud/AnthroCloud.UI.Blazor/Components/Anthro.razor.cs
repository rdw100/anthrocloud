using AnthroCloud.Business;
using AnthroCloud.UI.Blazor.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Components
{
    public class AnthroBase : ComponentBase
    {
        [Inject]
        public IAnthroService AnthroService { get; set; }

        public double BMI { get; set; }

        public string AgeString { get; set; }

        public Age Age { get; set; }
                        
        [Parameter]
        public double Weight { get; set; } = 9.00;

        [Parameter]
        public double Height { get; set; } = 73.00;

        [Parameter]
        public DateTime Birth { get; set; } = DateTime.Today.AddYears(-1);

        [Parameter]
        public DateTime Visit { get; set; } = DateTime.Today;

        public async Task<double> CalculateBMI()
        {
            string BirthDateString = string.Format("{0:yyyy-MM-dd}", Birth);
            string VisitDateString = string.Format("{0:yyyy-MM-dd}", Visit);

            Age = await AnthroService.GetAge(BirthDateString, VisitDateString);            
            AgeString = Age.ToReadableString();

            BMI = await AnthroService.GetBMI(Weight, Height);
            return BMI;
        }
    }
}

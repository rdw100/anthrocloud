using AnthroCloud.UI.Blazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Components
{
    public class AnthroFormBase : ComponentBase
    {
        [Inject]
        public IAnthroService AnthroService { get; set; }

        protected EditContext editContext;

        public FormViewModel formModel = new FormViewModel();

        protected override void OnInitialized()
        {
            editContext = new EditContext(formModel);
        }

        protected async Task HandleValidSubmitAsync()
        {
            var isValid = editContext.Validate();
            if (isValid)
            {
                string BirthDateString = string.Format("{0:yyyy-MM-dd}", formModel.DateOfBirth);
                string VisitDateString = string.Format("{0:yyyy-MM-dd}", formModel.DateOfVisit);

                formModel.Age = await AnthroService.GetAge(BirthDateString, VisitDateString);
                formModel.AgeString = formModel.Age.ToReadableString().ToString();

                Tuple<double, double> wfaTuple = await AnthroService.GetWFA(formModel.Weight, formModel.Age.TotalDays.ToString(), formModel.Sex);

                formModel.WfaZscore = wfaTuple.Item1;
                formModel.WfaPercentile = wfaTuple.Item2;

                formModel.BMI = await AnthroService.GetBMI(formModel.Weight, formModel.Height);                    
            }
            else
            {
                    
            }
        }
    }
}

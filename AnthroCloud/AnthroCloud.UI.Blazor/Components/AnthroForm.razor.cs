using AnthroCloud.Business;
using AnthroCloud.Entities;
using AnthroCloud.UI.Blazor.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Components
{
    public class AnthroFormBase : ComponentBase
    {
        [Inject]
        public IAnthroService AnthroService { get; set; }

        public FormViewModel formModel = new FormViewModel();

        public async void HandleValidSubmitAsync() // TODO: <task> async
        {
            string BirthDateString = string.Format("{0:yyyy-MM-dd}", formModel.DateOfBirth);
            string VisitDateString = string.Format("{0:yyyy-MM-dd}", formModel.DateOfVisit);

            formModel.Age = await AnthroService.GetAge(BirthDateString, VisitDateString);
            formModel.AgeString = formModel.Age.ToReadableString();
            
            //Tuple<double, double> wfaTuple = await AnthroService.GetWFA(formModel.Weight, formModel.Age.ToDaysString(), formModel.Sex);

            //formModel.WfaZscore = wfaTuple.Item1; //SetDecimalZero(wfaTuple.Item1);
            //formModel.WfaPercentile = wfaTuple.Item2; //SetDecimalZero(wfaTuple.Item2);

            //Task<Tuple<double, double>> GetWFA(double weight, string ageInDays, Sexes sex)

            formModel.BMI = await AnthroService.GetBMI(formModel.Weight, formModel.Height);
        }
    }
}

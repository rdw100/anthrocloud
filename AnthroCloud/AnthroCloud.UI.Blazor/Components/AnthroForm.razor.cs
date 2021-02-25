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

        [Inject]
        public IAnthroStatsService AnthroStatsService { get; set; }

        protected EditContext editContext;

        public FormViewModel formModel = new FormViewModel();

        public bool loadFailed;

        protected override void OnInitialized()
        {
            editContext = new EditContext(formModel);
        }

        protected async Task HandleValidSubmitAsync()
        {
            var isValid = editContext.Validate();
            
            try
            {
                loadFailed = false;
                if (isValid)
                {
                    string BirthDateString = string.Format("{0:yyyy-MM-dd}", formModel.DateOfBirth);
                    string VisitDateString = string.Format("{0:yyyy-MM-dd}", formModel.DateOfVisit);

                    formModel.Age = await AnthroService.GetAge(BirthDateString, VisitDateString);
                    formModel.AgeString = formModel.Age.ToReadableString().ToString();
                    formModel.BMI = await AnthroService.GetBMI(formModel.Weight, formModel.LengthHeight);  

                    Tuple<double, double> wfaTuple = await AnthroStatsService.GetWFA(formModel.Weight, formModel.Age.TotalDays.ToString(), formModel.Sex);
                    formModel.WfaZscore = wfaTuple.Item1;
                    formModel.WfaPercentile = wfaTuple.Item2;

                    Tuple<double, double> muacTuple = await AnthroStatsService.GetMUAC(formModel.MUAC, formModel.Age.TotalDays.ToString(), formModel.Sex);
                    formModel.MuacZscore = muacTuple.Item1;
                    formModel.MuacPercentile = muacTuple.Item2;

                    Tuple<double, double> bfaTuple = await AnthroStatsService.GetBFA(formModel.BMI, formModel.Age.TotalDays.ToString(), formModel.Sex);
                    formModel.BfaZscore = bfaTuple.Item1;
                    formModel.BfaPercentile = bfaTuple.Item2;

                    Tuple<double, double> hcaTuple = await AnthroStatsService.GetHCA(formModel.HeadCircumference, formModel.Age.TotalDays.ToString(), formModel.Sex);
                    formModel.HcaZscore = hcaTuple.Item1;
                    formModel.HcaPercentile = hcaTuple.Item2;

                    Tuple<double, double> hfaTuple = await AnthroStatsService.GetHFA(formModel.LengthHeight, formModel.Age.TotalDays.ToString(), formModel.Sex);
                    formModel.HfaZscore = hfaTuple.Item1;
                    formModel.HfaPercentile = hfaTuple.Item2;

                    Tuple<double, double> lfaTuple = await AnthroStatsService.GetLFA(formModel.LengthHeight, formModel.Age.TotalDays.ToString(), formModel.Sex);
                    formModel.LfaZscore = lfaTuple.Item1;
                    formModel.LfaPercentile = lfaTuple.Item2;

                    Tuple<double, double> sfaTuple = await AnthroStatsService.GetSFA(formModel.SubscapularSkinFold, formModel.Age.TotalDays.ToString(), formModel.Sex);
                    formModel.SsfZscore = sfaTuple.Item1;
                    formModel.SsfPercentile = sfaTuple.Item2;

                    Tuple<double, double> tfaTuple = await AnthroStatsService.GetTFA(formModel.TricepsSkinFold, formModel.Age.TotalDays.ToString(), formModel.Sex);
                    formModel.TsfZscore = tfaTuple.Item1;
                    formModel.TsfPercentile = tfaTuple.Item2;

                    Tuple<double, double> wfhTuple = await AnthroStatsService.GetWFH(formModel.Weight, formModel.LengthHeight, formModel.Sex);
                    formModel.WfhZscore = wfhTuple.Item1;
                    formModel.WfhPercentile = wfhTuple.Item2;

                    Tuple<double, double> wflTuple = await AnthroStatsService.GetWFL(formModel.Weight, formModel.LengthHeight, formModel.Sex);
                    formModel.WflZscore = wflTuple.Item1;
                    formModel.WflPercentile = wflTuple.Item2;
                }
                else
                {
                    loadFailed = true;
                }
            }
            catch (Exception)
            {
                loadFailed = true;
            }
        }
    }
}

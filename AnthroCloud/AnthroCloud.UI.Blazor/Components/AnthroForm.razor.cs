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

        protected async Task HandleSubmitAsync()
        {
            var isValid = editContext.Validate();

            try
            {
                loadFailed = false;
                if (isValid)
                {
                    string BirthDateString = string.Format("{0:yyyy-MM-dd}", formModel.FormInputs.DateOfBirth);
                    string VisitDateString = string.Format("{0:yyyy-MM-dd}", formModel.FormInputs.DateOfVisit);

                    formModel.FormInputs.Age = await AnthroService.GetAge(BirthDateString, VisitDateString);
                    formModel.FormInputs.AgeString = formModel.FormInputs.Age.ToReadableString().ToString();

                    formModel.FormInputs.BMI = await AnthroService.GetBMI(formModel.FormInputs.Weight, formModel.FormInputs.LengthHeight);

                    formModel.FormOutputs = await AnthroStatsService.GetScores(formModel.FormInputs);                    
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

        protected async Task HandleValidSubmitAsync()
        {
            var isValid = editContext.Validate();
            
            try
            {
                loadFailed = false;
                if (isValid)
                {
                    string BirthDateString = string.Format("{0:yyyy-MM-dd}", formModel.FormInputs.DateOfBirth);
                    string VisitDateString = string.Format("{0:yyyy-MM-dd}", formModel.FormInputs.DateOfVisit);

                    formModel.FormInputs.Age = await AnthroService.GetAge(BirthDateString, VisitDateString);
                    formModel.FormInputs.AgeString = formModel.FormInputs.Age.ToReadableString().ToString();

                    formModel.FormInputs.BMI = await AnthroService.GetBMI(formModel.FormInputs.Weight, formModel.FormInputs.LengthHeight);  

                    Tuple<double, double> wfaTuple = await AnthroStatsService.GetWFA(formModel.FormInputs.Weight, formModel.FormInputs.Age.TotalDays.ToString(), formModel.FormInputs.Sex);
                    formModel.WfaZscore = wfaTuple.Item1;
                    formModel.WfaPercentile = wfaTuple.Item2;

                    Tuple<double, double> muacTuple = await AnthroStatsService.GetMUAC(formModel.FormInputs.MUAC, formModel.FormInputs.Age.TotalDays.ToString(), formModel.FormInputs.Sex);
                    formModel.MuacZscore = muacTuple.Item1;
                    formModel.MuacPercentile = muacTuple.Item2;

                    Tuple<double, double> bfaTuple = await AnthroStatsService.GetBFA(formModel.FormInputs.BMI, formModel.FormInputs.Age.TotalDays.ToString(), formModel.FormInputs.Sex);
                    formModel.BfaZscore = bfaTuple.Item1;
                    formModel.BfaPercentile = bfaTuple.Item2;

                    Tuple<double, double> hcaTuple = await AnthroStatsService.GetHCA(formModel.FormInputs.HeadCircumference, formModel.FormInputs.Age.TotalDays.ToString(), formModel.FormInputs.Sex);
                    formModel.HcaZscore = hcaTuple.Item1;
                    formModel.HcaPercentile = hcaTuple.Item2;

                    Tuple<double, double> hfaTuple = await AnthroStatsService.GetHFA(formModel.FormInputs.LengthHeight, formModel.FormInputs.Age.TotalDays.ToString(), formModel.FormInputs.Sex);
                    formModel.HfaZscore = hfaTuple.Item1;
                    formModel.HfaPercentile = hfaTuple.Item2;

                    Tuple<double, double> lfaTuple = await AnthroStatsService.GetLFA(formModel.FormInputs.LengthHeight, formModel.FormInputs.Age.TotalDays.ToString(), formModel.FormInputs.Sex);
                    formModel.LfaZscore = lfaTuple.Item1;
                    formModel.LfaPercentile = lfaTuple.Item2;

                    Tuple<double, double> sfaTuple = await AnthroStatsService.GetSFA(formModel.FormInputs.SubscapularSkinFold, formModel.FormInputs.Age.TotalDays.ToString(), formModel.FormInputs.Sex);
                    formModel.SsfZscore = sfaTuple.Item1;
                    formModel.SsfPercentile = sfaTuple.Item2;

                    Tuple<double, double> tfaTuple = await AnthroStatsService.GetTFA(formModel.FormInputs.TricepsSkinFold, formModel.FormInputs.Age.TotalDays.ToString(), formModel.FormInputs.Sex);
                    formModel.TsfZscore = tfaTuple.Item1;
                    formModel.TsfPercentile = tfaTuple.Item2;

                    Tuple<double, double> wfhTuple = await AnthroStatsService.GetWFH(formModel.FormInputs.Weight, formModel.FormInputs.LengthHeight, formModel.FormInputs.Sex);
                    formModel.WfhZscore = wfhTuple.Item1;
                    formModel.WfhPercentile = wfhTuple.Item2;

                    Tuple<double, double> wflTuple = await AnthroStatsService.GetWFL(formModel.FormInputs.Weight, formModel.FormInputs.LengthHeight, formModel.FormInputs.Sex);
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

        public string setColor(double zscore)
        {
            var colorCode = zscore switch
            {
                double n when (n <= 1 && n >= -1) => "#eafaf1", //GREEN
                double n when (n <= -1 && n >= -2) || (n <= 2 && n > 1) => "#fef9e7", //GOLD
                double n when (n < -2 && n >= -3) || (n <= 3 && n > 2) => "#fdedec", //RED
                double n when (n > 3 || n < -3) => "#aab3bb", //BLACK
                _ => string.Empty,
            };
            return colorCode;
        }

        public string setPercentileRange(double measure)
        {
            string result = string.Empty;

            if (measure >= 99.9 || measure <= .01)
            {
                result = "NA";
            }
            else
            {
                result = measure.ToString();
            }

            return result;
        }

        public string setRangeControl(double measure, byte ageInYears, byte ageInMonths)
        {
            string result = string.Empty;

            if (ageInYears < 1 && ageInMonths < 3)
            {
                result = "50";
            }
            else
            {
                result = measure.ToString();
            }

            return result;
        }

        public string setPercText(double measure, byte ageInYears, byte ageInMonths)
        {
            string result = string.Empty;

            if (ageInYears < 1 && ageInMonths < 3)
            {
                result = "NA";
            }
            else
            {
                result = measure.ToString();
            }

            return result;
        }

        public string setZscoreText(double measure, byte ageInYears, byte ageInMonths)
        {
            string result = string.Empty;

            if (ageInYears < 1 && ageInMonths < 3)
            {
                result = "NA";
            }
            else
            {
                result = measure.ToString("0.00");
            }

            return result;
        }
    }
}

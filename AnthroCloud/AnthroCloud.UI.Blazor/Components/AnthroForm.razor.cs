using AnthroCloud.Entities;
using AnthroCloud.Entities.Charts;
using AnthroCloud.UI.Blazor.Pages;
using AnthroCloud.UI.Blazor.Services;
using AnthroCloud.UI.Blazor.Shared;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Components
{
    public class AnthroFormBase : ComponentBase
    {
        [Inject]
        public IAnthroService AnthroService { get; set; }

        [Inject]
        public IAnthroStatsService AnthroStatsService { get; set; }

        [Inject]
        [CascadingParameter] public IModalService Modal { get; set; }

        [Inject]
        protected ILogger<AnthroFormBase> Logger { get; set; }

        [CascadingParameter]
        public GlobalError Error { get; set; }

        protected EditContext editContext;

        public FormViewModel formModel = new();

        public bool loadFailed;

        public string ExecutionTime;

        public string ErrorMessage;

        public bool IsError => !string.IsNullOrWhiteSpace(ErrorMessage);

        protected bool IsCalculating { get; set; }

        protected override void OnInitialized()
        {
            editContext = new EditContext(formModel);
        }

        protected async Task HandleHcaAsync()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var isValid = editContext.Validate();

            try
            {
                loadFailed = false;

                if (isValid)
                {
                    IsCalculating = true;

                    string BirthDateString = FormattableString.Invariant($"{formModel.FormInputs.DateOfBirth:yyyy-MM-dd}");
                    string VisitDateString = FormattableString.Invariant($"{formModel.FormInputs.DateOfVisit:yyyy-MM-dd}");

                    formModel.FormInputs.Age = await AnthroService.GetAge(BirthDateString, VisitDateString);
                    formModel.FormInputs.AgeString = formModel.FormInputs.Age.ToReadableString().ToString();

                    formModel.FormInputs.BMI = await AnthroService.GetBMI(formModel.FormInputs.Weight, formModel.FormInputs.LengthHeightAdjusted);

                    formModel.FormOutputs = await AnthroService.GetHcaScores(formModel.FormInputs);

                    IsCalculating = false;
                }
                else
                {
                    loadFailed = true;
                }
            }
            catch (Exception ex)
            {
                loadFailed = true;
                Error.ProcessError(ex);
                ErrorMessage = ex.Message;
                Logger.LogWarning(ex.Message);
            }

            watch.Stop();
            ExecutionTime = "- HCA Click - " + watch.ElapsedMilliseconds + "ms";
        }

        protected async Task HandleMuacAsync()
        {
            var isValid = editContext.Validate();

            var watch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                loadFailed = false;

                if (isValid)
                {
                    IsCalculating = true;

                    string BirthDateString = FormattableString.Invariant($"{formModel.FormInputs.DateOfBirth:yyyy-MM-dd}");
                    string VisitDateString = FormattableString.Invariant($"{formModel.FormInputs.DateOfVisit:yyyy-MM-dd}");

                    formModel.FormInputs.Age = await AnthroService.GetAge(BirthDateString, VisitDateString);
                    formModel.FormInputs.AgeString = formModel.FormInputs.Age.ToReadableString().ToString();

                    formModel.FormInputs.BMI = await AnthroService.GetBMI(formModel.FormInputs.Weight, formModel.FormInputs.LengthHeightAdjusted);

                    formModel.FormOutputs = await AnthroService.GetMuacScores(formModel.FormInputs);

                    IsCalculating = false;
                }
                else
                {
                    loadFailed = true;
                }
            }
            catch (Exception ex)
            {
                loadFailed = true;
                Error.ProcessError(ex);
                ErrorMessage = ex.Message;
                Logger.LogWarning(ex.Message);
            }

            watch.Stop();
            ExecutionTime = "- MUAC Click - " + watch.ElapsedMilliseconds + "ms";
        }

        protected async Task HandleTsfAsync()
        {
            var isValid = editContext.Validate();

            var watch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                loadFailed = false;

                if (isValid)
                {
                    IsCalculating = true;

                    string BirthDateString = FormattableString.Invariant($"{formModel.FormInputs.DateOfBirth:yyyy-MM-dd}");
                    string VisitDateString = FormattableString.Invariant($"{formModel.FormInputs.DateOfVisit:yyyy-MM-dd}");

                    formModel.FormInputs.Age = await AnthroService.GetAge(BirthDateString, VisitDateString);
                    formModel.FormInputs.AgeString = formModel.FormInputs.Age.ToReadableString().ToString();

                    formModel.FormInputs.BMI = await AnthroService.GetBMI(formModel.FormInputs.Weight, formModel.FormInputs.LengthHeightAdjusted);

                    formModel.FormOutputs = await AnthroService.GetTsfScores(formModel.FormInputs);

                    IsCalculating = false;
                }
                else
                {
                    loadFailed = true;
                }
            }
            catch (Exception ex)
            {
                loadFailed = true;
                Error.ProcessError(ex);
                ErrorMessage = ex.Message;
                Logger.LogWarning(ex.Message);
            }

            watch.Stop();
            ExecutionTime = "- TSF Click - " + watch.ElapsedMilliseconds + "ms";
        }

        protected async Task HandleSsfAsync()
        {
            var isValid = editContext.Validate();

            var watch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                loadFailed = false;

                if (isValid)
                {
                    IsCalculating = true;

                    string BirthDateString = FormattableString.Invariant($"{formModel.FormInputs.DateOfBirth:yyyy-MM-dd}");
                    string VisitDateString = FormattableString.Invariant($"{formModel.FormInputs.DateOfVisit:yyyy-MM-dd}");

                    formModel.FormInputs.Age = await AnthroService.GetAge(BirthDateString, VisitDateString);
                    formModel.FormInputs.AgeString = formModel.FormInputs.Age.ToReadableString().ToString();

                    formModel.FormInputs.BMI = await AnthroService.GetBMI(formModel.FormInputs.Weight, formModel.FormInputs.LengthHeightAdjusted);

                    formModel.FormOutputs = await AnthroService.GetSsfScores(formModel.FormInputs);

                    IsCalculating = false;
                }
                else
                {
                    loadFailed = true;
                }
            }
            catch (Exception ex)
            {
                loadFailed = true;
                Error.ProcessError(ex);
                ErrorMessage = ex.Message;
                Logger.LogWarning(ex.Message);
            }

            watch.Stop();
            ExecutionTime = "- SSF Click - " + watch.ElapsedMilliseconds + "ms";
        }

        protected async Task HandleMeasuredAsync()
        {
            var isValid = editContext.Validate();

            var watch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                loadFailed = false;

                if (isValid)
                {
                    IsCalculating = true;

                    string BirthDateString = FormattableString.Invariant($"{formModel.FormInputs.DateOfBirth:yyyy-MM-dd}");
                    string VisitDateString = FormattableString.Invariant($"{formModel.FormInputs.DateOfVisit:yyyy-MM-dd}");

                    formModel.FormInputs.Age = await AnthroService.GetAge(BirthDateString, VisitDateString);
                    formModel.FormInputs.AgeString = formModel.FormInputs.Age.ToReadableString().ToString();

                    formModel.FormInputs.BMI = await AnthroService.GetBMI(formModel.FormInputs.Weight, formModel.FormInputs.LengthHeightAdjusted);

                    formModel.FormOutputs = await AnthroService.GetMeasuredScores(formModel.FormInputs);

                    IsCalculating = false;
                }
                else
                {
                    loadFailed = true;
                }
            }
            catch (Exception ex)
            {
                loadFailed = true;
                Error.ProcessError(ex);
                ErrorMessage = ex.Message;
                Logger.LogWarning(ex.Message);
            }

            watch.Stop();
            ExecutionTime = "- Measured (HT/WT) Click - " + watch.ElapsedMilliseconds + "ms";
        }

        protected async Task HandleSubmitAsync()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var isValid = editContext.Validate();

            try
            {
                loadFailed = false;

                if (isValid)
                {
                    IsCalculating = true;

                    string BirthDateString = FormattableString.Invariant($"{formModel.FormInputs.DateOfBirth:yyyy-MM-dd}");
                    string VisitDateString = FormattableString.Invariant($"{formModel.FormInputs.DateOfVisit:yyyy-MM-dd}");

                    formModel.FormInputs.Age = await AnthroService.GetAge(BirthDateString, VisitDateString);
                    formModel.FormInputs.AgeString = formModel.FormInputs.Age.ToReadableString().ToString();

                    formModel.FormInputs.BMI = await AnthroService.GetBMI(formModel.FormInputs.Weight, formModel.FormInputs.LengthHeight);

                    formModel.FormOutputs = await AnthroService.GetScores(formModel.FormInputs);

                    IsCalculating = false;
                }
                else
                {
                    loadFailed = true;
                }
            }
            catch (Exception ex)
            {
                loadFailed = true;
                Error.ProcessError(ex);
                ErrorMessage = ex.Message;
                Logger.LogWarning(ex.Message);
            }

            watch.Stop();
            ExecutionTime = "- Submit 1 (New) - " + watch.ElapsedMilliseconds + "ms";
        }

        protected async Task HandleValidSubmitAsync()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var isValid = editContext.Validate();

            try
            {
                loadFailed = false;

                if (isValid)
                {
                    IsCalculating = true;

                    string BirthDateString = FormattableString.Invariant($"{formModel.FormInputs.DateOfBirth:yyyy-MM-dd}");
                    string VisitDateString = FormattableString.Invariant($"{formModel.FormInputs.DateOfVisit:yyyy-MM-dd}");

                    formModel.FormInputs.Age = await AnthroService.GetAge(BirthDateString, VisitDateString);
                    formModel.FormInputs.AgeString = formModel.FormInputs.Age.ToReadableString().ToString();

                    formModel.FormInputs.BMI = await AnthroService.GetBMI(formModel.FormInputs.Weight, formModel.FormInputs.LengthHeight);

                    Tuple<double, double> wfaTuple = await AnthroStatsService.GetWFA(formModel.FormInputs.Weight, FormattableString.Invariant($"{formModel.FormInputs.Age.TotalDays}"), formModel.FormInputs.Sex);
                    formModel.FormOutputs.WfaZscore = wfaTuple.Item1;
                    formModel.FormOutputs.WfaPercentile = wfaTuple.Item2;

                    Tuple<double, double> muacTuple = await AnthroStatsService.GetMUAC(formModel.FormInputs.MUAC, FormattableString.Invariant($"{formModel.FormInputs.Age.TotalDays}"), formModel.FormInputs.Sex);
                    formModel.FormOutputs.MuacZscore = muacTuple.Item1;
                    formModel.FormOutputs.MuacPercentile = muacTuple.Item2;

                    Tuple<double, double> bfaTuple = await AnthroStatsService.GetBFA(formModel.FormInputs.BMI, FormattableString.Invariant($"{formModel.FormInputs.Age.TotalDays}"), formModel.FormInputs.Sex);
                    formModel.FormOutputs.BfaZscore = bfaTuple.Item1;
                    formModel.FormOutputs.BfaPercentile = bfaTuple.Item2;

                    Tuple<double, double> hcaTuple = await AnthroStatsService.GetHCA(formModel.FormInputs.HeadCircumference, FormattableString.Invariant($"{formModel.FormInputs.Age.TotalDays}"), formModel.FormInputs.Sex);
                    formModel.FormOutputs.HcaZscore = hcaTuple.Item1;
                    formModel.FormOutputs.HcaPercentile = hcaTuple.Item2;

                    Tuple<double, double> hfaTuple = await AnthroStatsService.GetHFA(formModel.FormInputs.LengthHeight, FormattableString.Invariant($"{formModel.FormInputs.Age.TotalDays}"), formModel.FormInputs.Sex);
                    formModel.FormOutputs.HfaZscore = hfaTuple.Item1;
                    formModel.FormOutputs.HfaPercentile = hfaTuple.Item2;

                    Tuple<double, double> lfaTuple = await AnthroStatsService.GetLFA(formModel.FormInputs.LengthHeight, FormattableString.Invariant($"{formModel.FormInputs.Age.TotalDays}"), formModel.FormInputs.Sex);
                    formModel.FormOutputs.LfaZscore = lfaTuple.Item1;
                    formModel.FormOutputs.LfaPercentile = lfaTuple.Item2;

                    Tuple<double, double> sfaTuple = await AnthroStatsService.GetSFA(formModel.FormInputs.SubscapularSkinFold, FormattableString.Invariant($"{formModel.FormInputs.Age.TotalDays}"), formModel.FormInputs.Sex);
                    formModel.FormOutputs.SsfZscore = sfaTuple.Item1;
                    formModel.FormOutputs.SsfPercentile = sfaTuple.Item2;

                    Tuple<double, double> tfaTuple = await AnthroStatsService.GetTFA(formModel.FormInputs.TricepsSkinFold, FormattableString.Invariant($"{formModel.FormInputs.Age.TotalDays}"), formModel.FormInputs.Sex);
                    formModel.FormOutputs.TsfZscore = tfaTuple.Item1;
                    formModel.FormOutputs.TsfPercentile = tfaTuple.Item2;

                    Tuple<double, double> wfhTuple = await AnthroStatsService.GetWFH(formModel.FormInputs.Weight, formModel.FormInputs.LengthHeight, formModel.FormInputs.Sex);
                    formModel.FormOutputs.WfhZscore = wfhTuple.Item1;
                    formModel.FormOutputs.WfhPercentile = wfhTuple.Item2;

                    Tuple<double, double> wflTuple = await AnthroStatsService.GetWFL(formModel.FormInputs.Weight, formModel.FormInputs.LengthHeight, formModel.FormInputs.Sex);
                    formModel.FormOutputs.WflZscore = wflTuple.Item1;
                    formModel.FormOutputs.WflPercentile = wflTuple.Item2;

                    IsCalculating = false;
                }
                else
                {
                    loadFailed = true;
                }
            }
            catch (Exception ex)
            {
                loadFailed = true;
                Error.ProcessError(ex);
                ErrorMessage = ex.Message;
                Logger.LogWarning(ex.Message);
            }

            watch.Stop();
            ExecutionTime = "- Submit 2 (Original) - " + watch.ElapsedMilliseconds + "ms";
        }

        public string SetColor(double zscore)
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

        public string SetPercentileRange(double measure)
        {
            string result;
            if (measure >= 99.9 || measure <= .01)
            {
                result = "NA";
            }
            else
            {
                result = FormattableString.Invariant($"{measure}");
            }

            return result;
        }

        public string SetRangeControl(double measure, byte ageInYears, byte ageInMonths)
        {
            string result;
            if (ageInYears < 1 && ageInMonths < 3)
            {
                result = "50";
            }
            else
            {
                result = FormattableString.Invariant($"{measure}");
            }

            return result;
        }

        public string SetPercText(double measure, byte ageInYears, byte ageInMonths)
        {
            string result;
            if (ageInYears < 1 && ageInMonths < 3)
            {
                result = "NA";
            }
            else
            {
                result = FormattableString.Invariant($"{measure}");
            }

            return result;
        }

        public string SetZscoreText(double measure, byte ageInYears, byte ageInMonths)
        {
            string result;
            if (ageInYears < 1 && ageInMonths < 3)
            {
                result = "NA";
            }
            else
            {
                result = measure.ToString("0.00", CultureInfo.InvariantCulture);
            }

            return result;
        }

        public string SetChartTitle(string title, Sexes sex)
        {
            if (sex == Sexes.Male)
                title += " Boys";
            else if (sex == Sexes.Female)
                title += " Girls";
            return title;
        }

        public MarkupString LocalLogger { get; set; }

        public void OnValidSubmit()
        {
            LocalLogger = new MarkupString(LocalLogger + $"<br />valid submit on {DateTime.Now}");
        }

        public void OnInvalidSubmit()
        {
            LocalLogger = new MarkupString(LocalLogger + $"<br />INVALID submit on {DateTime.Now}");
        }

        public void ShowGrowthChart(GrowthTypes growth, GraphTypes graph, Sexes sex, double x, double y, string title)
        {
            var parameters = new ModalParameters();
            parameters.Add(nameof(Chart.Growth), growth);
            parameters.Add(nameof(Chart.Graph), graph);
            parameters.Add(nameof(Chart.Sex), sex);
            parameters.Add(nameof(Chart.X), x);
            parameters.Add(nameof(Chart.Y), y);
            Modal.Show<Chart>(SetChartTitle(title, sex), parameters);
        }
    }
}

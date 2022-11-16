﻿using AnthroCloud.Entities;
using AnthroCloud.Entities.Charts;
using AnthroCloud.UI.BlazorApp.Pages;
using AnthroCloud.UI.BlazorApp.Services;
using AnthroCloud.UI.BlazorApp.Shared;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace AnthroCloud.UI.BlazorApp.Components
{
    public class AnthroFormBase : ComponentBase, IDisposable
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

        protected EditContext EditContext { get; set; }

        public FormViewModel FormModel { get; set; }

        public bool LoadFailed { get; set; }

        public string ExecutionTime { get; set; }

        public string ErrorMessage { get; set; }

        public bool IsError => !string.IsNullOrWhiteSpace(ErrorMessage);

        protected bool IsCalculating { get; set; }

        private bool formInvalid = true;

        protected override void OnInitialized()
        {
            FormModel = new FormViewModel();
            EditContext = new EditContext(FormModel);
            EditContext.OnFieldChanged += HandleFieldChanged;
        }

        private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
        {
            formInvalid = !EditContext.Validate();

            if (e.FieldIdentifier.FieldName == "DateOfVisit")
            {
            }

            StateHasChanged();
        }

        public void Dispose()
        {
            EditContext.OnFieldChanged -= HandleFieldChanged;
        }

        protected async Task HandleHcaAsync()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var isValid = EditContext.Validate();

            try
            {
                LoadFailed = false;

                if (isValid)
                {
                    IsCalculating = true;

                    Tuple<double, double> hcaTuple = await AnthroStatsService.GetHCA(
                        FormModel.FormInputs.HeadCircumference,
                        FormattableString.Invariant($"{FormModel.FormOutputs.Age.TotalDays}"),
                        FormModel.FormInputs.Sex).ConfigureAwait(false);

                    FormModel.FormOutputs.HcaZscore = hcaTuple.Item1;
                    FormModel.FormOutputs.HcaPercentile = hcaTuple.Item2;

                    IsCalculating = false;
                }
                else
                {
                    LoadFailed = true;
                }
            }
            catch (ApplicationException ex)
            {
                LoadFailed = true;
                Error.ProcessError(ex);
                ErrorMessage = ex.Message;
                Logger.LogWarning(ex.Message);
            }

            watch.Stop();
            ExecutionTime = "- HCA Click - " + watch.ElapsedMilliseconds + "ms";
        }

        protected async Task HandleMuacAsync()
        {
            var isValid = EditContext.Validate();

            var watch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                LoadFailed = false;

                if (isValid)
                {
                    IsCalculating = true;

                    Tuple<double, double> muacTuple = await AnthroStatsService.GetMUAC(
                        FormModel.FormInputs.MUAC,
                        FormattableString.Invariant($"{FormModel.FormOutputs.Age.TotalDays}"),
                        FormModel.FormInputs.Sex).ConfigureAwait(false);

                    FormModel.FormOutputs.MuacZscore = muacTuple.Item1;
                    FormModel.FormOutputs.MuacPercentile = muacTuple.Item2;

                    IsCalculating = false;
                }
                else
                {
                    LoadFailed = true;
                }
            }
            catch (ApplicationException ex)
            {
                LoadFailed = true;
                Error.ProcessError(ex);
                ErrorMessage = ex.Message;
                Logger.LogWarning(ex.Message);
            }

            watch.Stop();
            ExecutionTime = "- MUAC Click - " + watch.ElapsedMilliseconds + "ms";
        }

        protected async Task HandleTsfAsync()
        {
            var isValid = EditContext.Validate();

            var watch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                LoadFailed = false;

                if (isValid)
                {
                    IsCalculating = true;

                    Tuple<double, double> tfaTuple = await AnthroStatsService.GetTFA(
                        FormModel.FormInputs.TricepsSkinFold,
                        FormattableString.Invariant($"{FormModel.FormOutputs.Age.TotalDays}"),
                        FormModel.FormInputs.Sex).ConfigureAwait(false);

                    FormModel.FormOutputs.TsfZscore = tfaTuple.Item1;
                    FormModel.FormOutputs.TsfPercentile = tfaTuple.Item2;

                    IsCalculating = false;
                }
                else
                {
                    LoadFailed = true;
                }
            }
            catch (ApplicationException ex)
            {
                LoadFailed = true;
                Error.ProcessError(ex);
                ErrorMessage = ex.Message;
                Logger.LogWarning(ex.Message);
            }

            watch.Stop();
            ExecutionTime = "- TSF Click - " + watch.ElapsedMilliseconds + "ms";
        }

        protected async Task HandleSsfAsync()
        {
            var isValid = EditContext.Validate();

            var watch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                LoadFailed = false;

                if (isValid)
                {
                    IsCalculating = true;

                    Tuple<double, double> sfaTuple = await AnthroStatsService.GetSFA(
                        FormModel.FormInputs.SubscapularSkinFold,
                        FormattableString.Invariant($"{FormModel.FormOutputs.Age.TotalDays}"),
                        FormModel.FormInputs.Sex).ConfigureAwait(false);

                    FormModel.FormOutputs.SsfZscore = sfaTuple.Item1;
                    FormModel.FormOutputs.SsfPercentile = sfaTuple.Item2;

                    IsCalculating = false;
                }
                else
                {
                    LoadFailed = true;
                }
            }
            catch (ApplicationException ex)
            {
                LoadFailed = true;
                Error.ProcessError(ex);
                ErrorMessage = ex.Message;
                Logger.LogWarning(ex.Message);
            }

            watch.Stop();
            ExecutionTime = "- SSF Click - " + watch.ElapsedMilliseconds + "ms";
        }

        //protected async Task HandleMeasuredAsync()
        //{
        //    var isValid = EditContext.Validate();

        //    var watch = System.Diagnostics.Stopwatch.StartNew();

        //    try
        //    {
        //        LoadFailed = false;

        //        if (isValid)
        //        {
        //            IsCalculating = true;

        //            //string BirthDateString = FormattableString.Invariant($"{FormModel.FormInputs.DateOfBirth:yyyy-MM-dd}");
        //            //string VisitDateString = FormattableString.Invariant($"{FormModel.FormInputs.DateOfVisit:yyyy-MM-dd}");

        //            //FormModel.FormInputs.Age = await AnthroService.GetAge(BirthDateString, VisitDateString).ConfigureAwait(false);
        //            //FormModel.FormInputs.AgeString = FormModel.FormInputs.Age.ToReadableString().ToString();

        //            //FormModel.FormInputs.BMI = await AnthroService.GetBMI(FormModel.FormInputs.Weight, FormModel.FormInputs.LengthHeightAdjusted).ConfigureAwait(false);

        //            FormModel.FormOutputs = await AnthroService.GetMeasuredScores(FormModel.FormInputs).ConfigureAwait(false);

        //            IsCalculating = false;
        //        }
        //        else
        //        {
        //            LoadFailed = true;
        //        }
        //    }
        //    catch (ApplicationException ex)
        //    {
        //        LoadFailed = true;
        //        Error.ProcessError(ex);
        //        ErrorMessage = ex.Message;
        //        Logger.LogWarning(ex.Message);
        //    }

        //    watch.Stop();
        //    ExecutionTime = "- Measured (HT/WT) Click - " + watch.ElapsedMilliseconds + "ms";
        //}

        public async Task HandleRadioChange(Sexes value)
        {
            FormModel.FormInputs.Sex = value;

            await HandleSubmitAsync().ConfigureAwait(false);

            _ = Task.CompletedTask;
        }

        public async Task HandleMeasuredChange(MeasurementTypes value)
        {
            FormModel.FormInputs.Measured = value;

            await HandleSubmitAsync().ConfigureAwait(false);

            _ = Task.CompletedTask;
        }

        public async Task HandleVisitChange(DateTime dt)
        {
            FormModel.FormInputs.DateOfVisit = dt;
            await HandleSubmitAsync().ConfigureAwait(false);
        }

        public async Task HandleBirthChange(DateTime dt)
        {
            FormModel.FormInputs.DateOfBirth = dt;
            await HandleSubmitAsync().ConfigureAwait(false);
        }

        protected async Task HandleSubmitAsync()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var isValid = EditContext.Validate();

            try
            {
                LoadFailed = false;

                if (isValid)
                {
                    IsCalculating = true;

                    FormModel.FormOutputs = await AnthroService.GetScores(FormModel.FormInputs).ConfigureAwait(true);

                    IsCalculating = false;
                }
                else
                {
                    LoadFailed = true;
                }
            }
            catch (ApplicationException ex)
            {
                LoadFailed = true;
                Error.ProcessError(ex);
                ErrorMessage = ex.Message;
                Logger.LogWarning(ex.Message);
            }

            watch.Stop();
            ExecutionTime = "- Submit 1 (New) - " + watch.ElapsedMilliseconds + "ms";
        }

        //protected async Task HandleValidSubmitAsync()
        //{
        //    var watch = System.Diagnostics.Stopwatch.StartNew();

        //    var isValid = EditContext.Validate();

        //    try
        //    {
        //        LoadFailed = false;

        //        if (isValid)
        //        {
        //            IsCalculating = true;

        //            string BirthDateString = FormattableString.Invariant($"{FormModel.FormInputs.DateOfBirth:yyyy-MM-dd}");
        //            string VisitDateString = FormattableString.Invariant($"{FormModel.FormInputs.DateOfVisit:yyyy-MM-dd}");

        //            FormModel.FormInputs.Age = await AnthroService.GetAge(BirthDateString, VisitDateString).ConfigureAwait(false);
        //            FormModel.FormInputs.AgeString = FormModel.FormOutputs.Age;

        //            FormModel.FormInputs.BMI = await AnthroService.GetBMI(FormModel.FormInputs.Weight, FormModel.FormInputs.LengthHeight).ConfigureAwait(false);

        //            Tuple<double, double> wfaTuple = await AnthroStatsService.GetWFA(FormModel.FormInputs.Weight, FormattableString.Invariant($"{FormModel.FormInputs.Age.TotalDays}"), FormModel.FormInputs.Sex).ConfigureAwait(false);
        //            FormModel.FormOutputs.WfaZscore = wfaTuple.Item1;
        //            FormModel.FormOutputs.WfaPercentile = wfaTuple.Item2;

        //            Tuple<double, double> muacTuple = await AnthroStatsService.GetMUAC(FormModel.FormInputs.MUAC, FormattableString.Invariant($"{FormModel.FormInputs.Age.TotalDays}"), FormModel.FormInputs.Sex).ConfigureAwait(false);
        //            FormModel.FormOutputs.MuacZscore = muacTuple.Item1;
        //            FormModel.FormOutputs.MuacPercentile = muacTuple.Item2;

        //            Tuple<double, double> bfaTuple = await AnthroStatsService.GetBFA(FormModel.FormInputs.BMI, FormattableString.Invariant($"{FormModel.FormInputs.Age.TotalDays}"), FormModel.FormInputs.Sex).ConfigureAwait(false);
        //            FormModel.FormOutputs.BfaZscore = bfaTuple.Item1;
        //            FormModel.FormOutputs.BfaPercentile = bfaTuple.Item2;

        //            Tuple<double, double> hcaTuple = await AnthroStatsService.GetHCA(FormModel.FormInputs.HeadCircumference, FormattableString.Invariant($"{FormModel.FormInputs.Age.TotalDays}"), FormModel.FormInputs.Sex).ConfigureAwait(false);
        //            FormModel.FormOutputs.HcaZscore = hcaTuple.Item1;
        //            FormModel.FormOutputs.HcaPercentile = hcaTuple.Item2;

        //            Tuple<double, double> hfaTuple = await AnthroStatsService.GetHFA(FormModel.FormInputs.LengthHeight, FormattableString.Invariant($"{FormModel.FormInputs.Age.TotalDays}"), FormModel.FormInputs.Sex).ConfigureAwait(false);
        //            FormModel.FormOutputs.HfaZscore = hfaTuple.Item1;
        //            FormModel.FormOutputs.HfaPercentile = hfaTuple.Item2;

        //            Tuple<double, double> lfaTuple = await AnthroStatsService.GetLFA(FormModel.FormInputs.LengthHeight, FormattableString.Invariant($"{FormModel.FormInputs.Age.TotalDays}"), FormModel.FormInputs.Sex).ConfigureAwait(false);
        //            FormModel.FormOutputs.LfaZscore = lfaTuple.Item1;
        //            FormModel.FormOutputs.LfaPercentile = lfaTuple.Item2;

        //            Tuple<double, double> sfaTuple = await AnthroStatsService.GetSFA(FormModel.FormInputs.SubscapularSkinFold, FormattableString.Invariant($"{FormModel.FormInputs.Age.TotalDays}"), FormModel.FormInputs.Sex).ConfigureAwait(false);
        //            FormModel.FormOutputs.SsfZscore = sfaTuple.Item1;
        //            FormModel.FormOutputs.SsfPercentile = sfaTuple.Item2;

        //            Tuple<double, double> tfaTuple = await AnthroStatsService.GetTFA(FormModel.FormInputs.TricepsSkinFold, FormattableString.Invariant($"{FormModel.FormInputs.Age.TotalDays}"), FormModel.FormInputs.Sex).ConfigureAwait(false);
        //            FormModel.FormOutputs.TsfZscore = tfaTuple.Item1;
        //            FormModel.FormOutputs.TsfPercentile = tfaTuple.Item2;

        //            Tuple<double, double> wfhTuple = await AnthroStatsService.GetWFH(FormModel.FormInputs.Weight, FormModel.FormInputs.LengthHeight, FormModel.FormInputs.Sex).ConfigureAwait(false);
        //            FormModel.FormOutputs.WfhZscore = wfhTuple.Item1;
        //            FormModel.FormOutputs.WfhPercentile = wfhTuple.Item2;

        //            Tuple<double, double> wflTuple = await AnthroStatsService.GetWFL(FormModel.FormInputs.Weight, FormModel.FormInputs.LengthHeight, FormModel.FormInputs.Sex).ConfigureAwait(false);
        //            FormModel.FormOutputs.WflZscore = wflTuple.Item1;
        //            FormModel.FormOutputs.WflPercentile = wflTuple.Item2;

        //            IsCalculating = false;
        //        }
        //        else
        //        {
        //            LoadFailed = true;
        //        }
        //    }
        //    catch (ApplicationException ex)
        //    {
        //        LoadFailed = true;
        //        Error.ProcessError(ex);
        //        ErrorMessage = ex.Message;
        //        Logger.LogWarning(ex.Message);
        //    }

        //    watch.Stop();
        //    ExecutionTime = "- Submit 2 (Original) - " + watch.ElapsedMilliseconds + "ms";
        //}

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
            if (measure >= 99.9 || measure <= 0)
            {
                result = "NA";
            }
            else
            {
                result = FormattableString.Invariant($"{measure}");
            }

            return result;
        }

        public string SetRangeControl(double measure, int ageInYears, int ageInMonths)
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

        public string SetPercText(double measure, int ageInYears, int ageInMonths)
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

        public string SetZscoreText(double measure, int ageInYears, int ageInMonths)
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
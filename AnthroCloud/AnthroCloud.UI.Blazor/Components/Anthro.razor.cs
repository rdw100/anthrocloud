using AnthroCloud.Business;
using AnthroCloud.Entities;
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

        [Inject]
        public IAnthroStatsService AnthroStatsService { get; set; }

        public double BMI { get; set; }

        public string AgeString { get; set; }

        public double WfaZscore { get; set; }

        public double WfaPercentile { get; set; }

        public Age Age { get; set; }

        [Parameter]
        public double Weight { get; set; } = 9.00;

        [Parameter]
        public double Height { get; set; } = 73.00;

        [Parameter]
        public DateTime Birth { get; set; } = DateTime.Today.AddYears(-1);

        [Parameter]
        public DateTime Visit { get; set; } = DateTime.Today;

        [Parameter]
        public Sexes Sex { get; set; }

        [Parameter]
        public Boolean Oedema { get; set; }

        [Parameter]
        public double HeadCircumference { get; set; }

        [Parameter]
        public double MUAC { get; set; }

        [Parameter]
        public double TricepsSkinFold { get; set; }

        [Parameter]
        public double SubscapularSkinFold { get; set; }

        public async Task<double> CalculateBMI()
        {
            //string BirthDateString = FormattableString.Invariant($"{Birth:yyyy-MM-dd}");
            //string VisitDateString = FormattableString.Invariant($"{Visit:yyyy-MM-dd}");

            //Age = await AnthroService.GetAge(BirthDateString, VisitDateString).ConfigureAwait(false);
            //AgeString = Age.ToReadableString();

            Tuple<double, double> wfaTuple = await AnthroStatsService.GetWFA(Weight, "365", Sex).ConfigureAwait(false);

            WfaZscore = wfaTuple.Item1;
            WfaPercentile = wfaTuple.Item2;

            BMI = await AnthroService.GetBMI(Weight, Height).ConfigureAwait(false);
            return BMI;
        }

        public static double SetDecimalZero(double value)
        {
            if (value == 0)
            {
                return 0.00d;
            }

            return value;
        }
    }
}

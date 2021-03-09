using AnthroCloud.UI.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration iConfig)
        {
            _configuration = iConfig;
        }

        public IActionResult Index()
        {
            return View(new FormViewModel());
        }

        public ActionResult MyHtml()
        {
            return Redirect("~/Views/LineChart/Chart.html");
        }

        [HttpPost]
        public IActionResult Index(FormViewModel model)
        {
            HttpClient client = new();

            string baseAddressPath = _configuration.GetValue<string>("ConfigurationSettings:baseApiAddressPath");

            // api / anthro / age / 2016 - 12 - 01T00: 00:00 / 2019-12-31T23:59:59
            client.BaseAddress = new Uri(baseAddressPath);
            client.DefaultRequestHeaders.Clear();

            string BirthDateString = string.Format("{0:yyyy-MM-dd}", model.DateOfBirth);            
            string VisitDateString = string.Format("{0:yyyy-MM-dd}", model.DateOfVisit); 

            string path = "anthro/age/" + BirthDateString + "/" + VisitDateString; 
            
            //GET: //anthro/age/2016-12-01T00:00:00/2019-12-31T23:59:59
            var response = client.GetAsync(path).Result;
            string res = "";
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                Task<string> result = content.ReadAsStringAsync();
                res = result.Result;
            }
            model.Age = res;

            //api/anthro/age/days/2016-12-01T00:00:00/2019-12-31T23:59:59
            string pathAgeInDays = "anthro/age/days/" + BirthDateString + "/" + VisitDateString; //"anthro/age/2016-12-01T00:00:00/2019-12-31T23:59:59";

            var responseAnthroAge = client.GetAsync(pathAgeInDays).Result;
            string resAge = "";
            using (HttpContent content = responseAnthroAge.Content)
            {
                // ... Read the string.
                Task<string> result = content.ReadAsStringAsync();
                resAge = result.Result;
            }

            model.AgeInDays = resAge;

            //api/anthro/age/months/2016-12-01T00:00:00/2019-12-31T23:59:59
            string pathAgeInMonths = "anthro/age/months/" + BirthDateString + "/" + VisitDateString; //"anthro/age/2016-12-01T00:00:00/2019-12-31T23:59:59";

            var responseAnthroAgeInMonths = client.GetAsync(pathAgeInMonths).Result;
            string resAgeInMonths = "";
            using (HttpContent content = responseAnthroAgeInMonths.Content)
            {
                // ... Read the string.
                Task<string> result = content.ReadAsStringAsync();
                resAgeInMonths = result.Result;
            }

            model.AgeInMonths = Convert.ToByte(resAgeInMonths);

            //api/anthro/age/years/2016-12-01T00:00:00/2019-12-31T23:59:59
            string pathAgeInYears = "anthro/age/years/" + BirthDateString + "/" + VisitDateString; //"anthro/age/2016-12-01T00:00:00/2019-12-31T23:59:59";

            var responseAnthroAgeInYears = client.GetAsync(pathAgeInYears).Result;
            string resAgeInYears = "";
            using (HttpContent content = responseAnthroAgeInYears.Content)
            {
                // ... Read the string.
                Task<string> result = content.ReadAsStringAsync();
                resAgeInYears = result.Result;
            }

            model.AgeInYears = Convert.ToByte(resAgeInYears);

            string pathBMI = "anthro/BMI/" + model.Weight + "/" + model.LengthHeight; //"anthro/BMI/9.10/73.00"
            var responseBMI = client.GetAsync(pathBMI).Result;
            string resBMI = "";
            using (HttpContent contentBMI = responseBMI.Content)
            {
                // ... Read the string.
                Task<string> result = contentBMI.ReadAsStringAsync();
                resBMI = result.Result;
            }

            model.BMI = Convert.ToDouble(resBMI);

            // GET: api/Stats/WeightForAge/9.00/365/Male
            string pathStatsWFA = "Stats/WeightForAge/" + model.Weight + "/" + model.AgeInDays + "/" + (Sexes)model.Sex;
            var responseStatsWFA = client.GetAsync(pathStatsWFA).Result;
            string resStatsWFA = "";

            using (HttpContent contentStatsWFA = responseStatsWFA.Content)
            {
                // ... Read the string.
                Task<string> result = contentStatsWFA.ReadAsStringAsync();
                resStatsWFA = result.Result;
            }
            
            var wfaTuple = JsonConvert.DeserializeObject<Tuple<double, double>>(resStatsWFA);            
            
            model.WfaZscore = SetDecimalZero(wfaTuple.Item1);
            model.WfaPercentile = SetDecimalZero(wfaTuple.Item2);

            // GET: api/Stats/ArmCircumferenceForAge/15.00/365/Male
            string pathStatsMUAC = "Stats/ArmCircumferenceForAge/" + model.MUAC + "/" + model.AgeInDays + "/" + (Sexes)model.Sex;
            var responseStatsMUAC = client.GetAsync(pathStatsMUAC).Result;
            string resStatsMUAC = "";

            using (HttpContent contentStatsMUAC = responseStatsMUAC.Content)
            {
                // ... Read the string.
                Task<string> result = contentStatsMUAC.ReadAsStringAsync();
                resStatsMUAC = result.Result;
            }

            var muacTuple = JsonConvert.DeserializeObject<Tuple<double, double>>(resStatsMUAC);

            model.MuacZscore = SetDecimalZero(muacTuple.Item1);
            model.MuacPercentile = SetDecimalZero(muacTuple.Item2);

            // GET: api/Stats/BodyMassIndexForAge/16.89/365/Male
            string pathStatsBFA = "Stats/BodyMassIndexForAge/" + model.BMI + "/" + model.AgeInDays + "/" + (Sexes)model.Sex;
            var responseStatsBFA = client.GetAsync(pathStatsBFA).Result;
            string resStatsBFA = "";

            using (HttpContent contentStatsBFA = responseStatsBFA.Content)
            {
                // ... Read the string.
                Task<string> result = contentStatsBFA.ReadAsStringAsync();
                resStatsBFA = result.Result;
            }

            var bfaTuple = JsonConvert.DeserializeObject<Tuple<double, double>>(resStatsBFA);

            model.BfaZscore = SetDecimalZero(bfaTuple.Item1);
            model.BfaPercentile = SetDecimalZero(bfaTuple.Item2);

            // GET: api/Stats/HeadCircumferenceForAge/45.00/365/Male
            string pathStatsHCA = "Stats/HeadCircumferenceForAge/" + model.HeadCircumference + "/" + model.AgeInDays + "/" + (Sexes)model.Sex;
            var responseStatsHCA = client.GetAsync(pathStatsHCA).Result;
            string resStatsHCA = "";

            using (HttpContent contentStatsHCA = responseStatsHCA.Content)
            {
                // ... Read the string.
                Task<string> result = contentStatsHCA.ReadAsStringAsync();
                resStatsHCA = result.Result;
            }

            var hcaTuple = JsonConvert.DeserializeObject<Tuple<double, double>>(resStatsHCA);

            model.HcaZscore = SetDecimalZero(hcaTuple.Item1);
            model.HcaPercentile = SetDecimalZero(hcaTuple.Item2);

            // GET: api/Stats/HeightForAge/96.00/1095/Male
            string pathStatsHFA = "Stats/HeightForAge/" + model.LengthHeight + "/" + model.AgeInDays + "/" + (Sexes)model.Sex;
            var responseStatsHFA = client.GetAsync(pathStatsHFA).Result;
            string resStatsHFA = "";

            using (HttpContent contentStatsHFA = responseStatsHFA.Content)
            {
                // ... Read the string.
                Task<string> result = contentStatsHFA.ReadAsStringAsync();
                resStatsHFA = result.Result;
            }

            var hfaTuple = JsonConvert.DeserializeObject<Tuple<double, double>>(resStatsHFA);

            model.HfaZscore = SetDecimalZero(hfaTuple.Item1);
            model.HfaPercentile = SetDecimalZero(hfaTuple.Item2);

            // GET: api/Stats/LengthForAge/73.00/365/Sex.Male
            string pathStatsLFA = "Stats/LengthForAge/" + model.LengthHeight + "/" + model.AgeInDays + "/" + (Sexes)model.Sex; 
            var responseStatsLFA = client.GetAsync(pathStatsLFA).Result;
            string resStatsLFA = "";

            using (HttpContent contentStatsLFA = responseStatsLFA.Content)
            {
                // ... Read the string.
                Task<string> result = contentStatsLFA.ReadAsStringAsync();
                resStatsLFA = result.Result;
            }

            var lfaTuple = JsonConvert.DeserializeObject<Tuple<double, double>>(resStatsLFA);

            model.LfaZscore = SetDecimalZero(lfaTuple.Item1);
            model.LfaPercentile = SetDecimalZero(lfaTuple.Item2);

            // GET: api/Stats/SubscapularSkinfoldForAge/7.00/365/Male
            string pathStatsSFA = "Stats/SubscapularSkinfoldForAge/" + model.SubscapularSkinFold + "/" + model.AgeInDays + "/" + (Sexes)model.Sex;
            var responseStatsSFA = client.GetAsync(pathStatsSFA).Result;
            string resStatsSFA = "";

            using (HttpContent contentStatsSFA = responseStatsSFA.Content)
            {
                // ... Read the string.
                Task<string> result = contentStatsSFA.ReadAsStringAsync();
                resStatsSFA = result.Result;
            }

            var sfaTuple = JsonConvert.DeserializeObject<Tuple<double, double>>(resStatsSFA);

            model.SsfZscore = SetDecimalZero(sfaTuple.Item1);
            model.SsfPercentile = SetDecimalZero(sfaTuple.Item2);

            // GET: api/Stats/TricepsSkinfoldForAge/8.00/365/Male
            string pathStatsTFA = "Stats/TricepsSkinfoldForAge/" + model.TricepsSkinFold + "/" + model.AgeInDays + "/" + (Sexes)model.Sex;
            var responseStatsTFA = client.GetAsync(pathStatsTFA).Result;
            string resStatsTFA = "";

            using (HttpContent contentStatsTFA = responseStatsTFA.Content)
            {
                // ... Read the string.
                Task<string> result = contentStatsTFA.ReadAsStringAsync();
                resStatsTFA = result.Result;
            }

            var tfaTuple = JsonConvert.DeserializeObject<Tuple<double, double>>(resStatsTFA);

            model.TsfZscore = SetDecimalZero(tfaTuple.Item1);
            model.TsfPercentile = SetDecimalZero(tfaTuple.Item2);

            // GET: api/Stats/WeightForHeight/14.00/96.00/Male
            string pathStatsWFH = "Stats/WeightForHeight/" + model.Weight + "/" + model.LengthHeight + "/" + (Sexes)model.Sex;
            var responseStatsWFH = client.GetAsync(pathStatsWFH).Result;
            string resStatsWFH = "";

            using (HttpContent contentStatsWFH = responseStatsWFH.Content)
            {
                // ... Read the string.
                Task<string> result = contentStatsWFH.ReadAsStringAsync();
                resStatsWFH = result.Result;
            }

            var wfhTuple = JsonConvert.DeserializeObject<Tuple<double, double>>(resStatsWFH);

            model.WfhZscore = SetDecimalZero(wfhTuple.Item1);
            model.WfhPercentile = SetDecimalZero(wfhTuple.Item2);

            // GET: api/Stats/WeightForLength/9.00/73.00/Male
            string pathStatsWFL = "Stats/WeightForLength/" + model.Weight + "/" + model.LengthHeight + "/" + (Sexes)model.Sex;
            var responseStatsWFL = client.GetAsync(pathStatsWFL).Result;
            string resStatsWFL = "";

            using (HttpContent contentStatsWFL = responseStatsWFL.Content)
            {
                // ... Read the string.
                Task<string> result = contentStatsWFL.ReadAsStringAsync();
                resStatsWFL = result.Result;
            }

            var wflTuple = JsonConvert.DeserializeObject<Tuple<double, double>>(resStatsWFL);

            model.WflZscore = SetDecimalZero(wflTuple.Item1);
            model.WflPercentile = SetDecimalZero(wflTuple.Item2);

            // Allow model update
            ModelState.Clear();
            
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static double SetDecimalZero( double value)
        {
            if (value == 0)
            {
                return 0.00d;
            }

            return value;
        }
    }
}

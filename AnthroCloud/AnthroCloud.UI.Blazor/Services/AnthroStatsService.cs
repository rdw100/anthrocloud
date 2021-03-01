using AnthroCloud.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Services
{
    public class AnthroStatsService : IAnthroStatsService
    {
        private readonly HttpClient httpClient;

        public AnthroStatsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        // GET: https://localhost:5001/api/Stats/WeightForAge/9.00/365/Male
        public async Task<Tuple<double, double>> GetWFA(double weight, string ageInDays, Sexes sex)
        {
            // GET: api/Stats/WeightForAge/9.00/365/Male
            string pathStatsWFA = "Stats/WeightForAge/" + weight + "/" + ageInDays + "/" + sex;
            var responseStatsWFA = await httpClient.GetAsync(pathStatsWFA);
            string resStatsWFA = "";

            using (HttpContent contentStatsWFA = responseStatsWFA.Content)
            {
                // ... Read the string.
                Task<string> result = contentStatsWFA.ReadAsStringAsync();
                resStatsWFA = result.Result;
            }

            var wfaTuple = JsonConvert.DeserializeObject<Tuple<double, double>>(resStatsWFA);

            return wfaTuple;
        }

        // GET: https://localhost:5001/api/Stats/ArmCircumferenceForAge/15.00/365/Male
        public async Task<Tuple<double, double>> GetMUAC(double muac, string ageInDays, Sexes sex)
        {
            string pathStatsMUAC = "Stats/ArmCircumferenceForAge/" + muac + "/" + ageInDays + "/" + sex;
            var responseStatsMUAC = await httpClient.GetAsync(pathStatsMUAC);
            string resStatsMUAC = "";

            using (HttpContent contentStatsMUAC = responseStatsMUAC.Content)
            {
                // ... Read the string.
                Task<string> result = contentStatsMUAC.ReadAsStringAsync();
                resStatsMUAC = result.Result;
            }

            var muacTuple = JsonConvert.DeserializeObject<Tuple<double, double>>(resStatsMUAC);

            return muacTuple;
        }

        // GET: api/Stats/BodyMassIndexForAge/16.89/365/Male
        public async Task<Tuple<double, double>> GetBFA(double bmi, string ageInDays, Sexes sex)
        {
            string pathStatsBFA = "Stats/BodyMassIndexForAge/" + bmi + "/" + ageInDays + "/" + sex;
            var responseStatsBFA = await httpClient.GetAsync(pathStatsBFA);
            string resStatsBFA = "";

            using (HttpContent contentStatsBFA = responseStatsBFA.Content)
            {
                // ... Read the string.
                Task<string> result = contentStatsBFA.ReadAsStringAsync();
                resStatsBFA = result.Result;
            }

            var bfaTuple = JsonConvert.DeserializeObject<Tuple<double, double>>(resStatsBFA);
            return bfaTuple;
        }

        // GET: api/Stats/HeadCircumferenceForAge/45.00/365/Male
        public async Task<Tuple<double, double>> GetHCA(double headCircumference, string ageInDays, Sexes sex)
        {
            string pathStatsHCA = "Stats/HeadCircumferenceForAge/" + headCircumference + "/" + ageInDays + "/" + sex;
            var responseStatsHCA = await httpClient.GetAsync(pathStatsHCA);
            string resStatsHCA = "";

            using (HttpContent contentStatsHCA = responseStatsHCA.Content)
            {
                // ... Read the string.
                Task<string> result = contentStatsHCA.ReadAsStringAsync();
                resStatsHCA = result.Result;
            }

            var hcaTuple = JsonConvert.DeserializeObject<Tuple<double, double>>(resStatsHCA);
            return hcaTuple;
        }

        // GET: api/Stats/HeightForAge/96.00/1095/Male
        public async Task<Tuple<double, double>> GetHFA(double height, string ageInDays, Sexes sex)
        {
            string pathStatsHFA = "Stats/HeightForAge/" + height + "/" + ageInDays + "/" + sex;
            var responseStatsHFA = await httpClient.GetAsync(pathStatsHFA);
            string resStatsHFA = "";

            using (HttpContent contentStatsHFA = responseStatsHFA.Content)
            {
                // ... Read the string.
                Task<string> result = contentStatsHFA.ReadAsStringAsync();
                resStatsHFA = result.Result;
            }

            var hfaTuple = JsonConvert.DeserializeObject<Tuple<double, double>>(resStatsHFA);
            return hfaTuple;
        }

        // GET: api/Stats/LengthForAge/73.00/365/Sex.Male
        public async Task<Tuple<double, double>> GetLFA(double length, string ageInDays, Sexes sex)
        {
            string pathStatsLFA = "Stats/LengthForAge/" + length + "/" + ageInDays + "/" + sex;
            var responseStatsLFA = await httpClient.GetAsync(pathStatsLFA);
            string resStatsLFA = "";

            using (HttpContent contentStatsLFA = responseStatsLFA.Content)
            {
                // ... Read the string.
                Task<string> result = contentStatsLFA.ReadAsStringAsync();
                resStatsLFA = result.Result;
            }

            var lfaTuple = JsonConvert.DeserializeObject<Tuple<double, double>>(resStatsLFA);
            return lfaTuple;
        }

        // GET: api/Stats/SubscapularSkinfoldForAge/7.00/365/Male
        public async Task<Tuple<double, double>> GetSFA(double subScapularSkinfold, string ageInDays, Sexes sex)
        {
            string pathStatsSFA = "Stats/SubscapularSkinfoldForAge/" + subScapularSkinfold + "/" + ageInDays + "/" + sex;
            var responseStatsSFA = await httpClient.GetAsync(pathStatsSFA);
            string resStatsSFA = "";

            using (HttpContent contentStatsSFA = responseStatsSFA.Content)
            {
                // ... Read the string.
                Task<string> result = contentStatsSFA.ReadAsStringAsync();
                resStatsSFA = result.Result;
            }

            var sfaTuple = JsonConvert.DeserializeObject<Tuple<double, double>>(resStatsSFA);
            return sfaTuple;
        }

        // GET: api/Stats/TricepsSkinfoldForAge/8.00/365/Male
        public async Task<Tuple<double, double>> GetTFA(double tricepsSkinfold, string ageInDays, Sexes sex)
        {
            string pathStatsTFA = "Stats/TricepsSkinfoldForAge/" + tricepsSkinfold + "/" + ageInDays + "/" + sex;
            var responseStatsTFA = await httpClient.GetAsync(pathStatsTFA);
            string resStatsTFA = "";

            using (HttpContent contentStatsTFA = responseStatsTFA.Content)
            {
                // ... Read the string.
                Task<string> result = contentStatsTFA.ReadAsStringAsync();
                resStatsTFA = result.Result;
            }

            var tfaTuple = JsonConvert.DeserializeObject<Tuple<double, double>>(resStatsTFA);
            return tfaTuple;
        }

        // GET: api/Stats/WeightForHeight/14.00/96.00/Male
        public async Task<Tuple<double, double>> GetWFH(double weight, double height, Sexes sex)
        {
            string pathStatsWFH = "Stats/WeightForHeight/" + weight + "/" + height + "/" + sex;
            var responseStatsWFH = await httpClient.GetAsync(pathStatsWFH);
            string resStatsWFH = "";

            using (HttpContent contentStatsWFH = responseStatsWFH.Content)
            {
                // ... Read the string.
                Task<string> result = contentStatsWFH.ReadAsStringAsync();
                resStatsWFH = result.Result;
            }

            var wfhTuple = JsonConvert.DeserializeObject<Tuple<double, double>>(resStatsWFH);
            return wfhTuple;
        }

        // GET: api/Stats/WeightForLength/9.00/73.00/Male
        public async Task<Tuple<double, double>> GetWFL(double weight, double height, Sexes sex)
        {
            string pathStatsWFL = "Stats/WeightForLength/" + weight + "/" + height + "/" + sex;
            var responseStatsWFL = await httpClient.GetAsync(pathStatsWFL);
            string resStatsWFL = "";

            using (HttpContent contentStatsWFL = responseStatsWFL.Content)
            {
                // ... Read the string.
                Task<string> result = contentStatsWFL.ReadAsStringAsync();
                resStatsWFL = result.Result;
            }

            var wflTuple = JsonConvert.DeserializeObject<Tuple<double, double>>(resStatsWFL);
            return wflTuple;
        }

        public async Task<Outputs> GetScores(Inputs inputs)
        {
            string stringData = JsonConvert.SerializeObject(inputs);
            var contentData = new StringContent(stringData,
                System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync
                ("Stats", contentData);
            string result = response.Content.ReadAsStringAsync().Result;
            var outputs = JsonConvert.DeserializeObject<Outputs>(result);
            return outputs;
        }
    }
}

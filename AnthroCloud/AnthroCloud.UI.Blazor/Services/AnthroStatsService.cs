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
    }
}

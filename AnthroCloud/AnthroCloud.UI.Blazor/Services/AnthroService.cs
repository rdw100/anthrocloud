using AnthroCloud.Business;
using AnthroCloud.Entities;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Services
{
    /// <summary>
    /// A typed client accepts an HttpClient parameter in its constructor.
    /// </summary>
    /// <seealso cref="AnthroCloud.UI.Blazor.Services.IAnthroService" />
    public class AnthroService : IAnthroService
    {
        private readonly HttpClient httpClient;

        public AnthroService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        // https://localhost:5001/api/anthro/BMIAsync/9.00/73.00
        public async Task<double> GetBMI(double weight, double height)
        {
            string uri = $"anthro/BMIAsync/{weight}/{height}";
            var response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync
                <double>(responseStream);
        }

        // https://localhost:5001/api/anthro/AgeObjectAsync/2016-12-01T00:00:00/2019-12-01T23:59:59
        public async Task<Age> GetAge(string birth, string visit)
        {
            string uri = $"anthro/AgeObjectAsync/{birth}/{visit}";
            var response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync
                <Age>(responseStream);
        }

        // GET: https://localhost:5001/api/Stats/WeightForAge/9.00/365/Male
        public async Task<Tuple<double, double>> GetWFA(double weight, string ageInDays, Sexes sex)
        {
            var result = Tuple.Create(1.1, 2.2);
            return result;
        }
    }

    public class StatsDisplay
    {
        public double WflPercentile { get; set; } = 61.4;
        public double WflZscore { get; set; }  = 0.29;
        public double WfaPercentile { get; set; }  = 51.9;
        public double WfaZscore { get; set; }  = 0.05;
        public double LfaPercentile { get; set; } = 34.8;
        public double LfaZscore { get; set; } = -0.39;
        public double BfaPercentile { get; set; } = 64.1;
        public double BfaZscore { get; set; } = 0.36;
        public double HcaPercentile { get; set; } = 53.1;
        public double HcaZscore { get; set; } = 0.08;
        public double MuacPercentile { get; set; } = 74.3;
        public double MuacZscore { get; set; } = 0.65;
        public double TsfPercentile { get; set; } = 49.9;
        public double TsfZscore { get; set; } = 0.00;
        public double SsfPercentile { get; set; } = 65.0;
        public double SsfZscore { get; set; } = 0.38;
        public double WfhPercentile { get; set; }
        public double WfhZscore { get; set; }
        public double HfaPercentile { get; set; } = 53.1;
        public double HfaZscore { get; set; } = 0.08;
    }
}

using AnthroCloud.Entities;
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

        public async Task<Outputs> GetScores(Inputs inputs)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                $"STATS", inputs);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Outputs>();
        }

        public async Task<Outputs> GetMeasuredScores(Inputs inputs)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                $"STATS/MEASURED", inputs);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Outputs>();
        }

        public async Task<Outputs> GetHcaScores(Inputs inputs)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                $"STATS/HCA", inputs);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Outputs>();
        }

        public async Task<Outputs> GetMuacScores(Inputs inputs)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                $"STATS/MUAC", inputs);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Outputs>();
        }

        public async Task<Outputs> GetTsfScores(Inputs inputs)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                $"STATS/TSF", inputs);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Outputs>();
        }

        public async Task<Outputs> GetSsfScores(Inputs inputs)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                $"STATS/SSF", inputs);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Outputs>();
        }
    }
}

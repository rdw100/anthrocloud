using AnthroCloud.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
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
        ILogger<AnthroService> Logger;

        private readonly HttpClient httpClient;

        public AnthroService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        // https://localhost:5001/api/anthro/BMIAsync/9.00/73.00
        public async Task<double> GetBMI(double weight, double height)
        {
            double result = 0D;
            string uri = string.Empty;
            try
            {
                uri = $"anthro/BMIAsync/{weight}/{height}";
                var response = await httpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                using var responseStream = await response.Content.ReadAsStreamAsync();

                result = await JsonSerializer.DeserializeAsync
                    <double>(responseStream);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, "Failed to retrieve data {uri}.", uri);
            }
            return result;
        }

        // https://localhost:5001/api/anthro/AgeObjectAsync/2016-12-01T00:00:00/2019-12-01T23:59:59
        public async Task<Age> GetAge(string birth, string visit)
        {
            Age result = new();
            string uri = string.Empty;
            try 
            { 
                uri = $"anthro/AgeObjectAsync/{birth}/{visit}";
                var response = await httpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                using var responseStream = await response.Content.ReadAsStreamAsync();

                result = await JsonSerializer.DeserializeAsync
                    <Age>(responseStream);            
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, "Failed to retrieve data {uri}.", uri);
            }
            return result;
        }

        public async Task<Outputs> GetScores(Inputs inputs)
        {
            Outputs results = new();
            string uri = string.Empty;
            try
            {
                uri = $"STATS";
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                    uri, inputs);
                response.EnsureSuccessStatusCode();

                results = await response.Content.ReadFromJsonAsync<Outputs>();
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, "Failed to retrieve data {uri}.", uri);
            }
            return results;
        }

        public async Task<Outputs> GetMeasuredScores(Inputs inputs)
        {
            Outputs results = new();
            string uri = string.Empty;
            try
            {
                uri = $"STATS/MEASURED";
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                    uri, inputs);
                response.EnsureSuccessStatusCode();

                results = await response.Content.ReadFromJsonAsync<Outputs>();
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, "Failed to retrieve data {uri}.", uri);
            }
            return results;
        }

        public async Task<Outputs> GetHcaScores(Inputs inputs)
        {
            Outputs results = new();
            string uri = string.Empty;
            try
            {
                uri = $"STATS/HCA";
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                    uri, inputs);
                response.EnsureSuccessStatusCode();

                results = await response.Content.ReadFromJsonAsync<Outputs>();
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, "Failed to retrieve data {uri}.", uri);
            }
            return results;
        }

        public async Task<Outputs> GetMuacScores(Inputs inputs)
        {
            Outputs results = new();
            string uri = string.Empty;
            try
            {
                uri = $"STATS/MUAC";
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                    uri, inputs);
                response.EnsureSuccessStatusCode();

                results = await response.Content.ReadFromJsonAsync<Outputs>();
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, "Failed to retrieve data {uri}.", uri);
            }
            return results;
        }

        public async Task<Outputs> GetTsfScores(Inputs inputs)
        {
            Outputs results = new();
            string uri = string.Empty;
            try
            {
                uri = $"STATS/TSF";
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                    uri, inputs);
                response.EnsureSuccessStatusCode();

                results = await response.Content.ReadFromJsonAsync<Outputs>();
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, "Failed to retrieve data {uri}.", uri);
            }
            return results;
        }

        public async Task<Outputs> GetSsfScores(Inputs inputs)
        {
            Outputs results = new();
            string uri = string.Empty;
            try
            {
                uri = $"STATS/SSF";
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                    uri, inputs);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<Outputs>();
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, "Failed to retrieve data {uri}.", uri);
            }
            return results;
        }
    }
}

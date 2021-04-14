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
        [Inject]
        protected ILogger<AnthroService> Logger { get; set; }

        private readonly HttpClient httpClient;

        public AnthroService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        // https://localhost:5001/api/anthro/BMIAsync/9.00/73.00
        public async Task<double> GetBMI(double weight, double height)
        {
            double result = 0D;
            Uri newUri = new(httpClient.BaseAddress + $"anthro/BMIAsync/{weight}/{height}");
            try
            {                
                var response = await httpClient.GetAsync(newUri).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

                result = await JsonSerializer.DeserializeAsync
                    <double>(responseStream).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, $"Failed to retrieve data {newUri}.", newUri);
                throw;
            }
            return result;
        }

        // https://localhost:5001/api/anthro/AgeObjectAsync/2016-12-01T00:00:00/2019-12-01T23:59:59
        public async Task<Age> GetAge(string birth, string visit)
        {
            Age result = new();
            Uri newUri = new(httpClient.BaseAddress + $"anthro/AgeObjectAsync/{birth}/{visit}");
            try
            {                
                var response = await httpClient.GetAsync(newUri).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

                result = await JsonSerializer.DeserializeAsync
                    <Age>(responseStream).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, $"Failed to retrieve data {newUri}.", newUri);
                throw;
            }
            return result;
        }

        public async Task<Outputs> GetScores(Inputs inputs)
        {
            Outputs results;
            Uri newUri = new(httpClient.BaseAddress + $"STATS");
            try
            {
                
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                    newUri, inputs).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                results = await response.Content.ReadFromJsonAsync<Outputs>().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, $"Failed to retrieve data {newUri}.", newUri);
                throw;
            }
            return results;
        }

        public async Task<Outputs> GetMeasuredScores(Inputs inputs)
        {
            Outputs results;
            Uri newUri = new(httpClient.BaseAddress + $"STATS/MEASURED");
            try
            {                
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                    newUri, inputs).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                results = await response.Content.ReadFromJsonAsync<Outputs>().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, $"Failed to retrieve data {newUri}.", newUri);
                throw;
            }
            return results;
        }

        public async Task<Outputs> GetHcaScores(Inputs inputs)
        {
            Outputs results;
            Uri newUri = new(httpClient.BaseAddress + $"STATS/HCA");
            try
            {                
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                    newUri, inputs).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                results = await response.Content.ReadFromJsonAsync<Outputs>().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, $"Failed to retrieve data {newUri}.", newUri);
                throw;
            }
            return results;
        }

        public async Task<Outputs> GetMuacScores(Inputs inputs)
        {
            Outputs results;
            Uri newUri = new(httpClient.BaseAddress + $"STATS/MUAC");
            try
            {                
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                    newUri, inputs).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                results = await response.Content.ReadFromJsonAsync<Outputs>().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, $"Failed to retrieve data {newUri}.", newUri);
                throw;
            }
            return results;
        }

        public async Task<Outputs> GetTsfScores(Inputs inputs)
        {
            Outputs results;
            Uri newUri = new(httpClient.BaseAddress + $"STATS/TSF");
            try
            {                
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                    newUri, inputs).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                results = await response.Content.ReadFromJsonAsync<Outputs>().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, $"Failed to retrieve data {newUri}.", newUri);
                throw;
            }
            return results;
        }

        public async Task<Outputs> GetSsfScores(Inputs inputs)
        {
            Outputs results;
            Uri newUri = new(httpClient.BaseAddress + $"STATS/SSF");
            try
            {
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                    newUri, inputs).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                results = await response.Content.ReadFromJsonAsync<Outputs>().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, $"Failed to retrieve data {newUri}.", newUri);
                throw;
            }
            return results;
        }

        // GET: https://localhost:5001/api/Stats/WeightForAge/9.00/365/Male
        public async Task<Tuple<double, double>> GetWFA(double weight, string ageInDays, Sexes sex)
        {
            Tuple<double, double> tuple;
            Uri newUri = new(httpClient.BaseAddress + $"Stats/WeightForAge/{weight}/{ageInDays}/{sex}");
            try
            {
                var message = await httpClient.GetAsync(newUri).ConfigureAwait(false);
                using var responseStream = await message.Content.ReadAsStreamAsync().ConfigureAwait(false);
                tuple = await JsonSerializer.DeserializeAsync<Tuple<double, double>>(responseStream).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, $"Failed to calculate data {newUri}.", newUri);
                throw;
            }

            return tuple;
        }

        // GET: https://localhost:5001/api/Stats/ArmCircumferenceForAge/15.00/365/Male
        public async Task<Tuple<double, double>> GetMUAC(double muac, string ageInDays, Sexes sex)
        {
            Tuple<double, double> tuple;
            Uri newUri = new(httpClient.BaseAddress + $"Stats/ArmCircumferenceForAge/{muac}/{ageInDays}/{sex}");
            try
            {
                var message = await httpClient.GetAsync(newUri).ConfigureAwait(false);
                using var responseStream = await message.Content.ReadAsStreamAsync().ConfigureAwait(false);
                tuple = await JsonSerializer.DeserializeAsync<Tuple<double, double>>(responseStream).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, $"Failed to calculate data {newUri}.", newUri);
                throw;
            }

            return tuple;
        }

        // GET: api/Stats/BodyMassIndexForAge/16.89/365/Male
        public async Task<Tuple<double, double>> GetBFA(double bmi, string ageInDays, Sexes sex)
        {
            Tuple<double, double> tuple;
            Uri newUri = new(httpClient.BaseAddress + $"Stats/ArmCircumferenceForAge/{bmi}/{ageInDays}/{sex}");
            try
            {
                var message = await httpClient.GetAsync(newUri).ConfigureAwait(false);
                using var responseStream = await message.Content.ReadAsStreamAsync().ConfigureAwait(false);
                tuple = await JsonSerializer.DeserializeAsync<Tuple<double, double>>(responseStream).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, $"Failed to calculate data {newUri}.", newUri);
                throw;
            }

            return tuple;
        }

        // GET: api/Stats/HeadCircumferenceForAge/45.00/365/Male
        public async Task<Tuple<double, double>> GetHCA(double headCircumference, string ageInDays, Sexes sex)
        {
            Tuple<double, double> tuple;
            Uri newUri = new(httpClient.BaseAddress
                + $"Stats/HeadCircumferenceForAge/{headCircumference}/{ageInDays}/{sex}");
            try
            {
                var message = await httpClient.GetAsync(newUri).ConfigureAwait(false);
                using var responseStream = await message.Content.ReadAsStreamAsync().ConfigureAwait(false);
                tuple = await JsonSerializer.DeserializeAsync<Tuple<double, double>>(responseStream).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, $"Failed to calculate data {newUri}.", newUri);
                throw;
            }

            return tuple;
        }

        // GET: api/Stats/HeightForAge/96.00/1095/Male
        public async Task<Tuple<double, double>> GetHFA(double height, string ageInDays, Sexes sex)
        {
            Tuple<double, double> tuple;
            Uri newUri = new(httpClient.BaseAddress + $"Stats/HeightForAge/{height}/{ageInDays}/{sex}");
            try
            {
                var message = await httpClient.GetAsync(newUri).ConfigureAwait(false);
                using var responseStream = await message.Content.ReadAsStreamAsync().ConfigureAwait(false);
                tuple = await JsonSerializer.DeserializeAsync<Tuple<double, double>>(responseStream).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, $"Failed to calculate data {newUri}.", newUri);
                throw;
            }

            return tuple;
        }

        // GET: api/Stats/LengthForAge/73.00/365/Sex.Male
        public async Task<Tuple<double, double>> GetLFA(double length, string ageInDays, Sexes sex)
        {
            Tuple<double, double> tuple;
            Uri newUri = new(httpClient.BaseAddress + $"Stats/LengthForAge/{length}/{ageInDays}/{sex}");
            try
            {
                var message = await httpClient.GetAsync(newUri).ConfigureAwait(false);
                using var responseStream = await message.Content.ReadAsStreamAsync().ConfigureAwait(false);
                tuple = await JsonSerializer.DeserializeAsync<Tuple<double, double>>(responseStream).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, $"Failed to calculate data {newUri}.", newUri);
                throw;
            }

            return tuple;
        }

        // GET: api/Stats/SubscapularSkinfoldForAge/7.00/365/Male
        public async Task<Tuple<double, double>> GetSFA(double subScapularSkinfold, string ageInDays, Sexes sex)
        {
            Tuple<double, double> tuple;
            Uri newUri = new(httpClient.BaseAddress + $"Stats/SubscapularSkinfoldForAge/{subScapularSkinfold}/{ageInDays}/{sex}");
            try
            {
                var message = await httpClient.GetAsync(newUri).ConfigureAwait(false);
                using var responseStream = await message.Content.ReadAsStreamAsync().ConfigureAwait(false);
                tuple = await JsonSerializer.DeserializeAsync<Tuple<double, double>>(responseStream).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, $"Failed to calculate data {newUri}.", newUri);
                throw;
            }

            return tuple;
        }

        // GET: api/Stats/TricepsSkinfoldForAge/8.00/365/Male
        public async Task<Tuple<double, double>> GetTFA(double tricepsSkinfold, string ageInDays, Sexes sex)
        {
            Tuple<double, double> tuple;
            Uri newUri = new(httpClient.BaseAddress + $"Stats/TricepsSkinfoldForAge/{tricepsSkinfold}/{ageInDays}/{sex}");
            try
            {
                var message = await httpClient.GetAsync(newUri).ConfigureAwait(false);
                using var responseStream = await message.Content.ReadAsStreamAsync().ConfigureAwait(false);
                tuple = await JsonSerializer.DeserializeAsync<Tuple<double, double>>(responseStream).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, $"Failed to calculate data {newUri}.", newUri);
                throw;
            }

            return tuple;
        }

        // GET: api/Stats/WeightForHeight/14.00/96.00/Male
        public async Task<Tuple<double, double>> GetWFH(double weight, double height, Sexes sex)
        {
            Tuple<double, double> tuple;
            Uri newUri = new(httpClient.BaseAddress + $"Stats/WeightForHeight/{weight}/{height}/{sex}");
            try
            {
                var message = await httpClient.GetAsync(newUri).ConfigureAwait(false);
                using var responseStream = await message.Content.ReadAsStreamAsync().ConfigureAwait(false);
                tuple = await JsonSerializer.DeserializeAsync<Tuple<double, double>>(responseStream).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, $"Failed to calculate data {newUri}.", newUri);
                throw;
            }

            return tuple;
        }

        // GET: api/Stats/WeightForLength/9.00/73.00/Male
        public async Task<Tuple<double, double>> GetWFL(double weight, double length, Sexes sex)
        {
            Tuple<double, double> tuple;
            Uri newUri = new(httpClient.BaseAddress + $"Stats/WeightForLength/{weight}/{length}/{sex}");
            try
            {
                var message = await httpClient.GetAsync(newUri).ConfigureAwait(false);
                using var responseStream = await message.Content.ReadAsStreamAsync().ConfigureAwait(false);
                tuple = await JsonSerializer.DeserializeAsync<Tuple<double, double>>(responseStream).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, $"Failed to calculate data {newUri}.", newUri);
                throw;
            }

            return tuple;
        }
    }
}

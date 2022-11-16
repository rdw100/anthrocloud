using AnthroCloud.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;


namespace AnthroCloud.UI.BlazorApp.Services
{
    public class AnthroStatsService : IAnthroStatsService
    {
        [Inject]
        protected ILogger<AnthroStatsService> Logger { get; set; }

        private readonly HttpClient httpClient;

        public AnthroStatsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        // GET: https://localhost:5001/api/Stats/WeightForAge/9.00/365/Male
        public async Task<System.Tuple<double, double>> GetWFA(double weight, string ageInDays, Sexes sex)
        {
            System.Tuple<double, double> tuple;
            System.Uri newUri = new(httpClient.BaseAddress + $"Stats/WeightForAge/{weight}/{ageInDays}/{sex}");

            var message = await httpClient.GetAsync(newUri).ConfigureAwait(false);
            string result = "";

            using (HttpContent content = message.Content)
            {
                // ... Read the string.
                Task<string> response = content.ReadAsStringAsync();
                result = response.Result;
            }

            tuple = JsonConvert.DeserializeObject<System.Tuple<double, double>>(result);

            return tuple;
        }

        // GET: https://localhost:5001/api/Stats/ArmCircumferenceForAge/15.00/365/Male
        public async Task<System.Tuple<double, double>> GetMUAC(double muac, string ageInDays, Sexes sex)
        {
            System.Tuple<double, double> tuple;
            System.Uri newUri = new(httpClient.BaseAddress + $"Stats/ArmCircumferenceForAge/{muac}/{ageInDays}/{sex}");

            var message = await httpClient.GetAsync(newUri).ConfigureAwait(false);
            string result = "";

            using (HttpContent content = message.Content)
            {
                // ... Read the string.
                Task<string> response = content.ReadAsStringAsync();
                result = response.Result;
            }

            tuple = JsonConvert.DeserializeObject<System.Tuple<double, double>>(result);

            return tuple;
        }

        // GET: api/Stats/BodyMassIndexForAge/16.89/365/Male
        public async Task<System.Tuple<double, double>> GetBFA(double bmi, string ageInDays, Sexes sex)
        {
            System.Tuple<double, double> tuple;
            System.Uri newUri = new(httpClient.BaseAddress + $"Stats/BodyMassIndexForAge/{bmi}/{ageInDays}/{sex}");

            var message = await httpClient.GetAsync(newUri).ConfigureAwait(false);
            string result = "";

            using (HttpContent content = message.Content)
            {
                // ... Read the string.
                Task<string> response = content.ReadAsStringAsync();
                result = response.Result;
            }

            tuple = JsonConvert.DeserializeObject<System.Tuple<double, double>>(result);

            return tuple;
        }

        // GET: api/Stats/HeadCircumferenceForAge/45.00/365/Male
        public async Task<System.Tuple<double, double>> GetHCA(double headCircumference, string ageInDays, Sexes sex)
        {
            System.Tuple<double, double> tuple;
            System.Uri newUri = new(httpClient.BaseAddress 
                + $"Stats/HeadCircumferenceForAge/{headCircumference}/{ageInDays}/{sex}");

            var message = await httpClient.GetAsync(newUri).ConfigureAwait(false);
            string result = "";

            using (HttpContent content = message.Content)
            {
                // ... Read the string.
                Task<string> response = content.ReadAsStringAsync();
                result = response.Result;
            }

            tuple = JsonConvert.DeserializeObject<System.Tuple<double, double>>(result);

            return tuple;
        }

        // GET: api/Stats/HeightForAge/96.00/1095/Male
        public async Task<System.Tuple<double, double>> GetHFA(double height, string ageInDays, Sexes sex)
        {
            System.Tuple<double, double> tuple;
            System.Uri newUri = new(httpClient.BaseAddress + $"Stats/HeightForAge/{height}/{ageInDays}/{sex}");

            var message = await httpClient.GetAsync(newUri).ConfigureAwait(false);
            string result = "";

            using (HttpContent content = message.Content)
            {
                // ... Read the string.
                Task<string> response = content.ReadAsStringAsync();
                result = response.Result;
            }

            tuple = JsonConvert.DeserializeObject<System.Tuple<double, double>>(result);

            return tuple;
        }

        // GET: api/Stats/LengthForAge/73.00/365/Sex.Male
        public async Task<System.Tuple<double, double>> GetLFA(double length, string ageInDays, Sexes sex)
        {
            System.Tuple<double, double> tuple;
            System.Uri newUri = new(httpClient.BaseAddress + $"Stats/LengthForAge/{length}/{ageInDays}/{sex}");

            var message = await httpClient.GetAsync(newUri).ConfigureAwait(false);
            string result = "";

            using (HttpContent content = message.Content)
            {
                // ... Read the string.
                Task<string> response = content.ReadAsStringAsync();
                result = response.Result;
            }

            tuple = JsonConvert.DeserializeObject<System.Tuple<double, double>>(result);

            return tuple;
        }

        // GET: api/Stats/SubscapularSkinfoldForAge/7.00/365/Male
        public async Task<System.Tuple<double, double>> GetSFA(double subScapularSkinfold, string ageInDays, Sexes sex)
        {
            System.Tuple<double, double> tuple;
            System.Uri newUri = new(httpClient.BaseAddress + $"Stats/SubscapularSkinfoldForAge/{subScapularSkinfold}/{ageInDays}/{sex}");

            var message = await httpClient.GetAsync(newUri).ConfigureAwait(false);
            string result = "";

            using (HttpContent content = message.Content)
            {
                // ... Read the string.
                Task<string> response = content.ReadAsStringAsync();
                result = response.Result;
            }

            tuple = JsonConvert.DeserializeObject<System.Tuple<double, double>>(result);

            return tuple;
        }

        // GET: api/Stats/TricepsSkinfoldForAge/8.00/365/Male
        public async Task<System.Tuple<double, double>> GetTFA(double tricepsSkinfold, string ageInDays, Sexes sex)
        {
            System.Tuple<double, double> tuple;
            System.Uri newUri = new(httpClient.BaseAddress + $"Stats/TricepsSkinfoldForAge/{tricepsSkinfold}/{ageInDays}/{sex}");

            var message = await httpClient.GetAsync(newUri).ConfigureAwait(false);
            string response = "";

            using (HttpContent content = message.Content)
            {
                // ... Read the string.
                Task<string> result = content.ReadAsStringAsync();
                response = result.Result;
            }

            tuple = JsonConvert.DeserializeObject<System.Tuple<double, double>>(response);

            return tuple;
        }

        // GET: api/Stats/WeightForHeight/14.00/96.00/Male
        public async Task<System.Tuple<double, double>> GetWFH(double weight, double height, Sexes sex)
        {
            System.Tuple<double, double> tuple;
            System.Uri newUri = new(httpClient.BaseAddress + $"Stats/WeightForHeight/{weight}/{height}/{sex}");

            var message = await httpClient.GetAsync(newUri).ConfigureAwait(false);
            string result = "";

            using (HttpContent content = message.Content)
            {
                // ... Read the string.
                Task<string> response = content.ReadAsStringAsync();
                result = response.Result;
            }

            tuple = JsonConvert.DeserializeObject<System.Tuple<double, double>>(result);

            return tuple;
        }

        // GET: api/Stats/WeightForLength/9.00/73.00/Male
        public async Task<System.Tuple<double, double>> GetWFL(double weight, double length, Sexes sex)
        {
            System.Tuple<double, double> tuple;
            System.Uri newUri = new(httpClient.BaseAddress + $"Stats/WeightForLength/{weight}/{length}/{sex}");

            var message = await httpClient.GetAsync(newUri).ConfigureAwait(false);
            string result = "";

            using (HttpContent content = message.Content)
            {
                // ... Read the string.
                Task<string> response = content.ReadAsStringAsync();
                result = response.Result;
            }

            tuple = JsonConvert.DeserializeObject<System.Tuple<double, double>>(result);

            return tuple;
        }

        public async Task<Outputs> GetScores(Inputs inputs)
        {
            Outputs outputs;
            System.Uri newUri = new(httpClient.BaseAddress + $"Stats");

            string stringData = JsonConvert.SerializeObject(inputs);
            using StringContent contentData = new(stringData,
                System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync
                (newUri, contentData).ConfigureAwait(false);
            string result = response.Content.ReadAsStringAsync().Result;
            outputs = JsonConvert.DeserializeObject<Outputs>(result);

            return outputs;
        }
    }
}
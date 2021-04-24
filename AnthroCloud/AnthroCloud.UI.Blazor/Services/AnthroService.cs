using AnthroCloud.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
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
            System.Uri newUri = new(httpClient.BaseAddress + $"anthro/BMIAsync/{weight}/{height}");
            
            var response = await httpClient.GetAsync(newUri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            result = await JsonSerializer.DeserializeAsync
                <double>(responseStream).ConfigureAwait(false);

            return result;
        }

        public async Task<Outputs> GetScores(Inputs inputs)
        {
            Outputs results;
            System.Uri newUri = new(httpClient.BaseAddress + $"STATS");

            HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                newUri, inputs).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            results = await response.Content.ReadFromJsonAsync<Outputs>().ConfigureAwait(false);

            return results;
        }

        //public async Task<Outputs> GetMeasuredScores(Inputs inputs)
        //{
        //    Outputs results;
        //    Uri newUri = new(httpClient.BaseAddress + $"STATS/MEASURED");
        //    try
        //    {
        //        string BirthDateString = FormattableString.Invariant($"{inputs.DateOfBirth:yyyy-MM-dd}");
        //        string VisitDateString = FormattableString.Invariant($"{inputs.DateOfVisit:yyyy-MM-dd}");

        //        inputs.Age = await GetAge(BirthDateString, VisitDateString).ConfigureAwait(false);
        //        inputs.AgeString = inputs.Age.ToReadableString().ToString();

        //        inputs.BMI = await GetBMI(inputs.Weight, inputs.LengthHeight).ConfigureAwait(false);

        //        HttpResponseMessage response = await httpClient.PostAsJsonAsync(
        //            newUri, inputs).ConfigureAwait(false);
        //        response.EnsureSuccessStatusCode();

        //        results = await response.Content.ReadFromJsonAsync<Outputs>().ConfigureAwait(false);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogWarning(ex, $"Failed to retrieve data {newUri}.", newUri);
        //        throw;
        //    }
        //    return results;
        //}

        public async Task<Outputs> GetHcaScores(Inputs inputs)
        {
            Outputs results;
            System.Uri newUri = new(httpClient.BaseAddress + $"STATS/HCA");

            //string BirthDateString = FormattableString.Invariant($"{inputs.DateOfBirth:yyyy-MM-dd}");
            //string VisitDateString = FormattableString.Invariant($"{inputs.DateOfVisit:yyyy-MM-dd}");

            //inputs.Age = await GetAge(BirthDateString, VisitDateString).ConfigureAwait(false);
            //inputs.AgeString = inputs.Age.ToReadableString().ToString();

            //inputs.BMI = await GetBMI(inputs.Weight, inputs.LengthHeight).ConfigureAwait(false);

            HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                newUri, inputs).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            results = await response.Content.ReadFromJsonAsync<Outputs>().ConfigureAwait(false);

            return results;
        }

        public async Task<Outputs> GetMuacScores(Inputs inputs)
        {
            Outputs results;
            System.Uri newUri = new(httpClient.BaseAddress + $"STATS/MUAC");

            //string BirthDateString = FormattableString.Invariant($"{inputs.DateOfBirth:yyyy-MM-dd}");
            //string VisitDateString = FormattableString.Invariant($"{inputs.DateOfVisit:yyyy-MM-dd}");

            //inputs.Age = await GetAge(BirthDateString, VisitDateString).ConfigureAwait(false);
            //inputs.AgeString = inputs.Age.ToReadableString().ToString();

            //inputs.BMI = await GetBMI(inputs.Weight, inputs.LengthHeight).ConfigureAwait(false);

            HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                newUri, inputs).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            results = await response.Content.ReadFromJsonAsync<Outputs>().ConfigureAwait(false);

            return results;
        }

        public async Task<Outputs> GetTsfScores(Inputs inputs)
        {
            Outputs results;
            System.Uri newUri = new(httpClient.BaseAddress + $"STATS/TSF");

            //string BirthDateString = FormattableString.Invariant($"{inputs.DateOfBirth:yyyy-MM-dd}");
            //string VisitDateString = FormattableString.Invariant($"{inputs.DateOfVisit:yyyy-MM-dd}");

            //inputs.Age = await GetAge(BirthDateString, VisitDateString).ConfigureAwait(false);
            //inputs.AgeString = inputs.Age.ToReadableString().ToString();

            //inputs.BMI = await GetBMI(inputs.Weight, inputs.LengthHeight).ConfigureAwait(false);

            HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                newUri, inputs).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            results = await response.Content.ReadFromJsonAsync<Outputs>().ConfigureAwait(false);

            return results;
        }

        public async Task<Outputs> GetSsfScores(Inputs inputs)
        {
            Outputs results;
            System.Uri newUri = new(httpClient.BaseAddress + $"STATS/SSF");

            //string BirthDateString = FormattableString.Invariant($"{inputs.DateOfBirth:yyyy-MM-dd}");
            //string VisitDateString = FormattableString.Invariant($"{inputs.DateOfVisit:yyyy-MM-dd}");

            //inputs.Age = await GetAge(BirthDateString, VisitDateString).ConfigureAwait(false);
            //inputs.AgeString = inputs.Age.ToReadableString().ToString();

            //inputs.BMI = await GetBMI(inputs.Weight, inputs.LengthHeight).ConfigureAwait(false);

            HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                newUri, inputs).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            results = await response.Content.ReadFromJsonAsync<Outputs>().ConfigureAwait(false);

            return results;
        }
    }
}
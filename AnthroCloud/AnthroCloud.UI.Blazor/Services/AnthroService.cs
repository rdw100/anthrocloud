using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;


namespace AnthroCloud.UI.Blazor.Services
{
    /// <summary>
    /// A typed client accepts an HttpClient parameter in its constructor.
    /// https://www.youtube.com/watch?v=2cg7oGV19YY
    /// https://docs.microsoft.com/en-us/aspnet/core/blazor/call-web-api?view=aspnetcore-5.0
    /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-5.0
    /// </summary>
    /// <seealso cref="AnthroCloud.UI.Blazor.Services.IAnthroService" />
    public class AnthroService : IAnthroService
    {
        private readonly HttpClient httpClient;

        public AnthroService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }        

        // https://localhost:5001/api/anthro/BMI/9.00/73.00
        public async Task<double> GetBMI(double weight, double height)
        {
            var response = await httpClient.GetAsync($"anthro/BMIAsync/{weight}/{height}");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync
                <double>(responseStream);
        }
    }
}

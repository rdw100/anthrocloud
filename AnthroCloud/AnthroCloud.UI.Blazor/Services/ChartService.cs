using AnthroCloud.Entities.Charts;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Services
{
    public class ChartService : IChartService
    {
        private readonly HttpClient httpClient;

        public ChartService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> GetBfa(byte id, byte x, double y, GraphTypes z)
        {
            string uri = $"chart/BFA/{id}/{x}/{y}/{z}";
            var response = await httpClient.GetAsync(uri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return responseBody;
        }

        public async Task<string> GetHcfa(byte id, byte x, double y, GraphTypes z)
        {
            string uri = $"chart/HCFA/{id}/{x}/{y}/{z}";
            var response = await httpClient.GetAsync(uri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return responseBody;
        }

        public async Task<string> GetLhfa(byte id, byte x, double y, GraphTypes z)
        {
            string uri = $"chart/LHFA/{id}/{x}/{y}/{z}";
            var response = await httpClient.GetAsync(uri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return responseBody;
        }

        public async Task<string> GetMuac(byte id, byte x, double y, GraphTypes z)
        {
            string uri = $"chart/MUAC/{id}/{x}/{y}/{z}";
            var response = await httpClient.GetAsync(uri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return responseBody;
        }

        public async Task<string> GetSsfa(byte id, byte x, double y, GraphTypes z)
        {
            string uri = $"chart/SSFA/{id}/{x}/{y}/{z}";
            var response = await httpClient.GetAsync(uri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return responseBody;
        }

        public async Task<string> GetTsfa(byte id, byte x, double y, GraphTypes z)
        {
            string uri = $"chart/TSFA/{id}/{x}/{y}/{z}";
            var response = await httpClient.GetAsync(uri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return responseBody;
        }

        public async Task<string> GetWfa(byte id, byte x, double y, GraphTypes z)
        {
            string uri = $"chart/WFA/{id}/{x}/{y}/{z}";
            var response = await httpClient.GetAsync(uri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return responseBody;
        }

        public async Task<string> GetWfh(byte id, double x, double y, GraphTypes z)
        {
            string uri = $"chart/WFH/{id}/{x}/{y}/{z}";
            var response = await httpClient.GetAsync(uri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return responseBody;
        }

        public async Task<string> GetWfl(byte id, double x, double y, GraphTypes z)
        {
            string uri = $"chart/WFL/{id}/{x}/{y}/{z}";
            var response = await httpClient.GetAsync(uri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return responseBody;
        }
    }
}

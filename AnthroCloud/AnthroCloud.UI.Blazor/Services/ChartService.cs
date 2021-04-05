using AnthroCloud.Entities;
using AnthroCloud.Entities.Charts;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
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

        public async Task<string> GetAllBfaJson(byte id, byte x, decimal y, GraphTypes z)
        {
            string uri = $"chart/BFAJson/{id}/{x}/{y}/{z}";
            var response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        public async Task<string> GetAllHcfaJson(byte id, byte x, decimal y, GraphTypes z)
        {
            string uri = $"chart/HCFAJson/{id}/{x}/{y}/{z}";
            var response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        public async Task<string> GetAllLhfaJson(byte id, byte x, decimal y, GraphTypes z)
        {
            string uri = $"chart/LHFAJson/{id}/{x}/{y}/{z}";
            var response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        public async Task<string> GetAllMuacJson(byte id, byte x, decimal y, GraphTypes z)
        {
            string uri = $"chart/MUACJson/{id}/{x}/{y}/{z}";
            var response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        public async Task<string> GetAllSsfaJson(byte id, byte x, decimal y, GraphTypes z)
        {
            string uri = $"chart/SSFAJson/{id}/{x}/{y}/{z}";
            var response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        public async Task<string> GetAllTsfaJson(byte id, byte x, decimal y, GraphTypes z)
        {
            string uri = $"chart/TSFAJson/{id}/{x}/{y}/{z}";
            var response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        public async Task<string> GetAllWfaJson(byte id, byte x, decimal y, GraphTypes z)
        {
            string uri = $"chart/WFAJson/{id}/{x}/{y}/{z}";
            var response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        public async Task<string> GetAllWfhJson(byte id, decimal x, decimal y, GraphTypes z)
        {
            string uri = $"chart/WFHJson/{id}/{x}/{y}/{z}";
            var response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        public async Task<string> GetAllWflJson(byte id, decimal x, decimal y, GraphTypes z)
        {
            string uri = $"chart/WFLJson/{id}/{x}/{y}/{z}";
            var response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}

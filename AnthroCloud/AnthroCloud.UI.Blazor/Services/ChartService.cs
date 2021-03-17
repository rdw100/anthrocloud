using AnthroCloud.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Services
{
    public class ChartService
    {
        private readonly HttpClient httpClient;

        public ChartService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        // https://localhost:5001/api/chart/WFL/1/73/9
        public async Task<List<WeightForLength>> GetAllWFL(byte id, double x, double y)
        {
            string uri = $"chart/WFL/{id}/{x}/{y}";
            var response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync
                <List<WeightForLength>>(responseStream);
        }
    }
}

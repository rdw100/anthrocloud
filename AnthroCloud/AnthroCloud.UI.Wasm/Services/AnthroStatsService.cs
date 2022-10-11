using AnthroCloud.Entities;
using System.Net.Http.Json;

namespace AnthroCloud.UI.Wasm.Services
{
    public class AnthroStatsService : IAnthroStatsService
    {
        private readonly HttpClient _httpClient;

        public AnthroStatsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Measure>> GetVisitScores(int visitId)
        {
            return await _httpClient.GetFromJsonAsync<List<Measure>>($"{_httpClient.BaseAddress}{ visitId}");
        }
    }
}
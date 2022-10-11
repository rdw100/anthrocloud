using AnthroCloud.Entities;

namespace AnthroCloud.UI.Wasm.Services
{
    public interface IAnthroStatsService
    {
        Task<List<Measure>> GetVisitScores(int visitId);
    }
}
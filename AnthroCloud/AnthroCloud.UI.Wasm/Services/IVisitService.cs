using AnthroCloud.Entities;

namespace AnthroCloud.UI.Wasm.Services
{
    public interface IVisitService
    {
        Task<IEnumerable<Visit>> GetVisits(int patientId);
        Task<IEnumerable<Measure>> GetVisitMeasures(int visitId);
        Task<IEnumerable<Visit>> GetVisitsMeasures(int patientId);
        Task<Visit> GetVisit(int visitId);
        Task<Visit> CreateVisit(Visit newVisit);
        Task<Visit> UpdateVisit(int visitId, Visit updatedVisit);
        Task DeleteVisit(int visitId);
    }
}

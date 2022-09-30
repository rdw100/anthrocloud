using AnthroCloud.Entities;

namespace AnthroCloud.UI.Wasm.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatient(int patientId);
        Task<Patient> UpdatePatient(int patientId, Patient updatedPatient);
        Task<Patient> CreatePatient(Patient newPatient);
        Task DeletePatient(int patientId);
    }
}

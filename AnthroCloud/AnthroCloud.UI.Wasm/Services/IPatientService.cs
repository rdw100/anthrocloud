using AnthroCloud.Entities;

namespace AnthroCloud.UI.Wasm.Services
{
    public interface IPatientService
    {
        Task<List<Patient>> GetPatients();
        Task<Patient> GetPatient(int patientId);
        Task<Patient> UpdatePatient(Patient updatedPatient);
        Task<Patient> CreatePatient(Patient newPatient);
    }
}

using AnthroCloud.Entities;
using System.Net.Http;
using System.Net.Http.Json;

namespace AnthroCloud.UI.Wasm.Services
{
    public class PatientService : IPatientService
    {
        private readonly HttpClient _httpClient;
        
        public PatientService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        
        public async Task<Patient> CreatePatient(Patient newPatient)
        {
            await _httpClient.PostAsJsonAsync<Patient>(_httpClient.BaseAddress + "Patients/", newPatient);
            return newPatient;
        }

        public Task<Patient> GetPatient(int patientId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Patient>> GetPatients()
        {
            throw new NotImplementedException();
        }

        public Task<Patient> UpdatePatient(Patient updatedPatient)
        {
            throw new NotImplementedException();
        }
    }
}

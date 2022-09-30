using AnthroCloud.Entities;
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

        public async Task<Patient> GetPatient(int patientId)
        {
            return await _httpClient.GetFromJsonAsync<Patient>(_httpClient.BaseAddress + "Patients/" + patientId);
        }
        
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _httpClient.GetFromJsonAsync<List<Patient>>(_httpClient.BaseAddress + "Patients/");
        }

        public async Task<Patient> UpdatePatient(int patientId, Patient updatedPatient)
        {
            await _httpClient.PutAsJsonAsync<Patient>(_httpClient.BaseAddress + "Patients/" + patientId, updatedPatient);
            return updatedPatient;
        }
        public async Task DeletePatient(int patientId)
        {
            await _httpClient.DeleteAsync(_httpClient.BaseAddress + "Patients/" + patientId);
        }
    }
}
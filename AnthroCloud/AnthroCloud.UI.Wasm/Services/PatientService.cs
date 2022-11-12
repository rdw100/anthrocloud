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
            await _httpClient.PostAsJsonAsync<Patient>(_httpClient.BaseAddress, newPatient);
            return newPatient;
        }

        public async Task<Patient> GetPatient(int patientId)
        {
            return await _httpClient.GetFromJsonAsync<Patient>($"{_httpClient.BaseAddress}{patientId}");
        }
        
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _httpClient.GetFromJsonAsync<List<Patient>>(_httpClient.BaseAddress);
        }

        public async Task<IEnumerable<Patient>> GetPatientsVisits()
        {
            return await _httpClient.GetFromJsonAsync<List<Patient>>(_httpClient.BaseAddress + "Visits/");
        }

        public async Task<Patient> UpdatePatient(int patientId, Patient updatedPatient)
        {
            await _httpClient.PutAsJsonAsync<Patient>($"{_httpClient.BaseAddress}{patientId}", updatedPatient);
            return updatedPatient;
        }

        public async Task DeletePatient(int patientId)
        {
            await _httpClient.DeleteAsync($"{_httpClient.BaseAddress}{patientId}");
        }
    }
}
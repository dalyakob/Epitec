using DevTraining.BlazorServer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevTraining.BlazorServer.Data.Services
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ContactResponseDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("api/Contacts");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStreamAsync();

            return  await JsonSerializer.DeserializeAsync<List<ContactResponseDTO>>
                          (responseContent, 
                          new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public async Task<ContactResponseDTO> Get(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/Contacts/{id}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<ContactResponseDTO>
                          (responseContent,
                          new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public async Task<ContactResponseDTO> Create(ContactResponseDTO contact)
        {
            var response = await _httpClient.PostAsync("api/Contacts",
                new StringContent(JsonSerializer.Serialize(contact), Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
                return await JsonSerializer.DeserializeAsync<ContactResponseDTO>(await response.Content.ReadAsStreamAsync());
            return null;

        }

        public async Task<ContactResponseDTO> Edit(ContactResponseDTO contact)
        {
            var contactJson = new StringContent(JsonSerializer.Serialize(contact), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/Contacts", contactJson);
            if (response.IsSuccessStatusCode)
                return await JsonSerializer.DeserializeAsync<ContactResponseDTO>(await response.Content.ReadAsStreamAsync());
            return null;
        }

        public async Task Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/Contacts/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

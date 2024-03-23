using Hotel.Entity.Models;
using Hotel.WebApi.Services.ApiResponseModels;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.WebApi.Services.WebApiServices
{
    public class ContactApiService
    {
        private readonly HttpClient _httpClient;

        public ContactApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7197");
        }

        public async Task<List<Contact>> GetAllContactsAsync()
        {
            var response = await _httpClient.GetAsync("/api/Contact/getall");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<JObject>(data);
            var staff = jsonObject["data"].ToObject<List<Contact>>();

            return staff ?? throw new Exception("Contact is empty");
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Contact/{id}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ResponseData<Contact>>(data);

            return responseData.Data ?? throw new Exception("Contact is empty");
        }

        public async Task AddContactAsync(Contact contact)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Contact/add", contact);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddRangeContactAsync(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                var response = await _httpClient.PostAsJsonAsync("/api/Contact/addrange", contact);
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteContactAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Contact/delete/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteRangeContactAsync(List<int> contactIds)
        {
            var content = new StringContent(JsonConvert.SerializeObject(contactIds), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, "/api/Contact/deleterange"),
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task DestroyContactAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Contact/destroy?id={id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DestroyRangeContactAysnc(List<int> contactIds)
        {
            var content = new StringContent(JsonConvert.SerializeObject(contactIds), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, "/api/Contact/destroyrange"),
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateContactAsync(Contact model)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/Contact/update/", model);
            response.EnsureSuccessStatusCode();
        }
    }
}
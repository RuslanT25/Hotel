using Hotel.Entity.Models;
using Hotel.WebApi.Services.ApiResponseModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.WebApi.Services.WebApiServices
{
    public class ServiceApiService
    {
        readonly HttpClient _httpClient;
        public ServiceApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7197");
        }

        public async Task<List<Service>> GetAllServices()
        {
            var response = await _httpClient.GetAsync("/api/Service/getall");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<JObject>(data);
            var services = jsonObject["data"].ToObject<List<Service>>();

            return services ?? throw new Exception("Service is empty.");
        }

        public async Task<Service> GetServiceByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Service/{id}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ResponseData<Service>>(data);

            return responseData.Data ?? throw new Exception("Service is empty");
        }
        public async Task AddServiceAsync(Service service)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Service/add", service);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddRangeServiceAsync(List<Service> services)
        {
            foreach (var service in services)
            {
                var response = await _httpClient.PostAsJsonAsync("/api/Service/addrange", service);
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteServiceAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Service/delete/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteRangeServiceAsync(List<int> serviceIds)
        {
            var content = new StringContent(JsonConvert.SerializeObject(serviceIds), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, "/api/Service/deleterange"),
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task DestroyServiceAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Service/destroy/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DestroyRangeServiceAysnc(List<int> serviceIds)
        {
            var content = new StringContent(JsonConvert.SerializeObject(serviceIds), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, "/api/Service/destroyrange"),
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateServiceAsync(Service model)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/Service/update/", model);
            response.EnsureSuccessStatusCode();
        }
    }
}

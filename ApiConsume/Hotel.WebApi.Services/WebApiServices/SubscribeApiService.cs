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
    public class SubscribeApiService
    {
        private readonly HttpClient _httpClient;

        public SubscribeApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7197");
        }

        public async Task<List<Subscribe>> GetAllSubscribesAsync()
        {
            var response = await _httpClient.GetAsync("/api/Subscribe/getall");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<JObject>(data);
            var staff = jsonObject["data"].ToObject<List<Subscribe>>();

            return staff ?? throw new Exception("Subscribe is empty");
        }


        public async Task<Subscribe> GetSubscribeByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Subscribe/{id}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ResponseData<Subscribe>>(data);

            return responseData.Data ?? throw new Exception("Subscribe is empty");
        }

        public async Task AddSubscribeAsync(Subscribe subscribe)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Subscribe/add", subscribe);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddRangeSubscribeAsync(List<Subscribe> subscribes)
        {
            foreach (var subscribe in subscribes)
            {
                var response = await _httpClient.PostAsJsonAsync("/api/Subscribe/addrange", subscribe);
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteSubscribeAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Subscribe/delete/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteRangeSubscribeAsync(List<int> subscribeIds)
        {
            var content = new StringContent(JsonConvert.SerializeObject(subscribeIds), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, "/api/Subscribe/deleterange"),
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task DestroySubscribeAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Subscribe/destroy?id={id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DestroyRangeSubscribeAysnc(List<int> subscribeIds)
        {
            var content = new StringContent(JsonConvert.SerializeObject(subscribeIds), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, "/api/Subscribe/destroyrange"),
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateSubscribeAsync(Subscribe model)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/Subscribe/update/", model);
            response.EnsureSuccessStatusCode();
        }
    }
}

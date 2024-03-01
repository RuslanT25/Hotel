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
using Hotel.Entity.DTOs.About;

namespace Hotel.WebApi.Services.WebApiServices
{
    public class AboutApiService
    {
        private readonly HttpClient _httpClient;

        public AboutApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7197");
        }

        public async Task<List<About>> GetAllAboutsAsync()
        {
            var response = await _httpClient.GetAsync("/api/About/getall");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<JObject>(data);
            var staff = jsonObject["data"].ToObject<List<About>>();

            return staff ?? throw new Exception("About is empty");
        }


        public async Task<About> GetAboutByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/About/{id}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ResponseData<About>>(data);

            return responseData.Data ?? throw new Exception("About is empty");
        }

        public async Task AddAboutAsync(About about)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/About/add", about);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddRangeAboutAsync(List<About> abouts)
        {
            foreach (var about in abouts)
            {
                var response = await _httpClient.PostAsJsonAsync("/api/About/addrange", about);
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteAboutAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/About/delete/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteRangeAboutAsync(List<int> aboutIds)
        {
            var content = new StringContent(JsonConvert.SerializeObject(aboutIds), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, "/api/About/deleterange"),
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task DestroyAboutAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/About/destroy?id={id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DestroyRangeAboutAysnc(List<int> aboutIds)
        {
            var content = new StringContent(JsonConvert.SerializeObject(aboutIds), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, "/api/About/destroyrange"),
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAboutAsync(About model)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/About/update/", model);
            response.EnsureSuccessStatusCode();
        }
    }
}

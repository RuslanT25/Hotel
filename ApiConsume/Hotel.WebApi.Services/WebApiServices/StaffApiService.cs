using Hotel.Entity.Models;
using Hotel.WebApi.Services.ApiResponseModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace Hotel.WebApi.Services.WebApiServices
{
    public class StaffApiService
    {
        private readonly HttpClient _httpClient;

        public StaffApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7197");
        }

        public async Task<List<Staff>> GetAllStaffAsync()
        {
            var response = await _httpClient.GetAsync("/api/Staff/getall");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<JObject>(data);
            var staff = jsonObject["data"].ToObject<List<Staff>>();

            return staff ?? throw new Exception("Staff is empty");
        }


        public async Task<Staff> GetStaffByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Staff/{id}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ResponseData<Staff>>(data);

            return responseData.Data ?? throw new Exception("Staff is empty");
        }

        public async Task AddStaffAsync(Staff staff, IFormFile image)
        {
            using var content = new MultipartFormDataContent();
            using var imageContent = new StreamContent(image.OpenReadStream());
            imageContent.Headers.ContentType = new MediaTypeHeaderValue(image.ContentType);
            content.Add(imageContent, "ImageFile", image.FileName);
            content.Add(new StringContent(staff.Name), "Name");
            content.Add(new StringContent(staff.Title.ToString()), "Title");
            content.Add(new StringContent(staff.Number.ToString()), "Number");
            content.Add(new StringContent(staff.SocialMedia1.ToString()), "SocialMedia1");
            content.Add(new StringContent(staff.SocialMedia2.ToString()), "SocialMedia2");
            content.Add(new StringContent(staff.SocialMedia3.ToString()), "SocialMedia3");

            var response = await _httpClient.PostAsync("api/Staff/add", content);
            response.EnsureSuccessStatusCode();
        }


        public async Task AddRangeStaffAsync(List<Staff> staff)
        {
            foreach (var _staff in staff)
            {
                var response = await _httpClient.PostAsJsonAsync("/api/Staff/addrange", _staff);
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteStaffAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Staff/delete/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteRangeStaffAsync(List<int> staffIds)
        {
            var content = new StringContent(JsonConvert.SerializeObject(staffIds), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, "/api/Staff/deleterange"),
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task DestroyStaffAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Staff/destroy?id={id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DestroyRangeStaffAysnc(List<int> staffIds)
        {
            var content = new StringContent(JsonConvert.SerializeObject(staffIds), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, "/api/Staff/destroyrange"),
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateStaffAsync(Staff model)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/Staff/update/", model);
            response.EnsureSuccessStatusCode();
        }
    }
}

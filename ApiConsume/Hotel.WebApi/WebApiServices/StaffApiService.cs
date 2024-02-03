using Hotel.Entity.Entities;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace Hotel.WebApi.WebApiServices
{
    public class StaffApiService
    {
        private readonly HttpClient _httpClient;

        public StaffApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<List<Staff>> GetAllStaff()
        {
            var response = await _httpClient.GetAsync("/api/Room/getall");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var staff= JsonConvert.DeserializeObject<List<Staff>>(data);

            return staff ?? throw new Exception("Staff is empty");
        }

        public async Task<Staff> GetStaff(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Staff/{id}");
            response.EnsureSuccessStatusCode();

            var data=await response.Content.ReadAsStringAsync();
            var staff=JsonConvert.DeserializeObject<Staff>(data);

            return staff ?? throw new Exception("Staff is empty");
        }

        public async Task AddStaff(Staff staff)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Staff/add",staff);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddRangeStaff(List<Staff> staffList)
        {
            foreach (var staff in staffList)
            {
                var response = await _httpClient.PostAsJsonAsync("/api/Staff/addrange", staff);
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteStaff(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Staff/delete/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteRangeStaff(List<int> staffIds)
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

        public async Task DestroyStaff(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Staff/destroy/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DestroyRangeStaff(List<int> staffIds)
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
    }
}

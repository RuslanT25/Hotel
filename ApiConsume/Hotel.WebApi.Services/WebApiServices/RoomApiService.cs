using Hotel.Entity.Models;
using Hotel.WebApi.Services.ApiResponseModels;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace Hotel.WebApi.Services.WebApiServices
{
    public class RoomApiService
    {
        private readonly HttpClient _httpClient;

        public RoomApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7197");
        }

        public async Task<List<Room>> GetAllRoomsAsync()
        {
            var response = await _httpClient.GetAsync("/api/Room/getall");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<JObject>(data);
            var room = jsonObject["data"].ToObject<List<Room>>();

            return room ?? throw new Exception("Room is empty");
        }


        public async Task<Room> GetRoomByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Room/{id}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ResponseData<Room>>(data);

            return responseData.Data ?? throw new Exception("Room is empty");
        }

        public async Task AddRoomAsync(Room room, IFormFile image)
        {
            using var content = new MultipartFormDataContent();
            using var imageContent = new StreamContent(image.OpenReadStream());
            imageContent.Headers.ContentType = new MediaTypeHeaderValue(image.ContentType);
            content.Add(imageContent, "ImageFile", image.FileName);
            content.Add(new StringContent(room.RoomNumber), "RoomNumber");
            content.Add(new StringContent(room.Price.ToString()), "Price");
            content.Add(new StringContent(room.Title.ToString()), "Title");
            content.Add(new StringContent(room.BedCount.ToString()), "BedCount");
            content.Add(new StringContent(room.BathCount.ToString()), "BathCount");
            content.Add(new StringContent(room.Description.ToString()), "Description");
            content.Add(new StringContent(room.Wifi.ToString()), "Wifi");

            var response = await _httpClient.PostAsync("api/Room/add", content);
            response.EnsureSuccessStatusCode();
        }


        public async Task AddRangeRoomAsync(List<Room> rooms)
        {
            foreach (var room in rooms)
            {
                var response = await _httpClient.PostAsJsonAsync("/api/Room/addrange", room);
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteRoomAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Room/delete/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteRangeRoomAsync(List<int> roomIds)
        {
            var content = new StringContent(JsonConvert.SerializeObject(roomIds), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, "/api/Room/deleterange"),
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task DestroyRoomAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Room/destroy?id={id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DestroyRangeRoomAysnc(List<int> roomIds)
        {
            var content = new StringContent(JsonConvert.SerializeObject(roomIds), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, "/api/Room/destroyrange"),
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateRoomAsync(Room model)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/Room/update/", model);
            response.EnsureSuccessStatusCode();
        }
    }
}

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
    public class BookingApiService
    {
        private readonly HttpClient _httpClient;

        public BookingApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7197");
        }

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            var response = await _httpClient.GetAsync("/api/Booking/getall");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<JObject>(data);
            var staff = jsonObject["data"].ToObject<List<Booking>>();

            return staff ?? throw new Exception("Booking is empty");
        }


        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Booking/{id}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ResponseData<Booking>>(data);

            return responseData.Data ?? throw new Exception("Booking is empty");
        }

        public async Task AddBookingAsync(Booking booking)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Booking/add", booking);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddRangeBookingAsync(List<Booking> bookings)
        {
            foreach (var booking in bookings)
            {
                var response = await _httpClient.PostAsJsonAsync("/api/Booking/addrange", booking);
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteBookingAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Booking/delete/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteRangeBookingAsync(List<int> bookingIds)
        {
            var content = new StringContent(JsonConvert.SerializeObject(bookingIds), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, "/api/Booking/deleterange"),
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task DestroyBookingAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Booking/destroy?id={id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DestroyRangeBookingAysnc(List<int> bookingIds)
        {
            var content = new StringContent(JsonConvert.SerializeObject(bookingIds), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, "/api/Booking/destroyrange"),
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateBookingAsync(Booking model)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/Booking/update/", model);
            response.EnsureSuccessStatusCode();
        }
    }
}

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
    public class SendMessageApiService
    {
        private readonly HttpClient _httpClient;

        public SendMessageApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7197");
        }

        public async Task<List<SendMessage>> GetAllSendMessagesAsync()
        {
            var response = await _httpClient.GetAsync("/api/SendMessage/getall");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<JObject>(data);
            var staff = jsonObject["data"].ToObject<List<SendMessage>>();

            return staff ?? throw new Exception("SendMessage is empty");
        }

        public async Task<SendMessage> GetSendMessageByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/SendMessage/{id}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ResponseData<SendMessage>>(data);

            return responseData.Data ?? throw new Exception("SendMessage is empty");
        }

        public async Task AddSendMessageAsync(SendMessage sendMessage)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/SendMessage/add", sendMessage);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddRangeSendMessageAsync(List<SendMessage> sendMessages)
        {
            foreach (var sendMessage in sendMessages)
            {
                var response = await _httpClient.PostAsJsonAsync("/api/SendMessage/addrange", sendMessage);
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteSendMessageAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/SendMessage/delete/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteRangeSendMessageAsync(List<int> sendMessageIds)
        {
            var content = new StringContent(JsonConvert.SerializeObject(sendMessageIds), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, "/api/SendMessage/deleterange"),
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task DestroySendMessageAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/SendMessage/destroy?id={id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DestroyRangeSendMessageAysnc(List<int> sendMessageIds)
        {
            var content = new StringContent(JsonConvert.SerializeObject(sendMessageIds), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, "/api/SendMessage/destroyrange"),
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateSendMessageAsync(SendMessage model)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/SendMessage/update/", model);
            response.EnsureSuccessStatusCode();
        }
    }
}

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
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace Hotel.WebApi.Services.WebApiServices
{
    public class TestimonialApiService
    {
        private readonly HttpClient _httpClient;

        public TestimonialApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7197");
        }

        public async Task<List<Testimonial>> GetAllTestimonialsAsync()
        {
            var response = await _httpClient.GetAsync("/api/Testimonial/getall");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<JObject>(data);
            var staff = jsonObject["data"].ToObject<List<Testimonial>>();

            return staff ?? throw new Exception("Testimonial is empty");
        }


        public async Task<Testimonial> GetTestimonialByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Testimonial/{id}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ResponseData<Testimonial>>(data);

            return responseData.Data ?? throw new Exception("Testimonial is empty");
        }

        public async Task AddTestimonialAsync(Testimonial testimonial,IFormFile image)
        {
            using var content = new MultipartFormDataContent();
            using var imageContent = new StreamContent(image.OpenReadStream());
            imageContent.Headers.ContentType = new MediaTypeHeaderValue(image.ContentType);
            content.Add(imageContent, "ImageFile", image.FileName);
            content.Add(new StringContent(testimonial.Title), "Title");
            content.Add(new StringContent(testimonial.Description.ToString()), "Description");
            content.Add(new StringContent(testimonial.Name.ToString()), "Name");

            var response = await _httpClient.PostAsync("api/Testimonial/add", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddRangeTestimonialAsync(List<Testimonial> testimonials)
        {
            foreach (var testimonial in testimonials)
            {
                var response = await _httpClient.PostAsJsonAsync("/api/Testimonial/addrange", testimonial);
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteTestimonialAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Testimonial/delete/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteRangeTestimonialAsync(List<int> testimonialIds)
        {
            var content = new StringContent(JsonConvert.SerializeObject(testimonialIds), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, "/api/Testimonial/deleterange"),
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task DestroyTestimonialAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Testimonial/destroy/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DestroyRangeTestimonialAysnc(List<int> testimonialIds)
        {
            var content = new StringContent(JsonConvert.SerializeObject(testimonialIds), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, "/api/Testimonial/destroyrange"),
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateTestimonialAsync(Testimonial model)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/Testimonial/update/", model);
            response.EnsureSuccessStatusCode();
        }
    }
}

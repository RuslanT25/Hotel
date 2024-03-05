using Hotel.Business.Constants;
using Hotel.Business.ManagerServices.Abstracts;
using Hotel.Business.Results;
using Hotel.DAL.Contracts;
using Hotel.DAL.Implementations;
using Hotel.Entity.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.ManagerServices.Concretes
{
    public class TestimonialManager : BaseManager<Testimonial>, ITestimonialService
    {
        readonly ITestimonialRepository _testimonialRepository;
        public TestimonialManager(ITestimonialRepository testimonialRepository) : base(testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }
        public async Task<Result> AddTestimonialWithImageAsync(Testimonial testimonial, IFormFile image)
        {
            if (image.Length > 500000) // 500KB limit
            {
                return new ErrorResult("Image size cannot be more than 500KB.");
            }

            var allowedContentTypes = new[] { "image/jpeg", "image/png", "image/jpg" };
            if (!allowedContentTypes.Contains(image.ContentType))
            {
                return new ErrorResult("Invalid image format. Only .jpg and .png formats are allowed.");
            }

            await _testimonialRepository.AddTestimonialWithImageAsync(testimonial, image);
            return new SuccessResult(Messages<Testimonial>.Entity<Testimonial>.Add());
        }
    }
}

﻿using Hotel.Business.Results;
using Hotel.Entity.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.ManagerServices.Abstracts
{
    public interface ITestimonialService : IBaseService<Testimonial>
    {
        Task<Result> AddTestimonialWithImageAsync(Testimonial testimonial, IFormFile image);
    }
}

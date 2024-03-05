using Hotel.DAL.Repositories.Abstracts;
using Hotel.Entity.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAL.Contracts
{
    public interface IStaffRepository : IGenericRepository<Staff>
    {
        Task AddStaffWithImageAsync(Staff staff, IFormFile image);
    }
}

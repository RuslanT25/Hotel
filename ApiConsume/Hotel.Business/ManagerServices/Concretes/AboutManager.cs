using Hotel.Business.ManagerServices.Abstracts;
using Hotel.DAL.Contracts;
using Hotel.DAL.Repositories.Abstracts;
using Hotel.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.ManagerServices.Concretes
{
    public class AboutManager : BaseManager<About>, IAboutService
    {
        readonly IAboutRepository _aboutRepository;
        public AboutManager(IAboutRepository aboutRepository) : base(aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }
    }
}

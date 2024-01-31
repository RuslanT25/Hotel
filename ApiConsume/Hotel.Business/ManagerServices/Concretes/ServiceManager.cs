using Hotel.Business.ManagerServices.Abstracts;
using Hotel.DAL.Contracts;
using Hotel.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.ManagerServices.Concretes
{
    public class ServiceManager : BaseManager<Service>, IServiceService
    {
        readonly IServiceRepository _serviceRepository;
        public ServiceManager(IServiceRepository serviceRepository) : base(serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
    }
}

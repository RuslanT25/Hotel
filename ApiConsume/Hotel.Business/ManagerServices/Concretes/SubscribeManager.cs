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
    public class SubscribeManager : BaseManager<Subscribe>, ISubscribeService
    {
        readonly ISubscribeRepository _subscribeRepository;
        public SubscribeManager(ISubscribeRepository subscribeRepository ) : base( subscribeRepository )
        {
            _subscribeRepository = subscribeRepository;
        }
    }
}

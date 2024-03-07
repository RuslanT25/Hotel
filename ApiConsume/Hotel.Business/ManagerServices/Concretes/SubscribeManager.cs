using Hotel.Business.Constants;
using Hotel.Business.ManagerServices.Abstracts;
using Hotel.Business.Results;
using Hotel.DAL.Contracts;
using Hotel.Entity.Models;
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
        public SubscribeManager(ISubscribeRepository subscribeRepository) : base(subscribeRepository)
        {
            _subscribeRepository = subscribeRepository;
        }

        public override Result Add(Subscribe entity)
        {
            var result = _subscribeRepository.Any(x => x.Mail == entity.Mail);
            if (!result)
            {
                _subscribeRepository.Add(entity);
                return new SuccessResult(Messages<Subscribe>.Entity<Subscribe>.Add());
            }

            return new ErrorResult("This e-mail already subscribed.");
        }

        public override async Task<Result> AddAsync(Subscribe entity)
        {
            var result = await _subscribeRepository.AnyAsync(x => x.Mail == entity.Mail);
            if (!result)
            {
                await _subscribeRepository.AddAsync(entity);
                return new SuccessResult(Messages<Subscribe>.Entity<Subscribe>.Add());
            }

            return new ErrorResult("This e-mail already subscribed.");
        }
    }
}


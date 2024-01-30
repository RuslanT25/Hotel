using Hotel.Business.ManagerServices.Abstracts;
using Hotel.DAL.Repositories.Abstracts;
using Hotel.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.ManagerServices.Concretes
{
    public class BaseManager<T> : IBaseService<T> where T : BaseEntity
    {
        readonly IGenericRepository<T> _genericRepository;
        public BaseManager(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(List<T> list)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(List<T> list)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(List<T> list)
        {
            throw new NotImplementedException();
        }

        public void Destroy(T entity)
        {
            throw new NotImplementedException();
        }

        public void DestroyRange(List<T> list)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public T GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(List<T> list)
        {
            throw new NotImplementedException();
        }
    }
}

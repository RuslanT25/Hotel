using Hotel.DAL.ApplicationContext;
using Hotel.DAL.Repositories.Concretes;
using Hotel.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAL.Repositories.Abstracts
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        readonly HotelDbContext _context;
        public GenericRepository(HotelDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void AddRange(List<T> list)
        {
            _context.AddRange(list);
            _context.SaveChanges();
        }

        public async Task AddRangeAsync(List<T> list)
        {
            await _context.AddRangeAsync(list);
            await _context.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            entity.DeletedDate = DateTime.Now;
            _context.SaveChanges();
        }

        public void DeleteRange(List<T> list)
        {
            foreach (T entity in list)
            {
                Delete(entity);
            }
        }

        public void Destroy(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void DestroyRange(List<T> list)
        {
            _context.Set<T>().RemoveRange(list);
            _context.SaveChanges();
        }

        public List<T> GetAllAsync()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByIdAsync(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _context.Update(entity);
            _context.SaveChanges();
        }

        public void UpdateRange(List<T> list)
        {
            foreach (T entity in list)
            {
                Update(entity);
            }
        }
    }
}

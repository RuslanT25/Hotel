using Azure.Core;
using Hotel.DAL.ApplicationContext;
using Hotel.DAL.Repositories.Abstracts;
using Hotel.Entity.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAL.Repositories.Concretes
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

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateRange(List<T> list)
        {
            foreach (T entity in list)
            {
                Update(entity);
            }
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AnyAsync(expression);
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<T> FindAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public T Find(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }
    }
}

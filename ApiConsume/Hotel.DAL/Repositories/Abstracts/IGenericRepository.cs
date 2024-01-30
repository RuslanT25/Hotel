using Hotel.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAL.Repositories.Abstracts
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        List<T> GetAllAsync();
        T GetByIdAsync(int id);

        //Modify Commands
        void Add(T entity);
        Task AddAsync(T entity);
        void AddRange(List<T> list);
        Task AddRangeAsync(List<T> list);
        void Update(T entity);
        void UpdateRange(List<T> list);
        void Delete(T entity);
        void DeleteRange(List<T> list);
        void Destroy(T entity);
        void DestroyRange(List<T> list);

        // Linq Commands
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindAsync(int id);
    }
}

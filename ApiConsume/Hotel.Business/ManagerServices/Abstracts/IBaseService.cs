using Hotel.Business.Results;
using Hotel.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.ManagerServices.Abstracts
{
    public interface IBaseService<T> where T : BaseEntity
    {
        DataResult<List<T>> GetAll();
        DataResult<T> GetById(int id);

        //Modify Commands
        Result Add(T entity);
        Task<Result> AddAsync(T entity);
        Result AddRange(List<T> list);
        Task<Result> AddRangeAsync(List<T> list);
        Result Update(T entity);
        Result UpdateRange(List<T> list);
        Result Delete(T entity);
        Result DeleteRange(List<T> list);
        Result Destroy(T entity);
        Result DestroyRange(List<T> list);
    }
}

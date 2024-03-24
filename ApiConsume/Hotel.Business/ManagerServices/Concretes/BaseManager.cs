using AutoMapper;
using Hotel.Business.Constants;
using Hotel.Business.ManagerServices.Abstracts;
using Hotel.Business.Results;
using Hotel.DAL.Repositories.Abstracts;
using Hotel.Entity.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.ManagerServices.Concretes
{
    public abstract class BaseManager<T> : IBaseService<T> where T : BaseEntity
    {
        readonly IGenericRepository<T> _genericRepository;
        protected BaseManager(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public virtual Result Add(T entity)
        {
            var result = _genericRepository.Any(x => x.Id == entity.Id);
            if (!result)
            {
                _genericRepository.Add(entity);
                return new SuccessResult(Messages<T>.Entity<T>.Add());
            }

            return new ErrorResult(Messages<T>.Entity<T>.Exists());
        }

        public virtual async Task<Result> AddAsync(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            var result = await _genericRepository.AnyAsync(x => x.Id == entity.Id);
            if (!result)
            {
                await _genericRepository.AddAsync(entity);
                return new SuccessResult(Messages<T>.Entity<T>.Add());
            }

            return new ErrorResult(Messages<T>.Entity<T>.Exists());
        }

        public Result AddRange(List<T> list)
        {
            try
            {
                foreach (var entity in list)
                {
                    if (!_genericRepository.Any(x => x.Id == entity.Id))
                    {
                        _genericRepository.Add(entity);
                    }
                }

                return new SuccessResult(Messages<T>.Entity<T>.AddRange());
            }
            catch (Exception ex)
            {
                return new ErrorResult($"An error occurred: {ex.Message}");
            }
        }

        public async Task<Result> AddRangeAsync(List<T> list)
        {
            try
            {
                foreach (var entity in list)
                {
                    if (!await _genericRepository.AnyAsync(x => x.Id == entity.Id))
                    {
                        await _genericRepository.AddAsync(entity);
                    }
                }

                return new SuccessResult(Messages<T>.Entity<T>.AddRange());
            }
            catch (Exception ex)
            {
                return new ErrorResult($"An error occurred: {ex.Message}");
            }
        }


        public Result Delete(T entity)
        {
            var result = _genericRepository.Find(entity.Id);
            if (result !=  null)
            {
                _genericRepository.Delete(entity);
                return new SuccessResult(Messages<T>.Entity<T>.Delete());
            }

            return new ErrorResult(Messages<T>.Error());
        }

        public Result DeleteRange(List<T> list)
        {
            try
            {
                foreach (var entity in list)
                {
                    if (_genericRepository.Any(x => x.Id == entity.Id))
                    {
                        _genericRepository.Delete(entity);
                    }
                }

                return new SuccessResult(Messages<T>.Entity<T>.DeleteRange());
            }
            catch (Exception ex)
            {
                return new ErrorResult($"An error occurred: {ex.Message}");
            }
        }


        public Result Destroy(T entity)
        {
            var result = _genericRepository.Any(x => x.Id == entity.Id);
            if (result)
            {
                _genericRepository.Destroy(entity);
                return new SuccessResult(Messages<T>.Entity<T>.Destroy());
            }

            return new ErrorResult(Messages<T>.Error()); 
        }

        public Result DestroyRange(List<T> list)
        {
            try
            {
                foreach (var entity in list)
                {
                    if (_genericRepository.Any(x => x.Id == entity.Id))
                    {
                        _genericRepository.Destroy(entity);
                    }
                }

                return new SuccessResult(Messages<T>.Entity<T>.DestroyRange());
            }
            catch (Exception ex)
            {
                return new ErrorResult($"An error occurred: {ex.Message}");
            }
        }

        public async Task<DataResult<List<T>>> GetAllAsync()
        {
            var result = await _genericRepository.CountAsync();
            //if (result == 0)
            //{
            //    return new ErrorDataResult<List<T>>(Messages<T>.NotFound());
            //}

            return new SuccessDataResult<List<T>>(await _genericRepository.GetAllAsync());
        }

        public async Task<DataResult<T>> GetByIdAsync(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);
            if (entity != null)
            {
                return new SuccessDataResult<T>(entity);
            }

            return new ErrorDataResult<T>(Messages<T>.NotFound());
        }

        public Result Update(T entity)
        {
            var result = _genericRepository.GetById(entity.Id);
            if (result != null)
            {
                _genericRepository.Update(entity);
                return new SuccessDataResult<T>(Messages<T>.Entity<T>.Update());
            }

            return new ErrorDataResult<T>(Messages<T>.Entity<T>.Exists());
        }

        public Result UpdateRange(List<T> list)
        {
            try
            {
                foreach (var entity in from entity in list
                                       where _genericRepository.Any(x => x.Id == entity.Id)
                                       select entity)
                {
                    //_genericRepository.Update(entity);
                }

                return new SuccessResult(Messages<T>.Entity<T>.UpdateRange());
            }
            catch (Exception ex)
            {
                return new ErrorResult($"An error occurred: {ex.Message}");
            }
        }
    }
}

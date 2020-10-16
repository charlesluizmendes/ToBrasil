using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToBrasil.Domain.Interfaces.Repository;
using ToBrasil.Infrastructure.Data.Context;
using Dapper;
using System.Data;
using ToBrasil.Infrastructure.Data.Factory;

namespace ToBrasil.Infrastructure.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ToBrabilFactory _factory;
        private readonly ToBrasilContext _context;

        public BaseRepository(ToBrabilFactory factory,
            ToBrasilContext context)
        {
            _factory = factory;
            _context = context;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                var result = await _factory.GetConnection().QueryAsync<T>($"Select * From { typeof(T).Name }");

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<T> GetByIdAsync(object id)
        {
            try
            {
                var result = await _factory.GetConnection().QueryAsync<T>($"Select * From { typeof(T).Name } Where Id = { id }");

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        public virtual async Task<T> DeleteAsync(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }

        #endregion
    }
}

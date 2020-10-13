using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToBrasil.Domain.Interfaces.Repository;
using ToBrasil.Infrastructure.Data.Context;

namespace ToBrasil.Infrastructure.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ToBrasilContext _context;

        public BaseRepository(ToBrasilContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _context.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T GetById(object id)
        {
            try
            {
                return _context.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(T entidade)
        {
            try
            {
                _context.Set<T>().Add(entidade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(T entidade)
        {
            try
            {
                _context.Entry(entidade).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        public void Delete(T entidade)
        {
            try
            {
                _context.Set<T>().Remove(entidade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Commit()
        {
            return _context.SaveChanges();
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

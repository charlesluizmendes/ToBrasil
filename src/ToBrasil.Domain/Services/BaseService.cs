using System;
using System.Collections.Generic;
using System.Text;
using ToBrasil.Domain.Interfaces.Repository;
using ToBrasil.Domain.Interfaces.Services;

namespace ToBrasil.Domain.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }       

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(object id)
        {
            return _repository.GetById(id);
        }

        public void Insert(T entidade)
        {
            _repository.Insert(entidade);
        }

        public void Update(T entidade)
        {
            _repository.Update(entidade);
        }
        public void Delete(T entidade)
        {
            _repository.Delete(entidade);
        }

        public int Commit()
        {
            return _repository.Commit();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}

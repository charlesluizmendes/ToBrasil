using System;
using System.Collections.Generic;
using System.Text;
using ToBrasil.Application.Interfaces;
using ToBrasil.Domain.Interfaces.Services;

namespace ToBrasil.Application.Services
{
    public class BaseAppService<T> : IBaseAppService<T> where T : class
    {
        private readonly IBaseService<T> _service;

        public BaseAppService(IBaseService<T> service)
        {
            _service = service;
        }        

        public IEnumerable<T> GetAll()
        {
            return _service.GetAll();
        }

        public T GetById(object id)
        {
            return _service.GetById(id);
        }

        public void Insert(T entidade)
        {
            _service.Insert(entidade);
        }

        public void Update(T entidade)
        {
            _service.Update(entidade);
        }

        public void Delete(T entidade)
        {
            _service.Delete(entidade);
        }

        public int Commit()
        {
            return _service.Commit();
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ToBrasil.Application.Interfaces
{
    public interface IBaseAppService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T entidade);
        void Update(T entidade);
        void Delete(T entidade);
        int Commit();
        void Dispose();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.DataAccess
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetBYId(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}

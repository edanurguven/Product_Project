using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IRepository<T>
        where T : class, new()
    {
        void Add(T entity);
        void Delete(int id);
        List<T> GetAll();
        void Update(T entity);

        T GetById(int id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class BaseRepository<T> : IRepository<T>
        where T : class, new()
    {
        public List<T> list = new List<T>();
        public void Add(T entity)
        {
            using (var context = new ProjeDbContext())
            {
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new ProjeDbContext())
            {
                var entity = context.Find<T>(id);
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Update(T entity)
        {
            using (var context = new ProjeDbContext())
            {
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<T> GetAll()
        {
            using (var context = new ProjeDbContext())
            {
                list = context.Set<T>().ToList();
            }
            return list;
        }

        public T GetById(int id)
        {
            using (var context = new ProjeDbContext())
            {
                return context.Find<T>(id);
            }

        }

    }
}

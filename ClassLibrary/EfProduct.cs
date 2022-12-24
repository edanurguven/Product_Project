using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class EfProduct: BaseRepository<Product>, IProduct, IRepository<Product>
    {
        public List<Product> GetChoose(string[] Array)
        {
            using (var context = new ProjeDbContext())
            {
                IQueryable<Product> query = context.Products;
                foreach (string keyword in Array)
                    query = query.Where(p => p.Name.Contains(keyword));

                return query.ToList();

            }
        }
    }
}

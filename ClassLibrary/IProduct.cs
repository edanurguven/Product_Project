using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IProduct:IRepository<Product>
    {
        List<Product> GetChoose(string[] Array);
    }
}

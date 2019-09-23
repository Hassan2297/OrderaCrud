using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Repostiry
{
    interface IProductRepositry
    {
        IEnumerable<Product> GetAll();
        Product Get(int? id);
        void Add(Product item);
        void Remove(int id);
        void Update(Product item);
    }
}

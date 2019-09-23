using CrudProdcutApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    interface ICategoryRepositry
    {
        IEnumerable<Category> GetAll();
        Category Get(int id);
        void Add(Category item);
        void Remove(int id);
        void Update(Category item);
    }
}

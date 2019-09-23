using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;
namespace WebApplication2.ViewModels
{
    public class UserProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Category
    {
        public int categoryId { get; set; }

        [Display(Name = "Category Name")]
        public String categoryName { get; set; }

        public IList<Product> Products { get; set; }
    }
}
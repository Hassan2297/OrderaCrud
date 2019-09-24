using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Product
    {
        public int productId { get; set; }

        [Display(Name ="Product Name")]
        public String productName { get; set; }

        [Display(Name ="Product Price")]
        public int price { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }
    }
}
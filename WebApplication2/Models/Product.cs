using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Product
    {
        public int productId { get; set; }
        public String productName { get; set; }
        public int price { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Category
    {
        public int categoryId { get; set; }
        public String categoryName { get; set; }

        public IList<Product> Products { get; set; }
    }
}
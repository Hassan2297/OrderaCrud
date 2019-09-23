using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudProdcutApp.Models;
using WebApplication2.Repostiry;

namespace WebApplication2.Models
{
    public class UserProductRepositry : IRepositryProduct
    {
        private ApplicationDbContext _context;

        public UserProductRepositry()
        {
            _context = new ApplicationDbContext();
        }

       

        public object HttpNotFound { get; private set; }

        public void Add(Product product)
        {
            if (product != null)
                _context.Product.Add(product);

            _context.SaveChanges();
        }

        private Product BadRequest()
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            var product = _context.Product.SingleOrDefault(c => c.productId == id);

            if (product == null)
                return BadRequest();

            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Product.ToList();
        }

        public void Remove(int id)
        {
            var product = _context.Product.SingleOrDefault(c => c.productId == id);

            _context.Product.Remove(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            var productInDb = _context.Product.Single(c => c.productId == product.productId);

            productInDb.productName = product.productName;
            productInDb.price = product.price;
            productInDb.Category = product.Category;

            _context.SaveChanges();

        }
    }
}
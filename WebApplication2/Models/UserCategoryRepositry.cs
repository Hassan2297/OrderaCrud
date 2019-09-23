using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Models
{
    public class UserCategoryRepositry : ICategoryRepositry
    {
        private ApplicationDbContext _context;

        public UserCategoryRepositry()
        {
            _context = new ApplicationDbContext();
        }

        public void Add(Category category)
        {
            if (category != null)
                _context.Categories.Add(category);

            _context.SaveChanges();
        }

        public Category Get(int? id)
        {
            var cateogry = _context.Categories.SingleOrDefault(c => c.categoryId == id);

            

            return cateogry;
        }

        private Category BadRequest()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            var cateogry = _context.Categories.ToList();

            return cateogry;
        }

        public void Remove(int id)
        {
            var cateogry = _context.Categories.SingleOrDefault(c => c.categoryId == id);

            _context.Categories.Remove(cateogry);
            _context.SaveChanges();
        }

        public void Update(Category item)
        {
            var categoryInDb = _context.Categories.Single(c => c.categoryId == item.categoryId);

            categoryInDb.categoryName = item.categoryName;


            _context.SaveChanges();
        }
    }
}
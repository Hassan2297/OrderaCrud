using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        private readonly ICategoryRepositry categoryService = new UserCategoryRepositry();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Categories
        public ActionResult Index()
        {
            var catgoryList = categoryService.GetAll();

            return View(catgoryList);
        }

       

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryService.Add(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = categoryService.Get(id);

            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Category category)
        {
            if (ModelState.IsValid)
            {
                categoryService.Update(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {

            var category = categoryService.Get(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            categoryService.Remove(id);

            return RedirectToAction("Index");
        }

       

      
    }
}

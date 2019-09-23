using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Repostiry;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        private  readonly IProductRepositry productService = new UserProductRepositry();
        private readonly ICategoryRepositry categoryService = new UserCategoryRepositry();

         protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Products
        public ActionResult Index()
        {
            var productsList = productService.GetAll();

            return View(productsList);
        }

      

        [HttpGet]
        // GET: Prodcut form to create a product
        public ActionResult Create()
        {
            var categories = categoryService.GetAll();
            var viewModel = new UserProductViewModel
            {
                Categories = categories
            };
            return View(viewModel);
        }

        // POST: Products/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                productService.Add(product);
                return RedirectToAction("Index");
            }

            var categories = categoryService.GetAll();
            var viewModel = new UserProductViewModel
            {
                Product = product,
                Categories = categories
            };

            return View(viewModel);
        }

        [HttpGet]
        // GET: Products/Edit/id
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = productService.Get(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            var viewModel = new UserProductViewModel
            {
                Product = product,
                Categories = categoryService.GetAll()
            };
            return View(viewModel);
        }

        // POST: Products/Edit
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productService.Update(product);
                return RedirectToAction("Index");
            }
            var viewModel = new UserProductViewModel
            {
                Product = product,
                Categories = categoryService.GetAll()
            };
            return View(viewModel);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            
            var product = productService.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            productService.Remove(id);

            return RedirectToAction("Index");
        }

        

       
    }
}

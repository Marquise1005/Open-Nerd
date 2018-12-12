using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OpenNerd.Data;
using OpenNerd.Models;
using OpenNerd.Services;

namespace Open_Nerd_MVC.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var service = CreateProductService();
            var model = service.GetProducts();

            return View(model);
        }
        //Add method here VVVV
        // GET
        public ActionResult Create()
        {
            var service = CreateAuthorService();
            var authors = service.GetAuthors();
            ViewBag.AuthorId = new SelectList(authors, "AuthorId", "AuthorName");

            List<Genre> Genres = Enum.GetValues(typeof(Genre)).Cast<Genre>().ToList();
            ViewBag.RequiredLevel = new SelectList(Genres);

            return View();

        }

        //Add code here vvvv
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProductService();

            if (service.CreateProduct(model))
            {
                TempData["SaveResult"] = "Your Product was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Product could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateProductService();
            var detail = service.GetProductById(id);
            var model =
                new ProductEdit
                {
                    ProductId = detail.ProductId,
                    Title = detail.Title,
                    AuthorId=detail.AuthorId,
                     Volume= detail.Volume,
                     Genre= detail.Genre,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProductId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateProductService();

            if (service.UpdateProduct(model))
            {
                TempData["SaveResult"] = "Your Product was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Product could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int id)
        {
            var service = CreateProductService();

            service.DeleteProduct(id);

            TempData["SaveResult"] = "Your Product was deleted";

            return RedirectToAction("Index");
        }

        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            return service;
        }
        private AuthorService CreateAuthorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AuthorService(userId);
            return service;
        }
    }
}
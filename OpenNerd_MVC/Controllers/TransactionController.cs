using System;
using System.Collections;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OpenNerd.Models;
using OpenNerd.Services;

namespace Open_Nerd_MVC.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {
            var service = CreateTransactionService();
            var model = service.GetTransactions();

            return View(model);
        }
        //Add method here VVVV
        // GET

        public ActionResult Create()
        {
            var service = CreateProductService();
            var products = service.GetProducts();
            ViewBag.Title = new SelectList(products, "ProductId", "Title");
            return View();
        }


        //Add code here vvvv
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTransactionService();

            if (service.CreateTransaction(model))
            {
                TempData["SaveResult"] = "The Transaction you chose was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The Transaction was not created.");

            return View(model);
        }
        public TransactionService CreateTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionService(userId);
            return service;
        }
        public ActionResult Details(int id)
        {
            var svc = CreateTransactionService();
            var model = svc.GetTransactionById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateTransactionService();
            var detail = service.GetTransactionById(id);
            var model =
                new TransactionEdit
                {
                    ProductId = detail.ProductId,
                    Qauntity = detail.Qauntity,
                    Price= detail.Price,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TransactionId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTransactionService();

            if (service.UpdateTransaction(model))
            {
                TempData["SaveResult"] = "The Transaction was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The Transaction could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTransactionService();
            var model = svc.GetTransactionById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTransaction(int id)
        {
            var service = CreateTransactionService();

            service.DeleteProduct(id);

            TempData["SaveResult"] = "The Transaction was deleted";

            return RedirectToAction("Index");
        }
        private TransactionService CreateTransationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionService(userId);
            return service;
        }
        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            return service;
        }
    }
}
   

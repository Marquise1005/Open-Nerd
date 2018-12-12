using System;
using System.Collections.Generic;
using System.Web.Mvc;
using OpenNerd.Services;
using Microsoft.AspNet.Identity;
using OpenNerd.Models;
using OpenNerd.Data;
using System.Linq;

namespace Open_Nerd_MVC.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AuthorService(userId);
            var model = service.GetAuthors();


            return View(model);
        }
        //Add method here VVVV
        // GET

        public ActionResult Create()
        {
            //List<Gender> Genders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            //ViewBag.RequiredLevel = new SelectList(Genders);
            return View();
        }

        //Add code here vvvv
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAuthorService();

            if (service.CreateAuthor(model))
            {
                TempData["SaveResult"] = "The Author you chose was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The Author could not be created.");

            return View(model);
        }
        public AuthorService CreateAuthorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AuthorService(userId);
            return service;
        }
        public ActionResult Details(int id)
        {
            var svc = CreateAuthorService();
            var model = svc.GetAuthorById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateAuthorService();
            var detail = service.GetAuthorById(id);
            var model =
                new AuthorEdit
                {
                    AuthorId = detail.AuthorId,
                    AuthorName = detail.AuthorName,
                    Age = detail.Age,
                   
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AuthorEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AuthorId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAuthorService();

            if (service.UpdateAuthor(model))
            {
                TempData["SaveResult"] = "The Author was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Author could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAuthorService();
            var model = svc.GetAuthorById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAuthor(int id)
        {
            var service = CreateAuthorService();

            service.DeleteAuthor(id);

            TempData["SaveResult"] = "The Author was deleted";

            return RedirectToAction("Index");
        }
    }
}
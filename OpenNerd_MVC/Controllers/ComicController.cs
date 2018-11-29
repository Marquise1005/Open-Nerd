using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenNerd.Models;

namespace Open_Nerd_MVC.Controllers
{
    [Authorize]
    public class ComicController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var model = new ComicListItem[0];
            return View(model);
        }
        //Add method here VVVV
        // GET
        public ActionResult Create()
        {
            return View();
        }

    }

}
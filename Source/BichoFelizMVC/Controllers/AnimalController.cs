using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BichoFelizMVC.Controllers
{
    public class AnimalController : Controller
    {
        //
        // GET: /Animal/
        public ActionResult Index()
        {
            @TempData.Keep();
            return View();
        }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Controllers {
  public class HomeController : Controller {

    public ActionResult Index() {
      return View();
    }

    public ActionResult Registrar() {
      return View();
    }

    public ActionResult RecuperarSenha() {
      return View();
    }
  }
}

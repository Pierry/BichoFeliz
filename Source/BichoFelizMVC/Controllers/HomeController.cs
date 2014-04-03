using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BichoFelizMVC.Models;
using BichoFelizMVC.Repository;

namespace BichoFelizMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly LoginRepository _loginRepository = new LoginRepository();
  
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UsuarioModels usuario)
        {
            if (ModelState.IsValid)
            {
                var user = _loginRepository.LogIn(usuario.Email, usuario.Senha);
                if (user == null)
                {
                    @TempData["idcontato"] = "0";
                    @TempData["idempresa"] = "0";
                    return View(usuario);
                }
                @TempData["idcontato"] = user.IdContato;
                @TempData["idempresa"] = user.IdEmpresa;
                return RedirectToAction("Acompanhamento", "Home");
            }
            return View(usuario);
        }

        public ActionResult Acompanhamento()
        {
            @TempData.Keep();
            return View();
        }
        
        public ActionResult RegistrarUsuario()
        {
            @TempData.Keep();
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarUsuario(RegistrarUsuarioViewModel registrar)
      {
          if (ModelState.IsValid)
          {
              var user = _loginRepository.Registrar(registrar);
              if (user == 0)
              {
                  @TempData["IdUsuario"] = 0;
                  return View(registrar);
              }
              @TempData["IdUsuario"] = user;
              return RedirectToAction("Acompanhamento", "Home");
          }
            return View(registrar);
      }
    }
}

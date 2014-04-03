using System.Web.Mvc;
using BichoFelizMVC.Models;
using BichoFelizMVC.Repository;

namespace BichoFelizMVC.Controllers
{
    public class EmpresaController : Controller
    {
        private EmpresaRepository _empresaRepository = new EmpresaRepository();

        public ActionResult Index()
        {
            return View();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tcc_UI.Controllers
{
    public class MeusPedidosController : Controller
    {
        // GET: MeusPedidos
        public ActionResult Index()
        {
            if (Session["Login"] != null)
                return View();

            return RedirectToAction("AcessoNegado", "Login");
        }
    }
}
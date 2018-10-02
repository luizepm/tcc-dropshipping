using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tcc_UI.Helpers;
using tcc_UI.Models;

namespace tcc_UI.Controllers
{
    public class MinhaContaController : Controller
    {
        public LoginModels Login
        {
            get { return (LoginModels)Session["Login"]; }
        }

        public ActionResult Index()
        {
            if (Login != null)
            {
                var lojaApi = new LojaApi();
                var model = lojaApi.ObterDadosCliente(Login.IdLogin);

                return View(model);
            }

            return RedirectToAction("AcessoNegado", "Login");
        }
    }
}
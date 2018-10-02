using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tcc_UI.Helpers;
using tcc_UI.Models;

namespace tcc_UI.Controllers
{
    public class MeusPedidosController : Controller
    {
        public LoginModels Login
        {
            get { return (LoginModels)Session["Login"]; }
        }
        // GET: MeusPedidos
        public ActionResult Index()
        {
            if (Login != null)
            {
                var model = new MeusPedidosModel();
                var lojaApi = new LojaApi();

                model.Pedidos = lojaApi.ObterPedidosCliente(Login.IdLogin);

                return View(model);
            }

            return RedirectToAction("AcessoNegado", "Login");
        }
    }
}
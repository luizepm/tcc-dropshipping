using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tcc_UI.Controllers
{
    public class CarrinhoController : Controller
    {
        public ActionResult Index()
        {
            if (Session["ShoppingCarrinho"] == null)
                Session["ShoppingCarrinho"] = new Models.CarrinhoModels();

            // Pega o carrinho atual da Sessão
            var sc = (Models.CarrinhoModels)Session["ShoppingCarrinho"];

            return View(sc);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                if (Session["ShoppingCarrinho"] != null)
                {
                    var sc = (Models.CarrinhoModels)Session["ShoppingCarrinho"];
                    sc.RemoveItem(id);
                }
            }
            catch
            {

            }

            return RedirectToAction("Index");
        }
    }
}

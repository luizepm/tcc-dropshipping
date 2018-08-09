using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tcc_UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var fornecedor = new Helpers.FornecedorApi();
            ViewData["Produtos"] = fornecedor.ObterProdutos();

            ViewBag.Message = "Bem vindo a nossa loja!";
            return View();
        }

        public ActionResult Details(int id)
        {
            var fornecedor = new Helpers.FornecedorApi();
            var model = fornecedor.ObterProduto(id);

            if (model == null)
                return View();

            return View(model);
        }

        [HttpPost]
        public ActionResult Details(Models.ProdutoModels model)
        {
            var qtde = Request.Form["qtde"];
            model.Quantidade = Convert.ToInt32(qtde);

            // Cria um carrinho vazio na sessão se ele não exitir
            if (Session["ShoppingCarrinho"] == null)
                Session["ShoppingCarrinho"] = new Models.CarrinhoModels();

            // Pega o carrinho atual da Sessão
            var carrinho = (Models.CarrinhoModels)Session["ShoppingCarrinho"];

            carrinho.AddItem(model);

            return RedirectToAction("Index", "Carrinho");
        }
    }
}
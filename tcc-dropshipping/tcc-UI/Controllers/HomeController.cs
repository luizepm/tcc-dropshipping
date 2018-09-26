using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tcc_UI.Models;

namespace tcc_UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string nomePesquisa)
        {
            var fornecedor = new Helpers.LojaApi();

            if (string.IsNullOrEmpty(nomePesquisa))
            {
                ViewData["Produtos"] = fornecedor.ObterProdutos();
                ViewBag.NomePesquisa = "";
            }
            else
            {
                ViewData["Produtos"] = fornecedor.PesquisarProdutos(nomePesquisa);
                var model = ViewData["Produtos"] as List<tcc_UI.Models.ProdutoModels>;
                ViewBag.NomePesquisa = string.Format("{0} registro(s) encontrados para pesquisa {1}.", model.Count(), nomePesquisa);
            }

            ViewBag.Message = "Bem vindo a nossa loja!";
            return View();
        }

        public ActionResult Details(int id)
        {
            var fornecedor = new Helpers.LojaApi();
            var model = fornecedor.ObterProduto(id);

            if (model == null)
                return View();

            return View(model);
        }

        [HttpPost]
        public ActionResult Details(Models.ProdutoModels model)
        {
            var qtde = Request.Form["qtde"];

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
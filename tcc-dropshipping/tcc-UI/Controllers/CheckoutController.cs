using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tcc_UI.Helpers;
using tcc_UI.Models;

namespace tcc_UI.Controllers
{
    public class CheckoutController : Controller
    {
        public LoginModels Login
        {
            get { return (LoginModels)Session["Login"]; }
        }

        public CarrinhoModels Carrinho
        {
            get { return (CarrinhoModels)Session["ShoppingCarrinho"]; }
        }

        // GET: Checkout
        public ActionResult Index()
        {
            if (Login != null)
            {
                var model = new CheckoutModel();
                var lojaApi = new LojaApi();

                model.IdCliente = Login.IdLogin;
                model.Carrinho = Carrinho;

                return View(model);
            }

            return RedirectToAction("AcessoNegado", "Login");
        }

        [HttpPost]
        public ActionResult Index(CheckoutModel model)
        {
            if (ModelState.IsValid)
            {
                var lojaApi = new LojaApi();

                // gravar Pedido
                var pedido = new PedidoModel
                {
                    IdClienteRef = model.IdCliente,
                    IdEnderecoRef = model.IdEndereco,
                    IdFormaPagamento = model.TipoPagamento,
                    UsuarioManutencao = Login.Cliente.ObterNomeUsuario()
                };

                var idPedido = lojaApi.InserirPedido(pedido);

                // gravar PedidoProduto (para cada produto)
                foreach (var item in Carrinho.Itens)
                {
                    for (int i = 0; i < item.Quantidade; i++)
                    {
                        var pedidoProduto = new PedidoProdutoModel
                        {
                            IdPedidoRef = idPedido,
                            IdProdutoFornecedor = item.IdProdutoFornecedor,
                            IdFornecedorRef = item.IdFornecedor,
                            NomeProduto = item.NomeProduto,
                            Imagem = string.Empty,
                            ValorFornecedor = item.ValorFornecedor,
                            ValorFinal = item.ValorFinal,
                            UsuarioManutencao = Login.Cliente.ObterNomeUsuario()
                        };

                        var idPedidoProduto = lojaApi.InserirPedidoProduto(pedidoProduto);
                    }
                }

                // gravar Status do Pedido
                var statusPedido = new StatusPedidoModel
                {
                    IdPedidoRef = idPedido,
                    Status = "1",
                    UsuarioManutencao = Login.Cliente.ObterNomeUsuario()
                };

                var idStatusPedido = lojaApi.InserirStatusPedido(statusPedido);

                // gravar Frete
                //var frete = new FreteModel
                //{
                //    IdPedidoRef = idPedido,
                //    CodigoRastreio = "BR6645155XPTO",
                //    DtPrevisaoEntrega = DateTime.Now.AddDays(10),
                //    Valor = 15,
                //    UsuarioManutencao = Login.Cliente.ObterNomeUsuario()
                //};

                //var idFrete = lojaApi.InserirFrete(frete);

                // Zerar Carrinho
                Session["ShoppingCarrinho"] = null;

                var sucesso = new PedidoRealizadoComSucessoModel
                {
                    //CodigoRastreio = frete.CodigoRastreio,
                    //DtPrevisaoEntrega = frete.DtPrevisaoEntrega.ToString("dd/MM/yyyy"),
                    IdPedidoCliente = Funcoes.ObterCodigoPedidoCliente(idPedido, Login.Cliente.Nome, Login.Cliente.Sobrenome)
                };

                return View("Sucesso", sucesso);
            }
            else
            {
                model.IdCliente = Login.IdLogin;
                model.Carrinho = Carrinho;
                return View(model);
            }
        }
    }
}
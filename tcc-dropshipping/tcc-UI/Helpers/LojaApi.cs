using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using tcc_UI.Models;

namespace tcc_UI.Helpers
{
    public class LojaApi
    {
        private readonly string ApiBaseUrl = "http://localhost:51041/";

        public enum StatusPedido
        {
            PedidoEfetuado = 1,
            PagamentoAutorizado = 2,
            NotaFiscalEmitida = 3,
            EmTransporte = 4,
            ProdutoEntregue = 5
        }

        #region Fornecedor

        public int InserirPedido(PedidoModel pedido)
        {
            var metodo = "api/pedidos/";
            var objeto = ObjetoToJson(pedido);
            var retornoApi = ExecutarAPIPost(metodo, objeto);

            if (retornoApi.Status == HttpStatusCode.OK)
                pedido = JsonConvert.DeserializeObject<PedidoModel>(retornoApi.Objeto);

            return pedido.IdPedido;
        }

        public int InserirPedidoProduto(PedidoProdutoModel pedidoProduto)
        {
            var metodo = "api/pedidoProdutos/";
            var objeto = ObjetoToJson(pedidoProduto);
            var retornoApi = ExecutarAPIPost(metodo, objeto);

            if (retornoApi.Status == HttpStatusCode.OK)
                pedidoProduto = JsonConvert.DeserializeObject<PedidoProdutoModel>(retornoApi.Objeto);

            return pedidoProduto.IdPedidoProduto;
        }

        public int InserirStatusPedido(StatusPedidoModel statusPedido)
        {
            var metodo = "api/StatusPedido/";
            var objeto = ObjetoToJson(statusPedido);
            var retornoApi = ExecutarAPIPost(metodo, objeto);

            if (retornoApi.Status == HttpStatusCode.OK)
                statusPedido = JsonConvert.DeserializeObject<StatusPedidoModel>(retornoApi.Objeto);

            return statusPedido.IdStatusPedido;
        }

        public int InserirFrete(FreteModel frete)
        {
            var metodo = "api/Fretes/";
            var objeto = ObjetoToJson(frete);
            var retornoApi = ExecutarAPIPost(metodo, objeto);

            if (retornoApi.Status == HttpStatusCode.OK)
                frete = JsonConvert.DeserializeObject<FreteModel>(retornoApi.Objeto);

            return frete.IdFrete;
        }

        public List<EnderecoModel> ObterEnderecosCliente(int idCliente)
        {
            var metodo = "api/enderecos/cliente/" + idCliente.ToString();
            var enderecos = new List<EnderecoModel>();
            var retornoApi = ExecutarApiGet(metodo);

            if (retornoApi.Status == HttpStatusCode.OK)
                enderecos = JsonConvert.DeserializeObject<List<EnderecoModel>>(retornoApi.Objeto);

            return enderecos;
        }

        public List<ProdutoModels> ObterProdutos()
        {
            var metodo = "api/produtos/";
            var produtos = new List<ProdutoModels>();
            var retornoApi = ExecutarApiGet(metodo);

            if (retornoApi.Status == HttpStatusCode.OK)
                produtos = JsonConvert.DeserializeObject<List<ProdutoModels>>(retornoApi.Objeto);

            return produtos;
        }

        public List<ProdutoModels> PesquisarProdutos(string nomePesquisa)
        {
            var metodo = "api/produtos/" + nomePesquisa + "/null/null/null";
            var produtos = new List<ProdutoModels>();
            var retornoApi = ExecutarApiGet(metodo);

            if (retornoApi.Status == HttpStatusCode.OK)
                produtos = JsonConvert.DeserializeObject<List<ProdutoModels>>(retornoApi.Objeto);

            return produtos;
        }

        public Models.ProdutoModels ObterProduto(int id)
        {
            var metodo = "api/produtos/" + id;
            Models.ProdutoModels produto = null;
            var retornoApi = ExecutarApiGet(metodo);

            if (retornoApi.Status == HttpStatusCode.OK)
                produto = JsonConvert.DeserializeObject<Models.ProdutoModels>(retornoApi.Objeto);

            return produto;
        }

        #endregion

        #region Login

        public Models.LoginModels ValidarLogin(string email, string senha)
        {
            var metodo = "api/logins?email=" + email + "&senha=" + senha;
            LoginModels login = null;
            ClienteModel cliente = null;
            var retornoApi = ExecutarApiGet(metodo);

            if (retornoApi.Status == HttpStatusCode.OK)
            {
                login = JsonConvert.DeserializeObject<LoginModels>(retornoApi.Objeto);
                if (login != null)
                {
                    // Obter dados do Cliente
                    metodo = "api/Clientes/" + login.IdLogin;
                    retornoApi = ExecutarApiGet(metodo);

                    if (retornoApi.Status == HttpStatusCode.OK)
                    {
                        cliente = JsonConvert.DeserializeObject<ClienteModel>(retornoApi.Objeto);
                        if (cliente != null)
                            login.Cliente = cliente;
                    }
                }
            }

            return login;
        }

        #endregion

        #region Utilitarios

        public RespostaApi ExecutarApiGet(string metodo)
        {
            var resp = new RespostaApi();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + metodo);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    resp.Objeto = streamReader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse res = (HttpWebResponse)ex.Response;
                
                if (res.StatusCode == HttpStatusCode.NotFound)
                {
                    resp.Status = HttpStatusCode.NotFound;
                    resp.Mensagem = "Registro não encontrado.";
                }
            }

            return resp;
        }

        public RespostaApi ExecutarAPIPost(string metodo, string objetoJson)
        {
            var resp = new RespostaApi();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + metodo);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(objetoJson);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    resp.Objeto = streamReader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse res = (HttpWebResponse)ex.Response;

                if (res.StatusCode == HttpStatusCode.NotFound)
                {
                    resp.Status = HttpStatusCode.NotFound;
                    resp.Mensagem = "Registro não encontrado.";
                }
            }

            return resp;
        }

        public string ObjetoToJson(object obj)
        {
            return new JavaScriptSerializer().Serialize(obj).Replace("[", "").Replace("]", "");
        }

        #endregion
    }

    public class RespostaApi
    {
        public RespostaApi()
        {
            Status = HttpStatusCode.OK;
        }

        public HttpStatusCode Status { get; set; }
        public string Objeto { get; set; }
        public string Mensagem { get; set; }
    }
}
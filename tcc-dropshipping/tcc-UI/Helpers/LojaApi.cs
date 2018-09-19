using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace tcc_UI.Helpers
{
    public class LojaApi
    {
        private readonly string ApiBaseUrl = "http://localhost:51041/";

        #region Fornecedor

        public List<Models.ProdutoModels> ObterProdutos()
        {
            var metodo = "api/produtos/";
            var produtos = new List<Models.ProdutoModels>();
            var retornoApi = ExecutarApiGet(metodo);

            if (retornoApi.Status == HttpStatusCode.OK)
                produtos = JsonConvert.DeserializeObject<List<Models.ProdutoModels>>(retornoApi.Objeto);

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
            Models.LoginModels login = null;
            var retornoApi = ExecutarApiGet(metodo);

            if (retornoApi.Status == HttpStatusCode.OK)
                login = JsonConvert.DeserializeObject<Models.LoginModels>(retornoApi.Objeto);

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
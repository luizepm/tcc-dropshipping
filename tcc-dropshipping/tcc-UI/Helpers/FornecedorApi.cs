using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace tcc_UI.Helpers
{
    public class FornecedorApi
    {
        private readonly string ApiBaseUrl = "http://localhost:51041/";

        public Models.ProdutoModels ObterProdutos()
        {
            var metodo = "api/produtos/";
            var model = new Models.ProdutoModels();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + metodo);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var retorno = JsonConvert.DeserializeObject<List<Models.ProdutoModels>>(streamReader.ReadToEnd());

                    if (retorno != null)
                        model.ListaDeProdutos = retorno;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return model;
        }

        public Models.ProdutoModels ObterProduto(int id)
        {
            var metodo = "api/produtos/" + id;
            var model = new Models.ProdutoModels();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + metodo);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var retorno = JsonConvert.DeserializeObject<Models.ProdutoModels>(streamReader.ReadToEnd());

                    if (retorno != null)
                        model = retorno;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return model;
        }
    }
}
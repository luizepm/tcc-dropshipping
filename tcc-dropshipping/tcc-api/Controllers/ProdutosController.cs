using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace tcc_api.Controllers
{
    public class ProdutosController : ApiController
    {
        private FornecedorApi.Produto prd;

        // GET: api/Produtos
        public IEnumerable<FornecedorApi.Produto> Get()
        {
            prd = new FornecedorApi.Produto(null);
            return prd.ListaDeProdutos;
        }

        // GET: api/Produtos/5
        public FornecedorApi.Produto Get(int id)
        {
            prd = new FornecedorApi.Produto(null);
            var item = prd.ListaDeProdutos.FirstOrDefault(x => x.IdProduto == id);

            return item;
        }

        // POST: api/Produtos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Produtos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Produtos/5
        public void Delete(int id)
        {
        }
    }
}

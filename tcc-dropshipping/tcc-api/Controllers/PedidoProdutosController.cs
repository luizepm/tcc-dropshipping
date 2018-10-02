using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using tcc_api;

namespace CodeFirst.WebApi.Controller
{
    public class PedidoProdutosController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/PedidoProdutos
        public IQueryable<PedidoProduto> GetPedidoProdutos()
        {
            return db.PedidoProdutos;
        }

        // GET: api/PedidoProdutos/5
        [ResponseType(typeof(PedidoProduto))]
        public IHttpActionResult GetPedidoProduto(int id)
        {
            PedidoProduto pedidoProduto = db.PedidoProdutos.Find(id);
            if (pedidoProduto == null)
            {
                return NotFound();
            }

            return Ok(pedidoProduto);
        }

        [Route("api/PedidoProdutos/Pedido/{idPedido}")]
        public IQueryable<PedidoProduto> GetPedidoProdutoPorIdPedido(int idPedido)
        {
            return db.PedidoProdutos.Where(x => x.IdPedidoRef == idPedido);
        }

        // PUT: api/PedidoProdutos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPedidoProduto(int id, PedidoProduto pedidoProduto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedidoProduto.IdPedidoProduto)
            {
                return BadRequest();
            }

            db.Entry(pedidoProduto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoProdutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PedidoProdutos
        [ResponseType(typeof(PedidoProduto))]
        public IHttpActionResult PostPedidoProduto(PedidoProduto pedidoProduto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PedidoProdutos.Add(pedidoProduto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pedidoProduto.IdPedidoProduto }, pedidoProduto);
        }

        // DELETE: api/PedidoProdutos/5
        [ResponseType(typeof(PedidoProduto))]
        public IHttpActionResult DeletePedidoProduto(int id)
        {
            PedidoProduto pedidoProduto = db.PedidoProdutos.Find(id);
            if (pedidoProduto == null)
            {
                return NotFound();
            }

            db.PedidoProdutos.Remove(pedidoProduto);
            db.SaveChanges();

            return Ok(pedidoProduto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PedidoProdutoExists(int id)
        {
            return db.PedidoProdutos.Count(e => e.IdPedidoProduto == id) > 0;
        }
    }
}
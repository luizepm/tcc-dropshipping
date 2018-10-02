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
    public class StatusPedidosController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/StatusPedidos
        public IQueryable<StatusPedido> GetStatusPedido()
        {
            return db.StatusPedido;
        }

        // GET: api/StatusPedidos/5
        [ResponseType(typeof(StatusPedido))]
        public IHttpActionResult GetStatusPedido(int id)
        {
            StatusPedido statusPedido = db.StatusPedido.Find(id);
            if (statusPedido == null)
            {
                return NotFound();
            }

            return Ok(statusPedido);
        }

        [Route("api/StatusPedido/Pedido/{idPedido}")]
        public IQueryable<StatusPedido> GetStatusPedidoPorPedido(int idPedido)
        {
            var lista = db.StatusPedido.Where(x => x.IdPedidoRef == idPedido);

            return lista;
        }

        // PUT: api/StatusPedidos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatusPedido(int id, StatusPedido statusPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusPedido.IdStatusPedido)
            {
                return BadRequest();
            }

            db.Entry(statusPedido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusPedidoExists(id))
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

        // POST: api/StatusPedidos
        [ResponseType(typeof(StatusPedido))]
        public IHttpActionResult PostStatusPedido(StatusPedido statusPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatusPedido.Add(statusPedido);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StatusPedidoExists(statusPedido.IdStatusPedido))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = statusPedido.IdStatusPedido }, statusPedido);
        }

        // DELETE: api/StatusPedidos/5
        [ResponseType(typeof(StatusPedido))]
        public IHttpActionResult DeleteStatusPedido(int id)
        {
            StatusPedido statusPedido = db.StatusPedido.Find(id);
            if (statusPedido == null)
            {
                return NotFound();
            }

            db.StatusPedido.Remove(statusPedido);
            db.SaveChanges();

            return Ok(statusPedido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusPedidoExists(int id)
        {
            return db.StatusPedido.Count(e => e.IdStatusPedido == id) > 0;
        }
    }
}
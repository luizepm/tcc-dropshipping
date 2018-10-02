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
    public class FretesController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/Fretes
        public IQueryable<Frete> GetFrete()
        {
            return db.Frete;
        }

        // GET: api/Fretes/5
        [ResponseType(typeof(Frete))]
        public IHttpActionResult GetFrete(int id)
        {
            Frete frete = db.Frete.Find(id);
            if (frete == null)
            {
                return NotFound();
            }

            return Ok(frete);
        }

        [Route("api/fretes/cliente/{idPedido}")]
        public Frete GetFretePorPedido(int idPedido)
        {
            return db.Frete.First(x => x.IdPedidoRef == idPedido);
        }

        // PUT: api/Fretes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFrete(int id, Frete frete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != frete.IdFrete)
            {
                return BadRequest();
            }

            db.Entry(frete).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FreteExists(id))
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

        // POST: api/Fretes
        [ResponseType(typeof(Frete))]
        public IHttpActionResult PostFrete(Frete frete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Frete.Add(frete);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = frete.IdFrete }, frete);
        }

        // DELETE: api/Fretes/5
        [ResponseType(typeof(Frete))]
        public IHttpActionResult DeleteFrete(int id)
        {
            Frete frete = db.Frete.Find(id);
            if (frete == null)
            {
                return NotFound();
            }

            db.Frete.Remove(frete);
            db.SaveChanges();

            return Ok(frete);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FreteExists(int id)
        {
            return db.Frete.Count(e => e.IdFrete == id) > 0;
        }
    }
}
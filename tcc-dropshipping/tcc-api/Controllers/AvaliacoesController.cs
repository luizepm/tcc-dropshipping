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
    public class AvaliacoesController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/Avaliacoes
        public IQueryable<Avaliacao> GetAvaliacao()
        {
            return db.Avaliacao;
        }

        // GET: api/Avaliacoes/5
        [ResponseType(typeof(Avaliacao))]
        public IHttpActionResult GetAvaliacao(int id)
        {
            Avaliacao avaliacao = db.Avaliacao.Find(id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            return Ok(avaliacao);
        }

        // PUT: api/Avaliacoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAvaliacao(int id, Avaliacao avaliacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != avaliacao.IdAvaliacao)
            {
                return BadRequest();
            }

            db.Entry(avaliacao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvaliacaoExists(id))
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

        // POST: api/Avaliacoes
        [ResponseType(typeof(Avaliacao))]
        public IHttpActionResult PostAvaliacao(Avaliacao avaliacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Avaliacao.Add(avaliacao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = avaliacao.IdAvaliacao }, avaliacao);
        }

        // DELETE: api/Avaliacoes/5
        [ResponseType(typeof(Avaliacao))]
        public IHttpActionResult DeleteAvaliacao(int id)
        {
            Avaliacao avaliacao = db.Avaliacao.Find(id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            db.Avaliacao.Remove(avaliacao);
            db.SaveChanges();

            return Ok(avaliacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AvaliacaoExists(int id)
        {
            return db.Avaliacao.Count(e => e.IdAvaliacao == id) > 0;
        }
    }
}
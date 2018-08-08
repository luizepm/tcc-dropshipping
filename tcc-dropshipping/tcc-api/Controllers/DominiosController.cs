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
    public class DominiosController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/Dominios
        public IQueryable<Dominio> GetDominios()
        {
            return db.Dominios;
        }

        // GET: api/Dominios/5
        [ResponseType(typeof(Dominio))]
        public IHttpActionResult GetDominio(int id)
        {
            Dominio dominio = db.Dominios.Find(id);
            if (dominio == null)
            {
                return NotFound();
            }

            return Ok(dominio);
        }

        // PUT: api/Dominios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDominio(int id, Dominio dominio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dominio.IdDominio)
            {
                return BadRequest();
            }

            db.Entry(dominio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DominioExists(id))
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

        // POST: api/Dominios
        [ResponseType(typeof(Dominio))]
        public IHttpActionResult PostDominio(Dominio dominio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dominios.Add(dominio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dominio.IdDominio }, dominio);
        }

        // DELETE: api/Dominios/5
        [ResponseType(typeof(Dominio))]
        public IHttpActionResult DeleteDominio(int id)
        {
            Dominio dominio = db.Dominios.Find(id);
            if (dominio == null)
            {
                return NotFound();
            }

            db.Dominios.Remove(dominio);
            db.SaveChanges();

            return Ok(dominio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DominioExists(int id)
        {
            return db.Dominios.Count(e => e.IdDominio == id) > 0;
        }
    }
}
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
using API_Quiniela_Mundial.Models;

namespace API_Quiniela_Mundial.Controllers
{
    public class LigasController : ApiController
    {
        private BDD_Quiniela_Mundial db = new BDD_Quiniela_Mundial();

        // GET: api/Ligas
        public IQueryable<Liga> GetLiga()
        {
            return db.Liga;
        }

        // GET: api/Ligas/5
        [ResponseType(typeof(Liga))]
        public IHttpActionResult GetLiga(string id)
        {
            Liga liga = db.Liga.Find(id);
            if (liga == null)
            {
                return NotFound();
            }

            return Ok(liga);
        }

        // PUT: api/Ligas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLiga(string id, Liga liga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != liga.Id_liga)
            {
                return BadRequest();
            }

            db.Entry(liga).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LigaExists(id))
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

        // POST: api/Ligas
        [ResponseType(typeof(Liga))]
        public IHttpActionResult PostLiga(Liga liga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Liga.Add(liga);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LigaExists(liga.Id_liga))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = liga.Id_liga }, liga);
        }

        // DELETE: api/Ligas/5
        [ResponseType(typeof(Liga))]
        public IHttpActionResult DeleteLiga(string id)
        {
            Liga liga = db.Liga.Find(id);
            if (liga == null)
            {
                return NotFound();
            }

            db.Liga.Remove(liga);
            db.SaveChanges();

            return Ok(liga);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LigaExists(string id)
        {
            return db.Liga.Count(e => e.Id_liga == id) > 0;
        }
    }
}
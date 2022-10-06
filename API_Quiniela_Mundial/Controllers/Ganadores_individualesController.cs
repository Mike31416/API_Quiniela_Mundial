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
    public class Ganadores_individualesController : ApiController
    {
        private BDD_Quiniela_Mundial db = new BDD_Quiniela_Mundial();

        // GET: api/Ganadores_individuales
        public IQueryable<Ganadores_individuales> GetGanadores_individuales()
        {
            return db.Ganadores_individuales;
        }

        // GET: api/Ganadores_individuales/5
        [ResponseType(typeof(Ganadores_individuales))]
        public IHttpActionResult GetGanadores_individuales(string id)
        {
            Ganadores_individuales ganadores_individuales = db.Ganadores_individuales.Find(id);
            if (ganadores_individuales == null)
            {
                return NotFound();
            }

            return Ok(ganadores_individuales);
        }

        // PUT: api/Ganadores_individuales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGanadores_individuales(string id, Ganadores_individuales ganadores_individuales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ganadores_individuales.Id_gan_ind)
            {
                return BadRequest();
            }

            db.Entry(ganadores_individuales).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Ganadores_individualesExists(id))
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

        // POST: api/Ganadores_individuales
        [ResponseType(typeof(Ganadores_individuales))]
        public IHttpActionResult PostGanadores_individuales(Ganadores_individuales ganadores_individuales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ganadores_individuales.Add(ganadores_individuales);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Ganadores_individualesExists(ganadores_individuales.Id_gan_ind))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ganadores_individuales.Id_gan_ind }, ganadores_individuales);
        }

        // DELETE: api/Ganadores_individuales/5
        [ResponseType(typeof(Ganadores_individuales))]
        public IHttpActionResult DeleteGanadores_individuales(string id)
        {
            Ganadores_individuales ganadores_individuales = db.Ganadores_individuales.Find(id);
            if (ganadores_individuales == null)
            {
                return NotFound();
            }

            db.Ganadores_individuales.Remove(ganadores_individuales);
            db.SaveChanges();

            return Ok(ganadores_individuales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Ganadores_individualesExists(string id)
        {
            return db.Ganadores_individuales.Count(e => e.Id_gan_ind == id) > 0;
        }
    }
}
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
    public class EstadiosController : ApiController
    {
        private BDD_Quiniela_Mundial db = new BDD_Quiniela_Mundial();

        // GET: api/Estadios
        public IQueryable<Estadio> GetEstadio()
        {
            return db.Estadio;
        }

        // GET: api/Estadios/5
        [ResponseType(typeof(Estadio))]
        public IHttpActionResult GetEstadio(string id)
        {
            Estadio estadio = db.Estadio.Find(id);
            if (estadio == null)
            {
                return NotFound();
            }

            return Ok(estadio);
        }

        // PUT: api/Estadios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstadio(string id, Estadio estadio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estadio.Id_estadio)
            {
                return BadRequest();
            }

            db.Entry(estadio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadioExists(id))
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

        // POST: api/Estadios
        [ResponseType(typeof(Estadio))]
        public IHttpActionResult PostEstadio(Estadio estadio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Estadio.Add(estadio);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EstadioExists(estadio.Id_estadio))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = estadio.Id_estadio }, estadio);
        }

        // DELETE: api/Estadios/5
        [ResponseType(typeof(Estadio))]
        public IHttpActionResult DeleteEstadio(string id)
        {
            Estadio estadio = db.Estadio.Find(id);
            if (estadio == null)
            {
                return NotFound();
            }

            db.Estadio.Remove(estadio);
            db.SaveChanges();

            return Ok(estadio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstadioExists(string id)
        {
            return db.Estadio.Count(e => e.Id_estadio == id) > 0;
        }
    }
}
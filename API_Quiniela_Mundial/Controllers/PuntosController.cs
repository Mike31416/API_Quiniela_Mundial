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
    public class PuntosController : ApiController
    {
        private BDD_Quiniela_Mundial db = new BDD_Quiniela_Mundial();

        // GET: api/Puntos
        public IQueryable<Puntos> GetPuntos()
        {
            return db.Puntos;
        }

        // GET: api/Puntos/5
        [ResponseType(typeof(Puntos))]
        public IHttpActionResult GetPuntos(string id)
        {
            Puntos puntos = db.Puntos.Find(id);
            if (puntos == null)
            {
                return NotFound();
            }

            return Ok(puntos);
        }

        // PUT: api/Puntos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPuntos(string id, Puntos puntos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != puntos.Id_puntos)
            {
                return BadRequest();
            }

            db.Entry(puntos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuntosExists(id))
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

        // POST: api/Puntos
        [ResponseType(typeof(Puntos))]
        public IHttpActionResult PostPuntos(Puntos puntos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Puntos.Add(puntos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PuntosExists(puntos.Id_puntos))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = puntos.Id_puntos }, puntos);
        }

        // DELETE: api/Puntos/5
        [ResponseType(typeof(Puntos))]
        public IHttpActionResult DeletePuntos(string id)
        {
            Puntos puntos = db.Puntos.Find(id);
            if (puntos == null)
            {
                return NotFound();
            }

            db.Puntos.Remove(puntos);
            db.SaveChanges();

            return Ok(puntos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PuntosExists(string id)
        {
            return db.Puntos.Count(e => e.Id_puntos == id) > 0;
        }
    }
}
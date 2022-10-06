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
    public class Nombre_distintivoController : ApiController
    {
        private BDD_Quiniela_Mundial db = new BDD_Quiniela_Mundial();

        // GET: api/Nombre_distintivo
        public IQueryable<Nombre_distintivo> GetNombre_distintivo()
        {
            return db.Nombre_distintivo;
        }

        // GET: api/Nombre_distintivo/5
        [ResponseType(typeof(Nombre_distintivo))]
        public IHttpActionResult GetNombre_distintivo(string id)
        {
            Nombre_distintivo nombre_distintivo = db.Nombre_distintivo.Find(id);
            if (nombre_distintivo == null)
            {
                return NotFound();
            }

            return Ok(nombre_distintivo);
        }

        // PUT: api/Nombre_distintivo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNombre_distintivo(string id, Nombre_distintivo nombre_distintivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nombre_distintivo.Id_nom_distintivo)
            {
                return BadRequest();
            }

            db.Entry(nombre_distintivo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Nombre_distintivoExists(id))
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

        // POST: api/Nombre_distintivo
        [ResponseType(typeof(Nombre_distintivo))]
        public IHttpActionResult PostNombre_distintivo(Nombre_distintivo nombre_distintivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Nombre_distintivo.Add(nombre_distintivo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Nombre_distintivoExists(nombre_distintivo.Id_nom_distintivo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nombre_distintivo.Id_nom_distintivo }, nombre_distintivo);
        }

        // DELETE: api/Nombre_distintivo/5
        [ResponseType(typeof(Nombre_distintivo))]
        public IHttpActionResult DeleteNombre_distintivo(string id)
        {
            Nombre_distintivo nombre_distintivo = db.Nombre_distintivo.Find(id);
            if (nombre_distintivo == null)
            {
                return NotFound();
            }

            db.Nombre_distintivo.Remove(nombre_distintivo);
            db.SaveChanges();

            return Ok(nombre_distintivo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Nombre_distintivoExists(string id)
        {
            return db.Nombre_distintivo.Count(e => e.Id_nom_distintivo == id) > 0;
        }
    }
}
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
    public class ClasificacionsController : ApiController
    {
        private BDD_Quiniela_Mundial db = new BDD_Quiniela_Mundial();

        // GET: api/Clasificacions
        public IQueryable<Clasificacion> GetClasificacion()
        {
            return db.Clasificacion;
        }

        // GET: api/Clasificacions/5
        [ResponseType(typeof(Clasificacion))]
        public IHttpActionResult GetClasificacion(string id)
        {
            Clasificacion clasificacion = db.Clasificacion.Find(id);
            if (clasificacion == null)
            {
                return NotFound();
            }

            return Ok(clasificacion);
        }

        // PUT: api/Clasificacions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClasificacion(string id, Clasificacion clasificacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clasificacion.Id_clasificacion)
            {
                return BadRequest();
            }

            db.Entry(clasificacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClasificacionExists(id))
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

        // POST: api/Clasificacions
        [ResponseType(typeof(Clasificacion))]
        public IHttpActionResult PostClasificacion(Clasificacion clasificacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clasificacion.Add(clasificacion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ClasificacionExists(clasificacion.Id_clasificacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = clasificacion.Id_clasificacion }, clasificacion);
        }

        // DELETE: api/Clasificacions/5
        [ResponseType(typeof(Clasificacion))]
        public IHttpActionResult DeleteClasificacion(string id)
        {
            Clasificacion clasificacion = db.Clasificacion.Find(id);
            if (clasificacion == null)
            {
                return NotFound();
            }

            db.Clasificacion.Remove(clasificacion);
            db.SaveChanges();

            return Ok(clasificacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClasificacionExists(string id)
        {
            return db.Clasificacion.Count(e => e.Id_clasificacion == id) > 0;
        }
    }
}
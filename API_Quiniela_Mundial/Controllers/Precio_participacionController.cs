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
    public class Precio_participacionController : ApiController
    {
        private BDD_Quiniela_Mundial db = new BDD_Quiniela_Mundial();

        // GET: api/Precio_participacion
        public IQueryable<Precio_participacion> GetPrecio_participacion()
        {
            return db.Precio_participacion;
        }

        // GET: api/Precio_participacion/5
        [ResponseType(typeof(Precio_participacion))]
        public IHttpActionResult GetPrecio_participacion(string id)
        {
            Precio_participacion precio_participacion = db.Precio_participacion.Find(id);
            if (precio_participacion == null)
            {
                return NotFound();
            }

            return Ok(precio_participacion);
        }

        // PUT: api/Precio_participacion/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrecio_participacion(string id, Precio_participacion precio_participacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != precio_participacion.Id_participacion)
            {
                return BadRequest();
            }

            db.Entry(precio_participacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Precio_participacionExists(id))
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

        // POST: api/Precio_participacion
        [ResponseType(typeof(Precio_participacion))]
        public IHttpActionResult PostPrecio_participacion(Precio_participacion precio_participacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Precio_participacion.Add(precio_participacion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Precio_participacionExists(precio_participacion.Id_participacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = precio_participacion.Id_participacion }, precio_participacion);
        }

        // DELETE: api/Precio_participacion/5
        [ResponseType(typeof(Precio_participacion))]
        public IHttpActionResult DeletePrecio_participacion(string id)
        {
            Precio_participacion precio_participacion = db.Precio_participacion.Find(id);
            if (precio_participacion == null)
            {
                return NotFound();
            }

            db.Precio_participacion.Remove(precio_participacion);
            db.SaveChanges();

            return Ok(precio_participacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Precio_participacionExists(string id)
        {
            return db.Precio_participacion.Count(e => e.Id_participacion == id) > 0;
        }
    }
}
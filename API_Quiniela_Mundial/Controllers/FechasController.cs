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
    public class FechasController : ApiController
    {
        private BDD_Quiniela_Mundial db = new BDD_Quiniela_Mundial();

        // GET: api/Fechas
        public IQueryable<Fecha> GetFecha()
        {
            return db.Fecha;
        }

        // GET: api/Fechas/5
        [ResponseType(typeof(Fecha))]
        public IHttpActionResult GetFecha(string id)
        {
            Fecha fecha = db.Fecha.Find(id);
            if (fecha == null)
            {
                return NotFound();
            }

            return Ok(fecha);
        }

        // PUT: api/Fechas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFecha(string id, Fecha fecha)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fecha.Id_equipo)
            {
                return BadRequest();
            }

            db.Entry(fecha).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FechaExists(id))
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

        // POST: api/Fechas
        [ResponseType(typeof(Fecha))]
        public IHttpActionResult PostFecha(Fecha fecha)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fecha.Add(fecha);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FechaExists(fecha.Id_equipo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = fecha.Id_equipo }, fecha);
        }

        // DELETE: api/Fechas/5
        [ResponseType(typeof(Fecha))]
        public IHttpActionResult DeleteFecha(string id)
        {
            Fecha fecha = db.Fecha.Find(id);
            if (fecha == null)
            {
                return NotFound();
            }

            db.Fecha.Remove(fecha);
            db.SaveChanges();

            return Ok(fecha);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FechaExists(string id)
        {
            return db.Fecha.Count(e => e.Id_equipo == id) > 0;
        }
    }
}
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
    public class SedesController : ApiController
    {
        private BDD_Quiniela_Mundial db = new BDD_Quiniela_Mundial();

        // GET: api/Sedes
        public IQueryable<Sede> GetSede()
        {
            return db.Sede;
        }

        // GET: api/Sedes/5
        [ResponseType(typeof(Sede))]
        public IHttpActionResult GetSede(string id)
        {
            Sede sede = db.Sede.Find(id);
            if (sede == null)
            {
                return NotFound();
            }

            return Ok(sede);
        }

        // PUT: api/Sedes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSede(string id, Sede sede)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sede.Id_sede)
            {
                return BadRequest();
            }

            db.Entry(sede).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SedeExists(id))
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

        // POST: api/Sedes
        [ResponseType(typeof(Sede))]
        public IHttpActionResult PostSede(Sede sede)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sede.Add(sede);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SedeExists(sede.Id_sede))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sede.Id_sede }, sede);
        }

        // DELETE: api/Sedes/5
        [ResponseType(typeof(Sede))]
        public IHttpActionResult DeleteSede(string id)
        {
            Sede sede = db.Sede.Find(id);
            if (sede == null)
            {
                return NotFound();
            }

            db.Sede.Remove(sede);
            db.SaveChanges();

            return Ok(sede);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SedeExists(string id)
        {
            return db.Sede.Count(e => e.Id_sede == id) > 0;
        }
    }
}
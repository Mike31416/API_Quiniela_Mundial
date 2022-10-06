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
    public class Tipo_ligaController : ApiController
    {
        private BDD_Quiniela_Mundial db = new BDD_Quiniela_Mundial();

        // GET: api/Tipo_liga
        public IQueryable<Tipo_liga> GetTipo_liga()
        {
            return db.Tipo_liga;
        }

        // GET: api/Tipo_liga/5
        [ResponseType(typeof(Tipo_liga))]
        public IHttpActionResult GetTipo_liga(string id)
        {
            Tipo_liga tipo_liga = db.Tipo_liga.Find(id);
            if (tipo_liga == null)
            {
                return NotFound();
            }

            return Ok(tipo_liga);
        }

        // PUT: api/Tipo_liga/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipo_liga(string id, Tipo_liga tipo_liga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipo_liga.Id_tipo)
            {
                return BadRequest();
            }

            db.Entry(tipo_liga).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tipo_ligaExists(id))
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

        // POST: api/Tipo_liga
        [ResponseType(typeof(Tipo_liga))]
        public IHttpActionResult PostTipo_liga(Tipo_liga tipo_liga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tipo_liga.Add(tipo_liga);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Tipo_ligaExists(tipo_liga.Id_tipo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tipo_liga.Id_tipo }, tipo_liga);
        }

        // DELETE: api/Tipo_liga/5
        [ResponseType(typeof(Tipo_liga))]
        public IHttpActionResult DeleteTipo_liga(string id)
        {
            Tipo_liga tipo_liga = db.Tipo_liga.Find(id);
            if (tipo_liga == null)
            {
                return NotFound();
            }

            db.Tipo_liga.Remove(tipo_liga);
            db.SaveChanges();

            return Ok(tipo_liga);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tipo_ligaExists(string id)
        {
            return db.Tipo_liga.Count(e => e.Id_tipo == id) > 0;
        }
    }
}
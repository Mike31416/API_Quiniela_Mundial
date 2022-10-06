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
    public class PartidoesController : ApiController
    {
        private BDD_Quiniela_Mundial db = new BDD_Quiniela_Mundial();

        // GET: api/Partidoes
        public IQueryable<Partido> GetPartido()
        {
            return db.Partido;
        }

        // GET: api/Partidoes/5
        [ResponseType(typeof(Partido))]
        public IHttpActionResult GetPartido(string id)
        {
            Partido partido = db.Partido.Find(id);
            if (partido == null)
            {
                return NotFound();
            }

            return Ok(partido);
        }

        // PUT: api/Partidoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPartido(string id, Partido partido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partido.Id_partido)
            {
                return BadRequest();
            }

            db.Entry(partido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartidoExists(id))
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

        // POST: api/Partidoes
        [ResponseType(typeof(Partido))]
        public IHttpActionResult PostPartido(Partido partido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Partido.Add(partido);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PartidoExists(partido.Id_partido))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = partido.Id_partido }, partido);
        }

        // DELETE: api/Partidoes/5
        [ResponseType(typeof(Partido))]
        public IHttpActionResult DeletePartido(string id)
        {
            Partido partido = db.Partido.Find(id);
            if (partido == null)
            {
                return NotFound();
            }

            db.Partido.Remove(partido);
            db.SaveChanges();

            return Ok(partido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PartidoExists(string id)
        {
            return db.Partido.Count(e => e.Id_partido == id) > 0;
        }
    }
}
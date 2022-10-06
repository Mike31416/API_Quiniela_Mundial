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
    public class GanadorsController : ApiController
    {
        private BDD_Quiniela_Mundial db = new BDD_Quiniela_Mundial();

        // GET: api/Ganadors
        public IQueryable<Ganador> GetGanador()
        {
            return db.Ganador;
        }

        // GET: api/Ganadors/5
        [ResponseType(typeof(Ganador))]
        public IHttpActionResult GetGanador(string id)
        {
            Ganador ganador = db.Ganador.Find(id);
            if (ganador == null)
            {
                return NotFound();
            }

            return Ok(ganador);
        }

        // PUT: api/Ganadors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGanador(string id, Ganador ganador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ganador.Id_ganador)
            {
                return BadRequest();
            }

            db.Entry(ganador).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GanadorExists(id))
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

        // POST: api/Ganadors
        [ResponseType(typeof(Ganador))]
        public IHttpActionResult PostGanador(Ganador ganador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ganador.Add(ganador);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GanadorExists(ganador.Id_ganador))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ganador.Id_ganador }, ganador);
        }

        // DELETE: api/Ganadors/5
        [ResponseType(typeof(Ganador))]
        public IHttpActionResult DeleteGanador(string id)
        {
            Ganador ganador = db.Ganador.Find(id);
            if (ganador == null)
            {
                return NotFound();
            }

            db.Ganador.Remove(ganador);
            db.SaveChanges();

            return Ok(ganador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GanadorExists(string id)
        {
            return db.Ganador.Count(e => e.Id_ganador == id) > 0;
        }
    }
}
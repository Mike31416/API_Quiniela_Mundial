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
    public class Liga_ganadorController : ApiController
    {
        private BDD_Quiniela_Mundial db = new BDD_Quiniela_Mundial();

        // GET: api/Liga_ganador
        public IQueryable<Liga_ganador> GetLiga_ganador()
        {
            return db.Liga_ganador;
        }

        // GET: api/Liga_ganador/5
        [ResponseType(typeof(Liga_ganador))]
        public IHttpActionResult GetLiga_ganador(string id)
        {
            Liga_ganador liga_ganador = db.Liga_ganador.Find(id);
            if (liga_ganador == null)
            {
                return NotFound();
            }

            return Ok(liga_ganador);
        }

        // PUT: api/Liga_ganador/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLiga_ganador(string id, Liga_ganador liga_ganador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != liga_ganador.Id_liga_gan)
            {
                return BadRequest();
            }

            db.Entry(liga_ganador).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Liga_ganadorExists(id))
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

        // POST: api/Liga_ganador
        [ResponseType(typeof(Liga_ganador))]
        public IHttpActionResult PostLiga_ganador(Liga_ganador liga_ganador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Liga_ganador.Add(liga_ganador);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Liga_ganadorExists(liga_ganador.Id_liga_gan))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = liga_ganador.Id_liga_gan }, liga_ganador);
        }

        // DELETE: api/Liga_ganador/5
        [ResponseType(typeof(Liga_ganador))]
        public IHttpActionResult DeleteLiga_ganador(string id)
        {
            Liga_ganador liga_ganador = db.Liga_ganador.Find(id);
            if (liga_ganador == null)
            {
                return NotFound();
            }

            db.Liga_ganador.Remove(liga_ganador);
            db.SaveChanges();

            return Ok(liga_ganador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Liga_ganadorExists(string id)
        {
            return db.Liga_ganador.Count(e => e.Id_liga_gan == id) > 0;
        }
    }
}
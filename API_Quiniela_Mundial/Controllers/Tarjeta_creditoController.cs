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
    public class Tarjeta_creditoController : ApiController
    {
        private BDD_Quiniela_Mundial db = new BDD_Quiniela_Mundial();

        // GET: api/Tarjeta_credito
        public IQueryable<Tarjeta_credito> GetTarjeta_credito()
        {
            return db.Tarjeta_credito;
        }

        // GET: api/Tarjeta_credito/5
        [ResponseType(typeof(Tarjeta_credito))]
        public IHttpActionResult GetTarjeta_credito(string id)
        {
            Tarjeta_credito tarjeta_credito = db.Tarjeta_credito.Find(id);
            if (tarjeta_credito == null)
            {
                return NotFound();
            }

            return Ok(tarjeta_credito);
        }

        // PUT: api/Tarjeta_credito/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTarjeta_credito(string id, Tarjeta_credito tarjeta_credito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tarjeta_credito.id_tarjera)
            {
                return BadRequest();
            }

            db.Entry(tarjeta_credito).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tarjeta_creditoExists(id))
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

        // POST: api/Tarjeta_credito
        [ResponseType(typeof(Tarjeta_credito))]
        public IHttpActionResult PostTarjeta_credito(Tarjeta_credito tarjeta_credito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tarjeta_credito.Add(tarjeta_credito);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Tarjeta_creditoExists(tarjeta_credito.id_tarjera))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tarjeta_credito.id_tarjera }, tarjeta_credito);
        }

        // DELETE: api/Tarjeta_credito/5
        [ResponseType(typeof(Tarjeta_credito))]
        public IHttpActionResult DeleteTarjeta_credito(string id)
        {
            Tarjeta_credito tarjeta_credito = db.Tarjeta_credito.Find(id);
            if (tarjeta_credito == null)
            {
                return NotFound();
            }

            db.Tarjeta_credito.Remove(tarjeta_credito);
            db.SaveChanges();

            return Ok(tarjeta_credito);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tarjeta_creditoExists(string id)
        {
            return db.Tarjeta_credito.Count(e => e.id_tarjera == id) > 0;
        }
    }
}
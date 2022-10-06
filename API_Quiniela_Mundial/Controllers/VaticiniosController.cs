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
    public class VaticiniosController : ApiController
    {
        private BDD_Quiniela_Mundial db = new BDD_Quiniela_Mundial();

        // GET: api/Vaticinios
        public IQueryable<Vaticinio> GetVaticinio()
        {
            return db.Vaticinio;
        }

        // GET: api/Vaticinios/5
        [ResponseType(typeof(Vaticinio))]
        public IHttpActionResult GetVaticinio(string id)
        {
            Vaticinio vaticinio = db.Vaticinio.Find(id);
            if (vaticinio == null)
            {
                return NotFound();
            }

            return Ok(vaticinio);
        }

        // PUT: api/Vaticinios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVaticinio(string id, Vaticinio vaticinio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vaticinio.id_vaticinio)
            {
                return BadRequest();
            }

            db.Entry(vaticinio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaticinioExists(id))
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

        // POST: api/Vaticinios
        [ResponseType(typeof(Vaticinio))]
        public IHttpActionResult PostVaticinio(Vaticinio vaticinio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vaticinio.Add(vaticinio);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VaticinioExists(vaticinio.id_vaticinio))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vaticinio.id_vaticinio }, vaticinio);
        }

        // DELETE: api/Vaticinios/5
        [ResponseType(typeof(Vaticinio))]
        public IHttpActionResult DeleteVaticinio(string id)
        {
            Vaticinio vaticinio = db.Vaticinio.Find(id);
            if (vaticinio == null)
            {
                return NotFound();
            }

            db.Vaticinio.Remove(vaticinio);
            db.SaveChanges();

            return Ok(vaticinio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VaticinioExists(string id)
        {
            return db.Vaticinio.Count(e => e.id_vaticinio == id) > 0;
        }
    }
}
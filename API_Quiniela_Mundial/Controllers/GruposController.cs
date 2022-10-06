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
    public class GruposController : ApiController
    {
        private BDD_Quiniela_Mundial db = new BDD_Quiniela_Mundial();

        // GET: api/Grupos
        public IQueryable<Grupos> GetGrupos()
        {
            return db.Grupos;
        }

        // GET: api/Grupos/5
        [ResponseType(typeof(Grupos))]
        public IHttpActionResult GetGrupos(string id)
        {
            Grupos grupos = db.Grupos.Find(id);
            if (grupos == null)
            {
                return NotFound();
            }

            return Ok(grupos);
        }

        // PUT: api/Grupos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGrupos(string id, Grupos grupos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grupos.Id_grupos)
            {
                return BadRequest();
            }

            db.Entry(grupos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GruposExists(id))
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

        // POST: api/Grupos
        [ResponseType(typeof(Grupos))]
        public IHttpActionResult PostGrupos(Grupos grupos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Grupos.Add(grupos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GruposExists(grupos.Id_grupos))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = grupos.Id_grupos }, grupos);
        }

        // DELETE: api/Grupos/5
        [ResponseType(typeof(Grupos))]
        public IHttpActionResult DeleteGrupos(string id)
        {
            Grupos grupos = db.Grupos.Find(id);
            if (grupos == null)
            {
                return NotFound();
            }

            db.Grupos.Remove(grupos);
            db.SaveChanges();

            return Ok(grupos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GruposExists(string id)
        {
            return db.Grupos.Count(e => e.Id_grupos == id) > 0;
        }
    }
}
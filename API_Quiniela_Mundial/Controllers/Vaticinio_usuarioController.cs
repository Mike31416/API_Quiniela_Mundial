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
    public class Vaticinio_usuarioController : ApiController
    {
        private BDD_Quiniela_Mundial db = new BDD_Quiniela_Mundial();

        // GET: api/Vaticinio_usuario
        public IQueryable<Vaticinio_usuario> GetVaticinio_usuario()
        {
            return db.Vaticinio_usuario;
        }

        // GET: api/Vaticinio_usuario/5
        [ResponseType(typeof(Vaticinio_usuario))]
        public IHttpActionResult GetVaticinio_usuario(string id)
        {
            Vaticinio_usuario vaticinio_usuario = db.Vaticinio_usuario.Find(id);
            if (vaticinio_usuario == null)
            {
                return NotFound();
            }

            return Ok(vaticinio_usuario);
        }

        // PUT: api/Vaticinio_usuario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVaticinio_usuario(string id, Vaticinio_usuario vaticinio_usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vaticinio_usuario.Id_partido)
            {
                return BadRequest();
            }

            db.Entry(vaticinio_usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Vaticinio_usuarioExists(id))
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

        // POST: api/Vaticinio_usuario
        [ResponseType(typeof(Vaticinio_usuario))]
        public IHttpActionResult PostVaticinio_usuario(Vaticinio_usuario vaticinio_usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vaticinio_usuario.Add(vaticinio_usuario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Vaticinio_usuarioExists(vaticinio_usuario.Id_partido))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vaticinio_usuario.Id_partido }, vaticinio_usuario);
        }

        // DELETE: api/Vaticinio_usuario/5
        [ResponseType(typeof(Vaticinio_usuario))]
        public IHttpActionResult DeleteVaticinio_usuario(string id)
        {
            Vaticinio_usuario vaticinio_usuario = db.Vaticinio_usuario.Find(id);
            if (vaticinio_usuario == null)
            {
                return NotFound();
            }

            db.Vaticinio_usuario.Remove(vaticinio_usuario);
            db.SaveChanges();

            return Ok(vaticinio_usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Vaticinio_usuarioExists(string id)
        {
            return db.Vaticinio_usuario.Count(e => e.Id_partido == id) > 0;
        }
    }
}
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
    public class Tipo_rolesController : ApiController
    {
        private BDD_Quiniela_Mundial db = new BDD_Quiniela_Mundial();

        // GET: api/Tipo_roles
        public IQueryable<Tipo_roles> GetTipo_roles()
        {
            return db.Tipo_roles;
        }

        // GET: api/Tipo_roles/5
        [ResponseType(typeof(Tipo_roles))]
        public IHttpActionResult GetTipo_roles(string id)
        {
            Tipo_roles tipo_roles = db.Tipo_roles.Find(id);
            if (tipo_roles == null)
            {
                return NotFound();
            }

            return Ok(tipo_roles);
        }

        // PUT: api/Tipo_roles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipo_roles(string id, Tipo_roles tipo_roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipo_roles.Id_tipoRoles)
            {
                return BadRequest();
            }

            db.Entry(tipo_roles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tipo_rolesExists(id))
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

        // POST: api/Tipo_roles
        [ResponseType(typeof(Tipo_roles))]
        public IHttpActionResult PostTipo_roles(Tipo_roles tipo_roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tipo_roles.Add(tipo_roles);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Tipo_rolesExists(tipo_roles.Id_tipoRoles))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tipo_roles.Id_tipoRoles }, tipo_roles);
        }

        // DELETE: api/Tipo_roles/5
        [ResponseType(typeof(Tipo_roles))]
        public IHttpActionResult DeleteTipo_roles(string id)
        {
            Tipo_roles tipo_roles = db.Tipo_roles.Find(id);
            if (tipo_roles == null)
            {
                return NotFound();
            }

            db.Tipo_roles.Remove(tipo_roles);
            db.SaveChanges();

            return Ok(tipo_roles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tipo_rolesExists(string id)
        {
            return db.Tipo_roles.Count(e => e.Id_tipoRoles == id) > 0;
        }
    }
}
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
    public class MundialsController : ApiController
    {
        private BDD_Quiniela_Mundial db = new BDD_Quiniela_Mundial();

        // GET: api/Mundials
        public IQueryable<Mundial> GetMundial()
        {
            return db.Mundial;
        }

        // GET: api/Mundials/5
        [ResponseType(typeof(Mundial))]
        public IHttpActionResult GetMundial(string id)
        {
            Mundial mundial = db.Mundial.Find(id);
            if (mundial == null)
            {
                return NotFound();
            }

            return Ok(mundial);
        }

        // PUT: api/Mundials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMundial(string id, Mundial mundial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mundial.Id_mundial)
            {
                return BadRequest();
            }

            db.Entry(mundial).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MundialExists(id))
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

        // POST: api/Mundials
        [ResponseType(typeof(Mundial))]
        public IHttpActionResult PostMundial(Mundial mundial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mundial.Add(mundial);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MundialExists(mundial.Id_mundial))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mundial.Id_mundial }, mundial);
        }

        // DELETE: api/Mundials/5
        [ResponseType(typeof(Mundial))]
        public IHttpActionResult DeleteMundial(string id)
        {
            Mundial mundial = db.Mundial.Find(id);
            if (mundial == null)
            {
                return NotFound();
            }

            db.Mundial.Remove(mundial);
            db.SaveChanges();

            return Ok(mundial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MundialExists(string id)
        {
            return db.Mundial.Count(e => e.Id_mundial == id) > 0;
        }
    }
}
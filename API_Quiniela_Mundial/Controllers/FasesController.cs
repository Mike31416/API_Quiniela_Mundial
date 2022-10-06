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
    public class FasesController : ApiController
    {
        private BDD_Quiniela_Mundial db = new BDD_Quiniela_Mundial();

        // GET: api/Fases
        public IQueryable<Fase> GetFase()
        {
            return db.Fase;
        }

        // GET: api/Fases/5
        [ResponseType(typeof(Fase))]
        public IHttpActionResult GetFase(string id)
        {
            Fase fase = db.Fase.Find(id);
            if (fase == null)
            {
                return NotFound();
            }

            return Ok(fase);
        }

        // PUT: api/Fases/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFase(string id, Fase fase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fase.Id_fase)
            {
                return BadRequest();
            }

            db.Entry(fase).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaseExists(id))
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

        // POST: api/Fases
        [ResponseType(typeof(Fase))]
        public IHttpActionResult PostFase(Fase fase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fase.Add(fase);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FaseExists(fase.Id_fase))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = fase.Id_fase }, fase);
        }

        // DELETE: api/Fases/5
        [ResponseType(typeof(Fase))]
        public IHttpActionResult DeleteFase(string id)
        {
            Fase fase = db.Fase.Find(id);
            if (fase == null)
            {
                return NotFound();
            }

            db.Fase.Remove(fase);
            db.SaveChanges();

            return Ok(fase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FaseExists(string id)
        {
            return db.Fase.Count(e => e.Id_fase == id) > 0;
        }
    }
}
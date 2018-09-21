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
using Projet_Web.Data;
using Projet_Web.Models;

namespace Projet_Web.Controllers
{
    public class AssurancesController : ApiController
    {
        private BoVoyageDbContext db = new BoVoyageDbContext();

        // GET: api/Assurances
        public IQueryable<Assurance> GetAssurances()
        {
            return db.Assurances.Include(x => x.DossierReservations);
        }

        // GET: api/Assurances/5
        [ResponseType(typeof(Assurance))]
        public IHttpActionResult GetAssurance(int id)
        {
            Assurance assurance = db.Assurances.Include(x => x.DossierReservations)
                .SingleOrDefault(x => x.ID == id);
            if (assurance == null)
            {
                return NotFound();
            }

            return Ok(assurance);
        }

        // PUT: api/Assurances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssurance(int id, Assurance assurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assurance.ID)
            {
                return BadRequest();
            }

            db.Entry(assurance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssuranceExists(id))
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

        // POST: api/Assurances
        [ResponseType(typeof(Assurance))]
        public IHttpActionResult PostAssurance(Assurance assurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Assurances.Add(assurance);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = assurance.ID }, assurance);
        }

        // DELETE: api/Assurances/5
        [Route("api/Assurances/{id}")]
        [ResponseType(typeof(Assurance))]
        public IHttpActionResult DeleteAssurance(int id)
        {
            Assurance assurance = db.Assurances.Find(id);
            if (assurance == null)
            {
                return NotFound();
            }

            db.Assurances.Remove(assurance);
            db.SaveChanges();

            return Ok(assurance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssuranceExists(int id)
        {
            return db.Assurances.Count(e => e.ID == id) > 0;
        }
    }
}
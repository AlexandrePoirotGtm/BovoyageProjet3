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
    public class ClientsController : ApiController
    {
        private BoVoyageDbContext db = new BoVoyageDbContext();

        // GET: api/Clients
        public IQueryable<Client> GetClients()
        {
            return db.Clients.Include(x => x.DossiersReservation);
        }

        // GET: api/Clients/5
        [Route("api/Clients/{id:int}")]
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(int id)
        {
            Client client = db.Clients.Include(x => x.DossiersReservation)
                                       .SingleOrDefault(x => x.ID == id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // GET: api/Clients/Search
        [ResponseType(typeof(Client))]
        [Route("api/Clients/{Filter}")]
        [HttpGet]
        public IQueryable<Client> GetClientsFilter(string Filter)
        {
            //return db.Clients.Include(x => x.Nom).Where(x => x.Nom.Contains(Filter));
            return db.Clients.Where(x => x.Nom.Contains(Filter));
        }

        // PUT: api/Clients/5
        [Route("api/Clients/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.ID)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client.ID }, client);
        }

        // DELETE: api/Clients/5
        [Route("api/Clients/{id}")]
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }             
            db.Clients.Remove(client);
            try
            {
                db.SaveChanges();
            }
            catch
            {
                return (BadRequest("Le client a encore des reservations"));
            }

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Clients.Count(e => e.ID == id) > 0;
        }
    }
}
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
using PrimerIndividual;
using PrimerIndividual.Models;
using System.Web.Http.Cors;

namespace PrimerIndividual.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class PeliculasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Peliculas
        public IQueryable<Pelicula> GetPeliculas()
        {
            return db.Peliculas;
        }

        // GET: api/Peliculas/5
        [ResponseType(typeof(Pelicula))]
        public IHttpActionResult GetPelicula(long id)
        {
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return Ok(pelicula);
        }

        // PUT: api/Peliculas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPelicula(long id, Pelicula pelicula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pelicula.Id)
            {
                return BadRequest();
            }

            db.Entry(pelicula).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeliculaExists(id))
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

        // POST: api/Peliculas
        [ResponseType(typeof(Pelicula))]
        public IHttpActionResult PostPelicula(Pelicula pelicula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Peliculas.Add(pelicula);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pelicula.Id }, pelicula);
        }

        // DELETE: api/Peliculas/5
        [ResponseType(typeof(Pelicula))]
        public IHttpActionResult DeletePelicula(long id)
        {
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            db.Peliculas.Remove(pelicula);
            db.SaveChanges();

            return Ok(pelicula);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PeliculaExists(long id)
        {
            return db.Peliculas.Count(e => e.Id == id) > 0;
        }
    }
}
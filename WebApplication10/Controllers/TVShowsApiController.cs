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
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class TVShowsApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TVShowsApi
        public IQueryable<TVShow> GetTVShows()
        {
            return db.TVShows;
        }

        // GET: api/TVShowsApi/5
        [ResponseType(typeof(TVShowDTO))]
        public IHttpActionResult GetTVShow(int id)
        {
            TVShowDTO tVShow = db.TVShows.Where(z => z.Id == id).Select(z => new TVShowDTO
            {
                Id = z.Id,
                Rating = z.Rating,
                DownloadURL = z.DownloadURL,
                Genre = z.Genre,


            }).FirstOrDefault() ;
            if (tVShow == null)
            {
                return NotFound();
            }

            return Ok(tVShow);
        }

        // PUT: api/TVShowsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTVShow(int id, TVShow tVShow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tVShow.Id)
            {
                return BadRequest();
            }

            db.Entry(tVShow).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TVShowExists(id))
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

        // POST: api/TVShowsApi
        [ResponseType(typeof(TVShow))]
        public IHttpActionResult PostTVShow(TVShow tVShow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TVShows.Add(tVShow);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tVShow.Id }, tVShow);
        }

        // DELETE: api/TVShowsApi/5
        [ResponseType(typeof(TVShow))]
        public IHttpActionResult DeleteTVShow(int id)
        {
            TVShow tVShow = db.TVShows.Find(id);
            if (tVShow == null)
            {
                return NotFound();
            }

            db.TVShows.Remove(tVShow);
            db.SaveChanges();

            return Ok(tVShow);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TVShowExists(int id)
        {
            return db.TVShows.Count(e => e.Id == id) > 0;
        }
    }
}
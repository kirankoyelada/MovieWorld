using ProductsCatalog;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace MovieWorldAPI.Controllers
{
    public class tbl_MoviesController : ApiController
    {
        private MovieWorldEntities db = new MovieWorldEntities();

        // GET: api/tbl_Movies
        public IQueryable<tbl_Movies> Gettbl_Movies()
        {
            return db.tbl_Movies;
        }

        // GET: api/tbl_Movies/5
        [ResponseType(typeof(tbl_Movies))]
        public IHttpActionResult Gettbl_Movies(int id)
        {
            tbl_Movies tbl_Movies = db.tbl_Movies.Find(id);
            if (tbl_Movies == null)
            {
                return NotFound();
            }

            return Ok(tbl_Movies);
        }

        // PUT: api/tbl_Movies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_Movies(int id, tbl_Movies tbl_Movies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Movies.MovieID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Movies).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_MoviesExists(id))
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

        // POST: api/tbl_Movies
        [ResponseType(typeof(tbl_Movies))]
        public IHttpActionResult Posttbl_Movies(tbl_Movies tbl_Movies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Movies.Add(tbl_Movies);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Movies.MovieID }, tbl_Movies);
        }

        // DELETE: api/tbl_Movies/5
        [ResponseType(typeof(tbl_Movies))]
        public IHttpActionResult Deletetbl_Movies(int id)
        {
            tbl_Movies tbl_Movies = db.tbl_Movies.Find(id);
            if (tbl_Movies == null)
            {
                return NotFound();
            }

            db.tbl_Movies.Remove(tbl_Movies);
            db.SaveChanges();

            return Ok(tbl_Movies);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_MoviesExists(int id)
        {
            return db.tbl_Movies.Count(e => e.MovieID == id) > 0;
        }
    }
}
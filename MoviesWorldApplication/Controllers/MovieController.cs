using ProductsCatalog;
using System.Linq;
using System.Web.Mvc;
namespace MoviesWorldApplication.Controllers
{
    public class MovieController : Controller
    {
        MovieWorldEntities objContext = new MovieWorldEntities();
        // GET: Movie
        public ActionResult Index()
        {
            return View(objContext.tbl_Movies.ToList());
        }
        public ActionResult GetMovieCard(int movieID)
        {
            tbl_Movies movie = objContext.tbl_Movies.SingleOrDefault(x => x.MovieID == movieID);
            return View(movie);
        }
    }
}
using MoviesWorldApplication.Models;
using ProductsCatalog;
using System;
using System.Linq;
using System.Web.Mvc;
namespace MoviesWorldApplication.Controllers
{
    public class MovieController : Controller
    {
        MovieWorldEntities objContext = new MovieWorldEntities();
        MovieCustomModel objModel = new MovieCustomModel();
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
        [HttpPost]
        public ActionResult BookMovie(FormCollection movie)
        {
            string tokenID = movie["stripeToken"];
            string moviesID = Request["MovieID"];
            string amount = Request["Price"];
            string result = string.Empty;
            if (!string.IsNullOrEmpty(tokenID))
            {
                result = objModel.chargeCard(tokenID, Convert.ToInt32(amount), "This is movie pay");
            }
            if (!result.Contains("succeeded"))
            {
                return RedirectToAction("errorPage");
            }
            else
                return View("SuccessPage");
        }
        public ActionResult SuccessPage()
        {

            return View();
        }
    }
}
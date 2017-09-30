using ProductsCatalog;
using System.Linq;
using System.Web.Mvc;
namespace MoviesWorldApplication.Controllers
{
    public class AdminController : Controller
    {
        MovieWorldEntities objContext = new MovieWorldEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Display()
        {
            return View(objContext.tbl_Movies.ToList());
        }
        [HttpPost]
        public ActionResult Save(tbl_Movies movie)
        {
            objContext.tbl_Movies.Add(movie);
            int status = objContext.SaveChanges();
            return View(status);
        }
    }
}
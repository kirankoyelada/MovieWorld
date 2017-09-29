using ProductsCatalog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MovieWorldAPI.Controllers
{
    public class MovieWorldController : Controller
    {
        private MovieWorldEntities db = new MovieWorldEntities();
        // GET: MovieWorld
        public ActionResult Index()
        {
            return View(db.tbl_Movies.ToList());
        }
    }
}
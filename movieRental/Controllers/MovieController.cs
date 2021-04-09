using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using movieRental.Models;
using movieRental.ViewModels;

namespace movieRental.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            Movie movie = new Movie() { Name = "Matrix" };

            var customers = new List<Customer>()
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = GetMovies().FirstOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "name";

        //    return Content(String.Format("pageIndex = {0}&sortBy={1}", pageIndex, sortBy));
        //}

        public ActionResult Edit(int id)
        {
            return Content(String.Format("Id = {0}", id));
        }

        [Route("movie/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year +"/"+ month);
        }

        private IEnumerable<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();
            movies.Add(new Movie { Id = 1, Name = "Matrix" });
            movies.Add(new Movie { Id = 2, Name = "Law Abiding Citizen" });

            return movies;
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_DeMann.Models;

namespace Mission06_DeMann.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieDbContext _context;

        public HomeController(MovieDbContext context)
        {
            _context = context;
        }

        // Index method to list movies
        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        // Create method to display the movie creation form
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            // Ensure required fields are filled with default values if missing
            if (string.IsNullOrEmpty(movie.Title))
            {
                movie.Title = "N/A";  // Default value for Title
            }

            if (movie.Year == 0)
            {
                movie.Year = 1888;  // Default value for Year if it's missing
            }

            // Since Edited and CopiedToPlex are non-nullable, no need to check them for null
            // But we ensure they are set to default values if the user doesn't provide them
            if (movie.Edited == null)
            {
                movie.Edited = false;  // Default value for Edited
            }

            if (movie.CopiedToPlex == null)
            {
                movie.CopiedToPlex = false;  // Default value for CopiedToPlex
            }

            // Check if the model is valid before saving
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Return the view with validation errors if the model is not valid
            return View(movie);
        }

        // Edit method to display the movie edit form
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(int id, Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // Delete method to display the movie delete confirmation page
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _context.Movies
                .FirstOrDefault(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _context.Movies.Find(id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}

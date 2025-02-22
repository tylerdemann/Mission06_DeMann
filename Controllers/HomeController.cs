using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_DeMann.Models; // Make sure you're using the correct namespace for your MovieDbContext

namespace Mission06_DeMann.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieDbContext _context;

        // Constructor to inject the MovieDbContext
        public HomeController(MovieDbContext context)
        {
            _context = context;
        }

        // Action to list all movies
        public IActionResult MoviesList()
        {
            var movies = _context.Movies.ToList();  // Fetching all movies from the database
            return View(movies);  // Pass the movies to the view
        }

        // Action to display the 'Create' form
        public IActionResult Create()
        {
            return View();  // Display the form to create a new movie
        }

        // POST action for 'Create' to handle form submission
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            // Ensure that the model is valid (all required fields are filled)
            if (ModelState.IsValid)
            {
                _context.Add(movie);  // Add the movie to the context
                _context.SaveChanges();  // Save changes to the database
                return RedirectToAction(nameof(MoviesList));  // Redirect to the MoviesList page
            }
            return View(movie);  // Return the form if validation fails
        }

        // Action to display the 'Edit' form for a specific movie
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);  // Find the movie by ID
            if (movie == null)
            {
                return NotFound();  // Return 404 if movie not found
            }
            return View(movie);  // Pass the movie to the Edit view
        }

        // POST action for 'Edit' to handle form submission for an existing movie
        [HttpPost]
        public IActionResult Edit(int id, Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();  // Return 404 if IDs do not match
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);  // Update the movie in the context
                    _context.SaveChanges();  // Save changes to the database
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
                    {
                        return NotFound();  // Return 404 if the movie does not exist
                    }
                    else
                    {
                        throw;  // Re-throw if there is another exception
                    }
                }
                return RedirectToAction(nameof(MoviesList));  // Redirect to the MoviesList page
            }
            return View(movie);  // Return the form if validation fails
        }

        // Action to display the 'Delete' form for a specific movie
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);  // Find the movie by ID
            if (movie == null)
            {
                return NotFound();  // Return 404 if movie not found
            }
            return View(movie);  // Pass the movie to the Delete view
        }

        // POST action for 'Delete' to handle form submission for deleting a movie
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);  // Find the movie by ID
            if (movie != null)
            {
                _context.Movies.Remove(movie);  // Remove the movie from the context
                _context.SaveChanges();  // Save changes to the database
            }
            return RedirectToAction(nameof(MoviesList));  // Redirect to the MoviesList page
        }

        // Helper method to check if a movie exists by ID
        private bool MovieExists(int id)
        {
            return _context.Movies.Any(m => m.MovieId == id);  // Return true if movie exists
        }
    }
}

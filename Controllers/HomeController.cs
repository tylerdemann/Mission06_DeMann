using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_DeMann.Models;


namespace Mission06_DeMann.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(MovieDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Movies(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return View(movie);
        }
    }
}
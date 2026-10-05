using CookBook.Data;
using CookBook.Models;
using Microsoft.AspNetCore.Mvc;


namespace CookBook.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Recipe> recipes = _context.Recipes.ToList();

            return View(recipes);
        }
    }
}

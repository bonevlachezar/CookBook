using CookBook.Data;
using CookBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

		public IActionResult Details(int id)
		{
			Recipe? recipe = _context.Recipes
				.Include(r => r.Category)
				.FirstOrDefault(r => r.Id == id);

			if (recipe == null)
			{
				return NotFound();
			}

			return View(recipe);
		}

		public IActionResult Create()
		{
			ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
			return View();

		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Recipe recipe)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
				return View(recipe);
			}

			_context.Recipes.Add(recipe);
			_context.SaveChanges();

			return RedirectToAction(nameof(Index));
		}
	}
}

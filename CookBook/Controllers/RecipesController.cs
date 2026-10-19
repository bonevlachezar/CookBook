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

		public IActionResult Edit(int id)
		{
			Recipe? recipe = _context.Recipes.FirstOrDefault(r => r.Id == id);
			if (recipe == null)
			{
				return NotFound();
			}
			ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
			return View(recipe);

		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Recipe recipe)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
				return View(recipe);
			}

			_context.Recipes.Update(recipe);
			_context.SaveChanges();

			return RedirectToAction(nameof(Details), new { id = recipe.Id });
		}

		public IActionResult Delete(int id)
		{
			Recipe? recipe = _context.Recipes.Include(r => r.Category)
				.FirstOrDefault(r => r.Id == id);

			if (recipe == null)
				return NotFound();
			return View(recipe);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			Recipe? recipe = _context.Recipes.FirstOrDefault(r => r.Id == id);
			if (recipe == null)
			{
				return NotFound();
			}
			
			_context.Recipes.Remove(recipe);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		

	}
}

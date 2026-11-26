using CookBook.Data;
using CookBook.Models;
using CookBook.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Controllers
{
	public class RecipesController : Controller
	{
		private readonly ApplicationDbContext _context;

		private readonly IRecipeService _recipeService;

		public RecipesController(ApplicationDbContext context, IRecipeService recipeService)
		{
			_context = context;
			_recipeService = recipeService;
		}
		public IActionResult Index(string? search)
		{
			List<Recipe> recipes = _recipeService.GetAll(search);

			ViewData["Search"] = search;

			return View(recipes);
		}

		public IActionResult Details(int id)
		{
			Recipe? recipe = _recipeService.GetById(id);

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

			_recipeService.Add(recipe);

			return RedirectToAction(nameof(Index));
		}

		public IActionResult Edit(int id)
		{
			Recipe? recipe =
				_recipeService.GetById(id);

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

			_recipeService.Update(recipe);

			return RedirectToAction(nameof(Details), new { id = recipe.Id });
		}

		public IActionResult Delete(int id)
		{
			Recipe? recipe =
				_recipeService.GetById(id);

			if (recipe == null)
			{
				return NotFound();
			}
			return View(recipe);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			Recipe? recipe = _recipeService.GetById(id);

			if (recipe == null)
			{
				return NotFound();
			}
			_recipeService.Delete(recipe);
			return RedirectToAction(nameof(Index));
		}
	}
}
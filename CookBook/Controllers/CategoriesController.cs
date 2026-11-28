using CookBook.Models;
using CookBook.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CookBook.Controllers
{
	public class CategoriesController : Controller
	{
		private readonly ICategoryService _categoryService;

		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public IActionResult Index()
		{
			List<Category> categories = _categoryService.GetAll();

			
			return View(categories);
		}

		public IActionResult Details(int id)
		{
			Category? category = _categoryService.GetById(id);

			if (category == null)
			{
				return NotFound();
			}

			return View(category);

		}

		public IActionResult Create()
		{
			
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Create(Category category)
		{
			if (!ModelState.IsValid)
			{
				
				return View(category);
			}

			_categoryService.Add(category);

			return RedirectToAction(nameof(Index));
		}
		public IActionResult Edit(int id)
		{
			Category? category = _categoryService.GetById(id);

			if (category == null)
			{
				return NotFound();
			}

			return View(category);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Category category)
		{
			if (!ModelState.IsValid)
			{
				return View(category);
			}

			_categoryService.Update(category);

			return RedirectToAction(nameof(Details), new { id = category.Id });
		}
	}
}

using CookBook.Models;
using CookBook.Services;
using Microsoft.AspNetCore.Mvc;

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
			Category? categories = _categoryService.GetById(id);

			if (categories == null)
			{
				return NotFound();
			}

			return View(categories);
		}
	}
}

using CookBook.Data;
using CookBook.Models;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Services
{
	public class RecipeService : IRecipeService
	{
		private readonly ApplicationDbContext _context;

		public RecipeService(ApplicationDbContext context)
		{
			_context = context;
		}

		public void Add(Recipe recipe)
		{
			_context.Recipes.Add(recipe);
			_context.SaveChanges();
		}

		public void Delete(Recipe recipe)
		{
			_context.Recipes.Remove(recipe);
			_context.SaveChanges();
		}

		public List<Recipe> GetAll(string? search)
		{
			return _context.Recipes
				.Where(r => search == null || r.Name.Contains(search))
				.ToList();
		}

		public Recipe? GetById(int id)
		{
			return _context.Recipes
				.Include(r => r.Category)
				.FirstOrDefault(r => r.Id == id);
		}

		public void Update(Recipe recipe)
		{
			_context.Recipes.Update(recipe);
			_context.SaveChanges();
		}
	}
}

using CookBook.Data;
using CookBook.Models;
using Microsoft.EntityFrameworkCore;


namespace CookBook.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ApplicationDbContext _context;

		public CategoryService(ApplicationDbContext context)
		{
			_context = context;
		}

		public void Add(Category category)
		{
			_context.Categories.Add(category);
			_context.SaveChanges();
		}

		public void Delete(Category category)
		{
			_context.Categories.Remove(category);
			_context.SaveChanges();

		}

		public List<Category> GetAll()
		{
			return _context.Categories
				.ToList();

		}

		public Category? GetById(int id)
		{
			return _context.Categories
				.Include(c => c.Recipes)
				.FirstOrDefault(c => c.Id == id);
			
		}

		public void Update(Category category)
		{
			_context.Categories.Update(category);
			_context.SaveChanges();
		}
	}
}

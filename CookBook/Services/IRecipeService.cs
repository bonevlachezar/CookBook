using CookBook.Models;


namespace CookBook.Services
{
	public interface IRecipeService
	{
		List<Recipe> GetAll(string? search);

		Recipe? GetById(int id);
	}
}

using System.ComponentModel.DataAnnotations;

namespace CookBook.Models
{
	public class Recipe
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Името на рецептата е задължително")]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "Името трябва да е между 3 и 100 символа")]
		[Display(Name = "Име")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Описанието е задължително")]
		[StringLength(1000, MinimumLength = 10, ErrorMessage = "Описанието трябва да е между 10 и 1000 символа")]
		[Display(Name = "Описание")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Времето трябва да е между 1 и 600 минути")]
		[Range(1, 600, ErrorMessage = "Времето трябва да е между 1 и 600 минути")]
		[Display(Name = "Минути")]
		public int Minutes { get; set; }

		[Required(ErrorMessage = "Избирането на категория е задължително")]
		[Display(Name = "Категория")]
		public int CategoryId { get; set; }

		public Category? Category { get; set; }
	}
}



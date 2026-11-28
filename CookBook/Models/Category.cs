using System.ComponentModel.DataAnnotations;
namespace CookBook.Models
{
    public class Category
    {
        public int Id { get; set; }

		[Required(ErrorMessage = "Името на категорията е задължително")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Името трябва да е между 2 и 50 символа")]
		[Display(Name = "Име")]
		public string Name { get; set; }

        public List<Recipe> Recipes { get; set; } = new();

      
	}

}

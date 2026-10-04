using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CookBook.Models;

namespace CookBook.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(
                 new Category { Id = 1, Name = "Супи" },
                 new Category { Id = 2, Name = "Основни ястия" },
                 new Category { Id = 3, Name = "Десерти" },
                 new Category { Id = 4, Name = "Зимнина" });

            builder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 1,
                    Name = "Доматена супа с печени чушки",
                    Description = "Гъста супа от печени чушки и домати, поднесена със сирене",
                    Minutes = 40,
                    CategoryId = 1
                },
                new Recipe
                {
                    Id = 2,
                    Name = "Постни пълнени чушки с булгур",
                    Description = "Манджа",
                    Minutes = 70,
                    CategoryId = 2
                },
                 new Recipe
                 {
                     Id = 3,
                     Name = "Пълнена тиква с боб, праз и сини сливи",
                     Description = "Манджа",
                     Minutes = 60,
                     CategoryId = 2
                 },
                 new Recipe
                 {
                     Id = 4,
                     Name = "Кюфтенца от пилешки дробчета",
                     Description = "Пекани кюфтенца на фурна",
                     Minutes = 30,
                     CategoryId = 2
                 },
                 new Recipe
                 {
                     Id = 5,
                     Name = "Чеснови пилешки крилца с пармезан",
                     Description = "Панирани пилешки крилца",
                     Minutes = 45,
                     CategoryId = 2
                 },
                 new Recipe
                 {
                     Id = 6,
                     Name = "Агнешки врат на фурна",
                     Description = "Сочен агнешки врат на фурна",
                     Minutes = 130,
                     CategoryId = 2
                 },
                   new Recipe
                   {
                       Id = 7,
                       Name = "Ризото с лангустини",
                       Description = "Кремообразно ризото",
                       Minutes = 60,
                       CategoryId = 2
                   },
                    new Recipe
                    {
                        Id = 8,
                        Name = "Ябълков пай",
                        Description = "Сочно изпечен, ябълков пай",
                        Minutes = 70,
                        CategoryId = 3
                    },
                     new Recipe
                     {
                         Id = 9,
                         Name = "Сладки с ябълки и канела",
                         Description = "Печени на фурна",
                         Minutes = 30,
                         CategoryId = 3
                     },
                           new Recipe
                           {
                               Id = 10,
                               Name = "Лютеница",
                               Description = "Домашно приготвена",
                               Minutes = 30,
                               CategoryId = 4
                           });
           
            builder.Entity<Ingredient>().HasData(
                 new Ingredient { Id = 1, Name = "Домати", RecipeId = 1 });
        }
    }
}

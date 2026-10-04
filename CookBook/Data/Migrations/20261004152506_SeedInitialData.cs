using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CookBook.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Супи" },
                    { 2, "Основни ястия" },
                    { 3, "Десерти" },
                    { 4, "Зимнина" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "Description", "Minutes", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Гъста супа от печени чушки и домати, поднесена със сирене", 40, "Доматена супа с печени чушки" },
                    { 2, 2, "Манджа", 70, "Постни пълнени чушки с булгур" },
                    { 3, 2, "Манджа", 60, "Пълнена тиква с боб, праз и сини сливи" },
                    { 4, 2, "Пекани кюфтенца на фурна", 30, "Кюфтенца от пилешки дробчета" },
                    { 5, 2, "Панирани пилешки крилца", 45, "Чеснови пилешки крилца с пармезан" },
                    { 6, 2, "Сочен агнешки врат на фурна", 130, "Агнешки врат на фурна" },
                    { 7, 2, "Кремообразно ризото", 60, "Ризото с лангустини" },
                    { 8, 3, "Сочно изпечен, ябълков пай", 70, "Ябълков пай" },
                    { 9, 3, "Печени на фурна", 30, "Сладки с ябълки и канела" },
                    { 10, 4, "Домашно приготвена", 30, "Лютеница" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 1, "Домати", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

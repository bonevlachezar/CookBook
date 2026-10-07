using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRecipeDescriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Ястие за дома");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Гозба от пълнена тиква");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Манджа");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Манджа");
        }
    }
}

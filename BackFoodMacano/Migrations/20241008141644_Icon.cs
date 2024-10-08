using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class Icon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "categorias",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "IconUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/Icons%2FIconHamburguesa.png?alt=media&token=b280cbd2-9016-4647-85e9-048858807010");

            migrationBuilder.UpdateData(
                table: "categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "IconUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/Icons%2FIconSandwich.png?alt=media&token=dc21b284-630e-4b54-9b93-1b4668f316f2");

            migrationBuilder.UpdateData(
                table: "categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "IconUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/Icons%2FIconBebidas.png?alt=media&token=c87c60a9-215c-4a8f-8939-b3423e48a1c0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "categorias");
        }
    }
}

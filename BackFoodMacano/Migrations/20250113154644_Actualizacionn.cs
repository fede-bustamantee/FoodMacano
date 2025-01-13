using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class Actualizacionn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "usuarios",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "Id", "Email", "FirebaseId", "Password", "TipoUsuario", "User" },
                values: new object[] { 1, "f@gmail.com", "t7DM46Nrb5VABqoCkOQPv40VZfj2", "123456", 0, "fede" });
        }
    }
}

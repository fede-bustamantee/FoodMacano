using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class iocm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "Id", "Email", "FirebaseId", "Password", "TipoUsuario", "User" },
                values: new object[] { 1, "f@gmail.com", "t7DM46Nrb5VABqoCkOQPv40VZfj2", "123456", 0, "fede" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "usuarios",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customers.Migrations
{
    /// <inheritdoc />
    public partial class RenameAdressToAdress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Customers",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Customers",
                newName: "Adress");
        }
    }
}

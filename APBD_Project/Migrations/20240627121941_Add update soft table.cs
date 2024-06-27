using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APBD_Project.Migrations
{
    /// <inheritdoc />
    public partial class Addupdatesofttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Softwares",
                newName: "SubPrice");

            migrationBuilder.AddColumn<double>(
                name: "BuyPrice",
                table: "Softwares",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyPrice",
                table: "Softwares");

            migrationBuilder.RenameColumn(
                name: "SubPrice",
                table: "Softwares",
                newName: "Price");
        }
    }
}

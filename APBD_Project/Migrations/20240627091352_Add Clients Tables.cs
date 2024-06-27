using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APBD_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddClientsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "CompanyClients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KRSNumber = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyClients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_CompanyClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndividualClients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualClients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_IndividualClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Address", "Email", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St", "john.doe@example.com", "123456789" },
                    { 2, "456 Elm St", "jane.smith@example.com", "213456789" },
                    { 3, "789 Oak St", "alice.johnson@example.com", "987654321" },
                    { 4, "456 Corporate Blvd", "contact@abccorp.com", "066655999" },
                    { 5, "789 Business Rd", "info@xyzltd.com", "333222111" },
                    { 6, "123 Enterprise Ave", "support@mnoinc.com", "888999777" }
                });

            migrationBuilder.InsertData(
                table: "CompanyClients",
                columns: new[] { "ClientId", "CompanyName", "KRSNumber" },
                values: new object[,]
                {
                    { 4, "ABC Corp", "9876543210" },
                    { 5, "XYZ Ltd", "8765432109" },
                    { 6, "MNO Inc", "7654321098" }
                });

            migrationBuilder.InsertData(
                table: "IndividualClients",
                columns: new[] { "ClientId", "FirstName", "IsDeleted", "LastName", "Pesel" },
                values: new object[,]
                {
                    { 1, "John", false, "Doe", "12345678901" },
                    { 2, "Jane", false, "Smith", "23456789012" },
                    { 3, "Alice", false, "Johnson", "34567890123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyClients");

            migrationBuilder.DropTable(
                name: "IndividualClients");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}

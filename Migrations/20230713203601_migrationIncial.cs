using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.API.Migrations
{
    public partial class migrationIncial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    Size = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<float>(type: "REAL", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Adress = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    State = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleOrders_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Name", "Price", "Size", "Stock" },
                values: new object[] { 4, 0, "Remera basic", 10000f, 3, 3 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Name", "Price", "Size", "Stock" },
                values: new object[] { 5, 3, "Jean recto", 50000f, 2, 2 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Name", "Price", "Size", "Stock" },
                values: new object[] { 6, 4, "Campera basic", 60000f, 2, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Name", "Price", "Size", "Stock" },
                values: new object[] { 7, 0, "Remera Nation", 30000f, 1, 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role", "UserName" },
                values: new object[] { 3, "admin@gmail.com", "Password2", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adress", "Email", "LastName", "Name", "Password", "Role", "UserName" },
                values: new object[] { 1, "Alem 1333", "clararazzetto@gmail.com", "Razzetto", "Clara", "Password", "Client", "ClaraRazzetto" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adress", "Email", "LastName", "Name", "Password", "Role", "UserName" },
                values: new object[] { 2, "Urquiza 800", "nicop@gmail.com", "Perez", "Nicolas", "Password1", "Client", "NicolasPerez" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adress", "Email", "LastName", "Name", "Password", "Role", "UserName" },
                values: new object[] { 10, "Alem 1400", "rox@gmail.com", "Perez", "Roxana", "Password3", "Client", "RoxanaPerez" });

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_ClientId",
                table: "SaleOrders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_ProductId",
                table: "SaleOrders",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleOrders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

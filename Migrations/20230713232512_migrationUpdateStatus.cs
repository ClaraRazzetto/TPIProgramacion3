using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.API.Migrations
{
    public partial class migrationUpdateStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                table: "SaleOrders",
                newName: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "SaleOrders",
                newName: "State");
        }
    }
}

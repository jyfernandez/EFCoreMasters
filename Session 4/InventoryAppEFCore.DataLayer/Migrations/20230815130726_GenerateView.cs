using InventoryAppEFCore.DataLayer.Extensions;
using InventoryAppEFCore.DataLayer.Views;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAppEFCore.DataLayer.Migrations
{
    public partial class GenerateView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Views
            migrationBuilder.AddViewViaSql<SupplierView>("SupplierView", "Suppliers", "Name = 'Shoppee'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

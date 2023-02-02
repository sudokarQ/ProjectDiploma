using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomaProject.Backend.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ModelsUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "promotions");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "shop",
                type: "text",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotaPrice",
                table: "orders",
                type: "numeric",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "clients",
                type: "text",
                nullable: true,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "shop");

            migrationBuilder.DropColumn(
                name: "TotaPrice",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "clients");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "promotions",
                type: "text",
                nullable: true);
        }
    }
}

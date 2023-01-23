using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomaProject.Backend.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Promotionupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BeginDate",
                table: "promotions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "promotions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "CompanyPercent",
                table: "promotions",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "promotions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsCorporate",
                table: "promotions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OnDelivery",
                table: "orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "orders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "clients",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_promotions_CompanyId",
                table: "promotions",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_clients_CompanyId",
                table: "clients",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_clients_company_CompanyId",
                table: "clients",
                column: "CompanyId",
                principalTable: "company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_promotions_company_CompanyId",
                table: "promotions",
                column: "CompanyId",
                principalTable: "company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clients_company_CompanyId",
                table: "clients");

            migrationBuilder.DropForeignKey(
                name: "FK_promotions_company_CompanyId",
                table: "promotions");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropIndex(
                name: "IX_promotions_CompanyId",
                table: "promotions");

            migrationBuilder.DropIndex(
                name: "IX_clients_CompanyId",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "BeginDate",
                table: "promotions");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "promotions");

            migrationBuilder.DropColumn(
                name: "CompanyPercent",
                table: "promotions");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "promotions");

            migrationBuilder.DropColumn(
                name: "IsCorporate",
                table: "promotions");

            migrationBuilder.DropColumn(
                name: "OnDelivery",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "clients");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomaProject.Backend.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Companydeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clients_company_CompanyId",
                table: "clients");

            migrationBuilder.DropForeignKey(
                name: "FK_promotions_company_CompanyId",
                table: "promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_services_promotions_PromotionId",
                table: "services");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropIndex(
                name: "IX_services_PromotionId",
                table: "services");

            migrationBuilder.DropIndex(
                name: "IX_clients_CompanyId",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "services");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "clients");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "promotions",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_promotions_CompanyId",
                table: "promotions",
                newName: "IX_promotions_ServiceId");

            migrationBuilder.AddColumn<int>(
                name: "DiscountPercent",
                table: "shop",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "promotions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "clients",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_promotions_services_ServiceId",
                table: "promotions",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_promotions_services_ServiceId",
                table: "promotions");

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "shop");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "promotions");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "clients");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "promotions",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_promotions_ServiceId",
                table: "promotions",
                newName: "IX_promotions_CompanyId");

            migrationBuilder.AddColumn<Guid>(
                name: "PromotionId",
                table: "services",
                type: "uuid",
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
                name: "IX_services_PromotionId",
                table: "services",
                column: "PromotionId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_services_promotions_PromotionId",
                table: "services",
                column: "PromotionId",
                principalTable: "promotions",
                principalColumn: "Id");
        }
    }
}

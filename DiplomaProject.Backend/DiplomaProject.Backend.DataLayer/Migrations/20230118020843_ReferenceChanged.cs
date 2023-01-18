using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomaProject.Backend.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ReferenceChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_promotions_services_ServiceId",
                table: "promotions");

            migrationBuilder.DropIndex(
                name: "IX_promotions_ServiceId",
                table: "promotions");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "promotions");

            migrationBuilder.AddColumn<Guid>(
                name: "PromotionId",
                table: "services",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_services_PromotionId",
                table: "services",
                column: "PromotionId");

            migrationBuilder.AddForeignKey(
                name: "FK_services_promotions_PromotionId",
                table: "services",
                column: "PromotionId",
                principalTable: "promotions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_services_promotions_PromotionId",
                table: "services");

            migrationBuilder.DropIndex(
                name: "IX_services_PromotionId",
                table: "services");

            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "services");

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceId",
                table: "promotions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_promotions_ServiceId",
                table: "promotions",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_promotions_services_ServiceId",
                table: "promotions",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

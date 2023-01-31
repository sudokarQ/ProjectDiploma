using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomaProject.Backend.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class NullabaleAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_promotions_services_ServiceId",
                table: "promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_services_shop_ShopId",
                table: "services");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShopId",
                table: "services",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceId",
                table: "promotions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_promotions_services_ServiceId",
                table: "promotions",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_services_shop_ShopId",
                table: "services",
                column: "ShopId",
                principalTable: "shop",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_promotions_services_ServiceId",
                table: "promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_services_shop_ShopId",
                table: "services");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShopId",
                table: "services",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceId",
                table: "promotions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_promotions_services_ServiceId",
                table: "promotions",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_services_shop_ShopId",
                table: "services",
                column: "ShopId",
                principalTable: "shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomaProject.Backend.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_clients_ClientId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_services_ServiceId",
                table: "orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "promotions",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<decimal>(
                name: "CompanyPercent",
                table: "promotions",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BeginDate",
                table: "promotions",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "promotions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceId",
                table: "orders",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "orders",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_clients_ClientId",
                table: "orders",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_services_ServiceId",
                table: "orders",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_clients_ClientId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_services_ServiceId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "promotions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "promotions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CompanyPercent",
                table: "promotions",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BeginDate",
                table: "promotions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceId",
                table: "orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_clients_ClientId",
                table: "orders",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_services_ServiceId",
                table: "orders",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

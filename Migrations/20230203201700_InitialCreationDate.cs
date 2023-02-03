using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreationDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Task",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 3, 20, 16, 59, 932, DateTimeKind.Utc).AddTicks(2515),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Category",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 3, 20, 16, 59, 932, DateTimeKind.Utc).AddTicks(1347),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("c4e0d0e7-5f06-48c7-9246-11fe12f2c602"),
                column: "CreationDate",
                value: new DateTime(2023, 2, 3, 20, 16, 59, 932, DateTimeKind.Utc).AddTicks(1347));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("c4e0d0e7-5f06-48c7-9246-11fe12f2c657"),
                column: "CreationDate",
                value: new DateTime(2023, 2, 3, 20, 16, 59, 932, DateTimeKind.Utc).AddTicks(1347));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("c4e0d0e7-5f06-48c7-9246-11fe12f2c100"),
                column: "CreationDate",
                value: new DateTime(2023, 2, 3, 17, 16, 59, 932, DateTimeKind.Local).AddTicks(830));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("c4e0d0e7-5f06-48c7-9246-11fe12f2c101"),
                column: "CreationDate",
                value: new DateTime(2023, 2, 3, 17, 16, 59, 932, DateTimeKind.Local).AddTicks(855));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Task",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 2, 3, 20, 16, 59, 932, DateTimeKind.Utc).AddTicks(2515));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Category",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 2, 3, 20, 16, 59, 932, DateTimeKind.Utc).AddTicks(1347));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("c4e0d0e7-5f06-48c7-9246-11fe12f2c602"),
                column: "CreationDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("c4e0d0e7-5f06-48c7-9246-11fe12f2c657"),
                column: "CreationDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("c4e0d0e7-5f06-48c7-9246-11fe12f2c100"),
                column: "CreationDate",
                value: new DateTime(2023, 2, 3, 17, 7, 33, 858, DateTimeKind.Local).AddTicks(5894));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("c4e0d0e7-5f06-48c7-9246-11fe12f2c101"),
                column: "CreationDate",
                value: new DateTime(2023, 2, 3, 17, 7, 33, 858, DateTimeKind.Local).AddTicks(5919));
        }
    }
}

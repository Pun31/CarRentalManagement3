using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRentalManagement.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultDataAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", null, "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "c4d51344-2455-4bd4-a91a-15d7faab7d9c", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEBhZFvwJh+3kcYJvRx2Rel66IxsxYoP+b5eSlNP4acaLl3MCZoo5dMSmcEbwoOxeIg==", null, false, "15a8aa13-e6d0-4ab6-b24f-bef2e81967d3", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "Colours",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 11, 28, 16, 44, 30, 868, DateTimeKind.Local).AddTicks(7139), new DateTime(2023, 11, 28, 16, 44, 30, 868, DateTimeKind.Local).AddTicks(7150), "Black", "System" },
                    { 2, "System", new DateTime(2023, 11, 28, 16, 44, 30, 868, DateTimeKind.Local).AddTicks(7154), new DateTime(2023, 11, 28, 16, 44, 30, 868, DateTimeKind.Local).AddTicks(7154), "Blue", "System" }
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 11, 28, 16, 44, 30, 868, DateTimeKind.Local).AddTicks(7595), new DateTime(2023, 11, 28, 16, 44, 30, 868, DateTimeKind.Local).AddTicks(7595), "BMW", "System" },
                    { 2, "System", new DateTime(2023, 11, 28, 16, 44, 30, 868, DateTimeKind.Local).AddTicks(7597), new DateTime(2023, 11, 28, 16, 44, 30, 868, DateTimeKind.Local).AddTicks(7598), "Toyota", "System" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 11, 28, 16, 44, 30, 868, DateTimeKind.Local).AddTicks(7792), new DateTime(2023, 11, 28, 16, 44, 30, 868, DateTimeKind.Local).AddTicks(7792), "3 Series", "System" },
                    { 2, "System", new DateTime(2023, 11, 28, 16, 44, 30, 868, DateTimeKind.Local).AddTicks(7794), new DateTime(2023, 11, 28, 16, 44, 30, 868, DateTimeKind.Local).AddTicks(7794), "X5", "System" },
                    { 3, "System", new DateTime(2023, 11, 28, 16, 44, 30, 868, DateTimeKind.Local).AddTicks(7795), new DateTime(2023, 11, 28, 16, 44, 30, 868, DateTimeKind.Local).AddTicks(7795), "Prius", "System" },
                    { 4, "System", new DateTime(2023, 11, 28, 16, 44, 30, 868, DateTimeKind.Local).AddTicks(7797), new DateTime(2023, 11, 28, 16, 44, 30, 868, DateTimeKind.Local).AddTicks(7797), "Rav4", "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");
        }
    }
}

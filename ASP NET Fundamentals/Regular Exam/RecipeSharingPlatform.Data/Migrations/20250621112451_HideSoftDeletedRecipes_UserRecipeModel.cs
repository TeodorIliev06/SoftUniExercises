using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeSharingPlatform.Data.Migrations
{
    /// <inheritdoc />
    public partial class HideSoftDeletedRecipes_UserRecipeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f511ef0e-51f9-4d66-8422-4283f92c8eb3", "AQAAAAIAAYagAAAAEN7/awcVraHQdvpthd5UO+r6PFPERVR9RxMYjM+00xmxaZIM9XkFOGqQFyh5EpJifg==", "a5c38181-8a87-438a-a17a-efdaf072f5bd" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 21, 14, 24, 50, 491, DateTimeKind.Local).AddTicks(4488));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 21, 14, 24, 50, 491, DateTimeKind.Local).AddTicks(4549));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 21, 14, 24, 50, 491, DateTimeKind.Local).AddTicks(4552));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "794cc256-922d-424b-9ba5-b4a32d61d2f4", "AQAAAAIAAYagAAAAEDS5e35hpcc0potU7cJb1US/7DYXTwmenEMcV/KnrgTWjZhhMg6+ZQ/yk0YG0YH/lg==", "e316069b-d468-4aa5-b685-fcb203517e8d" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 21, 10, 7, 5, 146, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 21, 10, 7, 5, 146, DateTimeKind.Local).AddTicks(3085));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 21, 10, 7, 5, 146, DateTimeKind.Local).AddTicks(3152));
        }
    }
}

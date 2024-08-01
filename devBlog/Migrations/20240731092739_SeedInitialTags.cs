using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace devBlog.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagID", "Name" },
                values: new object[,]
                {
                    { new Guid("2aa5d99a-ee38-49fb-be79-839da93892e2"), "Health" },
                    { new Guid("775198da-5a26-42a6-bb8d-99ce21cfa346"), "Travel" },
                    { new Guid("9d967dd3-49af-43a0-b9d3-1020cf7d32e0"), "Technology" },
                    { new Guid("e7131b1e-1116-4640-84ee-5d175f001e8d"), "Science" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("2aa5d99a-ee38-49fb-be79-839da93892e2"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("775198da-5a26-42a6-bb8d-99ce21cfa346"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("9d967dd3-49af-43a0-b9d3-1020cf7d32e0"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("e7131b1e-1116-4640-84ee-5d175f001e8d"));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace devBlog.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialTagsNewTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagID", "Name" },
                values: new object[,]
                {
                    { new Guid("5575dbfd-ae48-42f7-9434-42c1b1219169"), "Cybersecurity" },
                    { new Guid("57c24af8-f317-4c5a-b746-5f68b54f1552"), "AI / ML" },
                    { new Guid("8099b903-d0ad-410e-9968-6ea4ba14b36e"), "Tech Industry News" },
                    { new Guid("a4e35d88-cf31-470a-9fbe-bb4f2d553160"), "Development" },
                    { new Guid("c10d5d9c-9c7d-4bfd-9708-8514a3d26fa9"), "Cloud Computing" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("5575dbfd-ae48-42f7-9434-42c1b1219169"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("57c24af8-f317-4c5a-b746-5f68b54f1552"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("8099b903-d0ad-410e-9968-6ea4ba14b36e"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("a4e35d88-cf31-470a-9fbe-bb4f2d553160"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("c10d5d9c-9c7d-4bfd-9708-8514a3d26fa9"));

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace devBlog.Migrations
{
    /// <inheritdoc />
    public partial class SeedTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagID", "Name" },
                values: new object[,]
                {
                    { new Guid("0e4b41d6-1f18-42c0-be97-a36978d07cb7"), "AI Applications" },
                    { new Guid("11243338-a9ed-46f8-9a7a-bd8e889491db"), "Mobile Development" },
                    { new Guid("1794de33-50c8-4a14-b4bb-a758e2ac2528"), "CSS" },
                    { new Guid("23d770ef-eb4b-41e3-a7e8-53963d2ce31b"), "Data Privacy" },
                    { new Guid("3487b5fd-230b-47c9-b3e4-0275f3afc74b"), "Security Tools" },
                    { new Guid("4d582a53-68c2-4697-b7b1-13883ee332ee"), "Ethics in AI" },
                    { new Guid("5f4ec4a1-fedc-474d-b7cf-1697286e8154"), "Application Security" },
                    { new Guid("72d4c9e8-bc49-4f4f-b393-f78a734bdbad"), "JavaScript" },
                    { new Guid("7a3473bd-1ae1-4e95-ab81-fc6e3361ce4b"), "Software Engineering" },
                    { new Guid("7ad686fb-6326-4891-a2a4-6b4cc6243960"), "Web Development" },
                    { new Guid("87488ca6-8e26-4ffa-ae02-89c13f3c6a18"), "Tech Industry News" },
                    { new Guid("8f7c4933-418d-4822-bab5-13a69703b66d"), "Software Development Tools" },
                    { new Guid("9034ea1f-bf09-4aa3-a406-ffe7ed6c7b57"), "Deep Learning" },
                    { new Guid("91713744-ee9b-4887-8160-6bee49446863"), "Angular" },
                    { new Guid("98b20f22-1948-4102-bd3b-06af09b2926e"), "Cybersecurity" },
                    { new Guid("aea4ae6a-823c-4517-a2ca-3b7a1dca6d73"), "React" },
                    { new Guid("b8baaf97-e783-4d35-936d-20ed9fdbd1e0"), "Incident Response" },
                    { new Guid("b9cffb4d-52e7-4a74-ab8e-d34fa3d6a380"), "Programming Language" },
                    { new Guid("bb29cca1-558e-413c-b49f-f13dcbddf8c7"), "Machine Learning Algorithms" },
                    { new Guid("bd8c477f-de79-40d7-9813-fcb02c50a901"), "Network Security" },
                    { new Guid("cfbdc79c-5b18-4ead-8e0f-601d833adb30"), "Cloud Computing" },
                    { new Guid("d2c40fae-ac15-4945-8762-d5c3e8bcd632"), "PHP" },
                    { new Guid("d7036da9-1e71-4a80-9580-d57ab6e56c8b"), "Software Testing" },
                    { new Guid("ddb5da94-1d04-4de3-81b0-25ce759b364d"), "HTML" },
                    { new Guid("e6eafb78-2d3d-488c-8ff6-41512fcf3b4b"), "Development" },
                    { new Guid("ec24b02f-98b6-42a5-aa58-9bbebf53f143"), "Data Science" },
                    { new Guid("ed218458-b1da-45e1-a2c6-2c13ea272d9d"), "AI / ML" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("0e4b41d6-1f18-42c0-be97-a36978d07cb7"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("11243338-a9ed-46f8-9a7a-bd8e889491db"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("1794de33-50c8-4a14-b4bb-a758e2ac2528"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("23d770ef-eb4b-41e3-a7e8-53963d2ce31b"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("3487b5fd-230b-47c9-b3e4-0275f3afc74b"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("4d582a53-68c2-4697-b7b1-13883ee332ee"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("5f4ec4a1-fedc-474d-b7cf-1697286e8154"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("72d4c9e8-bc49-4f4f-b393-f78a734bdbad"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("7a3473bd-1ae1-4e95-ab81-fc6e3361ce4b"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("7ad686fb-6326-4891-a2a4-6b4cc6243960"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("87488ca6-8e26-4ffa-ae02-89c13f3c6a18"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("8f7c4933-418d-4822-bab5-13a69703b66d"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("9034ea1f-bf09-4aa3-a406-ffe7ed6c7b57"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("91713744-ee9b-4887-8160-6bee49446863"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("98b20f22-1948-4102-bd3b-06af09b2926e"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("aea4ae6a-823c-4517-a2ca-3b7a1dca6d73"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("b8baaf97-e783-4d35-936d-20ed9fdbd1e0"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("b9cffb4d-52e7-4a74-ab8e-d34fa3d6a380"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("bb29cca1-558e-413c-b49f-f13dcbddf8c7"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("bd8c477f-de79-40d7-9813-fcb02c50a901"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("cfbdc79c-5b18-4ead-8e0f-601d833adb30"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("d2c40fae-ac15-4945-8762-d5c3e8bcd632"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("d7036da9-1e71-4a80-9580-d57ab6e56c8b"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("ddb5da94-1d04-4de3-81b0-25ce759b364d"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("e6eafb78-2d3d-488c-8ff6-41512fcf3b4b"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("ec24b02f-98b6-42a5-aa58-9bbebf53f143"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("ed218458-b1da-45e1-a2c6-2c13ea272d9d"));
        }
    }
}

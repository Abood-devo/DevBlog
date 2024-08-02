using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace devBlog.Migrations
{
    /// <inheritdoc />
    public partial class AddIsApprovedToBlogPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("03319be9-e0c3-4e0f-8694-b06269b2a3bd"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("13086d29-1cea-4d01-8b4e-9ab46c3bc4cf"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("1abcf16d-6e29-4362-a393-235ac76a6bd6"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("256a4262-6e8c-48bf-b417-4aa0860c9488"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("26f0f375-680e-4a26-88c6-7b1696d2b7a6"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("342d319f-5007-454c-b745-edc991a15dbd"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("386b6650-79a7-44ce-a9b8-74825734500d"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("3d54b292-f4ae-4c7b-a2c5-cdd474dc0be0"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("443106b3-7201-4234-982e-b1b5ba940e5d"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("47400c8d-4c7e-4df3-ba1d-53b563670a3b"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("47683a36-e952-4a75-90dc-f208f6c5cb7c"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("4dee430c-a677-4106-a783-1e75f5677c31"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("59b44982-8a8d-43fa-a171-ae64bcafd1ae"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("67f3804b-2e4c-4d4c-bc65-2e68a6d59fd4"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("6f10ed9d-42df-4398-ad13-a29acdb7fc01"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("87181401-d0df-4e62-a701-4dcd44ed03ad"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("8c937d06-3f61-43e0-8f65-3b283f430cef"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("93d5f149-a985-42de-8121-a78953e962b6"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("9b05aeea-cc50-49f6-9daf-1b883a32e9df"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("a9e689a4-975c-413f-84c2-dd0a25ccb6af"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("b8455130-b325-4656-80a6-5be15c13d74e"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("b87a8480-cc91-4e2d-8ff9-9f4a77512289"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("c533d844-a66f-4a4f-97d8-d7275b5198dc"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("d596f6a0-a3f3-4cce-9492-a0386306d39f"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("ea87cc48-ca65-496f-b0e2-d244589fda1b"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("ed227003-fc98-4683-becc-5719b4174f30"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: new Guid("f56bb2e2-f338-4111-88ef-4ceda922711e"));

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "BlogPost",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "BlogPost");

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagID", "Name" },
                values: new object[,]
                {
                    { new Guid("03319be9-e0c3-4e0f-8694-b06269b2a3bd"), "AI Applications" },
                    { new Guid("13086d29-1cea-4d01-8b4e-9ab46c3bc4cf"), "Security Tools" },
                    { new Guid("1abcf16d-6e29-4362-a393-235ac76a6bd6"), "Software Testing" },
                    { new Guid("256a4262-6e8c-48bf-b417-4aa0860c9488"), "Web Development" },
                    { new Guid("26f0f375-680e-4a26-88c6-7b1696d2b7a6"), "Angular" },
                    { new Guid("342d319f-5007-454c-b745-edc991a15dbd"), "HTML" },
                    { new Guid("386b6650-79a7-44ce-a9b8-74825734500d"), "Network Security" },
                    { new Guid("3d54b292-f4ae-4c7b-a2c5-cdd474dc0be0"), "Programming Language" },
                    { new Guid("443106b3-7201-4234-982e-b1b5ba940e5d"), "Mobile Development" },
                    { new Guid("47400c8d-4c7e-4df3-ba1d-53b563670a3b"), "JavaScript" },
                    { new Guid("47683a36-e952-4a75-90dc-f208f6c5cb7c"), "PHP" },
                    { new Guid("4dee430c-a677-4106-a783-1e75f5677c31"), "Cybersecurity" },
                    { new Guid("59b44982-8a8d-43fa-a171-ae64bcafd1ae"), "Deep Learning" },
                    { new Guid("67f3804b-2e4c-4d4c-bc65-2e68a6d59fd4"), "Development" },
                    { new Guid("6f10ed9d-42df-4398-ad13-a29acdb7fc01"), "AI / ML" },
                    { new Guid("87181401-d0df-4e62-a701-4dcd44ed03ad"), "Data Privacy" },
                    { new Guid("8c937d06-3f61-43e0-8f65-3b283f430cef"), "Ethics in AI" },
                    { new Guid("93d5f149-a985-42de-8121-a78953e962b6"), "Tech Industry News" },
                    { new Guid("9b05aeea-cc50-49f6-9daf-1b883a32e9df"), "Machine Learning Algorithms" },
                    { new Guid("a9e689a4-975c-413f-84c2-dd0a25ccb6af"), "Application Security" },
                    { new Guid("b8455130-b325-4656-80a6-5be15c13d74e"), "Software Engineering" },
                    { new Guid("b87a8480-cc91-4e2d-8ff9-9f4a77512289"), "Incident Response" },
                    { new Guid("c533d844-a66f-4a4f-97d8-d7275b5198dc"), "Cloud Computing" },
                    { new Guid("d596f6a0-a3f3-4cce-9492-a0386306d39f"), "React" },
                    { new Guid("ea87cc48-ca65-496f-b0e2-d244589fda1b"), "CSS" },
                    { new Guid("ed227003-fc98-4683-becc-5719b4174f30"), "Data Science" },
                    { new Guid("f56bb2e2-f338-4111-88ef-4ceda922711e"), "Software Development Tools" }
                });
        }
    }
}

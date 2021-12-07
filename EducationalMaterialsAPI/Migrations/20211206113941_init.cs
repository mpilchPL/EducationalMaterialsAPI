using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationalMaterialsAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EduMaterialTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EduMaterialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EduMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EduMaterialTypeId = table.Column<int>(type: "int", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EduMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EduMaterials_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EduMaterials_EduMaterialTypes_EduMaterialTypeId",
                        column: x => x.EduMaterialTypeId,
                        principalTable: "EduMaterialTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewPoints = table.Column<int>(type: "int", nullable: false),
                    EduMaterialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_EduMaterials_EduMaterialId",
                        column: x => x.EduMaterialId,
                        principalTable: "EduMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "This is Albert Einstein himself.", "Albert Einstein" },
                    { 2, "This is Vera Rubin herself.", "Vera Rubin" },
                    { 3, "This is Mikołaj Kopernik himself.", "Mikołaj Kopernik" },
                    { 4, "This is Maria Skłodowska-Curie herself.", "Maria Skłodowska-Curie" }
                });

            migrationBuilder.InsertData(
                table: "EduMaterialTypes",
                columns: new[] { "Id", "Definition", "Name" },
                values: new object[,]
                {
                    { 1, "Video material description", "Video" },
                    { 2, "Article material description", "Article" },
                    { 3, "Excercise material description", "Excercise" },
                    { 4, "Audio material description", "Audio" }
                });

            migrationBuilder.InsertData(
                table: "EduMaterials",
                columns: new[] { "Id", "AuthorId", "Description", "EduMaterialTypeId", "Location", "PublishDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, "EF Core educational material description.", 1, "www.wikipedia.com", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EF Core" },
                    { 2, 1, "EF Core educational material description.", 2, "www.wikipedia.com", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EF Core" },
                    { 3, 2, "Bike riding educational material description.", 3, "www.wikipedia.com", new DateTime(2011, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bike riding" },
                    { 4, 3, "Design Patterns educational material description.", 4, "www.wikipedia.com", new DateTime(2020, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Design Patterns" },
                    { 5, 4, "Origami Master educational material description.", 1, "www.wikipedia.com", new DateTime(1911, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Origami Master" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "EduMaterialId", "ReviewDescription", "ReviewPoints" },
                values: new object[,]
                {
                    { 1, 1, "This is some review", 6 },
                    { 2, 1, "This is some review", 7 },
                    { 3, 1, "This is some review", 5 },
                    { 4, 1, "This is some review", 6 },
                    { 5, 1, "This is some review", 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EduMaterials_AuthorId",
                table: "EduMaterials",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_EduMaterials_EduMaterialTypeId",
                table: "EduMaterials",
                column: "EduMaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_EduMaterialId",
                table: "Reviews",
                column: "EduMaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "EduMaterials");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "EduMaterialTypes");
        }
    }
}

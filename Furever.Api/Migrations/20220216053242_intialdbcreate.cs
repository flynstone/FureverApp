using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Furever.Api.Migrations
{
    public partial class intialdbcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Species = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Refuges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refuges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    RefugeId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Refuges_RefugeId",
                        column: x => x.RefugeId,
                        principalTable: "Refuges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => new { x.AnimalId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Favorites_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    IsMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    PublicId = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photo_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Species" },
                values: new object[] { 1, "Dogs" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Species" },
                values: new object[] { 2, "Cats" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Species" },
                values: new object[] { 3, "Birds" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Species" },
                values: new object[] { 4, "Reptiles" });

            migrationBuilder.InsertData(
                table: "Refuges",
                columns: new[] { "Id", "Address", "City", "Email", "FirstName", "LastName", "Phone", "Username" },
                values: new object[] { 1, "123 Fake Avenue", "Ottawa", "owner@test.com", "Owner", "Test", null, "Testing" });

            migrationBuilder.InsertData(
                table: "Refuges",
                columns: new[] { "Id", "Address", "City", "Email", "FirstName", "LastName", "Phone", "Username" },
                values: new object[] { 2, "123 Fake Street", "Montreal", "test@owner.com", "Test", "Owner", null, "Guest_01" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 1, "Test", "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 2, "User", "Test" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedDate", "Description", "IsAvailable", "Name", "RefugeId" },
                values: new object[] { 1, 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2 year old, Female, Cavalier King Charles Spaniel", true, "Daisy", 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedDate", "Description", "IsAvailable", "Name", "RefugeId" },
                values: new object[] { 18, 0, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4 month old, Male, Black and White Kitten", true, "Oreo", 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedDate", "Description", "IsAvailable", "Name", "RefugeId" },
                values: new object[] { 17, 0, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7 month old, Male, Gray Kitten", true, "Ollie", 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedDate", "Description", "IsAvailable", "Name", "RefugeId" },
                values: new object[] { 16, 0, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3 month old, Female, Orange Tabby", true, "Lulu", 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedDate", "Description", "IsAvailable", "Name", "RefugeId" },
                values: new object[] { 15, 0, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4 month old, Female, White Kitten", true, "Lucy", 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedDate", "Description", "IsAvailable", "Name", "RefugeId" },
                values: new object[] { 14, 5, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5 year old, Male, Gray Short Hair", true, "Jax", 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedDate", "Description", "IsAvailable", "Name", "RefugeId" },
                values: new object[] { 13, 6, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6 year old, Female, Short Hair", true, "Jade", 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedDate", "Description", "IsAvailable", "Name", "RefugeId" },
                values: new object[] { 12, 0, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5 month old, Male, Tri-Color Short Hair, Kitten", true, "Binx", 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedDate", "Description", "IsAvailable", "Name", "RefugeId" },
                values: new object[] { 11, 7, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7 year old, Female, Gray & White Maine Coon", true, "Abby", 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedDate", "Description", "IsAvailable", "Name", "RefugeId" },
                values: new object[] { 10, 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5 month old, Female, Yorkshire Terrier", true, "Zoe", 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedDate", "Description", "IsAvailable", "Name", "RefugeId" },
                values: new object[] { 9, 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6 month old, Male, German Sheppard", true, "Rocky", 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedDate", "Description", "IsAvailable", "Name", "RefugeId" },
                values: new object[] { 8, 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6 month old, Brother and Sister, Labrador Retrievers", true, "Molly and Toby", 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedDate", "Description", "IsAvailable", "Name", "RefugeId" },
                values: new object[] { 7, 4, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4 year old, Male, Pug", true, "Milo", 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedDate", "Description", "IsAvailable", "Name", "RefugeId" },
                values: new object[] { 6, 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2 year old, Female, Siberian Husky", true, "Luna", 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedDate", "Description", "IsAvailable", "Name", "RefugeId" },
                values: new object[] { 5, 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3 year old, Male, Corgi", true, "Kobe", 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedDate", "Description", "IsAvailable", "Name", "RefugeId" },
                values: new object[] { 4, 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4 month old, Male, Maltese", true, "Jasper", 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedDate", "Description", "IsAvailable", "Name", "RefugeId" },
                values: new object[] { 3, 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3 year old, Male, Boxer", true, "Gus", 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedDate", "Description", "IsAvailable", "Name", "RefugeId" },
                values: new object[] { 2, 4, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4 year old, Male, German Sheppard", true, "Duke", 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedDate", "Description", "IsAvailable", "Name", "RefugeId" },
                values: new object[] { 19, 0, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3 month old, Female, Gray and White Kitten", true, "Rosie", 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedDate", "Description", "IsAvailable", "Name", "RefugeId" },
                values: new object[] { 20, 8, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8 year old, Male, Orange and Gray Short Hair", true, "Simba", 1 });

            migrationBuilder.InsertData(
                table: "Favorites",
                columns: new[] { "AnimalId", "UserId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "Favorites",
                columns: new[] { "AnimalId", "UserId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "Favorites",
                columns: new[] { "AnimalId", "UserId" },
                values: new object[] { 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CategoryId",
                table: "Animals",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_RefugeId",
                table: "Animals",
                column: "RefugeId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_AnimalId",
                table: "Photo",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_UserId",
                table: "Photo",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Refuges");
        }
    }
}

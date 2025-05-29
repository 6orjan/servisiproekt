using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ISExam.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    BoxOfficeEarnings = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    MembershipCardNumber = table.Column<int>(type: "int", nullable: false),
                    MembershipValidityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "BoxOfficeEarnings", "Director", "Genre", "Name", "Rating", "Year" },
                values: new object[,]
                {
                    { 1, 15000f, "Director for Movie 1", "Comedy", "Movie 1", 4.5f, 2025 },
                    { 2, 500f, "Director for Movie 2", "Drama", "Movie 2", 1.5f, 2015 }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "DOB", "FirstName", "LastName", "MembershipCardNumber", "MembershipValidityDate", "MovieId", "RentDate", "ReturnDate" },
                values: new object[,]
                {
                    { 1, "Street 1, Number 20B", new DateTime(2002, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blagoja", "Blazhevski", 1234, new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2025, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Street 5, Number 63A", new DateTime(1991, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", "Testovski", 4567, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_MovieId",
                table: "Clients",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}

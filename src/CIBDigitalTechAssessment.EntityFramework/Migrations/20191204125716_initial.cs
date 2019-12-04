using System;
using CIBDigitalTechAssessment.Abstractions.Extensions;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CIBDigitalTechAssessment.EntityFramework.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE SCHEMA History");
            
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });
            migrationBuilder.AddTemporalTableSupport("People", "History");
            
            migrationBuilder.CreateTable(
                name: "PhoneBookEntries",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PersonId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneBookEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneBookEntries_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AddTemporalTableSupport("PhoneBookEntries", "History");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneBookEntries_PersonId",
                table: "PhoneBookEntries",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneBookEntries");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}

using CIBDigitalTechAssessment.EntityFramework.Views;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CIBDigitalTechAssessment.EntityFramework.Migrations
{
    public partial class viewphonebookenteriesmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(sql: view_PhoneBookEntries.Create);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(sql: view_PhoneBookEntries.Drop);
        }
    }
}

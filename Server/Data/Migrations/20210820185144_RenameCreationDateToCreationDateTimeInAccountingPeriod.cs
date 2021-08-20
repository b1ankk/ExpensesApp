using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpensesApp.Server.Data.Migrations
{
    public partial class RenameCreationDateToCreationDateTimeInAccountingPeriod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "creation_date",
                table: "accounting_periods",
                newName: "creation_date_time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "creation_date_time",
                table: "accounting_periods",
                newName: "creation_date");
        }
    }
}

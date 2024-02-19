using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calendar.Migrations
{
    public partial class Initcalendar2efois : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Calendars_ConsultantId",
                table: "Calendars",
                column: "ConsultantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_Consultants_ConsultantId",
                table: "Calendars",
                column: "ConsultantId",
                principalTable: "Consultants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_Consultants_ConsultantId",
                table: "Calendars");

            migrationBuilder.DropIndex(
                name: "IX_Calendars_ConsultantId",
                table: "Calendars");
        }
    }
}

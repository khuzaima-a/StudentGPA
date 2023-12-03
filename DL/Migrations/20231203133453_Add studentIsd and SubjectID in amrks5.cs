using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DL.Migrations
{
    public partial class AddstudentIsdandSubjectIDinamrks5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_markDbDto",
                table: "markDbDto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_markDbDto",
                table: "markDbDto",
                columns: new[] { "SID", "SubjectId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_markDbDto",
                table: "markDbDto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_markDbDto",
                table: "markDbDto",
                column: "Id");
        }
    }
}

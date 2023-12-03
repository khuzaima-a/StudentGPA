using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_markDbDto_studentSubjectDbDto_SID_SubjectId",
                table: "markDbDto");

            migrationBuilder.AddForeignKey(
                name: "FK_markDbDto_studentSubjectDbDto_SID_SubjectId",
                table: "markDbDto",
                columns: new[] { "SID", "SubjectId" },
                principalTable: "studentSubjectDbDto",
                principalColumns: new[] { "SID", "SubjectId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_markDbDto_studentSubjectDbDto_SID_SubjectId",
                table: "markDbDto");

            migrationBuilder.AddForeignKey(
                name: "FK_markDbDto_studentSubjectDbDto_SID_SubjectId",
                table: "markDbDto",
                columns: new[] { "SID", "SubjectId" },
                principalTable: "studentSubjectDbDto",
                principalColumns: new[] { "SID", "SubjectId" });
        }
    }
}

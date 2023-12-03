using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DL.Migrations
{
    public partial class AddstudentIsdandSubjectIDinamrks6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_markDbDto_studentSubjectDbDto_SubjectId",
                table: "markDbDto");

            migrationBuilder.DropIndex(
                name: "IX_studentSubjectDbDto_SID",
                table: "studentSubjectDbDto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_markDbDto",
                table: "markDbDto");

            migrationBuilder.DropIndex(
                name: "IX_markDbDto_SubjectId",
                table: "markDbDto");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_studentSubjectDbDto_SID_SubjectId",
                table: "studentSubjectDbDto",
                columns: new[] { "SID", "SubjectId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_markDbDto",
                table: "markDbDto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_markDbDto_studentSubjectDbDto_SID_SubjectId",
                table: "markDbDto",
                columns: new[] { "SID", "SubjectId" },
                principalTable: "studentSubjectDbDto",
                principalColumns: new[] { "SID", "SubjectId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_markDbDto_studentSubjectDbDto_SID_SubjectId",
                table: "markDbDto");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_studentSubjectDbDto_SID_SubjectId",
                table: "studentSubjectDbDto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_markDbDto",
                table: "markDbDto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_markDbDto",
                table: "markDbDto",
                columns: new[] { "SID", "SubjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_studentSubjectDbDto_SID",
                table: "studentSubjectDbDto",
                column: "SID");

            migrationBuilder.CreateIndex(
                name: "IX_markDbDto_SubjectId",
                table: "markDbDto",
                column: "SubjectId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_markDbDto_studentSubjectDbDto_SubjectId",
                table: "markDbDto",
                column: "SubjectId",
                principalTable: "studentSubjectDbDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

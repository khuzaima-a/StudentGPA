using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DL.Migrations
{
    public partial class StudentInital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "studentDbDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RollNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentDbDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subjectDbDto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditHour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjectDbDto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "studentSubjectDbDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SID = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentSubjectDbDto", x => x.Id);
                    table.UniqueConstraint("AK_studentSubjectDbDto_SID_SubjectId", x => new { x.SID, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_studentSubjectDbDto_studentDbDto_SID",
                        column: x => x.SID,
                        principalTable: "studentDbDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentSubjectDbDto_subjectDbDto_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subjectDbDto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "markDbDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SID = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Marks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_markDbDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_markDbDto_studentSubjectDbDto_SID_SubjectId",
                        columns: x => new { x.SID, x.SubjectId },
                        principalTable: "studentSubjectDbDto",
                        principalColumns: new[] { "SID", "SubjectId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_markDbDto_SID_SubjectId",
                table: "markDbDto",
                columns: new[] { "SID", "SubjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_studentSubjectDbDto_SubjectId",
                table: "studentSubjectDbDto",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "markDbDto");

            migrationBuilder.DropTable(
                name: "studentSubjectDbDto");

            migrationBuilder.DropTable(
                name: "studentDbDto");

            migrationBuilder.DropTable(
                name: "subjectDbDto");
        }
    }
}

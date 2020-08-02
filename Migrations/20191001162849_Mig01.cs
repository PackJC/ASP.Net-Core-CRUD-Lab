using Microsoft.EntityFrameworkCore.Migrations;

namespace LabW06StudentGrades.Migrations
{
    public partial class Mig01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 4, nullable: false),
                    Number = table.Column<string>(maxLength: 4, nullable: false),
                    CreditHours = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => new { x.Code, x.Number });
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ENumber = table.Column<string>(maxLength: 9, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ENumber);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourseGrades",
                columns: table => new
                {
                    StudentENumber = table.Column<string>(maxLength: 9, nullable: false),
                    CourseCode = table.Column<string>(maxLength: 4, nullable: false),
                    CourseNumber = table.Column<string>(maxLength: 4, nullable: false),
                    LetterGrade = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourseGrades", x => new { x.StudentENumber, x.CourseCode, x.CourseNumber });
                    table.ForeignKey(
                        name: "FK_StudentCourseGrades_Students_StudentENumber",
                        column: x => x.StudentENumber,
                        principalTable: "Students",
                        principalColumn: "ENumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourseGrades_Courses_CourseCode_CourseNumber",
                        columns: x => new { x.CourseCode, x.CourseNumber },
                        principalTable: "Courses",
                        principalColumns: new[] { "Code", "Number" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseGrades_CourseCode_CourseNumber",
                table: "StudentCourseGrades",
                columns: new[] { "CourseCode", "CourseNumber" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourseGrades");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}

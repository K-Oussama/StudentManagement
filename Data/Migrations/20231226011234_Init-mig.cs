using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagmentSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    module_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    module_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    module_level = table.Column<int>(type: "int", nullable: true),
                    passed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.module_id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    student_lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    student_email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    year_level = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.student_id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    course_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    course_hours = table.Column<int>(type: "int", nullable: true),
                    taught_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.course_id);
                    table.ForeignKey(
                        name: "FK_Course_Module_module_id",
                        column: x => x.module_id,
                        principalTable: "Module",
                        principalColumn: "module_id");
                });

            migrationBuilder.CreateTable(
                name: "Evaluation",
                columns: table => new
                {
                    evaluation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_id = table.Column<int>(type: "int", nullable: true),
                    student_id = table.Column<int>(type: "int", nullable: true),
                    evaluation_type = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    score = table.Column<decimal>(type: "decimal(4,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluation", x => x.evaluation_id);
                    table.ForeignKey(
                        name: "FK_Evaluation_Course_course_id",
                        column: x => x.course_id,
                        principalTable: "Course",
                        principalColumn: "course_id");
                    table.ForeignKey(
                        name: "FK_Evaluation_Student_student_id",
                        column: x => x.student_id,
                        principalTable: "Student",
                        principalColumn: "student_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_module_id",
                table: "Course",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_course_id",
                table: "Evaluation",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_student_id",
                table: "Evaluation",
                column: "student_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluation");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Module");
        }
    }
}

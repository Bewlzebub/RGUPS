using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab10_ASP.Migrations
{
    /// <inheritdoc />
    public partial class TestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Кафедры",
                columns: table => new
                {
                    код_кафедры = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    название = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    факультет = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    фио_заведующего = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    номер_комнаты = table.Column<int>(type: "int", nullable: false),
                    номер_корпуса = table.Column<int>(type: "int", nullable: false),
                    телефон = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    кол_во_преподавателей = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Кафедры", x => x.код_кафедры);
                });

            migrationBuilder.CreateTable(
                name: "Преподаватели",
                columns: table => new
                {
                    код_преподавателя = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    фамилия = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    имя = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    отчество = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    кафедра = table.Column<int>(type: "int", nullable: false),
                    год_рождения = table.Column<int>(type: "int", nullable: false),
                    год_поступления = table.Column<int>(type: "int", nullable: false),
                    стаж = table.Column<int>(type: "int", nullable: false),
                    должность = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    пол = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: false),
                    адрес = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    город = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    телефон = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Преподаватели", x => x.код_преподавателя);
                    table.ForeignKey(
                        name: "FK_Преподаватели_Кафедры",
                        column: x => x.кафедра,
                        principalTable: "Кафедры",
                        principalColumn: "код_кафедры");
                });

            migrationBuilder.CreateTable(
                name: "Студенты",
                columns: table => new
                {
                    код_студента = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    фамилия = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    имя = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    отчество = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    кафедра = table.Column<int>(type: "int", nullable: false),
                    год_рождения = table.Column<int>(type: "int", nullable: false),
                    пол = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: false),
                    адрес = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    город = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    телефон = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Студенты", x => x.код_студента);
                    table.ForeignKey(
                        name: "FK_Студенты_Кафедры",
                        column: x => x.кафедра,
                        principalTable: "Кафедры",
                        principalColumn: "код_кафедры");
                });

            migrationBuilder.CreateTable(
                name: "Дисциплины",
                columns: table => new
                {
                    код_дисциплины = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    название = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    кафедра = table.Column<int>(type: "int", nullable: false),
                    преподаватель = table.Column<int>(type: "int", nullable: false),
                    кол_во_часов = table.Column<int>(type: "int", nullable: false),
                    вид_контроля = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Дисциплины", x => x.код_дисциплины);
                    table.ForeignKey(
                        name: "FK_Дисциплины_Кафедры",
                        column: x => x.кафедра,
                        principalTable: "Кафедры",
                        principalColumn: "код_кафедры");
                    table.ForeignKey(
                        name: "FK_Дисциплины_Преподаватели",
                        column: x => x.преподаватель,
                        principalTable: "Преподаватели",
                        principalColumn: "код_преподавателя");
                });

            migrationBuilder.CreateTable(
                name: "Ведомости",
                columns: table => new
                {
                    код_записи = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    преподаватель = table.Column<int>(type: "int", nullable: false),
                    дисциплина = table.Column<int>(type: "int", nullable: false),
                    студент = table.Column<int>(type: "int", nullable: false),
                    оценка = table.Column<int>(type: "int", nullable: false),
                    дата_сдачи = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ведомости", x => x.код_записи);
                    table.ForeignKey(
                        name: "FK_Ведомости_Дисциплины",
                        column: x => x.дисциплина,
                        principalTable: "Дисциплины",
                        principalColumn: "код_дисциплины");
                    table.ForeignKey(
                        name: "FK_Ведомости_Преподаватели",
                        column: x => x.преподаватель,
                        principalTable: "Преподаватели",
                        principalColumn: "код_преподавателя");
                    table.ForeignKey(
                        name: "FK_Ведомости_Студенты",
                        column: x => x.студент,
                        principalTable: "Студенты",
                        principalColumn: "код_студента");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ведомости_дисциплина",
                table: "Ведомости",
                column: "дисциплина");

            migrationBuilder.CreateIndex(
                name: "IX_Ведомости_преподаватель",
                table: "Ведомости",
                column: "преподаватель");

            migrationBuilder.CreateIndex(
                name: "IX_Ведомости_студент",
                table: "Ведомости",
                column: "студент");

            migrationBuilder.CreateIndex(
                name: "IX_Дисциплины_кафедра",
                table: "Дисциплины",
                column: "кафедра");

            migrationBuilder.CreateIndex(
                name: "IX_Дисциплины_преподаватель",
                table: "Дисциплины",
                column: "преподаватель");

            migrationBuilder.CreateIndex(
                name: "IX_Преподаватели_кафедра",
                table: "Преподаватели",
                column: "кафедра");

            migrationBuilder.CreateIndex(
                name: "IX_Студенты_кафедра",
                table: "Студенты",
                column: "кафедра");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ведомости");

            migrationBuilder.DropTable(
                name: "Дисциплины");

            migrationBuilder.DropTable(
                name: "Студенты");

            migrationBuilder.DropTable(
                name: "Преподаватели");

            migrationBuilder.DropTable(
                name: "Кафедры");
        }
    }
}

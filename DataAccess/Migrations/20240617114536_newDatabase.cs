using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    UserGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImageByte = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ConfirmValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsConfirm = table.Column<bool>(type: "bit", nullable: false),
                    ForgotPasswordValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ForgotPasswordRequestDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsForgotPasswordComplete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.UserGuidId);
                });

            migrationBuilder.CreateTable(
                name: "Competencies",
                columns: table => new
                {
                    CompetencyGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencies", x => x.CompetencyGuidId);
                });

            migrationBuilder.CreateTable(
                name: "EmailParameters",
                columns: table => new
                {
                    EmailParameterGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Smtp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Port = table.Column<int>(type: "int", nullable: false),
                    SSL = table.Column<bool>(type: "bit", nullable: false),
                    Html = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailParameters", x => x.EmailParameterGuidId);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    HolidayGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HolidayFirstDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    HolidayFinishDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    HolidayName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.HolidayGuidId);
                });

            migrationBuilder.CreateTable(
                name: "JobDepartments",
                columns: table => new
                {
                    JobDepartmentGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDepartments", x => x.JobDepartmentGuidId);
                });

            migrationBuilder.CreateTable(
                name: "Loggings",
                columns: table => new
                {
                    LoggingGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogError = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogDebug = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loggings", x => x.LoggingGuidId);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    OperationClaimGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationClaimName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.OperationClaimGuidId);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    SettingsGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MontHour = table.Column<int>(type: "int", nullable: false),
                    WeekHour = table.Column<int>(type: "int", nullable: false),
                    DayHour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.SettingsGuidId);
                });

            migrationBuilder.CreateTable(
                name: "JobUnits",
                columns: table => new
                {
                    JobUnitGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobDepartmentGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobUnitName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobUnits", x => x.JobUnitGuidId);
                    table.ForeignKey(
                        name: "FK_JobUnits_JobDepartments_JobDepartmentGuidId",
                        column: x => x.JobDepartmentGuidId,
                        principalTable: "JobDepartments",
                        principalColumn: "JobDepartmentGuidId");
                });

            migrationBuilder.CreateTable(
                name: "OperationCompetencies",
                columns: table => new
                {
                    OperationCompetencyGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationClaimGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompetencyGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationCompetencies", x => x.OperationCompetencyGuidId);
                    table.ForeignKey(
                        name: "FK_OperationCompetencies_Competencies_CompetencyGuidId",
                        column: x => x.CompetencyGuidId,
                        principalTable: "Competencies",
                        principalColumn: "CompetencyGuidId");
                    table.ForeignKey(
                        name: "FK_OperationCompetencies_OperationClaims_OperationClaimGuidId",
                        column: x => x.OperationClaimGuidId,
                        principalTable: "OperationClaims",
                        principalColumn: "OperationClaimGuidId");
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    UserOperationClaimGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationClaimGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.UserOperationClaimGuidId);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_AppUser_UserGuidId",
                        column: x => x.UserGuidId,
                        principalTable: "AppUser",
                        principalColumn: "UserGuidId");
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimGuidId",
                        column: x => x.OperationClaimGuidId,
                        principalTable: "OperationClaims",
                        principalColumn: "OperationClaimGuidId");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImageByte = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    StudentNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Faculty = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FacultyDepartment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StudentClass = table.Column<int>(type: "int", nullable: false),
                    JobUnitGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentGuidId);
                    table.ForeignKey(
                        name: "FK_Students_JobUnits_JobUnitGuidId",
                        column: x => x.JobUnitGuidId,
                        principalTable: "JobUnits",
                        principalColumn: "JobUnitGuidId");
                });

            migrationBuilder.CreateTable(
                name: "UserJobUnits",
                columns: table => new
                {
                    UserJobUnitGuidId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    UserGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobUnitGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJobUnits", x => x.UserJobUnitGuidId);
                    table.ForeignKey(
                        name: "FK_UserJobUnits_AppUser_UserGuidId",
                        column: x => x.UserGuidId,
                        principalTable: "AppUser",
                        principalColumn: "UserGuidId");
                    table.ForeignKey(
                        name: "FK_UserJobUnits_JobUnits_JobUnitGuidId",
                        column: x => x.JobUnitGuidId,
                        principalTable: "JobUnits",
                        principalColumn: "JobUnitGuidId");
                });

            migrationBuilder.CreateTable(
                name: "Syllabus",
                columns: table => new
                {
                    SyllabusGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Syllabus", x => x.SyllabusGuidId);
                    table.ForeignKey(
                        name: "FK_Syllabus_Students_StudentGuidId",
                        column: x => x.StudentGuidId,
                        principalTable: "Students",
                        principalColumn: "StudentGuidId");
                });

            migrationBuilder.CreateTable(
                name: "Tallies",
                columns: table => new
                {
                    TallyGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountHour = table.Column<int>(type: "int", nullable: false),
                    StudentGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tallies", x => x.TallyGuidId);
                    table.ForeignKey(
                        name: "FK_Tallies_Students_StudentGuidId",
                        column: x => x.StudentGuidId,
                        principalTable: "Students",
                        principalColumn: "StudentGuidId");
                });

            migrationBuilder.CreateTable(
                name: "WeekTallies",
                columns: table => new
                {
                    WeekTallyGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeekDate = table.Column<int>(type: "int", nullable: false),
                    WeekNumber = table.Column<int>(type: "int", nullable: false),
                    FirstDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CountHour = table.Column<int>(type: "int", nullable: false),
                    StudentGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekTallies", x => x.WeekTallyGuidId);
                    table.ForeignKey(
                        name: "FK_WeekTallies_Students_StudentGuidId",
                        column: x => x.StudentGuidId,
                        principalTable: "Students",
                        principalColumn: "StudentGuidId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobUnits_JobDepartmentGuidId",
                table: "JobUnits",
                column: "JobDepartmentGuidId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationCompetencies_CompetencyGuidId",
                table: "OperationCompetencies",
                column: "CompetencyGuidId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationCompetencies_OperationClaimGuidId",
                table: "OperationCompetencies",
                column: "OperationClaimGuidId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_JobUnitGuidId",
                table: "Students",
                column: "JobUnitGuidId");

            migrationBuilder.CreateIndex(
                name: "IX_Syllabus_StudentGuidId",
                table: "Syllabus",
                column: "StudentGuidId");

            migrationBuilder.CreateIndex(
                name: "IX_Tallies_StudentGuidId",
                table: "Tallies",
                column: "StudentGuidId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJobUnits_JobUnitGuidId",
                table: "UserJobUnits",
                column: "JobUnitGuidId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJobUnits_UserGuidId",
                table: "UserJobUnits",
                column: "UserGuidId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimGuidId",
                table: "UserOperationClaims",
                column: "OperationClaimGuidId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserGuidId",
                table: "UserOperationClaims",
                column: "UserGuidId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekTallies_StudentGuidId",
                table: "WeekTallies",
                column: "StudentGuidId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailParameters");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "Loggings");

            migrationBuilder.DropTable(
                name: "OperationCompetencies");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Syllabus");

            migrationBuilder.DropTable(
                name: "Tallies");

            migrationBuilder.DropTable(
                name: "UserJobUnits");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "WeekTallies");

            migrationBuilder.DropTable(
                name: "Competencies");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "JobUnits");

            migrationBuilder.DropTable(
                name: "JobDepartments");
        }
    }
}

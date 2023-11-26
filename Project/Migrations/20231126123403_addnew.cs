using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class addnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Department_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Department_Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusApplicants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusApplicants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusInterviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusInterviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusVacancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusVacancies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Departments_Department_Id",
                        column: x => x.Department_Id,
                        principalTable: "Departments",
                        principalColumn: "Department_Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Employeecode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Departments_Department_Id",
                        column: x => x.Department_Id,
                        principalTable: "Departments",
                        principalColumn: "Department_Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Vacancy_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Hr_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Position_Id = table.Column<int>(type: "int", nullable: false),
                    StatusVacancy_Id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Requirement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Benefits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.Vacancy_Id);
                    table.ForeignKey(
                        name: "FK_Vacancies_Positions_Position_Id",
                        column: x => x.Position_Id,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacancies_StatusVacancies_StatusVacancy_Id",
                        column: x => x.StatusVacancy_Id,
                        principalTable: "StatusVacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacancies_Users_Hr_Id",
                        column: x => x.Hr_Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicantsVacancies",
                columns: table => new
                {
                    ApplicantVacancy_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Vacancy_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Applicant_Id = table.Column<int>(type: "int", nullable: true),
                    Hr_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StatusApplicant_Id = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantsVacancies", x => x.ApplicantVacancy_Id);
                    table.ForeignKey(
                        name: "FK_ApplicantsVacancies_Applicants_Applicant_Id",
                        column: x => x.Applicant_Id,
                        principalTable: "Applicants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicantsVacancies_StatusApplicants_StatusApplicant_Id",
                        column: x => x.StatusApplicant_Id,
                        principalTable: "StatusApplicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantsVacancies_Users_Hr_Id",
                        column: x => x.Hr_Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicantsVacancies_Vacancies_Vacancy_Id",
                        column: x => x.Vacancy_Id,
                        principalTable: "Vacancies",
                        principalColumn: "Vacancy_Id");
                });

            migrationBuilder.CreateTable(
                name: "VacanciesJobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vacancy_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Job_Id = table.Column<int>(type: "int", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacanciesJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacanciesJobs_Jobs_Job_Id",
                        column: x => x.Job_Id,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VacanciesJobs_Vacancies_Vacancy_Id",
                        column: x => x.Vacancy_Id,
                        principalTable: "Vacancies",
                        principalColumn: "Vacancy_Id");
                });

            migrationBuilder.CreateTable(
                name: "InterviewsVacancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusInterview_Id = table.Column<int>(type: "int", nullable: false),
                    ApplicantVacancy_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Interview_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewsVacancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterviewsVacancies_ApplicantsVacancies_ApplicantVacancy_Id",
                        column: x => x.ApplicantVacancy_Id,
                        principalTable: "ApplicantsVacancies",
                        principalColumn: "ApplicantVacancy_Id");
                    table.ForeignKey(
                        name: "FK_InterviewsVacancies_StatusInterviews_StatusInterview_Id",
                        column: x => x.StatusInterview_Id,
                        principalTable: "StatusInterviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterviewsVacancies_Users_Interview_Id",
                        column: x => x.Interview_Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Applicants",
                columns: new[] { "Id", "Birthday", "Created_at", "District", "Email", "Fullname", "Image", "Password", "Phone", "Province", "Updated_at", "Ward" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8013), "City of Westminster", "user1@example.com", "James Smith", "assets\\client\\img\\img-applicant\\default-image-applicant.png", "Abc12345678", "1234567890", "Greater London", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Westminster" },
                    { 2, new DateTime(1995, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8016), "Manchester City", "user2@example.com", "Sarah Johnson", "assets\\client\\img\\img-applicant\\default-image-applicant.png", "Abc12345678", "2345678901", "Greater Manchester", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City Centre" },
                    { 3, new DateTime(1985, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8019), "Birmingham City Centre", "user3@example.com", "David Williams", "assets\\client\\img\\img-applicant\\default-image-applicant.png", "Abc12345678", "3456789012", "West Midlands", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ladywood" },
                    { 4, new DateTime(1980, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8022), "Liverpool City Centre", "user4@example.com", "Emma Brown", "assets\\client\\img\\img-applicant\\default-image-applicant.png", "Abc12345678", "4567890123", "Merseyside", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Riverside" },
                    { 5, new DateTime(1992, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8026), "Leeds City Centre", "user5@example.com", "John Jones", "assets\\client\\img\\img-applicant\\default-image-applicant.png", "Abc12345678", "5678901234", "West Yorkshire", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City Centre" },
                    { 6, new DateTime(1978, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8029), "Bristol City Centre", "user6@example.com", "Lucy Taylor", "assets\\client\\img\\img-applicant\\default-image-applicant.png", "Abc12345678", "6789012345", "Bristol", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central" },
                    { 7, new DateTime(1988, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8082), "Sheffield City Centre", "user7@example.com", "Michael Davies", "assets\\client\\img\\img-applicant\\default-image-applicant.png", "Abc12345678", "7890123456", "South Yorkshire", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City Centre" },
                    { 8, new DateTime(1998, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8086), "Newcastle City Centre", "user8@example.com", "Olivia Wilson", "assets\\client\\img\\img-applicant\\default-image-applicant.png", "Abc12345678", "8901234567", "Tyne and Wear", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ouseburn" },
                    { 9, new DateTime(1983, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8089), "Nottingham City Centre", "user9@example.com", "Thomas Evans", "assets\\client\\img\\img-applicant\\default-image-applicant.png", "Abc12345678", "9012345678", "Nottinghamshire", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bridge" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Department_Id", "Created_at", "Name", "Updated_at" },
                values: new object[,]
                {
                    { "D0001", new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(7835), "Information Technology", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D0002", new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(7846), "Desgin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D0003", new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(7848), "Marketing", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Created_at", "Name", "Updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8162), "Intern", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8163), "Fresher", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8165), "Junior", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8167), "Senior", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8169), "Leader", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "StatusApplicants",
                columns: new[] { "Id", "Created_at", "Name", "Updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8196), "Not Process", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8198), "In Process", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8199), "Hired", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8201), "Banned", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "StatusInterviews",
                columns: new[] { "Id", "Created_at", "Name", "Updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8242), "Processing", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8244), "Scheduled", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8245), "Selected", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8247), "Rejected", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "StatusVacancies",
                columns: new[] { "Id", "Created_at", "Name", "Updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8220), "Open", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8221), "Close", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8223), "Suspended", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Created_at", "Department_Id", "Name", "Updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8121), "D0001", "C#", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8123), "D0001", "Java", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8125), "D0001", "PHP", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8127), "D0002", "Adobe Creative Suite", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8128), "D0002", "Sketch", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8130), "D0002", "Figma", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8132), "D0003", "Google Analytics", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8134), "D0003", "SEO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8136), "D0003", "Google AdWords , Facebook Ads", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Vacancies",
                columns: new[] { "Vacancy_Id", "Benefits", "Created_at", "Description", "EndDate", "Hr_Id", "Place", "Position_Id", "Quantity", "Requirement", "Salary", "StatusVacancy_Id", "Title", "Updated_at" },
                values: new object[,]
                {
                    { "V0001", "Benefits", new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8276), "Description", new DateTime(2023, 12, 6, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8270), null, "America", 1, 5, "Requirement", 2000, 1, "Title", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "V0002", "Benefits", new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8280), "Description", new DateTime(2023, 12, 6, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8279), null, "America", 2, 4, "Requirement", 7000, 1, "Title", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "V0003", "Benefits", new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8284), "Description", new DateTime(2023, 12, 6, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8283), null, "America", 3, 3, "Requirement", 10000, 1, "Title", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "V0004", "Benefits", new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8288), "Description", new DateTime(2023, 12, 6, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8287), null, "America", 4, 2, "Requirement", 13000, 1, "Title", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "V0005", "Benefits", new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8292), "Description", new DateTime(2023, 12, 6, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8291), null, "America", 5, 1, "Requirement", 15000, 1, "Title", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ApplicantsVacancies",
                columns: new[] { "ApplicantVacancy_Id", "Applicant_Id", "Created_at", "Hr_Id", "StatusApplicant_Id", "Updated_at", "Vacancy_Id" },
                values: new object[,]
                {
                    { "A0001", 1, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8366), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0001" },
                    { "A0002", 2, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8368), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0002" },
                    { "A0003", 3, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8370), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0003" },
                    { "A0004", 4, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8372), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0004" },
                    { "A0005", 5, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8374), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0005" },
                    { "A0006", 6, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8376), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0001" },
                    { "A0007", 7, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8378), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0002" },
                    { "A0008", 8, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8380), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0003" },
                    { "A0009", 9, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8382), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0004" }
                });

            migrationBuilder.InsertData(
                table: "VacanciesJobs",
                columns: new[] { "Id", "Created_at", "Job_Id", "Updated_at", "Vacancy_Id" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8315), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0001" },
                    { 2, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8317), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0001" },
                    { 3, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8319), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0001" },
                    { 4, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8321), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0002" },
                    { 5, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8323), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0002" },
                    { 6, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8325), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0002" },
                    { 7, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8327), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0003" },
                    { 8, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8328), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0003" },
                    { 9, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8330), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0003" },
                    { 10, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8332), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0004" },
                    { 11, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8334), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0004" },
                    { 12, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8336), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0004" },
                    { 13, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8338), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0005" },
                    { 14, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8340), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0005" },
                    { 15, new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8342), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0005" }
                });

            migrationBuilder.InsertData(
                table: "InterviewsVacancies",
                columns: new[] { "Id", "ApplicantVacancy_Id", "Created_at", "EndDate", "Interview_Id", "StartDate", "StatusInterview_Id", "Updated_at" },
                values: new object[,]
                {
                    { 1, "A0001", new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8450), null, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "A0002", new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8452), null, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "A0003", new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8454), null, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "A0004", new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8456), null, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "A0001", new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8458), null, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "A0002", new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8459), null, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "A0003", new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8461), null, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "A0004", new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8463), null, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "A0005", new DateTime(2023, 11, 26, 19, 34, 3, 461, DateTimeKind.Local).AddTicks(8465), null, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantsVacancies_Applicant_Id",
                table: "ApplicantsVacancies",
                column: "Applicant_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantsVacancies_Hr_Id",
                table: "ApplicantsVacancies",
                column: "Hr_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantsVacancies_StatusApplicant_Id",
                table: "ApplicantsVacancies",
                column: "StatusApplicant_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantsVacancies_Vacancy_Id",
                table: "ApplicantsVacancies",
                column: "Vacancy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewsVacancies_ApplicantVacancy_Id",
                table: "InterviewsVacancies",
                column: "ApplicantVacancy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewsVacancies_Interview_Id",
                table: "InterviewsVacancies",
                column: "Interview_Id");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewsVacancies_StatusInterview_Id",
                table: "InterviewsVacancies",
                column: "StatusInterview_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_Department_Id",
                table: "Jobs",
                column: "Department_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Department_Id",
                table: "Users",
                column: "Department_Id");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_Hr_Id",
                table: "Vacancies",
                column: "Hr_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_Position_Id",
                table: "Vacancies",
                column: "Position_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_StatusVacancy_Id",
                table: "Vacancies",
                column: "StatusVacancy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_VacanciesJobs_Job_Id",
                table: "VacanciesJobs",
                column: "Job_Id");

            migrationBuilder.CreateIndex(
                name: "IX_VacanciesJobs_Vacancy_Id",
                table: "VacanciesJobs",
                column: "Vacancy_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterviewsVacancies");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "VacanciesJobs");

            migrationBuilder.DropTable(
                name: "ApplicantsVacancies");

            migrationBuilder.DropTable(
                name: "StatusInterviews");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "StatusApplicants");

            migrationBuilder.DropTable(
                name: "Vacancies");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "StatusVacancies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}

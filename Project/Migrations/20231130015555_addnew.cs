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
                    Department_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Position_Id = table.Column<int>(type: "int", nullable: false),
                    StatusVacancy_Id = table.Column<int>(type: "int", nullable: false),
                    ActualQuantity = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Vacancies_Departments_Department_Id",
                        column: x => x.Department_Id,
                        principalTable: "Departments",
                        principalColumn: "Department_Id");
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vacancy_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Applicant_Id = table.Column<int>(type: "int", nullable: true),
                    Hr_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StatusApplicant_Id = table.Column<int>(type: "int", nullable: false),
                    Attachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantsVacancies", x => x.Id);
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
                    ApplicantVacancy_Id = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "Id");
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
                    { 1, new DateTime(1990, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6661), "City of Westminster", "user1@example.com", "James Smith", "assets\\client\\img\\img-applicant\\default-image-applicant.png", "Abc12345678", "1234567890", "Greater London", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Westminster" },
                    { 2, new DateTime(1995, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6664), "Manchester City", "user2@example.com", "Sarah Johnson", "assets\\client\\img\\img-applicant\\default-image-applicant.png", "Abc12345678", "2345678901", "Greater Manchester", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City Centre" },
                    { 3, new DateTime(1985, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6668), "Birmingham City Centre", "user3@example.com", "David Williams", "assets\\client\\img\\img-applicant\\default-image-applicant.png", "Abc12345678", "3456789012", "West Midlands", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ladywood" },
                    { 4, new DateTime(1980, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6671), "Liverpool City Centre", "user4@example.com", "Emma Brown", "assets\\client\\img\\img-applicant\\default-image-applicant.png", "Abc12345678", "4567890123", "Merseyside", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Riverside" },
                    { 5, new DateTime(1992, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6674), "Leeds City Centre", "user5@example.com", "John Jones", "assets\\client\\img\\img-applicant\\default-image-applicant.png", "Abc12345678", "5678901234", "West Yorkshire", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City Centre" },
                    { 6, new DateTime(1978, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6677), "Bristol City Centre", "user6@example.com", "Lucy Taylor", "assets\\client\\img\\img-applicant\\default-image-applicant.png", "Abc12345678", "6789012345", "Bristol", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central" },
                    { 7, new DateTime(1988, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6680), "Sheffield City Centre", "user7@example.com", "Michael Davies", "assets\\client\\img\\img-applicant\\default-image-applicant.png", "Abc12345678", "7890123456", "South Yorkshire", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City Centre" },
                    { 8, new DateTime(1998, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6683), "Newcastle City Centre", "user8@example.com", "Olivia Wilson", "assets\\client\\img\\img-applicant\\default-image-applicant.png", "Abc12345678", "8901234567", "Tyne and Wear", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ouseburn" },
                    { 9, new DateTime(1983, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6686), "Nottingham City Centre", "user9@example.com", "Thomas Evans", "assets\\client\\img\\img-applicant\\default-image-applicant.png", "Abc12345678", "9012345678", "Nottinghamshire", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bridge" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Department_Id", "Created_at", "Name", "Updated_at" },
                values: new object[,]
                {
                    { "D0001", new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6479), "Information Technology", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D0002", new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6492), "Desgin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D0003", new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6493), "Marketing", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Created_at", "Name", "Updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6808), "Intern", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6810), "Fresher", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6811), "Junior", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6813), "Senior", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6814), "Leader", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "StatusApplicants",
                columns: new[] { "Id", "Created_at", "Name", "Updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6842), "Not Process", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6844), "In Process", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6846), "Hired", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6847), "Banned", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "StatusInterviews",
                columns: new[] { "Id", "Created_at", "Name", "Updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6900), "Processing", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6901), "Scheduled", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6903), "Selected", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6905), "Rejected", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "StatusVacancies",
                columns: new[] { "Id", "Created_at", "Name", "Updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6870), "Open", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6872), "Close", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6873), "Suspended", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Created_at", "Department_Id", "Name", "Updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6763), "D0001", "C#", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6765), "D0001", "Java", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6766), "D0001", "PHP", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6768), "D0002", "Adobe Creative Suite", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6770), "D0002", "Sketch", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6772), "D0002", "Figma", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6773), "D0003", "Google Analytics", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6775), "D0003", "SEO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6777), "D0003", "Google AdWords , Facebook Ads", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Vacancies",
                columns: new[] { "Vacancy_Id", "ActualQuantity", "Benefits", "Created_at", "Department_Id", "Description", "EndDate", "Hr_Id", "Place", "Position_Id", "Quantity", "Requirement", "Salary", "StatusVacancy_Id", "Title", "Updated_at" },
                values: new object[,]
                {
                    { "V0001", 0, "Benefits", new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6936), null, "Description", new DateTime(2023, 12, 10, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6930), null, "America", 1, 13, "Requirement", 2000, 1, "Title", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "V0002", 0, "Benefits", new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6940), null, "Description", new DateTime(2023, 12, 10, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6939), null, "America", 2, 11, "Requirement", 7000, 1, "Title", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "V0003", 0, "Benefits", new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6944), null, "Description", new DateTime(2023, 12, 10, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6943), null, "America", 3, 9, "Requirement", 10000, 1, "Title", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "V0004", 0, "Benefits", new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6948), null, "Description", new DateTime(2023, 12, 10, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6947), null, "America", 4, 7, "Requirement", 13000, 1, "Title", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "V0005", 0, "Benefits", new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6952), null, "Description", new DateTime(2023, 12, 10, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6951), null, "America", 5, 5, "Requirement", 15000, 1, "Title", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ApplicantsVacancies",
                columns: new[] { "Id", "Applicant_Id", "Attachment", "Created_at", "Hr_Id", "StatusApplicant_Id", "Updated_at", "Vacancy_Id" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(7029), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0001" },
                    { 2, 2, null, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(7031), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0002" },
                    { 3, 3, null, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(7033), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0003" },
                    { 4, 4, null, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(7035), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0004" },
                    { 5, 5, null, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(7037), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0005" },
                    { 6, 6, null, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(7039), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0001" },
                    { 7, 7, null, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(7041), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0002" },
                    { 8, 8, null, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(7043), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0003" },
                    { 9, 9, null, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(7045), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0004" }
                });

            migrationBuilder.InsertData(
                table: "VacanciesJobs",
                columns: new[] { "Id", "Created_at", "Job_Id", "Updated_at", "Vacancy_Id" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6976), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0001" },
                    { 2, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6978), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0001" },
                    { 3, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6980), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0001" },
                    { 4, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6981), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0002" },
                    { 5, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6983), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0002" },
                    { 6, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6985), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0002" },
                    { 7, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6987), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0003" },
                    { 8, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6988), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0003" },
                    { 9, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6990), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0003" },
                    { 10, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6992), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0004" },
                    { 11, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6994), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0004" },
                    { 12, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6995), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0004" },
                    { 13, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6997), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0005" },
                    { 14, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(6999), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0005" },
                    { 15, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(7001), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V0005" }
                });

            migrationBuilder.InsertData(
                table: "InterviewsVacancies",
                columns: new[] { "Id", "ApplicantVacancy_Id", "Created_at", "EndDate", "Interview_Id", "StartDate", "StatusInterview_Id", "Updated_at" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(7135), null, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(7137), null, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(7139), null, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(7140), null, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(7142), null, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(7144), null, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 3, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(7146), null, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 4, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(7148), null, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 5, new DateTime(2023, 11, 30, 8, 55, 55, 210, DateTimeKind.Local).AddTicks(7149), null, null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
                name: "IX_Vacancies_Department_Id",
                table: "Vacancies",
                column: "Department_Id");

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

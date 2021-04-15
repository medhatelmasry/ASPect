using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCategory",
                columns: table => new
                {
                    ProjectCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectCategoryName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCategory", x => x.ProjectCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    RoleName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseTitle = table.Column<string>(type: "TEXT", nullable: true),
                    Term = table.Column<string>(type: "TEXT", nullable: true),
                    ProjectOutline = table.Column<string>(type: "TEXT", nullable: true),
                    InstructorID = table.Column<string>(type: "TEXT", nullable: true),
                    Id = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Course_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    courseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignments_Course_courseId",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offerings",
                columns: table => new
                {
                    OfferingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Semester = table.Column<string>(type: "TEXT", nullable: true),
                    Year = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Id = table.Column<string>(type: "TEXT", nullable: true),
                    CourseID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offerings", x => x.OfferingId);
                    table.ForeignKey(
                        name: "FK_Offerings_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offerings_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Requirement = table.Column<string>(type: "TEXT", nullable: true),
                    AssignmentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectRequirements_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OfferingId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<string>(type: "TEXT", nullable: true),
                    CourseID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollments_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollments_Offerings_OfferingId",
                        column: x => x.OfferingId,
                        principalTable: "Offerings",
                        principalColumn: "OfferingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeamName = table.Column<string>(type: "TEXT", nullable: true),
                    ProjectCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    AppName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    AspNetUserId = table.Column<string>(type: "TEXT", nullable: true),
                    OfferingId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_Offerings_OfferingId",
                        column: x => x.OfferingId,
                        principalTable: "Offerings",
                        principalColumn: "OfferingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_ProjectCategory_ProjectCategoryId",
                        column: x => x.ProjectCategoryId,
                        principalTable: "ProjectCategory",
                        principalColumn: "ProjectCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectRole = table.Column<string>(type: "TEXT", nullable: true),
                    CourseID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => new { x.Id, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_Memberships_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Memberships_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Memberships_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeerEvaluations",
                columns: table => new
                {
                    PeerEvaluationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserEvaluatingId = table.Column<string>(type: "TEXT", nullable: true),
                    UserBeingEvaluatedId = table.Column<string>(type: "TEXT", nullable: true),
                    Comments = table.Column<string>(type: "TEXT", nullable: true),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeerEvaluations", x => x.PeerEvaluationId);
                    table.ForeignKey(
                        name: "FK_PeerEvaluations_AspNetUsers_UserBeingEvaluatedId",
                        column: x => x.UserBeingEvaluatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeerEvaluations_AspNetUsers_UserEvaluatingId",
                        column: x => x.UserEvaluatingId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeerEvaluations_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgressUpdates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastWeekActivity = table.Column<string>(type: "TEXT", nullable: true),
                    NextWeekActivity = table.Column<string>(type: "TEXT", nullable: true),
                    Issues = table.Column<string>(type: "TEXT", nullable: true),
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    Complete = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressUpdates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgressUpdates_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "Description", "Name", "NormalizedName" },
                values: new object[] { "fe7dce26-ec5d-452a-8d5b-db9fdf6c7de8", "fe7dce26-ec5d-452a-8d5b-db9fdf6c7de8", new DateTime(2021, 4, 15, 2, 28, 6, 608, DateTimeKind.Local).AddTicks(7619), "This is the administrator role.", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "Description", "Name", "NormalizedName" },
                values: new object[] { "6fe5c0a6-9713-43c2-90e2-a1bbdc670580", "6fe5c0a6-9713-43c2-90e2-a1bbdc670580", new DateTime(2021, 4, 15, 2, 28, 6, 611, DateTimeKind.Local).AddTicks(4627), "This is the instructor role.", "Instructor", "INSTRUCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "Description", "Name", "NormalizedName" },
                values: new object[] { "c5b86ef1-3114-4dc7-a061-1bc704939396", "c5b86ef1-3114-4dc7-a061-1bc704939396", new DateTime(2021, 4, 15, 2, 28, 6, 611, DateTimeKind.Local).AddTicks(4716), "This is the student role.", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5bb3f1ca-d27c-4655-b8d6-6c2b3016f2d3", 0, "48688e7b-b728-48d2-8d8e-67679dd63b10", "admin@aspect.com", true, "Adam", "Aldridge", false, null, "ADMIN@ASPECT.COM", "ADMIN@ASPECT.COM", "AQAAAAEAACcQAAAAEC4KYrFMRS24TpW9CrSSgWatMbnxpj2aziAZtWuDJi5A326YIFj6A9mplLx8x/vzlQ==", null, false, "f7bfa6a4-2c8a-4acd-a3b3-df2d09d5840c", false, "admin@aspect.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9216a976-f1ba-4d73-aff6-f818b4b5c6a7", 0, "e98d12a6-4d42-428b-b90f-d2878c2948e9", "instructor@aspect.com", true, "Ted", "Smith", false, null, "INSTRUCTOR@ASPECT.COM", "INSTRUCTOR@ASPECT.COM", "AQAAAAEAACcQAAAAEPmYiHoZ3fYa77n7xXfKoFy36Y+wqnWM9yprZHUpjmtB/wggPHN/QBYTa+WajUkrDg==", null, false, "9df3d1ff-e6e6-4d2c-9604-38c22d1d7dd6", false, "instructor@aspect.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "363624a6-0978-4866-b5ee-b135a6fc3870", 0, "d559f32b-e4c5-47bb-8aca-dd5136350034", "student@aspect.com", true, "Mike", "Myers", false, null, "STUDENT@ASPECT.COM", "STUDENT@ASPECT.COM", "AQAAAAEAACcQAAAAECPFMa0zJ2QTFbXdrZMiPaIbq+VGmbI74gOFWHJyphJBJcZBZdxYcSkl4nsOEuSqXA==", null, false, "b4798073-7f0e-4b15-a372-c7bd7f392639", false, "student@aspect.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "363624a6-1111-4866-b5ee-b135a6fc3870", 0, "5faff30e-6150-4063-bbe5-e8db0760ad88", "student2@aspect.com", true, "Mike2", "Myers2", false, null, "STUDENT2@ASPECT.COM", "STUDENT2@ASPECT.COM", "AQAAAAEAACcQAAAAEGM7pkjl4fKnIaSKhoRFiD7xF4YU6TbNExCtf0PiUc/2cYRRzo6lFPXgrleVKZf7JQ==", null, false, "9ac275cf-3607-4cc8-8354-a19bfc6ce5da", false, "student2@aspect.com" });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseID", "CourseTitle", "Id", "InstructorID", "ProjectOutline", "Term" },
                values: new object[] { 1, "COMP3800 - Practicum", null, "9216a976-f1ba-4d73-aff6-f818b4b5c6a7", "https://www.bcit.ca/outlines/20211088135/", "4" });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseID", "CourseTitle", "Id", "InstructorID", "ProjectOutline", "Term" },
                values: new object[] { 2, "COMP4870 - Intranet Planning & Development", null, "9216a976-f1ba-4d73-aff6-f818b4b5c6a7", "https://www.bcit.ca/outlines/20211049852/", "4" });

            migrationBuilder.InsertData(
                table: "ProjectCategory",
                columns: new[] { "ProjectCategoryId", "ProjectCategoryName" },
                values: new object[] { 2, "React" });

            migrationBuilder.InsertData(
                table: "ProjectCategory",
                columns: new[] { "ProjectCategoryId", "ProjectCategoryName" },
                values: new object[] { 1, "Blockchain" });

            migrationBuilder.InsertData(
                table: "ProjectRoles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { "QA", "Quality Assurance" });

            migrationBuilder.InsertData(
                table: "ProjectRoles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { "Arch", "Software Architect" });

            migrationBuilder.InsertData(
                table: "ProjectRoles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { "DBA", "Database Administrator" });

            migrationBuilder.InsertData(
                table: "ProjectRoles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { "UIUIX", "UI/UX Designer" });

            migrationBuilder.InsertData(
                table: "ProjectRoles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { "SD", "Software Developer" });

            migrationBuilder.InsertData(
                table: "ProjectRoles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { "PM", "Project Manager" });

            migrationBuilder.InsertData(
                table: "ProjectRoles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { "SA", "System Administrator" });

            migrationBuilder.InsertData(
                table: "ProjectRoles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { "FE", "Front End Developer" });

            migrationBuilder.InsertData(
                table: "ProjectRoles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { "BE", "Back End Developer" });

            migrationBuilder.InsertData(
                table: "ProjectRoles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { "TE", "Software Tester" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fe7dce26-ec5d-452a-8d5b-db9fdf6c7de8", "5bb3f1ca-d27c-4655-b8d6-6c2b3016f2d3" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6fe5c0a6-9713-43c2-90e2-a1bbdc670580", "9216a976-f1ba-4d73-aff6-f818b4b5c6a7" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c5b86ef1-3114-4dc7-a061-1bc704939396", "363624a6-0978-4866-b5ee-b135a6fc3870" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c5b86ef1-3114-4dc7-a061-1bc704939396", "363624a6-1111-4866-b5ee-b135a6fc3870" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "AssignmentId", "DateCreated", "DueDate", "courseId", "description" },
                values: new object[] { 1, new DateTime(2021, 4, 15, 2, 28, 6, 646, DateTimeKind.Local).AddTicks(1754), new DateTime(2021, 4, 22, 2, 28, 6, 646, DateTimeKind.Local).AddTicks(2042), 1, "Create a CRUD application" });

            migrationBuilder.InsertData(
                table: "Offerings",
                columns: new[] { "OfferingId", "CourseID", "Id", "Semester", "Year" },
                values: new object[] { 2, 1, "9216a976-f1ba-4d73-aff6-f818b4b5c6a7", "Winter", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Offerings",
                columns: new[] { "OfferingId", "CourseID", "Id", "Semester", "Year" },
                values: new object[] { 1, 2, "9216a976-f1ba-4d73-aff6-f818b4b5c6a7", "Fall", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EnrollmentId", "CourseID", "Id", "OfferingId" },
                values: new object[] { 3, null, "363624a6-0978-4866-b5ee-b135a6fc3870", 2 });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EnrollmentId", "CourseID", "Id", "OfferingId" },
                values: new object[] { 1, null, "363624a6-0978-4866-b5ee-b135a6fc3870", 1 });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "AppName", "AspNetUserId", "Description", "OfferingId", "ProjectCategoryId", "TeamName" },
                values: new object[] { 3, "PlaneGo", "363624a6-0978-4866-b5ee-b135a6fc3870", "It's like uber but for planes", 2, 2, "Team Fly" });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "AppName", "AspNetUserId", "Description", "OfferingId", "ProjectCategoryId", "TeamName" },
                values: new object[] { 1, "Twitter", "363624a6-0978-4866-b5ee-b135a6fc3870", "An app for tweeting", 1, 1, "RA" });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "AppName", "AspNetUserId", "Description", "OfferingId", "ProjectCategoryId", "TeamName" },
                values: new object[] { 2, "PlaneGo", "363624a6-0978-4866-b5ee-b135a6fc3870", "It's like uber but for planes", 1, 2, "Team Fly" });

            migrationBuilder.InsertData(
                table: "ProjectRequirements",
                columns: new[] { "Id", "AssignmentId", "DateCreated", "DueDate", "Requirement" },
                values: new object[] { 1, 1, new DateTime(2021, 4, 15, 2, 28, 6, 646, DateTimeKind.Local).AddTicks(5798), new DateTime(2021, 4, 18, 2, 28, 6, 646, DateTimeKind.Local).AddTicks(6092), "Setup a WebAPI" });

            migrationBuilder.InsertData(
                table: "ProjectRequirements",
                columns: new[] { "Id", "AssignmentId", "DateCreated", "DueDate", "Requirement" },
                values: new object[] { 2, 1, new DateTime(2021, 4, 15, 2, 28, 6, 646, DateTimeKind.Local).AddTicks(6858), new DateTime(2021, 4, 21, 2, 28, 6, 646, DateTimeKind.Local).AddTicks(6869), "Setup a client" });

            migrationBuilder.InsertData(
                table: "ProjectRequirements",
                columns: new[] { "Id", "AssignmentId", "DateCreated", "DueDate", "Requirement" },
                values: new object[] { 3, 1, new DateTime(2021, 4, 15, 2, 28, 6, 646, DateTimeKind.Local).AddTicks(6873), new DateTime(2021, 4, 22, 2, 28, 6, 646, DateTimeKind.Local).AddTicks(6875), "Test your application" });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "Id", "ProjectId", "CourseID", "ProjectRole" },
                values: new object[] { "363624a6-0978-4866-b5ee-b135a6fc3870", 1, null, "Project Manager" });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "Id", "ProjectId", "CourseID", "ProjectRole" },
                values: new object[] { "363624a6-1111-4866-b5ee-b135a6fc3870", 1, null, "Database Administrator" });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "Id", "ProjectId", "CourseID", "ProjectRole" },
                values: new object[] { "363624a6-0978-4866-b5ee-b135a6fc3870", 2, null, "Project Manager" });

            migrationBuilder.InsertData(
                table: "ProgressUpdates",
                columns: new[] { "Id", "Complete", "Date", "Issues", "LastWeekActivity", "NextWeekActivity", "ProjectId" },
                values: new object[] { 1, false, new DateTime(2021, 4, 15, 2, 28, 6, 644, DateTimeKind.Local).AddTicks(380), "Schema may need to be reworked", "Finished DB Design", "Going to work on the API", 1 });

            migrationBuilder.InsertData(
                table: "ProgressUpdates",
                columns: new[] { "Id", "Complete", "Date", "Issues", "LastWeekActivity", "NextWeekActivity", "ProjectId" },
                values: new object[] { 2, false, new DateTime(2021, 4, 15, 2, 28, 6, 644, DateTimeKind.Local).AddTicks(1653), "Need to find solution for deployment", "Finished API Design", "Going to implement the API", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_courseId",
                table: "Assignments",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Id",
                table: "Course",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseID",
                table: "Enrollments",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_Id",
                table: "Enrollments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_OfferingId",
                table: "Enrollments",
                column: "OfferingId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_CourseID",
                table: "Memberships",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_ProjectId",
                table: "Memberships",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Offerings_CourseID",
                table: "Offerings",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Offerings_Id",
                table: "Offerings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PeerEvaluations_ProjectId",
                table: "PeerEvaluations",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PeerEvaluations_UserBeingEvaluatedId",
                table: "PeerEvaluations",
                column: "UserBeingEvaluatedId");

            migrationBuilder.CreateIndex(
                name: "IX_PeerEvaluations_UserEvaluatingId",
                table: "PeerEvaluations",
                column: "UserEvaluatingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressUpdates_ProjectId",
                table: "ProgressUpdates",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_OfferingId",
                table: "Project",
                column: "OfferingId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectCategoryId",
                table: "Project",
                column: "ProjectCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRequirements_AssignmentId",
                table: "ProjectRequirements",
                column: "AssignmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "PeerEvaluations");

            migrationBuilder.DropTable(
                name: "ProgressUpdates");

            migrationBuilder.DropTable(
                name: "ProjectRequirements");

            migrationBuilder.DropTable(
                name: "ProjectRoles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Offerings");

            migrationBuilder.DropTable(
                name: "ProjectCategory");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

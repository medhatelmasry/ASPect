﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Data.Migrations
{
    public partial class M1 : Migration
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
                name: "Course",
                columns: table => new
                {
                    courseID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    courseTitle = table.Column<string>(type: "TEXT", nullable: true),
                    term = table.Column<string>(type: "TEXT", nullable: true),
                    projectOutline = table.Column<string>(type: "TEXT", nullable: true),
                    instructorID = table.Column<string>(type: "TEXT", nullable: true),
                    courseID1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.courseID);
                    table.ForeignKey(
                        name: "FK_Course_Course_courseID1",
                        column: x => x.courseID1,
                        principalTable: "Course",
                        principalColumn: "courseID",
                        onDelete: ReferentialAction.Restrict);
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
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "courseID",
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
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false)
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
                        name: "FK_Memberships_Project_ProjectId",
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
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false)
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
                values: new object[] { "7750864b-179b-492a-b721-9c0029ae4f84", "7750864b-179b-492a-b721-9c0029ae4f84", new DateTime(2021, 4, 1, 12, 46, 28, 232, DateTimeKind.Local).AddTicks(9430), "This is the admin role", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "Description", "Name", "NormalizedName" },
                values: new object[] { "58ad514f-f039-49b4-9599-5d4e10683156", "58ad514f-f039-49b4-9599-5d4e10683156", new DateTime(2021, 4, 1, 12, 46, 28, 238, DateTimeKind.Local).AddTicks(1270), "This is the teacher role", "Teacher", "Teacher" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "Description", "Name", "NormalizedName" },
                values: new object[] { "c4e2c5ca-888b-4241-9321-17c421ce3313", "c4e2c5ca-888b-4241-9321-17c421ce3313", new DateTime(2021, 4, 1, 12, 46, 28, 238, DateTimeKind.Local).AddTicks(1300), "This is the student role", "Student", "Student" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e5d3d34e-9263-43cb-b3ea-52356fb3b44f", 0, "0f51f5ea-7a42-433a-a6ca-ce21fa7ba80f", "admin@aspect.com", true, "Adam", "Aldridge", false, null, "ADMIN@ASPECT.COM", "ADMIN@ASPECT.COM", "AQAAAAEAACcQAAAAEM0Tx/67q5xF9uI9ThfjrvP8W6CjFu7Y43vYzKepI6tPV3qSOKlQLwCKRWcrSD1Lhg==", null, false, "0fdba801-42d7-41cd-b62a-3e378549a865", false, "admin@aspect.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e5d3d34e-9263-43cb-b3ea-52356fb3b45e", 0, "f426ef81-893c-4c62-a7a5-287b2f7ab2ba", "instructor@aspect.com", true, "Ted", "Smith", false, null, "INSTRUCTOR@ASPECT.COM", "INSTRUCTOR@ASPECT.COM", "AQAAAAEAACcQAAAAEJo1tDB6UdqR90k/9WZpRz6wHxewopgDxtZuo/LUb/kGRxfQkivI8FjGN24erQ1R1w==", null, false, "da1307b7-985c-42e9-a9ff-227a0f5d9fbb", false, "instructor@aspect.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e5d3d34e-9263-43cb-b3ea-52356fb3b66z", 0, "72c260a5-d88b-49ed-85b4-ae8e928831e0", "student@aspect.com", true, "Mike", "Myers", false, null, "STUDENT@ASPECT.COM", "STUDENT@ASPECT.COM", "AQAAAAEAACcQAAAAEF/cGzTvkxbS9TP7oNHAiZmtP+BVc9Jc7ObBHAQKejMMQzw8mh+G2is5UhVn+osqyg==", null, false, "195c6226-342f-450f-8e7e-04163df2d6c5", false, "student@aspect.com" });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "courseID", "courseID1", "courseTitle", "instructorID", "projectOutline", "term" },
                values: new object[] { 1, null, "COMP3800 - Practicum", "e5d3d34e-9263-43cb-b3ea-52356fb3b45e", "https://www.bcit.ca/outlines/20211088135/", "4" });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "courseID", "courseID1", "courseTitle", "instructorID", "projectOutline", "term" },
                values: new object[] { 2, null, "COMP4870 - Intranet Planning & Development", "e5d3d34e-9263-43cb-b3ea-52356fb3b45e", "https://www.bcit.ca/outlines/20211049852/", "4" });

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
                values: new object[] { "7750864b-179b-492a-b721-9c0029ae4f84", "e5d3d34e-9263-43cb-b3ea-52356fb3b44f" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "58ad514f-f039-49b4-9599-5d4e10683156", "e5d3d34e-9263-43cb-b3ea-52356fb3b45e" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c4e2c5ca-888b-4241-9321-17c421ce3313", "e5d3d34e-9263-43cb-b3ea-52356fb3b66z" });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "AppName", "AspNetUserId", "CourseId", "Description", "ProjectCategoryId", "TeamName" },
                values: new object[] { 1, "Twitter", "e5d3d34e-9263-43cb-b3ea-52356fb3b66z", 1, "An app for tweeting", 1, "RA" });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "AppName", "AspNetUserId", "CourseId", "Description", "ProjectCategoryId", "TeamName" },
                values: new object[] { 2, "PlaneGo", "e5d3d34e-9263-43cb-b3ea-52356fb3b66z", 1, "It's like uber but for planes", 2, "Team Fly" });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "Id", "ProjectId" },
                values: new object[] { "e5d3d34e-9263-43cb-b3ea-52356fb3b66z", 1 });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "Id", "ProjectId" },
                values: new object[] { "e5d3d34e-9263-43cb-b3ea-52356fb3b66z", 2 });

            migrationBuilder.InsertData(
                table: "ProgressUpdates",
                columns: new[] { "Id", "Date", "Issues", "LastWeekActivity", "NextWeekActivity", "ProjectId" },
                values: new object[] { 1, new DateTime(2021, 4, 1, 12, 46, 28, 281, DateTimeKind.Local).AddTicks(7490), "Schema may need to be reworked", "Finished DB Design", "Going to work on the API", 1 });

            migrationBuilder.InsertData(
                table: "ProgressUpdates",
                columns: new[] { "Id", "Date", "Issues", "LastWeekActivity", "NextWeekActivity", "ProjectId" },
                values: new object[] { 2, new DateTime(2021, 4, 1, 12, 46, 28, 281, DateTimeKind.Local).AddTicks(9310), "Need to find solution for deployment", "Finished API Design", "Going to implement the API", 1 });

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
                name: "IX_Course_courseID1",
                table: "Course",
                column: "courseID1");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_ProjectId",
                table: "Memberships",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressUpdates_ProjectId",
                table: "ProgressUpdates",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CourseId",
                table: "Project",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectCategoryId",
                table: "Project",
                column: "ProjectCategoryId");
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
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "ProgressUpdates");

            migrationBuilder.DropTable(
                name: "ProjectRoles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "ProjectCategory");
        }
    }
}

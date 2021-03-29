﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web.Data;

namespace Web.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210329181457_M2")]
    partial class M2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("ASPectLibrary.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("ASPectLibrary.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ASPectLibrary.Course", b =>
                {
                    b.Property<int>("courseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("courseID1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("courseTitle")
                        .HasColumnType("TEXT");

                    b.Property<string>("instructorID")
                        .HasColumnType("TEXT");

                    b.Property<string>("projectOutline")
                        .HasColumnType("TEXT");

                    b.Property<string>("term")
                        .HasColumnType("TEXT");

                    b.HasKey("courseID");

                    b.HasIndex("courseID1");

                    b.ToTable("Course");

                    b.HasData(
                        new
                        {
                            courseID = 1,
                            courseTitle = "COMP3800 - Practicum",
                            instructorID = "0d56e795-1386-4462-85e7-960ef64ed67b",
                            projectOutline = "https://www.bcit.ca/outlines/20211088135/",
                            term = "4"
                        },
                        new
                        {
                            courseID = 2,
                            courseTitle = "COMP4870 - Intranet Planning & Development",
                            instructorID = "0d56e795-1386-4462-85e7-960ef64ed67b",
                            projectOutline = "https://www.bcit.ca/outlines/20211049852/",
                            term = "4"
                        });
                });

            modelBuilder.Entity("ASPectLibrary.Membership", b =>
                {
                    b.Property<string>("StudentId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("ASPectLibrary.ProgressUpdate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Issues")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastWeekActivity")
                        .HasColumnType("TEXT");

                    b.Property<string>("NextWeekActivity")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProgressUpdates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2021, 3, 29, 11, 14, 56, 719, DateTimeKind.Local).AddTicks(7370),
                            Issues = "Schema may need to be reworked",
                            LastWeekActivity = "Finished DB Design",
                            NextWeekActivity = "Going to work on the API",
                            ProjectId = 1
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2021, 3, 29, 11, 14, 56, 725, DateTimeKind.Local).AddTicks(8570),
                            Issues = "Need to find solution for deployment",
                            LastWeekActivity = "Finished API Design",
                            NextWeekActivity = "Going to implement the API",
                            ProjectId = 1
                        });
                });

            modelBuilder.Entity("ASPectLibrary.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AppName")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AspNetUserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProjectCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeamName")
                        .HasColumnType("TEXT");

                    b.HasKey("ProjectId");

                    b.HasIndex("CourseId");

                    b.HasIndex("ProjectCategoryId");

                    b.ToTable("Project");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            AppName = "Twitter",
                            AspNetUserId = new Guid("e5d3d34e-9263-43cb-b3ea-52356fb3b44f"),
                            CourseId = 1,
                            Description = "An app for tweeting",
                            ProjectCategoryId = 1,
                            TeamName = "RA"
                        },
                        new
                        {
                            ProjectId = 2,
                            AppName = "PlaneGo",
                            AspNetUserId = new Guid("e5d3d34e-9263-43cb-b3ea-52356fb3b44f"),
                            CourseId = 1,
                            Description = "It's like uber but for planes",
                            ProjectCategoryId = 2,
                            TeamName = "Team Fly"
                        });
                });

            modelBuilder.Entity("ASPectLibrary.ProjectCategory", b =>
                {
                    b.Property<int>("ProjectCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProjectCategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("ProjectCategoryId");

                    b.ToTable("ProjectCategory");

                    b.HasData(
                        new
                        {
                            ProjectCategoryId = 1,
                            ProjectCategoryName = "Blockchain"
                        },
                        new
                        {
                            ProjectCategoryId = 2,
                            ProjectCategoryName = "React"
                        });
                });

            modelBuilder.Entity("ASPectLibrary.ProjectRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProjectRoles");

                    b.HasData(
                        new
                        {
                            Id = "Arch",
                            RoleName = "Software Architect"
                        },
                        new
                        {
                            Id = "DBA",
                            RoleName = "Database Administrator"
                        },
                        new
                        {
                            Id = "UIUIX",
                            RoleName = "UI/UX Designer"
                        },
                        new
                        {
                            Id = "SD",
                            RoleName = "Software Developer"
                        },
                        new
                        {
                            Id = "PM",
                            RoleName = "Project Manager"
                        },
                        new
                        {
                            Id = "SA",
                            RoleName = "System Administrator"
                        },
                        new
                        {
                            Id = "FE",
                            RoleName = "Front End Developer"
                        },
                        new
                        {
                            Id = "BE",
                            RoleName = "Back End Developer"
                        },
                        new
                        {
                            Id = "QA",
                            RoleName = "Quality Assurance"
                        },
                        new
                        {
                            Id = "TE",
                            RoleName = "Software Tester"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ASPectLibrary.Course", b =>
                {
                    b.HasOne("ASPectLibrary.Course", "course")
                        .WithMany()
                        .HasForeignKey("courseID1");

                    b.Navigation("course");
                });

            modelBuilder.Entity("ASPectLibrary.Membership", b =>
                {
                    b.HasOne("ASPectLibrary.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASPectLibrary.ApplicationUser", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ASPectLibrary.ProgressUpdate", b =>
                {
                    b.HasOne("ASPectLibrary.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ASPectLibrary.Project", b =>
                {
                    b.HasOne("ASPectLibrary.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASPectLibrary.ProjectCategory", "ProjectCategory")
                        .WithMany()
                        .HasForeignKey("ProjectCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("ProjectCategory");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("ASPectLibrary.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ASPectLibrary.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ASPectLibrary.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("ASPectLibrary.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASPectLibrary.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ASPectLibrary.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
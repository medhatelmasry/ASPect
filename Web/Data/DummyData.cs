using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ASPectLibrary;
using System;

public static class DummyData {
  public static void Seed (this ModelBuilder modelBuilder) {
      modelBuilder.Entity<Course>().HasData (
          GetCourses()
      );
    //   modelBuilder.Entity<Membership>().HasData (
    //       GetMemberships()
    //   );
      modelBuilder.Entity<ProgressUpdate>().HasData (
          GetProgressUpdates()
      );
      modelBuilder.Entity<Project>().HasData (
          GetProjects()
      );
      modelBuilder.Entity<ProjectCategory>().HasData (
          GetProjectCategories()
      );
      modelBuilder.Entity<ProjectRole>().HasData (
          GetProjectRoles()
      );
  }


public static List<Course> GetCourses () {
    List<Course> courses = new List<Course> () {
        new Course {
            courseID = 1,
            courseTitle = "COMP3800 - Practicum",
            term = "4",
            projectOutline = "https://www.bcit.ca/outlines/20211088135/",
            instructorID = "0d56e795-1386-4462-85e7-960ef64ed67b",
        },
        new Course {
            courseID = 2,
            courseTitle = "COMP4870 - Intranet Planning & Development",
            term = "4",
            projectOutline = "https://www.bcit.ca/outlines/20211049852/",
            instructorID = "0d56e795-1386-4462-85e7-960ef64ed67b"
        }
    };
        return courses;
    }

    public static List<Membership> GetMemberships () {
    List<Membership> memberships = new List<Membership> () {
        new Membership {
            StudentId = "e5d3d34e-9263-43cb-b3ea-52356fb3b44f",
            ProjectId = 1
        }, 
        new Membership {
            StudentId = "e5d3d34e-9263-43cb-b3ea-52356fb3b44f",
            ProjectId = 2          
        }
    };
        return memberships;
    }
    public static List<ProgressUpdate> GetProgressUpdates () {
        List <ProgressUpdate> progressUpdates = new List<ProgressUpdate> () {
            new ProgressUpdate {
                Id = 1,
                Date = DateTime.Now,
                LastWeekActivity = "Finished DB Design",
                NextWeekActivity = "Going to work on the API",
                Issues = "Schema may need to be reworked",
                ProjectId = 1
            }, 
            new ProgressUpdate {
                Id = 2,
                Date = DateTime.Now,
                LastWeekActivity = "Finished API Design",
                NextWeekActivity = "Going to implement the API",
                Issues = "Need to find solution for deployment",
                ProjectId = 1
            }
        };
        return progressUpdates;
    }

    public static List<Project> GetProjects () {
        List <Project> projects = new List<Project> () {
            new Project {
                ProjectId = 1,
                TeamName = "RA",
                ProjectCategoryId = 1,
                AppName = "Twitter",
                Description = "An app for tweeting",
                AspNetUserId = new Guid("e5d3d34e-9263-43cb-b3ea-52356fb3b44f"),
                CourseId = 1
            },
            new Project {
                ProjectId = 2,
                TeamName = "Team Fly",
                ProjectCategoryId = 2,
                AppName = "PlaneGo",
                Description = "It's like uber but for planes",
                AspNetUserId = new Guid("e5d3d34e-9263-43cb-b3ea-52356fb3b44f"),
                CourseId = 1
            }

        };
        return projects;
    }

    public static List<ProjectCategory> GetProjectCategories () {
        List <ProjectCategory> projectCategories = new List<ProjectCategory> () {
            new ProjectCategory {
                ProjectCategoryId = 1,
                ProjectCategoryName = "Blockchain"
            },
            new ProjectCategory {
                ProjectCategoryId = 2,
                ProjectCategoryName = "React"
            }
        };
        return projectCategories;
    }

    public static List<ProjectRole> GetProjectRoles () {
        List <ProjectRole> projectRoles = new List<ProjectRole> () {
            new ProjectRole {
                Id = "Arch",
                RoleName = "Software Architect"
            },
            new ProjectRole {
                Id = "DBA",
                RoleName = "Database Administrator"
            },
            new ProjectRole {
                Id = "UIUIX",
                RoleName = "UI/UX Designer"
            },
            new ProjectRole {
                Id = "SD",
                RoleName = "Software Developer"
            },
            new ProjectRole {
                Id = "PM",
                RoleName = "Project Manager"
            },
            new ProjectRole {
                Id = "SA",
                RoleName = "System Administrator" 
            },
            new ProjectRole {
                Id = "FE",
                RoleName = "Front End Developer" 
            },
            new ProjectRole {
                Id = "BE",
                RoleName = "Back End Developer" 
            },
            new ProjectRole {
                Id = "QA",
                RoleName = "Quality Assurance" 
            },
            new ProjectRole {
                Id = "TE",
                RoleName = "Software Tester" 
            }
        };
        return projectRoles;
    }
}


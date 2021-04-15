using System;
using System.Collections.Generic;
using ASPectLibrary;
using Microsoft.EntityFrameworkCore;

public static class DummyData
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>().HasData(
            GetCourses()
        );
        modelBuilder.Entity<ProgressUpdate>().HasData(
            GetProgressUpdates()
        );
        modelBuilder.Entity<Project>().HasData(
            GetProjects()
        );
        modelBuilder.Entity<ProjectCategory>().HasData(
            GetProjectCategories()
        );
        modelBuilder.Entity<ProjectRole>().HasData(
            GetProjectRoles()
        );
        modelBuilder.Entity<Membership>().HasData(
            GetMemberships()
        );
        modelBuilder.Entity<Offering>().HasData(
            GetOfferings()
        );
        modelBuilder.Entity<Enrollment>().HasData(
            GetEnrollments()
        );
        modelBuilder.Entity<Assignment>().HasData(
            GetAssignments()
        );
        modelBuilder.Entity<ProjectRequirement>().HasData(
            GetRequirements()
        );

    }


    public static List<Course> GetCourses()
    {
        List<Course> courses = new List<Course>() {
        new Course {
            CourseID = 1,
            CourseTitle = "COMP3800 - Practicum",
            Term = "4",
            ProjectOutline = "https://www.bcit.ca/outlines/20211088135/",
            InstructorID = "9216a976-f1ba-4d73-aff6-f818b4b5c6a7"
        },
        new Course {
            CourseID = 2,
            CourseTitle = "COMP4870 - Intranet Planning & Development",
            Term = "4",
            ProjectOutline = "https://www.bcit.ca/outlines/20211049852/",
            InstructorID = "9216a976-f1ba-4d73-aff6-f818b4b5c6a7"
        }
    };
        return courses;
    }

    public static List<Membership> GetMemberships()
    {
        List<Membership> memberships = new List<Membership>() {
        new Membership {
            Id = "363624a6-0978-4866-b5ee-b135a6fc3870", //student
            ProjectId = 1,
            ProjectRole = "Project Manager",
        },
        new Membership {
            Id = "363624a6-1111-4866-b5ee-b135a6fc3870", //student
            ProjectId = 1,
            ProjectRole = "Database Administrator",
        },
        new Membership {
            Id = "363624a6-0978-4866-b5ee-b135a6fc3870", //student
            ProjectId = 2,
            ProjectRole = "Project Manager",
        }
    };
        return memberships;
    }
    public static List<ProgressUpdate> GetProgressUpdates()
    {
        List<ProgressUpdate> progressUpdates = new List<ProgressUpdate>() {
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

    public static List<Project> GetProjects()
    {
        List<Project> projects = new List<Project>() {
            new Project {
                ProjectId = 1,
                TeamName = "RA",
                ProjectCategoryId = 1,
                AppName = "Twitter",
                Description = "An app for tweeting",
                AspNetUserId = "363624a6-0978-4866-b5ee-b135a6fc3870", // student
                OfferingId = 1
            },
            new Project {
                ProjectId = 2,
                TeamName = "Team Fly",
                ProjectCategoryId = 2,
                AppName = "PlaneGo",
                Description = "It's like uber but for planes",
                AspNetUserId = "363624a6-0978-4866-b5ee-b135a6fc3870", // student
                OfferingId = 1
            },
            new Project {
                ProjectId = 3,
                TeamName = "Team Fly",
                ProjectCategoryId = 2,
                AppName = "PlaneGo",
                Description = "It's like uber but for planes",
                AspNetUserId = "363624a6-0978-4866-b5ee-b135a6fc3870", // student
                OfferingId = 2
            }

        };
        return projects;
    }

    public static List<ProjectCategory> GetProjectCategories()
    {
        List<ProjectCategory> projectCategories = new List<ProjectCategory>() {
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

    public static List<ProjectRole> GetProjectRoles()
    {
        List<ProjectRole> projectRoles = new List<ProjectRole>() {
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

    public static List<Offering> GetOfferings()
    {

        List<Offering> list = new List<Offering>() {
            new Offering {
                OfferingId = 1,
                Id = "9216a976-f1ba-4d73-aff6-f818b4b5c6a7",
                Year = new DateTime(),
                Semester = "Fall",
                CourseID = 2
            },
            new Offering {
                OfferingId = 2,
                Id = "9216a976-f1ba-4d73-aff6-f818b4b5c6a7",
                Year = new DateTime(),
                CourseID = 1,
                Semester = "Winter"
            }
        };
        return list;
    }

    public static List<Enrollment> GetEnrollments()
    {

        List<Enrollment> list = new List<Enrollment>() {
            new Enrollment {
                EnrollmentId = 1,
                //The students id
                Id = "363624a6-0978-4866-b5ee-b135a6fc3870",
                OfferingId = 1
            },
            new Enrollment {
                EnrollmentId = 3,
                //The students id
                Id = "363624a6-0978-4866-b5ee-b135a6fc3870",
                OfferingId = 2
            }
        };

        return list;
    }

    public static List<Assignment> GetAssignments()
    {
        List<Assignment> list = new List<Assignment>() {
                new Assignment() {
                    AssignmentId = 1,
                    DateCreated = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7),
                    description = "Create a CRUD application",
                    courseId = 1
                }
        };
        return list;
    }

    public static List<ProjectRequirement> GetRequirements()
    {
        List<ProjectRequirement> list = new List<ProjectRequirement>() {
                new ProjectRequirement() {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(3),
                    Requirement = "Setup a WebAPI",
                    AssignmentId = 1,
                },
                new ProjectRequirement() {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(6),
                    Requirement = "Setup a client",
                    AssignmentId = 1,
                },
                new ProjectRequirement() {
                    Id = 3,
                    DateCreated = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7),
                    Requirement = "Test your application",
                    AssignmentId = 1,
                }
        };
        return list;
    }
}


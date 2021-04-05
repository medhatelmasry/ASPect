using System;
using ASPectLibrary;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating (ModelBuilder builder) {
            base.OnModelCreating(builder);

            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            string PASSWORD = "P@$$w0rd";
 
            /* ----------------- Roles ----------------- */
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            var adminRole = new ApplicationRole()
            {
               
                Name = Constants.Account.ADMIN_ROLE_NAME,
                NormalizedName = Constants.Account.ADMIN_ROLE_NAME,
                Description = "This is the admin role",
                Id = ADMIN_ROLE_ID,
                ConcurrencyStamp = ADMIN_ROLE_ID,
                CreatedDate = DateTime.Now,
            };

            string INSTRUCTOR_ROLE_ID = Guid.NewGuid().ToString();
            var instructorRole = new ApplicationRole()
            {
                Name = Constants.Account.INSTRUCTOR_ROLE_NAME,
                NormalizedName = Constants.Account.INSTRUCTOR_ROLE_NAME,
                Description = "This is the teacher role",
                Id = INSTRUCTOR_ROLE_ID,
                ConcurrencyStamp = INSTRUCTOR_ROLE_ID,
                CreatedDate = DateTime.Now,
            };
    
            string STUDENT_ROLE_ID = Guid.NewGuid().ToString();
            var studentRole = new ApplicationRole()
            {
                Name = Constants.Account.STUDENT_ROLE_NAME,
                NormalizedName = Constants.Account.STUDENT_ROLE_NAME,
                Description = "This is the student role",
                Id = STUDENT_ROLE_ID,
                ConcurrencyStamp = STUDENT_ROLE_ID,
                CreatedDate = DateTime.Now,
            };
 
            //seed admin role
            builder.Entity<ApplicationRole>().HasData(
                adminRole,
                instructorRole,
                studentRole
            );
 
            /* ----------------- Add Admin User ----------------- */
            string ADMIN_USER_ID = "5bb3f1ca-d27c-4655-b8d6-6c2b3016f2d3";
            //create adminUser
            var adminUser = new ApplicationUser
            {
                Id = ADMIN_USER_ID,
                Email = "admin@aspect.com",
                NormalizedEmail = "ADMIN@ASPECT.COM",
                EmailConfirmed = true,
                FirstName = "Adam",
                LastName = "Aldridge",
                UserName = "admin@aspect.com",
                NormalizedUserName = "ADMIN@ASPECT.COM"
            };
            //set adminUser password
            adminUser.PasswordHash = ph.HashPassword(adminUser, PASSWORD);
 
            /* ----------------- Add Teacher User ----------------- */
            string TEACHER_USER_ID = "9216a976-f1ba-4d73-aff6-f818b4b5c6a7";
            //create memberUser
            var teacherUser = new ApplicationUser
            {
                Id = TEACHER_USER_ID,
                Email = "instructor@aspect.com",
                NormalizedEmail = "INSTRUCTOR@ASPECT.COM",
                EmailConfirmed = true,
                FirstName = "Ted",
                LastName = "Smith",
                UserName = "instructor@aspect.com",
                NormalizedUserName = "INSTRUCTOR@ASPECT.COM"
            };
            //set memberUser password
            teacherUser.PasswordHash = ph.HashPassword(teacherUser, PASSWORD);

            /* ----------------- Add Student User ----------------- */
            string STUDENT_USER_ID = "363624a6-0978-4866-b5ee-b135a6fc3870";
            //create memberUser
            var memberUser = new ApplicationUser
            {
                Id = STUDENT_USER_ID,
                Email = "student@aspect.com",
                NormalizedEmail = "STUDENT@ASPECT.COM",
                EmailConfirmed = true,
                FirstName = "Mike",
                LastName = "Myers",
                UserName = "student@aspect.com",
                NormalizedUserName = "STUDENT@ASPECT.COM"
            };
            //set memberUser password
            memberUser.PasswordHash = ph.HashPassword(memberUser, PASSWORD);
 
            //seed users
            builder.Entity<ApplicationUser>().HasData(adminUser, teacherUser, memberUser);

            /* ----------------- Add UserRoles ----------------- */
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_USER_ID
                },
                new IdentityUserRole<string>()
                {
                    RoleId = INSTRUCTOR_ROLE_ID,
                    UserId = TEACHER_USER_ID
                },
                new IdentityUserRole<string>()
                {
                    RoleId = STUDENT_ROLE_ID,
                    UserId = STUDENT_USER_ID
                }
            );

            builder.Entity<Project>().ToTable ("Project");
            builder.Entity<Membership>().HasOne(p => p.Project);
            //Defines a COMPOSITE KEY for Membership
            builder.Entity<Membership>()
                    .HasKey(c => new { c.Id, c.ProjectId });

            builder.Seed();
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> ProjectCategory { get; set; }
        public DbSet<ProgressUpdate> ProgressUpdates { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<ProjectRole> ProjectRoles { get; set; }
        public DbSet<PeerEvaluation> PeerEvaluations { get; set; }
    }
}

using System;
using ASPectLibrary;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
                Name = "Admin",
                NormalizedName = "Admin",
                Description = "This is the admin role",
                Id = ADMIN_ROLE_ID,
                ConcurrencyStamp = ADMIN_ROLE_ID,
                CreatedDate = DateTime.Now,
            };

            string TEACHER_ROLE_ID = Guid.NewGuid().ToString();
            var teacherRole = new ApplicationRole()
            {
                Name = "Teacher",
                NormalizedName = "Teacher",
                Description = "This is the teacher role",
                Id = TEACHER_ROLE_ID,
                ConcurrencyStamp = TEACHER_ROLE_ID,
                CreatedDate = DateTime.Now,
            };
    
            string MEMBER_ROLE_ID = Guid.NewGuid().ToString();
            var memberRole = new ApplicationRole()
            {
                Name = "Student",
                NormalizedName = "Student",
                Description = "This is the student role",
                Id = MEMBER_ROLE_ID,
                ConcurrencyStamp = MEMBER_ROLE_ID,
                CreatedDate = DateTime.Now,
            };
 
            //seed admin role
            builder.Entity<ApplicationRole>().HasData(
                adminRole,
                teacherRole,
                memberRole
            );
 
            /* ----------------- Add Admin User ----------------- */
            string ADMIN_USER_ID = "e5d3d34e-9263-43cb-b3ea-52356fb3b44f";
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
            string TEACHER_USER_ID = "e5d3d34e-9263-43cb-b3ea-52356fb3b45e";
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
            string MEMBER_USER_ID = "e5d3d34e-9263-43cb-b3ea-52356fb3b66z";
            //create memberUser
            var memberUser = new ApplicationUser
            {
                Id = MEMBER_USER_ID,
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
                    RoleId = TEACHER_ROLE_ID,
                    UserId = TEACHER_USER_ID
                },
                new IdentityUserRole<string>()
                {
                    RoleId = MEMBER_ROLE_ID,
                    UserId = MEMBER_USER_ID
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
    }
}

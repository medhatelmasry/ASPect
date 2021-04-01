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
 
            /* ----------------- Admin Role ----------------- */
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
 
            string MEMBER_ROLE_ID = Guid.NewGuid().ToString();
            var memberRole = new ApplicationRole()
            {
                Name = "Member",
                NormalizedName = "Member",
                Description = "This is the members role",
                Id = MEMBER_ROLE_ID,
                ConcurrencyStamp = MEMBER_ROLE_ID,
                CreatedDate = DateTime.Now,
            };
 
            //seed admin role
            builder.Entity<ApplicationRole>().HasData(
                adminRole,
                memberRole
            );
 
            /* ----------------- Add Admin User ----------------- */
            string ADMIN_USER_ID = "e5d3d34e-9263-43cb-b3ea-52356fb3b44f";
    
            //create adminUser
            var adminUser = new ApplicationUser
            {
                Id = ADMIN_USER_ID,
                Email = "aa@aa.aa",
                EmailConfirmed = true,
                FirstName = "Adam",
                LastName = "Aldridge",
                UserName = "aa@aa.aa",
            };
            //set adminUser password
            adminUser.PasswordHash = ph.HashPassword(adminUser, PASSWORD);
 
            /* ----------------- Add Member User ----------------- */
            string MEMBER_USER_ID = "e5d3d34e-9263-43cb-b3ea-52356fb3b45e";
            //create memberUser
            var memberUser = new ApplicationUser
            {
                Id = MEMBER_USER_ID,
                Email = "mm@mm.mm",
                EmailConfirmed = true,
                FirstName = "Mike",
                LastName = "Myers",
                UserName = "mm@mm.mm",
            };
            //set memberUser password
            memberUser.PasswordHash = ph.HashPassword(memberUser, PASSWORD);
 
            //seed users
            builder.Entity<ApplicationUser>().HasData(adminUser, memberUser);

            /* ----------------- Add UserRoles ----------------- */
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_USER_ID
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

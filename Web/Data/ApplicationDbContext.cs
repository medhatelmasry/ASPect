using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);
        
        #region "Seed Data"

        builder.Entity<IdentityRole>().HasData(
            new {Id = "1", Name = "Admin", NormalizedName = "ADMIN"},
            new { Id = "2", Name = "Student", NormalizedName = "STUDENT" }
        );

        #endregion
    }
    }
}

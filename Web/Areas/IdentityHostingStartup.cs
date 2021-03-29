using ASPectLibrary;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Data;

[assembly: HostingStartup(typeof(ASPect.Web.Areas.Identity.IdentityHostingStartup))]
namespace ASPect.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(context.Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>( options =>
            {
                options.Stores.MaxLengthForKeys = 128;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddRoles<ApplicationRole>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();
            });
        }
    }
}
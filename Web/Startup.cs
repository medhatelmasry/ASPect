using System.Text;
using ASPectLibrary;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Web.Data;

namespace Web
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite(
            Configuration.GetConnectionString("DefaultConnection")));

      services.AddCors(o => o.AddPolicy("CORSPolicy", builder =>
      {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
      }));

      services.AddDatabaseDeveloperPageExceptionFilter();

      services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
      {
        options.Stores.MaxLengthForKeys = 128;
      })
          .AddEntityFrameworkStores<ApplicationDbContext>()
          .AddRoles<ApplicationRole>()
          .AddDefaultUI()
          .AddDefaultTokenProviders();

      services.AddControllersWithViews();

      services.AddAuthentication(option =>
      {
        option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(options =>
      {
        options.SaveToken = true;
        options.RequireHttpsMetadata = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidAudience = Configuration["Jwt:Site"],
          ValidIssuer = Configuration["Jwt:Site"],
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SigningKey"]))
        };
      });

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context,
                            RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseMigrationsEndPoint();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }
      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      context.Database.Migrate();
      app.UseCors("CORSPolicy");

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
        endpoints.MapRazorPages();
      });
    }
  }
}

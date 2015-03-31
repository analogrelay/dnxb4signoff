using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Identity.EntityFramework;
using DnxSignOff.Models;
using Microsoft.Data.Entity;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity;

namespace DnxSignOff
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Setup configuration sources.
            Configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.Get("Data:DefaultConnection:ConnectionString")));
            services.AddIdentity<ApplicationUser, IdentityRole>(id =>
            {
                id.Password.RequireUppercase = false;
                id.Password.RequireDigit = false;
                id.Password.RequireNonLetterOrDigit = false;
                id.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExistingDbAndCoreLib.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExistingDbAndCoreLib
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
            // Data Source=GLANSEN\\SQLEXPRESS;Initial Catalog=dbSchool;Integrated Security=True
            // Scaffold-DbContext "Data Source=GLANSEN\\SQLEXPRESS;Initial Catalog=dbSchool;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DAL
            // Scaffold-DbContext "Server=\\GLANSEN\\SQLEXPRESS;Database=dbSchool;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DAL
            // Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            string dbSchoolConnection = Configuration.GetConnectionString("dbSchoolConnection");
            services.AddDbContext<dbSchoolContext>(options => options.UseSqlServer(dbSchoolConnection));            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}

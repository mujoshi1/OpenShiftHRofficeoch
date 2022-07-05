using HrOffice.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace HrOffice
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
            services.AddSession();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc(opt =>
            {
                opt.EnableEndpointRouting = false;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //ASPNETCORE_ENVIRONMENT  = Development
            var host = Configuration["DBHOST"] ?? "localhost";//mysqlhrdev//mysqlhrqa //127/0.0.1 / env Variable /mysqlhrstage /mysqldevdb ( new use)
            var port = Configuration["DBPORT"] ?? "3306";
            var databasename = Configuration["DBNAME"] ?? "hrdbstage";   //"hrdbdev";  
            var userid = Configuration["DBUSER"] ?? "hrdbstage";// "hrusername";
            var password = Configuration["DBPASSWORD"] ?? "hrpassword";
            //for MsSql
            
            //var MSSQL_SERVICE = Configuration["MSSQL_SERVICE"] ?? "mssqlhrochdb";  //localhost // SubscriptionPortalpassword

            //var MYSQL_USER = Configuration["MSSQL_SA_PASSWORD"] ?? "dbpassword";   // SubscriptionPortalpassword            
            //var MYSQL_PASSWORD = Configuration["SA_PASSWORD"] ?? "dbpassword";   // SubscriptionPortalpassword            
            //var MYSQL_DATABASE = Configuration["SA_PASSWORD"] ?? "dbpassword";   // SubscriptionPortalpassword            

            //var MSSQL_SA_PASSWORD = Configuration["MSSQL_SA_PASSWORD"] ?? "dbpassword";   // SubscriptionPortalpassword            
            //var MSSQL_SERVICE_NAME = Configuration["MSSQL_SERVICE_NAME"] ?? "mssqlhrochdb";   //localhost// SubscriptionPortalpassword
            // port = Configuration["DBPORT"] ?? "1433";

            services.AddDbContext<HrOfficeContext>(options =>
            {
                options.UseMySql(
                    $"server={host}; userid={userid}; pwd={password};"
                                + $"port={port}; database={databasename}");
            });

            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env
            //EmployeeContext context
            )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //context.Database.Migrate();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                    //template: "{controller=Login}/{action=Login}/{id?}");
                     // template: "{controller=Emp}/{action=Index}/{id?}");

            });
        }

    }
}


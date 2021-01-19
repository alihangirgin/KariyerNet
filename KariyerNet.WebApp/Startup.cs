using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KariyerNet.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Design;
using KariyerNet.Data.Domain;
using Microsoft.AspNetCore.Identity;
using KariyerNet.Business.Interfaces;
using KariyerNet.Business.Services;
using KariyerNet.Data.Interfaces;
using KariyerNet.Data.Repositories;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace KariyerNet.WebApp
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
            var connectionString = Configuration.GetConnectionString("AppDatabase");
            services.AddDbContext<KariyerNetDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IEducationLevelService, EducationLevelService>();
            services.AddScoped<IDepartmantService, DepartmantService>();
            services.AddScoped<IWorkTypeService, WorkTypeService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<ICompanyFollowerService, CompanyFollowerService>();

            services.AddScoped<IJobAdvertisementService, JobAdvertisementService>();
            services.AddScoped<ICompanyDetailService, CompanyDetailService>();
            services.AddScoped<IUserDetailService, UserDetailService>();
            services.AddScoped<ISectorService, SectorService>();
            services.AddScoped<ICompanyDetailRepository, CompanyDetailRepository>();
            services.AddScoped<ISectorRepository, SectorRepository>();
            services.AddScoped<IUserDetailRepository, UserDetailRepository>();
            services.AddScoped<IJobAdvertisementRepository, JobAdvertisementRepository>();
            services.AddScoped<IDrivingLicenseService, DrivingLicenseService>();
            services.AddScoped<INationalityService, NationalityService>();
            services.AddScoped<IMessageService, MessageService>();

            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IEducationLevelRepository, EducationLevelRepository>();
            services.AddScoped<IDepartmantRepository, DepartmantRepository>();
            services.AddScoped<IWorkTypeRepository, WorkTypeRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<ICompanyFollowerRepository, CompanyFollowerRepository>();
            services.AddScoped<IAdvertisementViewCountRepository, AdvertisementViewCountRepository>();
            services.AddScoped<IAdvertisementApplyRepository, AdvertisementApplyRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserCurriculumVitaeService, UserCurriculumVitaeService>();
            services.AddScoped<IUserCurriculumVitaeRepository, UserCurriculumVitaeRepository>();
            services.AddScoped<INationalityRepository, NationalityRepository>();
            services.AddScoped<IDrivingLicenseRepository, DrivingLicenseRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            services.AddHttpContextAccessor();

            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
            //services.AddTransient<ClaimsPrincipal>(s => s.GetService<IHttpContextAccessor>().HttpContext.User);

            services.AddIdentity<User, Role>()
              .AddRoles<Role>()
              .AddRoleManager<RoleManager<Role>>()
              .AddEntityFrameworkStores<KariyerNetDbContext>()
              .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                //options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = false;
            });

            services.Configure<IdentityOptions>(options =>
            {

                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 4;

                // User settings
                options.User.RequireUniqueEmail = true;
            });


            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using Business.Abstract;
using Business.Concrete;
using Business.ViewModels;
using Business.ViewModels.User;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using DataAccess.Concrete.EntityFramework.Repositories;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebUI
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
            services.AddDbContext<GraduationProjectContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies());

            services.AddIdentity<User,Role>(
            options =>
            {
                options.SignIn.RequireConfirmedAccount = false;

                //Other options go here
            }).AddEntityFrameworkStores<GraduationProjectContext>();

            //services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<GraduationProjectContext>();


            services.AddScoped<DbContext, GraduationProjectContext>();
            services.AddControllers();
            services.AddCors();
            services.AddAutoMapper(typeof(ViewModel).Assembly);           
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserDal, EfUserDal>();
            services.AddScoped<IBlockService, BlockService>();
            services.AddScoped<IBlockDal, EfBlockDal>();
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IApartmentDal, EfApartmentDal>();
            services.AddScoped<IEmailSendService, EmailSendService>();
            services.AddScoped<IEmailSendDal, EfEmailSendDal>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleDal, EfRoleDal>();
            services.AddControllersWithViews();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie(options =>
           {
               options.Cookie.Name = "authToken";
               options.LoginPath = new PathString("/Home/SignUp");
               options.LogoutPath = new PathString("/Home/Logout");
               options.ExpireTimeSpan = TimeSpan.FromMinutes(120);
               options.AccessDeniedPath = new PathString("/User/AccesDenied");
               options.Events = new CookieAuthenticationEvents()
               {
                   OnRedirectToLogin = (context) =>
                   {
                       context.HttpContext.Response.Redirect("https://example.com/test/expired.html");
                       return Task.CompletedTask;
                   }
               };
           });

            //CookieBuilder cookieBuilder = new CookieBuilder();
            //cookieBuilder.Name = "MySite";
            //cookieBuilder.HttpOnly = false;
            //cookieBuilder.Expiration = System.TimeSpan.FromDays(60);
            //cookieBuilder.SameSite = SameSiteMode.Lax;
            //cookieBuilder.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            //services.ConfigureApplicationCookie(options=>
            //{
            //    options.LoginPath = new PathString("/Home/Login");
            //    options.Cookie = cookieBuilder;
            //    options.SlidingExpiration = true;
            //});                                 
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

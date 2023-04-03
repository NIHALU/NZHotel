using System;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NZHotel.Business.DependencyResolvers.Microsoft;
using NZHotel.Business.Helpers;
using NZHotel.DataAccess.Contexts;
using NZHotel.DataAccess.Entities;
using NZHotel.UI.Areas.Admin.Models;
using NZHotel.UI.Areas.Management.Models;
using NZHotel.UI.Areas.Member.Models;
using NZHotel.UI.Areas.Reception.Models;
using NZHotel.UI.Mappings.AutoMapper;
using NZHotel.UI.ValidationRules;

namespace NZHotel.UI
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
            services.AddDependencies(Configuration);
            services.AddTransient<IValidator<RoomCreateViewModel>, RoomCreateModelValidator>();
            services.AddTransient<IValidator<RoomUpdateViewModel>, RoomUpdateModelValidator>();

            services.AddTransient<IValidator<RoomDetailCreateModel>, RoomDetailCreateModelValidator>();
            services.AddTransient<IValidator<RoomDetailUpdateModel>, RoomDetailUpdateModelValidator>();

            services.AddTransient<IValidator<CustomerCreateModel>, CustomerCreateModelValidator>();

            services.AddTransient<IValidator<BookRoomModel>, BookRoomModelValidator>();
            services.AddTransient<IValidator<BookingRoomModel>, BookingRoomModelValidator>();
            services.AddTransient<IValidator<BookRoomUpdateModel>, BookRoomUpdateModelValidator>();
            services.AddTransient<IValidator<GuestInfoCreateModel>, GuestInfoCreateModelValidator>();

            services.AddTransient<IValidator<PaymentCreateModel>, PaymentCreateModelValidator>();
            services.AddTransient<IValidator<PaymentCreateModel2>, PaymentCreateModel2Validator>();
            services.AddTransient<IValidator<GuestCreateModel>, GuestCreateModelValidator>();

            services.AddTransient<IValidator<EmployeeCreateModel>, EmployeeCreateModelValidator>();
            services.AddTransient<IValidator<EmployeeUpdateModel>, EmployeeUpdateModelValidator>();

            services.AddTransient<IValidator<EmployeeFileCreateModel>, EmployeeFileCreateModelValidator>();
            services.AddTransient<IValidator<EmployeeFileUpdateModel>, EmployeeFileUpdateModelValidator>();

            services.AddTransient<IValidator<ShiftCreateModel>, ShiftCreateModelValidator>();
            services.AddTransient<IValidator<ShiftUpdateModel>, ShiftUpdateModelValidator>();

            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false; //number required or not? 
                opt.Password.RequiredLength = 1;  //minimum lenght 
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.SignIn.RequireConfirmedEmail = false;    //default is False mail confirmed or not? 
                opt.Lockout.MaxFailedAccessAttempts = 3;   //after howm many times? will be locked
            }).AddEntityFrameworkStores<ProjectContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.HttpOnly = true;   // cannot be reached to the cookie via js 
                opt.Cookie.SameSite = SameSiteMode.Strict; //cookie can be used on only related domain 
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;  //https http
                opt.Cookie.Name = "ProjectCookie";
                opt.ExpireTimeSpan = TimeSpan.FromDays(25);   //cookie expiration time period (minutes)
                opt.LoginPath = new PathString("/Home/SignIn");
                opt.AccessDeniedPath = new PathString("/Home/AccessDenied");

            });

            services.AddControllersWithViews();

            var profiles = ProfileHelper.GetProfiles();
            profiles.Add(new RoomCreateViewModelProfile());
            profiles.Add(new RoomUpdateViewModelProfile());

            profiles.Add(new RoomDetailCreateModelProfile());
            profiles.Add(new RoomDetailUpdateModelProfile());

            profiles.Add(new CustomerCreateModelProfile());
            profiles.Add(new BookRoomCreateModelProfile());

            profiles.Add(new GuestInfoCreateModelProfile());

            profiles.Add(new BookRoomUpdateModelProfile());

            profiles.Add(new GuestCreateModelProfile());
            profiles.Add(new BookingRoomModelProfile());

            profiles.Add(new EmployeeCreateModelProfile());
            profiles.Add(new EmployeeUpdateModelProfile());

            profiles.Add(new EmployeeFileCreateModelProfile());
            profiles.Add(new EmployeeFileUpdateModelProfile());


            profiles.Add(new ShiftCreateModelProfile());
            profiles.Add(new ShiftUpdateModelProfile());



            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfiles(profiles);
            });
            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(50);
            });
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

            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area:exists}/{controller=Home}/{action=SignIn}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=SignIn}/{id?}");
            });
        }
    }
}

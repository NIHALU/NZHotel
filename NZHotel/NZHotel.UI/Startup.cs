using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NZHotel.Business.DependencyResolvers.Microsoft;
using NZHotel.Business.Helpers;
using NZHotel.UI.Areas.Admin.Models;
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
            services.AddTransient<IValidator<GuestInfoCreateModel>, GuestInfoCreateModelValidator>();
            services.AddTransient<IValidator<PaymentCreateModel>, PaymentCreateModelValidator>();



            services.AddControllersWithViews();

            var profiles = ProfileHelper.GetProfiles();
            profiles.Add(new RoomCreateViewModelProfile());
            profiles.Add(new RoomUpdateViewModelProfile());

            profiles.Add(new RoomDetailCreateModelProfile());
            profiles.Add(new RoomDetailUpdateModelProfile());

            profiles.Add(new CustomerCreateModelProfile());
            profiles.Add(new BookRoomCreateModelProfile());

            profiles.Add(new GuestInfoCreateModelProfile());



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
                   pattern: "{Area=Reception}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

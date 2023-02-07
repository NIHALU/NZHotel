using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NZHotel.Business.Interfaces;
using NZHotel.Business.Services;
using NZHotel.Business.ValidationRules;
using NZHotel.DataAccess.Contexts;
using NZHotel.DataAccess.UnitOfWork;
using NZHotel.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjectContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("conString"));

            });

            services.AddScoped<IUow, Uow>();
            services.AddTransient<IValidator<RoomCreateDto>, RoomCreateDtoValidator>();
            services.AddTransient<IValidator<RoomUpdateDto>, RoomUpdateDtoValidator>();

            services.AddTransient<IValidator<RoomStatusCreateDto>, RoomStatusCreateDtoValidator>();
            services.AddTransient<IValidator<RoomStatusUpdateDto>, RoomStatusUpdateDtoValidator>();

            services.AddTransient<IValidator<RoomTypeCreateDto>, RoomTypeCreateDtoValidator>();
            services.AddTransient<IValidator<RoomTypeUpdateDto>, RoomTypeUpdateDtoValidator>();

            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomStatusService, RoomStatusService>();
            services.AddScoped<IRoomTypeService, RoomTypeService>();
        }
    }
}

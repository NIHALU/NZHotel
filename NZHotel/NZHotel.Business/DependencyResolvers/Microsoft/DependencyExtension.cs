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
using NZHotel.DTOs.DepartmentDtos;

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

            services.AddTransient<IValidator<RoomDetailCreateDto>, RoomDetailCreateDtoValidator>();
            services.AddTransient<IValidator<RoomDetailUpdateDto>, RoomDetailUpdateDtoValidator>();

            services.AddTransient<IValidator<ReservationCreateDto>, ReservationCreateDtoValidator>();
            services.AddTransient<IValidator<ReservationUpdateDto>, ReservationUpdateDtoValidator>();

            services.AddTransient<IValidator<ReservationOptionCreateDto>, ReservationOptionCreateDtoValidator>();
            services.AddTransient<IValidator<ReservationOptionUpdateDto>, ReservationOptionUpdateDtoValidator>();

            services.AddTransient<IValidator<RoomStatusCreateDto>, RoomStatusCreateDtoValidator>();
            services.AddTransient<IValidator<RoomStatusUpdateDto>, RoomStatusUpdateDtoValidator>();

            services.AddTransient<IValidator<RoomTypeCreateDto>, RoomTypeCreateDtoValidator>();
            services.AddTransient<IValidator<RoomTypeUpdateDto>, RoomTypeUpdateDtoValidator>();

            services.AddTransient<IValidator<CleaningStatusCreateDto>, CleaningStatusCreateDtoValidator>();
            services.AddTransient<IValidator<CleaningStatusUpdateDto>, CleaningStatusUpdateDtoValidator>();

            services.AddTransient<IValidator<BookRoomCreateDto>, BookRoomCreateDtoValidator>();

            services.AddTransient<IValidator<CustomerCreateDto>, CustomerCreateDtoValidator>();
            services.AddTransient<IValidator<CustomerUpdateDto>, CustomerUpdateDtoValidator>();

            services.AddTransient<IValidator<GuestCreateDto>, GuestCreateDtoValidator>();
            services.AddTransient<IValidator<GuestUpdateDto>, GuestUpdateDtoValidator>();

            services.AddTransient<IValidator<GuestInfoCreateDto>, GuestInfoCreateDtoValidator>();
            services.AddTransient<IValidator<GuestInfoUpdateDto>, GuestInfoUpdateDtoValidator>();

            services.AddTransient<IValidator<PaymentTypeCreateDto>, PaymentTypeCreateDtoValidator>();
            services.AddTransient<IValidator<PaymentTypeUpdateDto>, PaymentTypeUpdateDtoValidator>();

            services.AddTransient<IValidator<GuestTypeCreateDto>, GuestTypeCreateDtoValidator>();
            services.AddTransient<IValidator<GuestTypeUpdateDto>, GuestTypeUpdateDtoValidator>();

            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>();
            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();

            services.AddTransient<IValidator<GuestReservationCreateDto>, GuestReservationCreateDtoValidator>();
            services.AddTransient<IValidator<GuestReservationUpdateDto>, GuestReservationUpdateDtoValidator>();

            services.AddTransient<IValidator<EmployeeCreateDto>, EmployeeCreateDtoValidator>();
            services.AddTransient<IValidator<EmployeeUpdateDto>, EmployeeUpdateDtoValidator>();

            services.AddTransient<IValidator<EmployeeFileCreateDto>, EmployeeFileCreateDtoValidator>();
            services.AddTransient<IValidator<EmployeeFileUpdateDto>, EmployeeFileUpdateDtoValidator>();

            services.AddTransient<IValidator<ShiftCreateDto>, ShiftCreateDtoValidator>();
            services.AddTransient<IValidator<ShiftUpdateDto>,  ShiftUpdateDtoValidator>();

            services.AddTransient<IValidator<DepartmentCreateDto>, DepartmentCreateDtoValidator>();
            services.AddTransient<IValidator<DepartmentUpdateDto>, DepartmentUpdateDtoValidator>();


            services.AddTransient<IValidator<WorkingTypeCreateDto>, WorkingTypeCreateDtoValidator>();
            services.AddTransient<IValidator<WorkingTypeUpdateDto>, WorkingTypeUpdateDtoValidator>();

            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomDetailService, RoomDetailService>();
            services.AddScoped<IRoomStatusService, RoomStatusService>();
            services.AddScoped<IRoomTypeService, RoomTypeService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IReservationOptionService, ReservationOptionService>();
            services.AddScoped<ICleaningStatusService,CleaningStatusService>();
            services.AddScoped<ICustomerService,CustomerService>();
            services.AddScoped<IGuestService,GuestService>();
            services.AddScoped<IGuestInfoService,GuestInfoService>();
            services.AddScoped<IPaymentTypeService, PaymentTypeService>();
            services.AddScoped<IGuestTypeService, GuestTypeService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IGuestReservationService, GuestReservationService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeFileService, EmployeeFileService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IWorkingTypeService, WorkingTypeService>();
            services.AddScoped<IShiftService, ShiftService>();





        }
    }
}

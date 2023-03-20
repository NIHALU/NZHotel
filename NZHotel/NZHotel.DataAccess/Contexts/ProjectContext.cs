using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NZHotel.DataAccess.Configurations;
using NZHotel.DataAccess.Entities;
using NZHotel.Entities;
using NZHotel.Entities.Employee;

namespace NZHotel.DataAccess.Contexts
{
    public class ProjectContext : IdentityDbContext<AppUser, AppRole, int>
    {
        //public DbSet<AppUser> AppUsers { get; set; }
        //public DbSet<AppRole> AppRoles { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoomConf());
            builder.ApplyConfiguration(new RoomDetailConf());
            builder.ApplyConfiguration(new RoomStatusConf());
            builder.ApplyConfiguration(new RoomTypeConf());
            builder.ApplyConfiguration(new CleaningStatusConf());
            builder.ApplyConfiguration(new GuestConf());
            builder.ApplyConfiguration(new GuestTypeConf());
            builder.ApplyConfiguration(new CustomerConf());
            builder.ApplyConfiguration(new DepartmentConf());
            builder.ApplyConfiguration(new EmployeeConf());
            builder.ApplyConfiguration(new EmployeeDetailConf());
            builder.ApplyConfiguration(new GenderConf());
            builder.ApplyConfiguration(new ReservationConf());
            builder.ApplyConfiguration(new ReservationOptionConf());
            builder.ApplyConfiguration(new ReservationTypeConf());
            builder.ApplyConfiguration(new PaymentStatusConf());
            builder.ApplyConfiguration(new GuestReservationConf());
            builder.ApplyConfiguration(new ImageConf());
            builder.ApplyConfiguration(new PaymentConf());
            builder.ApplyConfiguration(new PaymentTypeConf());
            base.OnModelCreating(builder);
        }


        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomDetail> RoomDetails { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RoomStatus> RoomStatuses { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<NZHotel.Entities.Employees.Employee> Employees { get; set; }
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<GuestType> GuestTypes { get; set; }
        public DbSet<GuestReservation> GuestReservations { get; set; }
        public DbSet<ReservationOption> ReservationOptions { get; set; }
        public DbSet<ReservationType> ReservationTypes { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public DbSet<CleaningStatus> CleaningStatuses { get; set; }
        public DbSet<Payment> Payments  { get; set; }
        public DbSet<PaymentType> PaymentTypes  { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}

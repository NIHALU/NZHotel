using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NZHotel.DataAccess.Configurations;
using NZHotel.DataAccess.Entities;
using NZHotel.Entities;
using NZHotel.Entities.Employee;

namespace NZHotel.DataAccess.Contexts
{
    public class ProjectContext:IdentityDbContext<AppUser,AppRole,int>
    {
        //public DbSet<AppUser> AppUsers { get; set; }
        //public DbSet<AppRole> AppRoles { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options) :base(options)
     {

     }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoomConf());
            builder.ApplyConfiguration(new GuestConf());
            builder.ApplyConfiguration(new ReservationConf());
            builder.ApplyConfiguration(new DepartmentConf());
            builder.ApplyConfiguration(new EmployeeConf());
            builder.ApplyConfiguration(new EmployeeDetailConf());
            builder.ApplyConfiguration(new RoomStatusConf());
            builder.ApplyConfiguration(new RoomTypeConf());
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




    }
}

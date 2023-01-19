using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NZHotel.DataAccess.Entities;
using NZHotel.Entities;

namespace NZHotel.DataAccess.Contexts
{
    public class ProjectContext:IdentityDbContext<AppUser,AppRole,int>
    {
      //public DbSet<AppUser> AppUsers { get; set; }
      //public DbSet<AppRole> AppRoles { get; set; }

     public ProjectContext(DbContextOptions<ProjectContext> options) :base(options)
     {

     }

      //protected override void OnModelCreating (ModelBuilder modelBuilder)
    }
}

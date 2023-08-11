using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DataAccess.Contexts;
using NZHotel.DataAccess.Interfaces;
using NZHotel.DataAccess.Repositories;
using NZHotel.Entities;

namespace NZHotel.DataAccess.UnitOfWork
{
    public class Uow:IUow
    {
        private readonly ProjectContext _context;

        public Uow(ProjectContext context)
        {
            _context = context;""
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

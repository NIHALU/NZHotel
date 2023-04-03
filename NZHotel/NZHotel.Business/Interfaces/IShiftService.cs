using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs;
using NZHotel.Entities.Employees;

namespace NZHotel.Business.Interfaces
{
    public interface IShiftService : IService<ShiftCreateDto, ShiftUpdateDto, ShiftListDto, Shift>
    {
        Task<List<ShiftListDto>> Getlist();
    }
}

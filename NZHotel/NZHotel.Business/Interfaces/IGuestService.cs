using NZHotel.DTOs;
using NZHotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Business.Interfaces
{
    public interface IGuestService : IService<GuestCreateDto, GuestUpdateDto, GuestListDto, Guest>
    {
        Task Create(List<GuestCreateDto> dtos);
        List<GuestListDto> Getlist();
        bool VisitedBefore(int id);
    }
}

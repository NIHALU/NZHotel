using NZHotel.Common;
using NZHotel.DTOs;
using NZHotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Business.Interfaces
{
    public interface IGuestInfoService: IService<GuestInfoCreateDto, GuestInfoUpdateDto, GuestInfoListDto, GuestInfo>
    {
        Task Create(GuestInfoCreateDto dto);
        Task<IResponse<List<GuestInfoListDto>>> GuestInfo(int reservationId);

        Task<IResponse<List<GuestInfoListDto>>> GuestInfoUpdated(int reservationId);
    }
}

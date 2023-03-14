using NZHotel.DTOs;
using NZHotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Business.Interfaces
{
    public interface ICleaningStatusService:IService<CleaningStatusCreateDto,CleaningStatusUpdateDto,CleaningStatusListDto,CleaningStatus>
    {

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs;
using NZHotel.Entities;

namespace NZHotel.Business.Interfaces
{
    public interface IWorkingTypeService : IService<WorkingTypeCreateDto, WorkingTypeUpdateDto, WorkingTypeListDto, WorkingType>
    {

    }
    
}

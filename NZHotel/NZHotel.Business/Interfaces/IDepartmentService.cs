using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs.DepartmentDtos;
using NZHotel.Entities;

namespace NZHotel.Business.Interfaces
{
    public interface IDepartmentService: IService<DepartmentCreateDto, DepartmentUpdateDto, DepartmentListDto, Department>
    {

    }
}

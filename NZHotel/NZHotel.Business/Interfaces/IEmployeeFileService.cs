using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs;
using NZHotel.Entities.Employees;

namespace NZHotel.Business.Interfaces
{
    public interface IEmployeeFileService : IService<EmployeeFileCreateDto, EmployeeFileUpdateDto, EmployeeFileListDto, EmployeeFile>
    {
        Task<List<EmployeeFileListDto>> Getlist();

        Task<List<EmployeeFileListDto>> SeeFile(int employeeId);
    }
}

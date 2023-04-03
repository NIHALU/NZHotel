using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NZHotel.Business.Interfaces;
using NZHotel.Common.Enums;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Management.Models;
using NZHotel.UI.Extensions;

namespace NZHotel.UI.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = "Manager")]
    public class EmployeeFileController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeFileService _employeeFileService;
        private readonly IEmployeeService _employeeService;
        private readonly IWorkingTypeService _workingTypeService;
        private readonly IValidator<EmployeeFileCreateModel> _employeeFileCreateVal;
        private readonly IValidator<EmployeeFileUpdateModel> _employeeFileUpdateVal;

        public EmployeeFileController(IMapper mapper, IEmployeeFileService employeeFileService, IEmployeeService employeeService, IWorkingTypeService workingTypeService, IValidator<EmployeeFileCreateModel> employeeFileCreateVal, IValidator<EmployeeFileUpdateModel> employeeFileUpdateVal)
        {
            _mapper = mapper;
            _employeeFileService = employeeFileService;
            _employeeService = employeeService;
            _workingTypeService = workingTypeService;
            _employeeFileCreateVal = employeeFileCreateVal;
            _employeeFileUpdateVal = employeeFileUpdateVal;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Create()
        {
            var response1 = await _workingTypeService.GetAllAsync();
            var response2 = await _employeeService.GetAllAsync();

            var model = new EmployeeFileCreateModel()
            {
                WorkingTypes = new SelectList(response1.Data, "Id", "Definition"),
                Employees = new SelectList(response2.Data, "Id", "IdentityNumber"),

            };
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeFileCreateModel model)
        {

            var result = _employeeFileCreateVal.Validate(model);
            if (result.IsValid)
            {
                if (model.WorkingTypeId==(int)WorkingType.Irregular)
                {
                    model.Salary =model.CalculateIrregularSalary();
                }
                else
                {
                    model.Salary = model.CalculateRegularSalary();
                }
                var dto = _mapper.Map<EmployeeFileCreateDto>(model);
                var response = await _employeeFileService.CreateAsync(dto);
                return this.ResponseRedirectAction(response, "List");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            var response1 = await _workingTypeService.GetAllAsync();
            var response2 = await _employeeService.GetAllAsync();
        
            model.WorkingTypes = new SelectList(response1.Data, "Id", "Definition");
            model.Employees = new SelectList(response2.Data, "Id", "IdentityNumber");
  
            return View(model);
        }

     


        public async Task<IActionResult> Update(int employeeFileId)
        {
            var response = await _employeeFileService.GetByIdAsync<EmployeeFileUpdateDto>(employeeFileId);
            if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound();
            }
            var model = _mapper.Map<EmployeeFileUpdateModel>(response.Data);
            var response1 = await _workingTypeService.GetAllAsync();
            var response2 = await _employeeService.GetAllAsync();

            model.WorkingTypes = new SelectList(response1.Data, "Id", "Definition");
            model.Employees = new SelectList(response2.Data, "Id", "IdentityNumber");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EmployeeFileUpdateModel model)
        {
            var result = _employeeFileUpdateVal.Validate(model);
            if (result.IsValid)
            {
                if (model.WorkingTypeId == (int)WorkingType.Irregular)
                {
                    model.Salary = model.CalculateIrregularSalary();
                }
                else
                {
                    model.Salary = model.CalculateRegularSalary();
                }
                var dto = _mapper.Map<EmployeeFileUpdateDto>(model);
                var response = await _employeeFileService.UpdateAsync(dto);
                return this.ResponseRedirectAction(response, "List");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            var response1 = await _workingTypeService.GetAllAsync();
            var response2 = await _employeeService.GetAllAsync();

            model.WorkingTypes = new SelectList(response1.Data, "Id", "Definition");
            model.Employees = new SelectList(response2.Data, "Id", "IdentityNumber");
           
            return View(model);

        }

        public async Task<IActionResult> List()
        {
            var list = await _employeeFileService.Getlist();
            foreach (var item in list)
            {
                if (item.OvertimeWage != null && item.OvertimeNumber != null)
                {
                    item.SalaryWithOverTime = item.CalculateOverTimeSalary();
                }

            }
            return View(list);
        }

       

        public async Task<IActionResult> Remove(int employeeFileId)
        {
            var response = await _employeeFileService.RemoveAsync(employeeFileId);
            return this.ResponseRedirectAction(response, "List");
        }



    }
}

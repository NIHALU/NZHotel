using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NZHotel.Business.Interfaces;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Management.Models;
using NZHotel.UI.Extensions;

namespace NZHotel.UI.Areas.Management.Controllers
{
    [Area("Management")]
    public class EmployeeController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;
        private readonly IValidator<EmployeeCreateModel> _employeeCreateModelVal;
        private readonly IValidator<EmployeeUpdateModel> _employeeUpdateModelVal;
        private readonly IMapper _mapper;

        public EmployeeController(IGenderService genderService, IDepartmentService departmentService, IEmployeeService employeeService, IValidator<EmployeeCreateModel> employeeCreateModelVal, IValidator<EmployeeUpdateModel> employeeUpdateModelVal, IMapper mapper)
        {
            _genderService = genderService;
            _departmentService = departmentService;
            _employeeService = employeeService;
            _employeeCreateModelVal = employeeCreateModelVal;
            _employeeUpdateModelVal = employeeUpdateModelVal;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var response1 = await _genderService.GetAllAsync();
            var response2 = await _departmentService.GetAllAsync();

            var model = new EmployeeCreateModel()
            {
                Genders = new SelectList(response1.Data, "Id", "Definition"),
                Departments = new SelectList(response2.Data, "Id", "Title"),

            };
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateModel model)
        {

            var result = _employeeCreateModelVal.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<EmployeeCreateDto>(model);
                var response = await _employeeService.CreateAsync(dto);
                return this.ResponseRedirectAction(response, "List");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            var response1 = await _genderService.GetAllAsync();
            var response2 = await _departmentService.GetAllAsync();

            model.Genders = new SelectList(response1.Data, "Id", "Definition");
            model.Departments = new SelectList(response2.Data, "Id", "Title");
            return View(model);

        }

        public async Task<IActionResult> List()
        {
            var list = await _employeeService.GetEmployeeList();
            return View(list);
        }

        public async Task<IActionResult> Update(int employeeId)
        {
            var response = await _employeeService.GetByIdAsync<EmployeeUpdateDto>(employeeId);
            if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound();
            }
            var model = _mapper.Map<EmployeeUpdateModel>(response.Data);

            var response1 = await _genderService.GetAllAsync();
            var response2 = await _departmentService.GetAllAsync();

            model.Genders = new SelectList(response1.Data, "Id", "Definition");
            model.Departments = new SelectList(response2.Data, "Id", "Title");

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Update(EmployeeUpdateModel model)
        {
            var result = _employeeUpdateModelVal.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<EmployeeUpdateDto>(model);
                var response = await _employeeService.UpdateAsync(dto);
                return this.ResponseRedirectAction(response, "List");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            var response1 = await _genderService.GetAllAsync();
            var response2 = await _departmentService.GetAllAsync();

            model.Genders = new SelectList(response1.Data, "Id", "Definition");
            model.Departments = new SelectList(response2.Data, "Id", "Title");
            return View(model);
        }

        //public async Task<IActionResult> Remove(int roomId)
        //{
        //    var response = await _roomService.RemoveAsync(roomId);
        //    return this.ResponseRedirectAction(response, "List");
        //}
    }
}

using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NZHotel.Business.Interfaces;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Management.Models;
using NZHotel.UI.Extensions;

namespace NZHotel.UI.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = "Manager")]
    public class ShiftController : Controller
    {
        private readonly IShiftService _shiftService;
        private readonly IEmployeeService _employeeService;
        private readonly IValidator<ShiftCreateModel> _shiftCreateModelValidator;
        private readonly IValidator<ShiftUpdateModel> _shiftUpdateModelValidator;
        private readonly IMapper _mapper;

        public ShiftController(IShiftService shiftService, IEmployeeService employeeService, IValidator<ShiftCreateModel> shiftCreateModelValidator, IMapper mapper)
        {
            _shiftService = shiftService;
            _employeeService = employeeService;
            _shiftCreateModelValidator = shiftCreateModelValidator;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var response1 = await _employeeService.GetAllAsync();


            var model = new ShiftCreateModel()
            {
                Employees = new SelectList(response1.Data, "Id", "Name"),

            };
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Create(ShiftCreateModel model)
        {

            var result = _shiftCreateModelValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<ShiftCreateDto>(model);
                var response = await _shiftService.CreateAsync(dto);
                return this.ResponseRedirectAction(response, "List");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            var response1 = await _employeeService.GetAllAsync();

            model.Employees = new SelectList(response1.Data, "Id", "Name");
            return View(model);

        }

        public async Task<IActionResult> List()
        {
            var list = await _shiftService.Getlist();
            return View(list);
        }


        public async Task<IActionResult> Update(int shiftId)
        {
            var response = await _shiftService.GetByIdAsync<ShiftUpdateDto>(shiftId);
            if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound();
            }
            var model = _mapper.Map<ShiftUpdateModel>(response.Data);
            var response1 = await _employeeService.GetAllAsync();

            model.Employees = new SelectList(response1.Data, "Id", "Name");


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ShiftUpdateModel model)
        {
            var result = _shiftUpdateModelValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<ShiftUpdateDto>(model);
                var response = await _shiftService.UpdateAsync(dto);
                return this.ResponseRedirectAction(response, "List");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            var response1 = await _employeeService.GetAllAsync();


            model.Employees = new SelectList(response1.Data, "Id", "Name");

            return View(model);

        }

        public async Task<IActionResult> Remove(int shiftId)
        {
            var response = await _shiftService.RemoveAsync(shiftId);
            return this.ResponseRedirectAction(response, "List");
        }
    }
}

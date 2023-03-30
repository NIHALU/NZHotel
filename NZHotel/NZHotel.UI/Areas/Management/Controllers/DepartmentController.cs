using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NZHotel.Business.Interfaces;
using NZHotel.DTOs.DepartmentDtos;
using NZHotel.UI.Extensions;

namespace NZHotel.UI.Areas.Management.Controllers
{
    [Area("Management")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {

            return View(new DepartmentCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentCreateDto dto)
        {
            var response = await _departmentService.CreateAsync(dto);
            return this.ResponseRedirectAction(response, "List");
        
        }

        public async Task<IActionResult> List()
        {
            var response = await _departmentService.GetAllAsync();
            return View(response.Data);
        }

        public async Task<IActionResult> Update(int departmentId)
        {
            var response = await _departmentService.GetByIdAsync<DepartmentUpdateDto>(departmentId);
            if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound();
            }

            return View(response.Data);
         
        }

        public async Task<IActionResult> Update(DepartmentUpdateDto dto)
        {
            var response = await _departmentService.UpdateAsync(dto);
            return this.ResponseRedirectAction(response, "List");

        }

        public async Task<IActionResult> Remove(int departmentId)
        {
            var response = await _departmentService.RemoveAsync(departmentId);
            return this.ResponseRedirectAction(response, "List");
        }



    }
}

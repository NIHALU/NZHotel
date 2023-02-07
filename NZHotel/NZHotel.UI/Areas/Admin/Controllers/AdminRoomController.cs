using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NZHotel.Business.Interfaces;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Admin.Models;
using NZHotel.UI.Extensions;

namespace NZHotel.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRoomController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IRoomStatusService _roomStatusService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly IMapper _mapper;
        private readonly IValidator<RoomCreateViewModel> _roomCreateModelValidator;

        public AdminRoomController(IRoomStatusService roomStatusService, IRoomTypeService roomTypeService,IRoomService roomService, IValidator<RoomCreateViewModel> roomCreateModelValidator, IMapper mapper)
        {
            _roomService = roomService;
            _roomStatusService = roomStatusService;
            _roomTypeService = roomTypeService;
            _roomCreateModelValidator = roomCreateModelValidator;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var response1= await _roomTypeService.GetAllAsync();
            var response2 = await _roomStatusService.GetAllAsync();
            var model = new RoomCreateViewModel()
            {
                RoomTypes = new SelectList(response1.Data, "Id", "Definition"),
                RoomStatuses = new SelectList(response2.Data, "Id", "Definition")
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomCreateViewModel model)
        {
            var result = _roomCreateModelValidator.Validate(model);
            if (result.IsValid)
            {
                var dto=_mapper.Map<RoomCreateDto>(model);
                var response= await _roomService.CreateAsync(dto);
                return this.ResponseRedirectAction(response,"List");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            var response1 = await _roomTypeService.GetAllAsync();
            var response2 = await _roomStatusService.GetAllAsync();
            model.RoomTypes = new SelectList(response1.Data, "Id", "Definition");
            model.RoomStatuses = new SelectList(response2.Data, "Id", "Definition");
            return View(model);     
        }

        public async Task<IActionResult> List()
        {
            var response = await _roomService.GetAllAsync();
            return this.ResponseView(response);
        }

    }
}

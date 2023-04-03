using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NZHotel.Business.Interfaces;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Admin.Models;
using NZHotel.UI.Extensions;

namespace NZHotel.UI.Areas.Admin.Controllers
{
    [Area("Management")]
   
    public class RoomDetailController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        private readonly IRoomDetailService _roomDetailService;
        private readonly IValidator<RoomDetailCreateModel> _roomDetailCreateModelValidator;
        private readonly IValidator<RoomDetailUpdateModel> _roomDetailUpdateModelValidator;



        public RoomDetailController(IRoomDetailService roomDetailService, IRoomService roomService, IMapper mapper, IValidator<RoomDetailCreateModel> roomDetailCreateModelValidator, IValidator<RoomDetailUpdateModel> roomDetailUpdateModelValidator)
        {
            _roomDetailService = roomDetailService;
            _roomService = roomService;
            _mapper = mapper;
            _roomDetailCreateModelValidator = roomDetailCreateModelValidator;
            _roomDetailUpdateModelValidator = roomDetailUpdateModelValidator;
        }

        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Create()
        {
            var response = await _roomService.GetAllAsync();
            var model = new RoomDetailCreateModel
            {
                RoomNumbers = new SelectList(response.Data, "Id", "RoomNo")
            };
            return View(model);
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> Create(RoomDetailCreateModel model)
        {
            var result = _roomDetailCreateModelValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<RoomDetailCreateDto>(model);
                var response = await _roomDetailService.CreateAsync(dto);
                return this.ResponseRedirectAction(response, "List");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            var response1 = await _roomService.GetAllAsync();
            model.RoomNumbers = new SelectList(response1.Data, "Id", "RoomNo");
            return View(model);
        }

        [Authorize(Roles = "Manager,Reception")]
        public async Task<IActionResult> List()
        {
            var list = await _roomDetailService.Getlist();
            return View(list);
        }

        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Update(int roomDetailId)
        {
            var response = await _roomDetailService.GetByIdAsync<RoomDetailUpdateDto>(roomDetailId);
            if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound();
            }
            var model = _mapper.Map<RoomDetailUpdateModel>(response.Data);
            var response1 = await _roomService.GetAllAsync();
           
            model.RoomNumbers = new SelectList(response1.Data, "Id", "RoomNo");
            return View(model);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> Update(RoomDetailUpdateModel model)
        {
            var result = _roomDetailUpdateModelValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<RoomDetailUpdateDto>(model);
                var response = await _roomDetailService.UpdateAsync(dto);
                return this.ResponseRedirectAction(response, "List");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            var response1 = await _roomService.GetAllAsync();
            
            model.RoomNumbers = new SelectList(response1.Data, "Id", "Definition");
            return View(model);
        }

        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Remove(int roomDetailId)
        {
            var response = await _roomDetailService.RemoveAsync(roomDetailId);
            return this.ResponseRedirectAction(response, "List");
        }


    }
}

﻿using System.IO;
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
    [Authorize(Roles = "Manager")]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IRoomStatusService _roomStatusService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly ICleaningStatusService _cleaningStatusService;
        private readonly IMapper _mapper;
        private readonly IValidator<RoomCreateViewModel> _roomCreateModelValidator;
        private readonly IValidator<RoomUpdateViewModel> _roomUpdateModelValidator;

        public RoomController(IRoomStatusService roomStatusService, IRoomTypeService roomTypeService, IRoomService roomService, IValidator<RoomCreateViewModel> roomCreateModelValidator, IMapper mapper, IValidator<RoomUpdateViewModel> roomUpdateModelValidator, ICleaningStatusService cleaningStatusService)
        {
            _roomService = roomService;
            _roomStatusService = roomStatusService;
            _roomTypeService = roomTypeService;
            _roomCreateModelValidator = roomCreateModelValidator;
            _mapper = mapper;
            _roomUpdateModelValidator = roomUpdateModelValidator;
            _cleaningStatusService = cleaningStatusService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var response1 = await _roomTypeService.GetAllAsync();
            var response2 = await _roomStatusService.GetAllAsync();
            var response3 = await _cleaningStatusService.GetAllAsync();
            var model = new RoomCreateViewModel()
            {
                RoomTypes = new SelectList(response1.Data, "Id", "Definition"),
                RoomStatuses = new SelectList(response2.Data, "Id", "Definition"),
                CleaningStatuses = new SelectList(response3.Data, "Id", "Definition")
            };
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Create(RoomCreateViewModel model)
        {
           
            var result = _roomCreateModelValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<RoomCreateDto>(model);
                var response = await _roomService.CreateAsync(dto);
                return this.ResponseRedirectAction(response, "List");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            var response1 = await _roomTypeService.GetAllAsync();
            var response2 = await _roomStatusService.GetAllAsync();
            var response3 = await _cleaningStatusService.GetAllAsync();
            model.RoomTypes = new SelectList(response1.Data, "Id", "Definition");
            model.RoomStatuses = new SelectList(response2.Data, "Id", "Definition");
            model.CleaningStatuses = new SelectList(response3.Data, "Id", "Definition");
            return View(model);
        }

        public async Task<IActionResult> List()
        {
            var list = await _roomService.Getlist();
            return View(list);
        }
        public async Task<IActionResult> Update(int roomId)
        {
            var response = await _roomService.GetByIdAsync<RoomUpdateDto>(roomId);
            if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound();
            }
            var model = _mapper.Map<RoomUpdateViewModel>(response.Data);
            var response1 = await _roomTypeService.GetAllAsync();
            var response2 = await _roomStatusService.GetAllAsync();
            var response3 = await _cleaningStatusService.GetAllAsync();


            model.RoomTypes = new SelectList(response1.Data, "Id", "Definition");
            model.RoomStatuses = new SelectList(response2.Data, "Id", "Definition");
            model.CleaningStatuses = new SelectList(response3.Data, "Id", "Definition");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoomUpdateViewModel model)
        {
            var result = _roomUpdateModelValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<RoomUpdateDto>(model);
                var response = await _roomService.UpdateAsync(dto);
                return this.ResponseRedirectAction(response, "List");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            var response1 = await _roomTypeService.GetAllAsync();
            var response2 = await _roomStatusService.GetAllAsync();
            var response3 = await _cleaningStatusService.GetAllAsync();

            model.RoomTypes = new SelectList(response1.Data, "Id", "Definition");
            model.RoomStatuses = new SelectList(response2.Data, "Id", "Definition");
            model.CleaningStatuses = new SelectList(response3.Data, "Id", "Definition");
            return View(model);

        }

     

        public async Task<IActionResult> Remove(int roomId)
        {
            var response = await _roomService.RemoveAsync(roomId);
            return this.ResponseRedirectAction(response, "List");
        }

        //Open New Controller --- RoomDetail Crud will be next step
    }
}

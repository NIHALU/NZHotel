using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NZHotel.Business.Interfaces;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Reception.Models;
using NZHotel.UI.Extensions;
using System;
using System.Threading.Tasks;

namespace NZHotel.UI.Areas.Reception.Controllers
{
    [Area("Reception")]
    public class GuestController : Controller
    {
        private readonly IGuestTypeService _guestTypeService;
        private readonly IGenderService _genderService;
        private readonly IGuestService _guestService;
        private readonly IValidator<GuestCreateModel> _guestCreateValidator;
        private readonly IMapper _mapper;
        private readonly IGuestReservationService _guestReservationService;
        private readonly IReservationService _reservationService;
        public GuestController(IGuestTypeService guestTypeService, IGenderService genderService, IGuestService guestService, IMapper mapper, IValidator<GuestCreateModel> guestCreateValidator, IGuestReservationService guestReservationService, IReservationService reservationService)
        {
            _guestTypeService = guestTypeService;
            _genderService = genderService;
            _guestService = guestService;
            _mapper = mapper;
            _guestCreateValidator = guestCreateValidator;
            _guestReservationService = guestReservationService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async  Task<IActionResult> Create()
        {
            var response1 = await _genderService.GetAllAsync();
            var response2 = await _guestTypeService.GetAllAsync();
         
            var model = new GuestCreateModel()
            {
                Genders = new SelectList(response1.Data, "Id", "Definition"),
                GuestTypes = new SelectList(response2.Data, "Id", "Definition"),
                BirthDay=DateTime.Now
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GuestCreateModel model)
        {
            model.Age = model.CalculateAge();
            var result = _guestCreateValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<GuestCreateDto>(model);
                var response = await _guestService.CreateAsync(dto);
                return this.ResponseRedirectAction(response, "List");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            var response1 = await _genderService.GetAllAsync();
            var response2 = await _guestTypeService.GetAllAsync();
            model.Genders = new SelectList(response1.Data, "Id", "Definition");
            model.GuestTypes = new SelectList(response2.Data, "Id", "Definition");

            return View(model);
        }

        public IActionResult List()
        {
            var list =  _guestService.Getlist();
            foreach (var item in list)
            {
                var visitedBefore =  _guestService.VisitedBefore(item.Id);
                item.VisitedBefore=visitedBefore;
            }
            
            return View(list);
        }

        public IActionResult CheckIn(int guestId)
        {
            GuestReservationCreateDto guestReservationCreateDto = new GuestReservationCreateDto()
            {
                 GuestId = guestId,
            };
              
            return View(guestReservationCreateDto);
        }

        [HttpPost]
        public async Task<IActionResult> CheckIn(GuestReservationCreateDto dto)
        {
            var response = await _reservationService.GetReservation(dto.ReservationCode);
            dto.ReservationId=response.Data.Id;
            var response2 = await _guestReservationService.CreateAsync(dto);
            return this.ResponseRedirectAction(response, "CheckInOutList");

        }

        public async Task<IActionResult> CheckInOutList()
        {
            var list = await _guestReservationService.CheckInOutList();
            return View(list);
         
        }





    }
}

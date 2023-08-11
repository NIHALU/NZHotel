using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NZHotel.Business.Interfaces;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Reception.Models;
using NZHotel.UI.Extensions;

namespace NZHotel.UI.Areas.Reception.Controllers
{
	[Area("Reception")]
	[Authorize(Roles = "Reception")]
	public class GuestController : Controller
	{
		private readonly IGuestTypeService _guestTypeService;
		private readonly IGenderService _genderService;
		private readonly IGuestService _guestService;
		private readonly ICustomerService _customerService;
		private readonly IValidator<GuestCreateModel> _guestCreateValidator;
		private readonly IMapper _mapper;
		private readonly IGuestReservationService _guestReservationService;
		private readonly IReservationService _reservationService;
		public GuestController(IGuestTypeService guestTypeService, IGenderService genderService, IGuestService guestService, IMapper mapper, IValidator<GuestCreateModel> guestCreateValidator, IGuestReservationService guestReservationService, IReservationService reservationService, ICustomerService customerService)
		{
			_guestTypeService = guestTypeService;
			_genderService = genderService;
			_guestService = guestService;
			_mapper = mapper;
			_guestCreateValidator = guestCreateValidator;
			_guestReservationService = guestReservationService;
			_reservationService = reservationService;
			_customerService = customerService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> Create()
		{
			var response1 = await _genderService.GetAllAsync();
			var response2 = await _guestTypeService.GetAllAsync();

			var model = new GuestCreateModel()
			{
				Genders = new SelectList(response1.Data, "Id", "Definition"),
				GuestTypes = new SelectList(response2.Data, "Id", "Definition"),
				BirthDay = DateTime.Now
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

		public async Task<IActionResult> List()
		{
			var list = _guestService.Getlist();
			foreach (var item in list)
			{
				item.VisitedBefore = await _guestService.VisitedBefore(item.Id);
			}

			return View(list);
		}

		public IActionResult CheckIn(int guestId)
		{
			GuestReservationCreateDto guestReservationCreateDto = new GuestReservationCreateDto()
			{
				GuestId = guestId,
				CheckInTime = DateTime.Now

			};

			return View(guestReservationCreateDto);
		}

		[HttpPost]
		public async Task<IActionResult> CheckIn(GuestReservationCreateDto dto)
		{
			var response = await _reservationService.GetReservation(dto.ReservationCode);
			if (response.Data == null)
			{
				ModelState.AddModelError("", "Please enter a valid reservation code!");
				return View();
			}
			dto.ReservationId = response.Data.Id;
			var response2 = await _guestReservationService.CreateAsync(dto);
			return this.ResponseRedirectAction(response, "CheckInOutList");

		}

		public async Task<IActionResult> CheckInOutList()
		{
			var list = await _guestReservationService.CheckInOutList();
			return View(list);
		}

		public async Task<IActionResult> CheckOut(int guestReservationId)
		{
			var response = await _guestReservationService.GetByIdAsync<GuestReservationUpdateDto>(guestReservationId);
			if (response.ResponseType == ResponseType.NotFound)
			{
				return NotFound();
			}
			response.Data.CheckOutTime = DateTime.Now;

			return View(response.Data);
		}

		[HttpPost]
		public async Task<IActionResult> CheckOut(GuestReservationUpdateDto dto)
		{
			var response2 = await _guestReservationService.UpdateAsync(dto);
			return this.ResponseRedirectAction(response2, "CheckInOutList");

		}

		public async Task<IActionResult> CusList()
		{
			var list = await _customerService.GetAllAsync();
			return View(list.Data);

		}

		public async Task<IActionResult> Passive(int reservationId)
		{
			var result = await _reservationService.GetByIdAsync<ReservationUpdateDto>(reservationId);
			result.Data.Active = false;
			var response = await _reservationService.UpdateAsync(result.Data);
			return this.ResponseRedirectAction(response, "GetNotActiveReservations", "Home");

		}





	}
}

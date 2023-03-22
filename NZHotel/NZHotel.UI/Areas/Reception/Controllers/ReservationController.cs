using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NZHotel.Business.Interfaces;
using NZHotel.Common.Enums;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Reception.Models;

namespace NZHotel.UI.Areas.Reception.Controllers
{
    [Area("Reception")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        private readonly IValidator<BookRoomModel> _bookRoomModelValidator;
        private readonly IValidator<GuestInfoCreateModel> _guestInfoValidator;
        private readonly IValidator<CustomerCreateModel> _customerValidator;
        private readonly ICustomerService _customerService;
        private readonly IGuestService _guestService;
        private readonly IReservationOptionService _reservationOptionService;
        public ReservationController(IReservationService reservationService, IRoomService roomService, IMapper mapper, IValidator<BookRoomModel> bookRoomModelValidator, IValidator<GuestInfoCreateModel> guestInfoValidator, IValidator<CustomerCreateModel> customerValidator, ICustomerService customerService, IGuestService guestService, IReservationOptionService reservationOptionService)
        {
            _reservationService = reservationService;
            _roomService = roomService;
            _mapper = mapper;
            _bookRoomModelValidator = bookRoomModelValidator;
            _guestInfoValidator = guestInfoValidator;
            _customerValidator = customerValidator;
            _customerService = customerService;
            _guestService = guestService;
            _reservationOptionService = reservationOptionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BookRoom()
        {
            var response = await _reservationOptionService.GetAllAsync();
            var model = new BookRoomModel()
            {
                ReservationOptions = new SelectList(response.Data, "Id", "Definition"),
                StartingDate=DateTime.Today,
                FinisingDate = DateTime.Today.AddDays(1),

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> BookRoom(BookRoomModel model)
        {
            var result = _bookRoomModelValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<BookRoomCreateDto>(model);
                ArrayList bookedRooms = new ArrayList();
                List<RoomListDto> roomListDtos = new();
                bookedRooms = await _reservationService.GetBookedRoomList(dto);
                int[] bookedRoomIds = (int[])bookedRooms.ToArray(System.Type.GetType("System.Int32"));
                roomListDtos = await _roomService.GetNotBookedRoomList(dto, bookedRoomIds);
                
                foreach (var item in roomListDtos)
                {
                    item.MainAmount = item.CalculateMainAmount(dto.ChildNumber, dto.InfantNumber, dto.NumberofDays);
                    item.EarlyBookingDisRate = dto.CalculateDiscountRate();
                }
                
                HttpContext.Session.SetString("bookRoomDto",JsonConvert.SerializeObject(dto));
                HttpContext.Session.SetString("NotBookedRooms", JsonConvert.SerializeObject(roomListDtos));
                return RedirectToAction("CheckNotBookedRooms");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            var response = await _reservationOptionService.GetAllAsync();
            model.ReservationOptions = new SelectList(response.Data, "Id", "Definition");

            return View(model);

        }

        public IActionResult CheckNotBookedRooms()
        {

            var value = HttpContext.Session.GetString("NotBookedRooms");
            var result = JsonConvert.DeserializeObject<List<RoomListDto>>(value);
            return View(result);
        }

        public IActionResult CustomerInfo(decimal totalAmount,int roomId)
        {
            HttpContext.Session.SetString("selectedRoomId", roomId.ToString());
            HttpContext.Session.SetString("totalAmount", totalAmount.ToString());
            var result = JsonConvert.DeserializeObject<BookRoomCreateDto>(HttpContext.Session.GetString("bookRoomDto"));

            int adultCount = result.AdultNumber;
            int childrenCount = result.ChildNumber;
            int infantCount = result.InfantNumber;
            List<GuestInfoCreateModel> adultList = new();
            List<GuestInfoCreateModel> childrenList = new();
            List<GuestInfoCreateModel> infantList = new();

            for (int i = 0; i < adultCount; i++)
            {
                adultList.Add(new GuestInfoCreateModel { GuestTypeId = (int)GuestType.ADT, BirthDay = DateTime.Today.AddYears(-12) });
            }

            if (childrenCount > 0)
            {
                for (int i = 0; i < childrenCount; i++)
                {
                    childrenList.Add(new GuestInfoCreateModel { GuestTypeId = (int)GuestType.CHD, BirthDay = DateTime.Today.AddYears(-2) });
                }
            }
            if (infantCount > 0)
            {
                for (int i = 0; i < infantCount; i++)
                {
                    infantList.Add(new GuestInfoCreateModel { GuestTypeId = (int)GuestType.INF, BirthDay = DateTime.Today });

                }
            }

            var tuple = (adultList, childrenList, infantList, new CustomerCreateModel());

            return View(tuple);

        }

        [HttpPost]
        public async Task<IActionResult> CustomerInfo([Bind(Prefix = "Item1")] List<GuestInfoCreateModel> adults, [Bind(Prefix = "Item2")] List<GuestInfoCreateModel> children, [Bind(Prefix = "Item3")] List<GuestInfoCreateModel> infants, [Bind(Prefix = "Item4")] CustomerCreateModel customer)
        {
            List<ValidationResult> guestValidResults = new();
            List<ValidationResult> guestNotValidResults = new();
            List<GuestInfoCreateModel> guests = adults.Concat(children).Concat(infants).ToList();
            foreach (var item in guests)
            {
                item.Age = item.CalculateAge();
                var result1 = _guestInfoValidator.Validate(item);
                if (result1.IsValid)
                {
                    guestValidResults.Add(result1);
                }
                else
                {
                    guestNotValidResults.Add(result1);
                }
               
            }
            var result2 = _customerValidator.Validate(customer);
            if (guests.Count == guestValidResults.Count && result2.IsValid)
            {
                await _customerService.Create(_mapper.Map<CustomerCreateDto>(customer));
                await _guestService.Create(_mapper.Map<List<GuestCreateDto>>(guests));
                return RedirectToAction("CreateReservation");
            }
            else
            {
                if (result2.IsValid==false)
                {
                    guestNotValidResults.Add(result2);
                    foreach (var item in guestNotValidResults)
                    {
                        item.Errors.ForEach(item => ModelState.AddModelError(item.PropertyName, item.ErrorMessage));

                    }

                }
            }

            var tuple = (adults, children, infants, customer);
            return View(tuple);


        }

        public IActionResult Payment()
        {
          
            return View();
        }

    }
}

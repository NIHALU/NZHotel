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

                HttpContext.Session.SetString("adultNumber", dto.AdultNumber.ToString());
                HttpContext.Session.SetString("childrenNumber", dto.ChildNumber.ToString());
                HttpContext.Session.SetString("infantNumber", dto.InfantNumber.ToString());
                HttpContext.Session.SetString("reservationOption", dto.ReservationOptionId.ToString());
                HttpContext.Session.SetString("sessionNotBookedRooms", JsonConvert.SerializeObject(roomListDtos));
                return RedirectToAction("CheckNotBookedRooms",dto.ReservationOptionId);
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            var response = await _reservationOptionService.GetAllAsync();
            model.ReservationOptions = new SelectList(response.Data, "Id", "Definition");

            return View(model);

        }

        public IActionResult CheckNotBookedRooms(int reservationOptionId)
        {

            var value = HttpContext.Session.GetString("sessionNotBookedRooms");
            var result = JsonConvert.DeserializeObject<List<RoomListDto>>(value);
            return View(result);
        }

        public IActionResult CustomerInfo(int roomId)
        {
            HttpContext.Session.SetString("selectedRoomId", roomId.ToString());
            int adultCount = Convert.ToInt32(HttpContext.Session.GetString("adultNumber"));
            int childrenCount = Convert.ToInt32(HttpContext.Session.GetString("childrenNumber"));
            int infantCount = Convert.ToInt32(HttpContext.Session.GetString("infantNumber"));
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
            /*
             * numberofDays=finishingdate-startingdate 
             * if startingdate-datetime >=90 alloptions %23 discount
             * if startingdate-datetime>=30 if fullpansion %16 disc if allinc  %16 disc
             * 
             * mainprice= roomprice*numberofdays
             * if selectedAdt = room.MaxAdult
             *     totalamount=mainprice
             * if child infant 
             * ------
             * 
             */
            return View();
        }

    }
}

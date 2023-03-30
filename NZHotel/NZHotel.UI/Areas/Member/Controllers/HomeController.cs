using System;
using System.Collections;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NZHotel.Business.Interfaces;
using NZHotel.Common.Enums;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Member.Models;
using NZHotel.UI.Areas.Reception.Models;
using NZHotel.UI.Models;
using NZHotel.UI.Extensions;

namespace NZHotel.UI.Controllers
{
    [Area("Member")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IReservationOptionService _reservationOptionService;
        private readonly IReservationService _reservationService;
        private readonly IRoomService _roomService;
        private readonly IValidator<BookingRoomModel> _bookingRoomValidator;
        private readonly IMapper _mapper;
        private readonly IValidator<GuestInfoCreateModel> _guestInfoValidator;
        private readonly IValidator<CustomerCreateModel> _customerValidator;
        private readonly ICustomerService _customerService;
        private readonly IGuestInfoService _guestInfoService;
        private readonly IValidator<PaymentCreateModel2> _paymentcreateModelValidator2;

        public HomeController(ILogger<HomeController> logger, IReservationOptionService reservationOptionService, IValidator<BookingRoomModel> bookingRoomValidator, IMapper mapper, IReservationService reservationService, IRoomService roomService, IValidator<GuestInfoCreateModel> guestInfoValidator, IValidator<CustomerCreateModel> customerValidator, ICustomerService customerService, IValidator<PaymentCreateModel2> paymentcreateModelValidator2, IGuestInfoService guestInfoService)
        {
            _logger = logger;
            _reservationOptionService = reservationOptionService;
            _bookingRoomValidator = bookingRoomValidator;
            _mapper = mapper;
            _reservationService = reservationService;
            _roomService = roomService;
            _guestInfoValidator = guestInfoValidator;
            _customerValidator = customerValidator;
            _customerService = customerService;
            _paymentcreateModelValidator2 = paymentcreateModelValidator2;
            _guestInfoService = guestInfoService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _reservationOptionService.GetAllAsync();
            var model = new BookingRoomModel()
            {
                ReservationOptions = new SelectList(response.Data, "Id", "Definition"),
                StartingDate = DateTime.Today,
                FinishingDate = DateTime.Today.AddDays(1),
                AdultNumber = 1

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(BookingRoomModel model)
        {


            var result = _bookingRoomValidator.Validate(model);
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

                HttpContext.Session.SetString("bookRoomDto", JsonConvert.SerializeObject(dto));
                HttpContext.Session.SetString("NotBookedRooms", JsonConvert.SerializeObject(roomListDtos));
                return RedirectToAction("CheckNotBookedRooms", dto);
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            var response = await _reservationOptionService.GetAllAsync();
            model.ReservationOptions = new SelectList(response.Data, "Id", "Definition");

            return View(model);

        }


        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> CheckNotBookedRooms(BookRoomCreateDto dtoBook)
        {

            var response = await _reservationOptionService.GetByIdAsync<ReservationOptionListDto>(dtoBook.ReservationOptionId);
            var value = HttpContext.Session.GetString("NotBookedRooms");
            var result = JsonConvert.DeserializeObject<List<RoomListDto>>(value);
            List<RoomListDto> filteredRooms = new();
            var items = Enum.GetValues(typeof(RoomType));
            foreach (int item in items)
            {
                RoomListDto dto = result.AsQueryable().FirstOrDefault(x => x.RoomTypeId == item);
                if (dto != null)
                {
                    filteredRooms.Add(dto);
                }
            }
            foreach (var item in filteredRooms)
            {
                item.ReservationOption = response.Data.Definition;
            }
            return View(filteredRooms);

        }

        public IActionResult CustomerGuestInfo(decimal totalAmount, int roomId)
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
        public async Task<IActionResult> CustomerGuestInfo([Bind(Prefix = "Item1")] List<GuestInfoCreateModel> adults, [Bind(Prefix = "Item2")] List<GuestInfoCreateModel> children, [Bind(Prefix = "Item3")] List<GuestInfoCreateModel> infants, [Bind(Prefix = "Item4")] CustomerCreateModel customer)
        {
            List<ValidationResult> guestValidResults = new();
            List<ValidationResult> guestNotValidResults = new();
            List<GuestInfoCreateModel> guestInformation = adults.Concat(children).Concat(infants).ToList();
            foreach (var item in guestInformation)
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
            if (guestInformation.Count == guestValidResults.Count && result2.IsValid)
            {
                if (customer.IsNoTurkishCitizen == false)
                {
                    HttpContext.Session.SetString("customerID", customer.TurkishIDNo);
                }
                else
                {
                    HttpContext.Session.SetString("customerID", customer.PassportNo);
                }
                await _customerService.Create(_mapper.Map<CustomerCreateDto>(customer));
                HttpContext.Session.SetString("guestInformation", JsonConvert.SerializeObject(_mapper.Map<List<GuestInfoCreateDto>>(guestInformation)));
                return RedirectToAction("Payment");
            }
            else
            {
                if (result2.IsValid == false)
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
            var totalAmount = Convert.ToDecimal(HttpContext.Session.GetString("totalAmount"));
            ViewBag.TotalAmount = totalAmount;
         
            var tuble = (new PaymentCreateModel2 { TotalAmount = totalAmount }, new ReservationCreateDto());
            return View(tuble);
        }

        [HttpPost]
        public async Task<IActionResult> Payment([Bind(Prefix = "Item1")] PaymentCreateModel2 payment, [Bind(Prefix = "Item2")] ReservationCreateDto reservation)
        {
            var result = _paymentcreateModelValidator2.Validate(payment);
            if (result.IsValid)
            {
                var customer = await _customerService.GetCustomer(HttpContext.Session.GetString("customerID").ToString());
               
                reservation.PaymentStatusId = (int)PaymentStatus.Paid;
                reservation.PaymentTypeId = (int)PaymentType.CreditCard;
                var selectedRoomId = Convert.ToInt32(HttpContext.Session.GetString("selectedRoomId"));

                var bookRoom = JsonConvert.DeserializeObject<BookRoomCreateDto>(HttpContext.Session.GetString("bookRoomDto"));

                reservation.RoomId = selectedRoomId;
                reservation.StartingDate = bookRoom.StartingDate;
                reservation.FinishingDate = bookRoom.FinishingDate;
                reservation.NumberofDays = bookRoom.NumberofDays;
                reservation.NumberofGuests = bookRoom.AdultNumber + bookRoom.ChildNumber + bookRoom.InfantNumber;
      
                reservation.ReservationOptionId = bookRoom.ReservationOptionId;
                reservation.TotalAmount = payment.TotalAmount/100;
                reservation.ReservationTypeId = (int)ReservationType.Web;
                reservation.CustomerId = customer.Id;
                reservation.ReservationCode = "NZ" + bookRoom.StartingDate.Day.ToString() + bookRoom.StartingDate.Month.ToString() + bookRoom.StartingDate.Year.ToString() + reservation.RoomId.ToString();
                reservation.Active = true;


                var response = await _reservationService.CreateReservation(reservation);
                return this.ResponseRedirectActionForReservation(response, "CreatedReservation");

            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            ViewBag.TotalAmount = payment.TotalAmount;

            var tuple = (payment, reservation);


            return View(tuple);
        }

        public async Task<IActionResult> CreatedReservation()
        {
            var selectedRoomId = Convert.ToInt32(HttpContext.Session.GetString("selectedRoomId"));
            var value1 = HttpContext.Session.GetString("bookRoomDto");
            var bookRoom = JsonConvert.DeserializeObject<BookRoomCreateDto>(value1);
            var reservation = await _reservationService.GetReservation(bookRoom, selectedRoomId);

            CreatedReservationModel model = new()
            {
                StartingDate = reservation.StartingDate.ToString("d"),
                FinishingDate = reservation.FinishingDate.ToString("d"),
                ReservationCode = reservation.ReservationCode,
                NZEmail = "info.nzhotel@gmail.com",
                NZPhone = "(+90) 533 665 81 81",

            };
            var value2 = HttpContext.Session.GetString("guestInformation");
            var guestInformation = JsonConvert.DeserializeObject<List<GuestInfoCreateDto>>(value2);
            foreach (var guestInfo in guestInformation)
            {
                guestInfo.ReservationId = reservation.Id;
                guestInfo.GuestTypeId = guestInfo.GuestTypeId;
                await _guestInfoService.Create(guestInfo);
            }
            HttpContext.Session.Clear();

            return View(model);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}

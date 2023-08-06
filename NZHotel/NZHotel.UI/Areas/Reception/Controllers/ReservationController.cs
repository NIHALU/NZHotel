using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NZHotel.Business.Interfaces;
using NZHotel.Common.Enums;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Reception.Models;
using NZHotel.UI.Extensions;

namespace NZHotel.UI.Areas.Reception.Controllers
{
    [Area("Reception")]
    [Authorize(Roles = "Reception")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        private readonly IValidator<BookRoomModel> _bookRoomModelValidator;
        private readonly IValidator<GuestInfoCreateModel> _guestInfoValidator;
        private readonly IValidator<CustomerCreateModel> _customerValidator;
        private readonly ICustomerService _customerService;
        private readonly IGuestInfoService _guestInfoService;
        private readonly IReservationOptionService _reservationOptionService;
        private readonly IValidator<PaymentCreateModel> _paymentCreateModelValidator;
        private readonly IPaymentTypeService _paymentTypeService;

        public ReservationController(IReservationService reservationService, IRoomService roomService, IMapper mapper, IValidator<BookRoomModel> bookRoomModelValidator, IValidator<GuestInfoCreateModel> guestInfoValidator, IValidator<CustomerCreateModel> customerValidator, ICustomerService customerService, IGuestInfoService guestInfoService, IReservationOptionService reservationOptionService, IValidator<PaymentCreateModel> paymentCreateModelValidator, IPaymentTypeService paymentTypeService)
        {
            _reservationService = reservationService;
            _roomService = roomService;
            _mapper = mapper;
            _bookRoomModelValidator = bookRoomModelValidator;
            _guestInfoValidator = guestInfoValidator;
            _customerValidator = customerValidator;
            _customerService = customerService;
            _guestInfoService = guestInfoService;
            _reservationOptionService = reservationOptionService;
            _paymentCreateModelValidator = paymentCreateModelValidator;
            _paymentTypeService = paymentTypeService;
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
                StartingDate = DateTime.Today,
                FinishingDate = DateTime.Today.AddDays(1),

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

                HttpContext.Session.SetString("bookRoomDto", JsonConvert.SerializeObject(dto));
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

        public IActionResult CustomerInfo(decimal totalAmount, int roomId)
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
            var items = Enum.GetValues(typeof(PaymentType));
            var list = new List<PaymentTypeListDto>();
            foreach (int item in items) 
            {
                list.Add(new PaymentTypeListDto
                {
                    Id = item,
                    Definition = Enum.GetName(typeof(PaymentType), item) //return card, cash ,paylater
                });
            }
            ViewBag.PaymentTypes = new SelectList(list, "Id", "Definition");

            var tuble = (new PaymentCreateModel { TotalAmount = totalAmount }, new ReservationCreateDto());
            return View(tuble);
        }

        [HttpPost]
        public async Task<IActionResult> Payment([Bind(Prefix = "Item1")] PaymentCreateModel payment, [Bind(Prefix = "Item2")] ReservationCreateDto reservation)
        {
            var result = _paymentCreateModelValidator.Validate(payment);
            if (result.IsValid)
            {
                var customer = await _customerService.GetCustomer(HttpContext.Session.GetString("customerID").ToString());
                if (payment.PaymentTypeId == (int)PaymentType.PayLater)
                {
                    reservation.PaymentStatusId = (int)PaymentStatus.NonPaid;

                }
                reservation.PaymentStatusId = (int)PaymentStatus.Paid;
                reservation.PaymentTypeId = payment.PaymentTypeId;
                var selectedRoomId = Convert.ToInt32(HttpContext.Session.GetString("selectedRoomId"));

                var bookRoom = JsonConvert.DeserializeObject<BookRoomCreateDto>(HttpContext.Session.GetString("bookRoomDto"));

                reservation.RoomId = selectedRoomId;
                reservation.StartingDate = bookRoom.StartingDate;
                reservation.FinishingDate = bookRoom.FinishingDate;
                reservation.NumberofDays = bookRoom.NumberofDays;
                reservation.NumberofGuests = bookRoom.AdultNumber + bookRoom.ChildNumber + bookRoom.InfantNumber;
                reservation.PaymentDeadline = payment.ExpectedPaymentDate;
                reservation.ReservationOptionId = bookRoom.ReservationOptionId;
                reservation.TotalAmount = payment.TotalAmount;
                reservation.ReservationTypeId = (int)ReservationType.CallCenter;
                reservation.CustomerId = customer.Id;
                reservation.ReservationCode ="NZ" + bookRoom.StartingDate.Day.ToString() + bookRoom.StartingDate.Month.ToString() + bookRoom.StartingDate.Year.ToString() + reservation.RoomId.ToString();
                reservation.Active = true;


                var response = await _reservationService.CreateReservation(reservation);
                return this.ResponseRedirectActionForReservation(response, "CreatedReservation");

            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            ViewBag.TotalAmount = payment.TotalAmount;

            var items = Enum.GetValues(typeof(PaymentType));
            var list = new List<PaymentTypeListDto>();
            foreach (int item in items)   //3,4,5
            {
                list.Add(new PaymentTypeListDto
                {
                    Id = item,
                    Definition = Enum.GetName(typeof(PaymentType), item) //return card, cash ,paylater
                });
            }
            ViewBag.PaymentTypes = new SelectList(list, "Id", "Definition");
            var tuple = (payment, reservation);


            return View(tuple);
        }


        public async Task<IActionResult> CreatedReservation()
        {
            var selectedRoomId = Convert.ToInt32(HttpContext.Session.GetString("selectedRoomId"));
            var value1 = HttpContext.Session.GetString("bookRoomDto");
            var bookRoom = JsonConvert.DeserializeObject<BookRoomCreateDto>(value1);
            var reservation = await _reservationService.GetReservation(bookRoom, selectedRoomId);

            CreatedReservationModel model = new() {
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
                guestInfo.GuestTypeId=guestInfo.GuestTypeId;
                await _guestInfoService.Create(guestInfo);
            }
            HttpContext.Session.Clear();
            
            return View(model);
        }

        public IActionResult TermsAndCondition()
        {
            return View();
        }
    }
}

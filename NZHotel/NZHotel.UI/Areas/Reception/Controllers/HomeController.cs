using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NZHotel.Business.Interfaces;
using NZHotel.Common.Enums;
using NZHotel.DTOs;
using NZHotel.DTOs.BookRoomDtos;
using NZHotel.UI.Areas.Reception.Models;
using NZHotel.UI.Extensions;

namespace NZHotel.UI.Areas.Reception.Controllers
{
    [Area("Reception")]
    public class HomeController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IGuestInfoService _guestInfoService;
        private readonly IReservationOptionService _reservationOptionService;
        private readonly IValidator<BookRoomUpdateModel> _bookRoomUpdateValidator;
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        private readonly IValidator<PaymentCreateModel> _paymentCreateModelValidator;



        public HomeController(IReservationService reservationService, IGuestInfoService guestInfoService, IReservationOptionService reservationOptionService, IValidator<BookRoomUpdateModel> bookRoomUpdateValidator, IRoomService roomService, IMapper mapper, IValidator<PaymentCreateModel> paymentCreateModelValidator)
        {
            _reservationService = reservationService;
            _guestInfoService = guestInfoService;
            _reservationOptionService = reservationOptionService;
            _bookRoomUpdateValidator = bookRoomUpdateValidator;
            _roomService = roomService;
            _mapper = mapper;
            _paymentCreateModelValidator = paymentCreateModelValidator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetActiveReservations()
        {
            var response = await _reservationService.GetActiveReservations();
            return View(response.Data);
        }

        public async Task<IActionResult> GetNotActiveReservations() // Not Active 
        {
            var response = await _reservationService.GetActiveReservations();
            return View(response.Data);
        }

        public async Task<IActionResult> GuestInfo(int reservationId)
        {
            var response = await _guestInfoService.GuestInfo(reservationId);
            return View(response.Data);
        }
        public async Task<IActionResult> BookRoomUpdate(int reservationId)
        {
            var response = await _reservationService.GetByIdAsync<ReservationListDto>(reservationId);

            if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound();
            }
            ReservationListDto reservationDto = response.Data;
            var response1 = await _guestInfoService.GuestInfoUpdated(reservationDto.Id);
            int AdultCount = response1.Data.Count(x => x.GuestTypeId == (int)GuestType.ADT);
            int childCount = response1.Data.Count(x => x.GuestTypeId == (int)GuestType.CHD);
            int InfantCount = response1.Data.Count(x => x.GuestTypeId == (int)GuestType.INF);


            var response3 = await _reservationOptionService.GetAllAsync();

            BookRoomUpdateModel bookRoomUpdateModel = new()
            {
                StartingDate = reservationDto.StartingDate,
                FinishingDate = reservationDto.FinishingDate,
                ReservationOptionId = reservationDto.ReservationOptionId,
                RoomId = reservationDto.RoomId,
                ReservationId = reservationDto.Id,
                OldAmount = reservationDto.TotalAmount,
                ReservationOptions = new SelectList(response3.Data, "Id", "Definition"),
                AdultNumber = AdultCount,
                ChildNumber = childCount,
                InfantNumber = InfantCount,
                
            };
            return View(bookRoomUpdateModel);
        }

        [HttpPost]
        public async Task<IActionResult> BookRoomUpdate(BookRoomUpdateModel model)
        {
            var result = _bookRoomUpdateValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<BookRoomUpdateDto>(model);
                ArrayList bookedRooms = new ArrayList();
                List<RoomListDto> roomListDtos = new();
                bookedRooms = await _reservationService.GetBookedRoomListForUpdate(dto);
                int[] bookedRoomIds = (int[])bookedRooms.ToArray(System.Type.GetType("System.Int32"));
                roomListDtos = await _roomService.GetNotBookedRoomListForUpdate(dto, bookedRoomIds);

                foreach (var item in roomListDtos)
                {
                    item.MainAmount = item.CalculateMainAmount(dto.ChildNumber, dto.InfantNumber, dto.NumberofDays);
                    item.EarlyBookingDisRate = dto.CalculateDiscountRate();
                }

                HttpContext.Session.SetString("bookRoomUpdateDto", JsonConvert.SerializeObject(dto));
                HttpContext.Session.SetString("NotBookedRoomsForUpdate", JsonConvert.SerializeObject(roomListDtos));
                return RedirectToAction("CheckNotBookedRoomsForUpdate");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            var response = await _reservationOptionService.GetAllAsync();
            model.ReservationOptions = new SelectList(response.Data, "Id", "Definition");
            return View(model);
        }

        public IActionResult CheckNotBookedRoomsForUpdate()
        {


            var value1 = HttpContext.Session.GetString("bookRoomUpdateDto");
            var result1 = JsonConvert.DeserializeObject<BookRoomUpdateDto>(value1);

            var value2 = HttpContext.Session.GetString("NotBookedRoomsForUpdate");
            var result2 = JsonConvert.DeserializeObject<List<RoomListDto>>(value2);
            foreach (var item in result2)
            {
                item.PaymentDifference = item.CalculatePaymentDifference(result1.OldAmount);
            }
            ViewBag.OldAmount = result1.OldAmount;

            return View(result2);
        }


        public async Task<IActionResult> Payment(decimal differenceAmount, int roomId)
        {
            var value = HttpContext.Session.GetString("bookRoomUpdateDto");
            var result = JsonConvert.DeserializeObject<BookRoomUpdateDto>(value);
            var response = await _reservationService.GetByIdAsync<ReservationUpdateDto>(result.ReservationId);
            response.Data.RoomId = roomId;

            if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound();
            }
            ViewBag.DifferenceAmount = differenceAmount;
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

            var tuble = (new PaymentCreateModel { TotalAmount = differenceAmount, PaymentTypeId = response.Data.PaymentTypeId },response.Data);
            return View(tuble);
        }

        [HttpPost]
        public async Task<IActionResult> Payment([Bind(Prefix = "Item1")] PaymentCreateModel payment, [Bind(Prefix = "Item2")] ReservationUpdateDto reservation)
        {
            var result = _paymentCreateModelValidator.Validate(payment);
            if (result.IsValid)
            {
                var value = HttpContext.Session.GetString("bookRoomUpdateDto");
                var result2 = JsonConvert.DeserializeObject<BookRoomUpdateDto>(value);
                reservation.StartingDate = result2.StartingDate;    
                reservation.FinishingDate = result2.FinishingDate;
                reservation.TotalAmount=reservation.TotalAmount+payment.TotalAmount;
                reservation.NumberofDays = result2.NumberofDays;
                reservation.ReservationOptionId = result2.ReservationOptionId;
                reservation.ReservationTypeId = (int)ReservationType.CallCenter;
                reservation.ReservationCode="NZ"+ reservation.StartingDate.Day.ToString() + reservation.StartingDate.Month.ToString()+reservation.StartingDate.Year.ToString() + reservation.RoomId.ToString();

                var response = await _reservationService.UpdateReservation(reservation);
                return this.ResponseRedirectActionForReservation(response, "UpdatedReservation");

            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            ViewBag.Difference = payment.TotalAmount;

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

        public async Task<IActionResult> UpdatedReservation()
        {
            var value = HttpContext.Session.GetString("bookRoomUpdateDto");
            var result = JsonConvert.DeserializeObject<BookRoomUpdateDto>(value);
            var response = await _reservationService.GetByIdAsync<ReservationUpdateDto>(result.ReservationId);
            
            CreatedReservationModel model = new()
            {
                StartingDate = response.Data.StartingDate.ToString("d"),
                FinishingDate = response.Data.FinishingDate.ToString("d"),
                ReservationCode = response.Data.ReservationCode,
                NZEmail = "info.nzhotel@gmail.com",
                NZPhone = "(+90) 533 665 81 81",

            };
            
            HttpContext.Session.Clear();

            return View(model);
        }


    }
}

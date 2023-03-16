using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NZHotel.Business.Interfaces;
using NZHotel.Common.Enums;
using NZHotel.DTOs;
using NZHotel.DTOs.GuestDtos;
using NZHotel.UI.Areas.Reception.Models;

namespace NZHotel.UI.Areas.Reception.Controllers
{
    [Area("Reception")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IRoomService _roomService;

        public ReservationController(IReservationService reservationService, IRoomService roomService)
        {
            _reservationService = reservationService;
            _roomService = roomService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BookRoom()
        {
            return View(new BookRoomModel());
        }

        [HttpPost]
        public async Task<IActionResult> BookRoom(RoomBookCreateDto dto)
        {
            ArrayList bookedRooms = new ArrayList();
            List<RoomListDto> roomListDtos = new();
            bookedRooms = await _reservationService.GetBokeedRoomList(dto);
            int[] bookedRoomIds = (int[])bookedRooms.ToArray(System.Type.GetType("System.Int32"));
            roomListDtos = await _roomService.GetNotBookedRoomList(dto, bookedRoomIds);

            HttpContext.Session.SetString("adultNumber",dto.AdultNumber.ToString());
            HttpContext.Session.SetString("childrenNumber",dto.ChildNumber.ToString());
            HttpContext.Session.SetString("infantNumber",dto.InfantNumber.ToString());
            HttpContext.Session.SetString("sessionNotBookedRooms", JsonConvert.SerializeObject(roomListDtos));
            return RedirectToAction("CheckNotBookedRooms");
        }

        public IActionResult CheckNotBookedRooms()
        {
            var value = HttpContext.Session.GetString("sessionNotBookedRooms");
            var result=JsonConvert.DeserializeObject<List<RoomListDto>>(value);
            return View(result);
        }

        public IActionResult CustomerInfo(int roomId)
        {
           HttpContext.Session.SetString("selectedRoomId",roomId.ToString());
           int adultCount = Convert.ToInt32(HttpContext.Session.GetString("adultNumber"));
           int childrenCount =Convert.ToInt32(HttpContext.Session.GetString("childrenNumber"));
           int infantCount = Convert.ToInt32( HttpContext.Session.GetString("infantNumber"));
           List<GuestInfoCreateModel> adultList = new ();
           List<GuestInfoCreateModel> childrenList = new ();
           List<GuestInfoCreateModel> infantList = new ();

            for (int i = 0; i < adultCount; i++)
            {
                adultList.Add(new GuestInfoCreateModel { GuestTypeId = (int)GuestType.ADT });
            }

            if (childrenCount>0)
            {
                for (int i = 0; i < childrenCount; i++)
                {
                    childrenList.Add(new GuestInfoCreateModel { GuestTypeId = (int)GuestType.CHD });
                }
            }
            if (infantCount>0)
            {
                for (int i = 0; i < infantCount; i++)
                {
                    infantList.Add(new GuestInfoCreateModel { GuestTypeId = (int)GuestType.INF });

                }
            }

            var tuple = (adultList, childrenList, infantList, new CustomerCreateModel());

            return View(tuple);

        }

        [HttpPost]
        public IActionResult CustomerInfo([Bind(Prefix ="Item1")]List<GuestInfoCreateModel> adults,[Bind(Prefix = "Item2")]List<GuestInfoCreateModel> children, [Bind(Prefix = "Item3")]List<GuestInfoCreateModel> infants,[Bind(Prefix = "Item4")]CustomerCreateModel customer)
        {
            return View();
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NZHotel.Business.Interfaces;
using NZHotel.DTOs;
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
            HttpContext.Session.SetString("selectedRoomId", JsonConvert.SerializeObject(roomId));
            return View(new CustomerCreateModel());

        }

    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NZHotel.Business.Interfaces;
using NZHotel.Common.Enums;
using NZHotel.DTOs;

namespace NZHotel.UI.Controllers
{
    [Area("Member")]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IRoomDetailService _roomDetailService;

        public RoomController(IRoomService roomService, IRoomDetailService roomDetailService)
        {
            _roomService = roomService;
            _roomDetailService = roomDetailService;
        }

        public async Task< IActionResult> Index()
        {
            List<RoomListDto> filteredRooms = new();
            var items = Enum.GetValues(typeof(RoomType));
            foreach (int item in items)
            {
                var filteredRoom = await _roomService.GetFilteredRoom(item);
                filteredRooms.Add(filteredRoom);
            }
            return View(filteredRooms);
        }

        public async Task<IActionResult> SeeDetail(int roomId)
        {
            var result = await _roomDetailService.GetDetail(roomId);
            return View(result);
        }


    }
}

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

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
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
    }
}

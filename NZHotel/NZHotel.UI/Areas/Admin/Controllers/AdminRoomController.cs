using Microsoft.AspNetCore.Mvc;
using NZHotel.DTOs;

namespace NZHotel.UI.Areas.Admin.Controllers
{
    public class AdminRoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View(new RoomCreateDto());
        }

        [HttpPost]
        public IActionResult Create(RoomCreateDto roomCreateDto)
        {
            return View(new RoomCreateDto());
        }

    }
}

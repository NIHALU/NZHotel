using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using NZHotel.Business.Interfaces;
using NZHotel.UI.Models;

namespace NZHotel.UI.Controllers
{
    [Area("Member")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IReservationOptionService _reservationOptionService;

        public HomeController(ILogger<HomeController> logger, IReservationOptionService reservationOptionService)
        {
            _logger = logger;
            _reservationOptionService = reservationOptionService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _reservationOptionService.GetAllAsync();
            var model = new BookRoomModel()
            {
                ReservationOptions = new SelectList(response.Data, "Id", "Definition"),
                StartingDate = DateTime.Today,
                FinishingDate = DateTime.Today.AddDays(1),
                AdultNumber=1

            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
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

using Microsoft.AspNetCore.Mvc;
using NZHotel.Business.Interfaces;

namespace NZHotel.ReservationAPI.Controllers
{
    [ApiController]
    [Route("[api/controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public IActionResult Index()
        {
            return View();
        }
    }
}

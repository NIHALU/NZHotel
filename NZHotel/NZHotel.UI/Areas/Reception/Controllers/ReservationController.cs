using Microsoft.AspNetCore.Mvc;
using NZHotel.Business.Interfaces;
using NZHotel.UI;

namespace NZHotel.UI.Areas.Reception.Controllers
{
    [Area("Reception")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;




        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BookRoom()
        {
            return View(new BookRoomModel());
        }

       
     

    }
}

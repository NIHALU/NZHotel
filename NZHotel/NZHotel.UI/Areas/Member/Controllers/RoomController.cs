using Microsoft.AspNetCore.Mvc;

namespace NZHotel.UI.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

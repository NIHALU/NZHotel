using Microsoft.AspNetCore.Mvc;

namespace NZHotel.UI.Areas.Admin.Controllers
{
    [Area("Management")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

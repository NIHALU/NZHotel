using Microsoft.AspNetCore.Mvc;

namespace NZHotel.UI.Areas.Reception.Controllers
{
    [Area("Reception")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

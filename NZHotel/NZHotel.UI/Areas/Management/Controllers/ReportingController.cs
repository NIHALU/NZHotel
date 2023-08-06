using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZHotel.Business.Interfaces;
using NZHotel.Common.Enums;

namespace NZHotel.UI.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = "Manager")]
    public class ReportingController : Controller
    {
        private readonly IGuestService _guestService;
        private readonly IGuestReservationService _guestReservationService;
        private readonly IReservationService _reservationService;

        public ReportingController(IGuestService guestService, IGuestReservationService guestReservationService, IReservationService reservationService)
        {
            _guestService = guestService;
            _guestReservationService = guestReservationService;
            _reservationService = reservationService;
        }



        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GuestList()
        {
            var list = _guestService.Getlist();
            foreach (var item in list)
            {
                item.VisitedBefore = await _guestService.VisitedBefore(item.Id);
            }

            return View(list);
            
        }

        public async Task<IActionResult> PastReservations(int guestId)
        {
            var list = await _guestReservationService.GetReservations(guestId);
           

            return View(list);

        }


        public async Task<IActionResult> GetReservations()
        {
           var response = await _reservationService.GetReservations(x => x.Active==true);


            return View(response.Data);

        }

		public async Task<IActionResult> GetPayLaterReservations()
		{
			var response = await _reservationService.GetReservations(x => x.PaymentTypeId==(int)PaymentType.PayLater);

			return View(response.Data);

		}






	}
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NZHotel.UI.Areas.Reception.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NZHotel.UI.Areas.Reception.Controllers
{
    [Area("Reception")]
    public class ApiExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ExchangeRatesModel2> exchangeRates = new();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=USD&locale=en-gb"),
                Headers =
            {
                     { "X-RapidAPI-Key", "c0839328aemsh16723cbbcad2e96p1bf152jsnc23f4154fc59" },
                      { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
                 },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeRatesModel2>(body);
                return View(values.exchange_rates);
            }
            
        }
    }
}

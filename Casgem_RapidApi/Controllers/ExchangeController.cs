using Casgem_RapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Casgem_RapidApi.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //using System.Net.Http.Headers;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
                Headers =
                {
                    { "X-RapidAPI-Key", "dd3fa5539bmsh3b20c335e1895adp104c66jsn47d0556c5e5e" },
                    { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                //Console.WriteLine(body);
                return View(values.exchange_rates.ToList());
            }
        }

        public async Task<IActionResult> ParameterIndex()
        {
            //using System.Net.Http.Headers;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
                Headers =
                {
                    { "X-RapidAPI-Key", "dd3fa5539bmsh3b20c335e1895adp104c66jsn47d0556c5e5e" },
                    { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                //Console.WriteLine(body);
                return View(values.exchange_rates.ToList());
            }
        }


        [HttpPost]
        public async Task<IActionResult> ParameterIndex(string x)
        {
            //using System.Net.Http.Headers;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency={x}&locale=en-gb"),
                Headers =
                {
                    { "X-RapidAPI-Key", "dd3fa5539bmsh3b20c335e1895adp104c66jsn47d0556c5e5e" },
                    { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                //Console.WriteLine(body);
                return View(values.exchange_rates.ToList());
            }
        }
    }
}
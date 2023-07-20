using Casgem_RapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Casgem_RapidApi.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ImdbListViewModel> model = new List<ImdbListViewModel>();
            //using System.Net.Http.Headers;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
                {
                    { "X-RapidAPI-Key", "dd3fa5539bmsh3b20c335e1895adp104c66jsn47d0556c5e5e" },
                    { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<List<ImdbListViewModel>>(body);
                Console.WriteLine(body);
                return View(model.ToList());
            }
            return View();
        }
    }
}

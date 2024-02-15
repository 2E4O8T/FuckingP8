using HMI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HMI.Controllers
{
    public class BookingController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly HttpClient _httpClient;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClient =httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:6001");
        }

        public async Task<IActionResult> Index()
        {
            var request = await _httpClient.GetAsync("/gateway/booking");

            if (request.IsSuccessStatusCode)
            {
                var appointments = await request.Content.ReadFromJsonAsync<List<BookingDto>>();

                return View(appointments);
            }

            else
            {
                return NoContent();
            }
        }
    }
}

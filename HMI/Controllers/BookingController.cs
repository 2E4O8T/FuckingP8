using HMI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

namespace HMI.Controllers
{
    public class BookingController : Controller
    {
        private readonly HttpClient _httpClient;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:6001");
        }

        public async Task<IActionResult> Index()
        {
            var request = await _httpClient.GetAsync("/gateway/simplebooking");

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

        //public IActionResult Create()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Create(BookingDto appointment)
        {
            if (!ModelState.IsValid)
            {
                return View(appointment);
            }

            var content = new StringContent(JsonSerializer.Serialize(appointment), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/gateway/simplebooking", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(appointment);
            }
        }
    }
}

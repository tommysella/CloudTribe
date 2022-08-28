using CloudTribe.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CloudTribe.Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            // Get tribe members from Backend
            var apiBaseUrl = Environment.GetEnvironmentVariable("API_BASE_URL");

            ViewBag.Text = $"apiBaseUrl: {apiBaseUrl}";

            HttpClient client = new HttpClient();
            var re = await client.GetAsync($"{apiBaseUrl}/TribeMembers");
            var text = await re.Content.ReadAsStringAsync();

            var tribeMembers = JsonConvert.DeserializeObject<List<TribeMember>>(text);

            return View(tribeMembers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

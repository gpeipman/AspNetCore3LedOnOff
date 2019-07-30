using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNetCore3LedOnOff.Models;

namespace AspNetCore3LedOnOff.Controllers
{
    public class HomeController : Controller
    {
        private readonly LedClient _ledClient;

        public HomeController(LedClient ledClient)
        {
            _ledClient = ledClient;
        }

        public IActionResult Index()
        {
            ViewBag.LedState = _ledClient.IsLedOn ? "On" : "Off";

            return View();
        }

        public IActionResult LedOn()
        {
            _ledClient.LedOn();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult LedOff()
        {
            _ledClient.LedOff();

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}

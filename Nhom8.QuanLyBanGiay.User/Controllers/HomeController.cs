using Microsoft.AspNetCore.Mvc;
using Nhom8.QuanLyBanGiay.User.Models;
using System.Diagnostics;

namespace Nhom8.QuanLyBanGiay.User.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Page404()
        {
            return View();
        }

        public IActionResult Shop()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult Single()
        {
            return View();
        }

        public IActionResult Contact()
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
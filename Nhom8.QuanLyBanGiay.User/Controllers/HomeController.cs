using Microsoft.AspNetCore.Mvc;
using Nhom8.QuanLyBanGiay.User.Models;
using System.Diagnostics;

namespace Nhom8.QuanLyBanGiay.User.Controllers
{
    public class HomeController : Controller
    {
        QlbanGiayContext db = new QlbanGiayContext();

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
			var ds_san_pham = db.Giays.ToList();
			return View(ds_san_pham);
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

        public IActionResult HienSanPham() {
            var ds_san_pham = db.Giays.ToList();
            return View(ds_san_pham);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Nhom8.QuanlyBanGiay.Admin.Models;
using System.Diagnostics;

namespace Nhom8.QuanlyBanGiay.Admin.Controllers
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
			var lstNhanVien = db.NhanViens.OrderBy(x=>x.MaNv).ToList();
			return View(lstNhanVien);
		}
        public IActionResult Products()
        {
            var lstGiay = db.Giays.OrderBy(x => x.MaGiay).ToList();
            return View(lstGiay);
        }
		public IActionResult HDN() 
		{
			var lstHDN = db.HoaDonNhaps.OrderBy(x => x.MaHdn).ToList();
			return View(lstHDN);
		}
        public IActionResult HDB()
        {
            var lstHDB = db.HoaDonBans.OrderBy(x => x.MaHdb).ToList();
            return View(lstHDB);
        }
        public IActionResult Login()
		{
			return View();
		}
		public IActionResult Register()
		{
			return View();
		}
        public IActionResult Password()
        {
            return View();
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
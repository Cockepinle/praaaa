using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lepilina.Controllers
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
            var tem = HttpContext.Items["Theme"]?.ToString();
            ViewBag.Theme = tem;
            return View();
        }

        [HttpPost]
        public IActionResult ToggleTheme()
        {
            var currentTheme = HttpContext.Items["Theme"].ToString();
            var newTem = currentTheme == "dark" ? "light" : "dark";
            Response.Cookies.Append("Theme", newTem);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}

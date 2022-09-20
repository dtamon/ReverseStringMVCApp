using Microsoft.AspNetCore.Mvc;
using ReverseStringMVCApp.Models;
using System.Diagnostics;

namespace ReverseStringMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new StringModel());
        }

        [HttpPost]
        public IActionResult Index(StringModel _stringModel)
        {
            _stringModel.Reversed = Reverse(_stringModel.ToReverse);
            return View(_stringModel);
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        static string Reverse(String str)
        {
            if (str.Length > 0)
                return str[str.Length - 1] + Reverse(str.Substring(0, str.Length - 1));
            else
                return str;
        }
    }
}
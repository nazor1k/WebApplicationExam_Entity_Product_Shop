using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplicationEXAM_N1.Helpers;
using WebApplicationEXAM_N1.Models;

namespace WebApplicationEXAM_N1.Controllers
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
            return RedirectToAction("Index", "Product");
        }

        public IActionResult About()
        {
            return View();
        }

        
    }
}

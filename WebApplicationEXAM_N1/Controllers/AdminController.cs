using Microsoft.AspNetCore.Mvc;

namespace WebApplicationEXAM_N1.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

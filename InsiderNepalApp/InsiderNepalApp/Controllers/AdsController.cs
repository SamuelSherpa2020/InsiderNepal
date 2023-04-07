using Microsoft.AspNetCore.Mvc;

namespace InsiderNepalApp.Controllers
{
    public class AdsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

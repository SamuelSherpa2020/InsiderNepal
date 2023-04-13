using Microsoft.AspNetCore.Mvc;

namespace InsiderNepalApp.Controllers
{
    public class JournalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

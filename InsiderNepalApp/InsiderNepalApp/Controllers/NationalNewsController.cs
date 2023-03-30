using InsiderNepalApp.Data;
using InsiderNepalApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InsiderNepalApp.Controllers
{
    public class NationalNewsController : Controller
    {
        private readonly InsiderNepalDbContext _ctx;
        public NationalNewsController(InsiderNepalDbContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
           return View();
        }

        // for adding news 
      
        public IActionResult AddNews()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult AddNews(NationalNews nationalNews)
        {
            
            if(!ModelState.IsValid)
            {
                return View();
            }
            return View();
        }


        // for editing and updating news

        // for deleting and updating news
    }
}

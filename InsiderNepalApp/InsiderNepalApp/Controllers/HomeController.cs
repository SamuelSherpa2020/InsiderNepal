using InsiderNepalApp.Data;
using InsiderNepalApp.Mapper;
using InsiderNepalApp.Models;
using InsiderNepalApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InsiderNepalApp.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly InsiderNepalDbContext _ctx;
        public HomeController(InsiderNepalDbContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            var nNews = _ctx.NationalNews.ToList();
            var nlNews = nNews.ToViewModel();
            
            var gNews = _ctx.GlobalNews.ToList();
            var glNews = gNews.ToViewModel();
            
            var bNews = _ctx.BussinessNews.ToList();
            var blNews = bNews.ToViewModel();

            var cNews = _ctx.CultureNews.ToList();
            var clNews = cNews.ToViewModel();

            var aNews = _ctx.AdsModel.ToList();
            var alNews = aNews.ToViewModel();

            HomeViewModel hmv = new HomeViewModel
            {
                //GlobalNewsVM = _ctx.GlobalNews.ToList(),
                NationalNewsVM = nlNews,
                GlobalNewsVM = glNews,
                BussinessNewsVM = blNews,
                CultureNewsVM = clNews,
                AdsVM = alNews

            };

            return View(hmv);
            
            //var gNews = _ctx.GlobalNews.ToList();
            //gNews.Reverse();
            //var gNewsVMM = gNews.ToViewModel();
            //return View(gNewsVMM);
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
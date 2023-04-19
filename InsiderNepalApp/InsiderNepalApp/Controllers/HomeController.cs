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


        public IActionResult ReadParticularNews(int id, string category)
        {


            //NationalNewsVM, GloblaNewsVM, BussinessNewsVM, CultureNewsVM 

            if (category == "NationalNewsVM")
            {
                var nnews = _ctx.NationalNews.Where(x => x.NationalNewsId == id).ToList();
                var nnewsVM = nnews.ToViewModel();
                //hmv.NationalNewsVM.Add(nnewsVM); 
                HomeViewModel hmv = new()
                {
                    NationalNewsVM = nnewsVM,
                    
                };
                return View(hmv);

            }
            else if (category == "BussinessNewsVM")
            {
                var bnews = _ctx.BussinessNews.Where(x => x.BussinessNewsId == id).ToList();
                var bnewsVM = bnews.ToViewModel();
                HomeViewModel hmv = new()
                { 
                    BussinessNewsVM = bnewsVM 
                };
                return View(hmv);

            }
            else if(category == "GlobalNewsVM")
            {
                var gnews = _ctx.GlobalNews.Where(x=>x.GlobalId == id).ToList();    
                var gnewsVM = gnews.ToViewModel();
                HomeViewModel hmv = new()
                {GlobalNewsVM= gnewsVM};
                return View(hmv);

            }
            else if(category == "CultureNewsVM")
            {
                var cnews = _ctx.CultureNews.Where(x=>x.CultureNewsId== id).ToList();
                var cnewsVM = cnews.ToViewModel();
                HomeViewModel hmv = new()
                {CultureNewsVM = cnewsVM};
                return View(hmv);

            }
            
            else
            {
                return View();

            }

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
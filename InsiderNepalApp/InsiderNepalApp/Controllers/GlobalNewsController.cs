using InsiderNepalApp.Data;
using InsiderNepalApp.Extensions;
using InsiderNepalApp.Mapper;
using InsiderNepalApp.Models;
using InsiderNepalApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Identity.Client;

namespace InsiderNepalApp.Controllers
{
    public class GlobalNewsController : Controller
    {
        private readonly InsiderNepalDbContext _gdx;
            public GlobalNewsController(InsiderNepalDbContext gdx)
        {
            _gdx = gdx;
        }
        public IActionResult Index()
        {
            var globalNews = _gdx.GlobalNews.ToList();
            globalNews.Reverse();
            var globalNewsVM = globalNews.ToViewModel();
            return View(globalNewsVM);
        }

        public IActionResult AddGlobalNews()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGlobalNews(GlobalNewsVM globalNewsVM)
        {
             if(globalNewsVM == null || !ModelState.IsValid)
            {
                //return View("Error", new ErrorViewModel {RequestId = "Registering Global News is not possible !!"});
                return View();
            }
            string imagePath = globalNewsVM.Avatar.SaveGlobalImage();
            var globalNews = globalNewsVM.ToModel();
            globalNews.ImageUrl = imagePath;

            try
            {
                _gdx.Add(globalNews);
                _gdx.SaveChanges();
                TempData["msg"] = "Added Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "could not be added !!";
            }
            return View();
        }
        

        // for editing 

        public IActionResult EditGlobalNews(int id)
        {
            var gNews = _gdx.GlobalNews.Find(id);
            var gNewsVM = gNews.ToViewModel();
            return View(gNewsVM);
        }

        [HttpPost]
        public IActionResult EditGlobalNews(GlobalNewsVM globalNewsVM)
        {
            if(globalNewsVM == null || !ModelState.IsValid)
            {
                return View("Error", new ErrorViewModel { RequestId = "Update Global news not successful" });
            }

            var gNews = globalNewsVM?.ToModel();
            if(globalNewsVM?.Avatar != null)
            {
                var path = globalNewsVM.Avatar.SaveGlobalImage();
                gNews.ImageUrl = path;
            }
            try
            {
                _gdx.GlobalNews.Update(gNews);
                _gdx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex) { }
            {
                TempData["msg"] = "could not be added";
                return View();
            }
            
        }
        //for deleting

        public IActionResult DeleteConfirm(int id)
        {
            var gnews = _gdx.GlobalNews.Find(id);
            var gnewsVM = gnews.ToViewModel();
            return View(gnewsVM);
        }

        [HttpPost]
        public IActionResult DeleteGlobalNews(GlobalNewsVM globalNewsVM)
        {
            try
            {
                var gnews = globalNewsVM.ToModel();
                if (gnews != null)
                {
                    _gdx.GlobalNews.Remove(gnews);
                    _gdx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
               
            }
            return RedirectToAction("Index");
            }
        }
    }


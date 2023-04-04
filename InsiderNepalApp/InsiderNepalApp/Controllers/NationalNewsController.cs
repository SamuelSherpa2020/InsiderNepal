using InsiderNepalApp.Data;
using InsiderNepalApp.Extensions;
using InsiderNepalApp.Mapper;
using InsiderNepalApp.Models;
using InsiderNepalApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

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
            var nnews = _ctx.NationalNews.ToList();
            nnews.Reverse();
            var nnewsVM = nnews.ToViewModel();
            return View(nnewsVM);
        }

        // for adding news 

        public IActionResult AddNews()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddNews(NationalNewsVM nationalNewsVM)
        {

            if (nationalNewsVM == null || !ModelState.IsValid)
            {
                // return View("Error", new ErrorViewModel { RequestId = "Register News" });
                return View();
            }

            string avatarPath = nationalNewsVM.Avatar.SaveNewsImage();
            var nationalNews = nationalNewsVM.ToModel();
            nationalNews.ImageUrl = avatarPath;
            try
            {
                _ctx.Add(nationalNews);
                _ctx.SaveChanges();
                TempData["msg"] = "Added Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "could not be added !!!";

            }
            return View();
        }


        // for editing and updating news

        public IActionResult EditNationalNews(int id)
        {
            var nnews = _ctx.NationalNews.Find(id);
            var nnewsVM = nnews?.ToViewModel();
            return View(nnewsVM);
        }

        [HttpPost]
        public IActionResult EditNationalNews(NationalNewsVM nationalNewsVM)
        {
            if (nationalNewsVM == null || !ModelState.IsValid)
            {
                return View("Error", new ErrorViewModel { RequestId = "Update NationalNews not successful" });

            }
            var nnews = nationalNewsVM.ToModel();
            if (nationalNewsVM.Avatar is not null)
            {
                var path = nationalNewsVM.Avatar.SaveNewsImage();
                nnews.ImageUrl = path;
            }
            try
            {
                _ctx.NationalNews.Update(nnews);
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["msg"] = "Could not be added";
                return View();
            }
        }




        // for deleting and updating news
        public IActionResult DeleteConfirmNN(int id)
        {
            var nnews = _ctx.NationalNews.Find(id);
            var nnewsVM = nnews?.ToViewModel();
            return View(nnewsVM);
        }

        [HttpPost]
        public IActionResult DeleteNN(NationalNewsVM nationalNewsVM)
        {
            try
            {
                var nnews = nationalNewsVM.ToModel();
                if(nnews != null)
                {
                    _ctx.NationalNews.Remove(nnews);
                    _ctx.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index");
        }
    }
}

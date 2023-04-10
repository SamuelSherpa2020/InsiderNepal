using InsiderNepalApp.Data;
using InsiderNepalApp.Extensions;
using InsiderNepalApp.Mapper;
using InsiderNepalApp.Models;
using InsiderNepalApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace InsiderNepalApp.Controllers
{
    public class AdsController : Controller
    {

        private readonly InsiderNepalDbContext _adx;
        public AdsController(InsiderNepalDbContext adx)
        {
            _adx = adx;
        }

        //to show the ads
        public IActionResult Index()
        {
            var adsi = _adx.AdsModel.ToList();
            adsi.Reverse();
            var adsiVM = adsi.ToViewModel();
            return View(adsiVM);
        }

        //get for adding new add
        public IActionResult AddAds()
        {
            return View();
        }


        //post method for adding new ads
        [HttpPost]
        public IActionResult AddAds(AdsVM advm)
        {
            if (advm == null || !ModelState.IsValid)
            {
                // return View("Error", new ErrorViewModel { RequestId = "Register News" });
                return View();
            }

            string avatarPath = advm.AdsAvatar.SaveAdsImage();
            var adsmodel = advm.ToModel();
            adsmodel.ImageUrl = avatarPath;
            try
            {
                _adx.Add(adsmodel);
                _adx.SaveChanges();
                TempData["msg"] = "Added Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "could not be added !!!";

            }
            return View();
        }


        // for editing ads
        public IActionResult EditAds(int id)
        {
            var ads = _adx.AdsModel.Find(id);
            var adsVM = ads?.ToViewModel();
            return View(adsVM);
        }

        [HttpPost]
        public IActionResult EditAds(AdsVM adsVM)
        {
            if (adsVM == null || !ModelState.IsValid)
            {
                return View("Error", new ErrorViewModel { RequestId = "Update Ads not successful" });

            }
            var ads = adsVM.ToModel();
            if (adsVM.AdsAvatar is not null)
            {
                var path = adsVM.AdsAvatar.SaveAdsImage();
                ads.ImageUrl = path;
            }
            try
            {
                _adx.AdsModel.Update(ads);
                _adx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not be added";
                return View();
            }
        }




        // for deleting and updating news
        public IActionResult DeleteConfirmAds(int id)
        {
            var ads = _adx.AdsModel.Find(id);
            var adsVM = ads?.ToViewModel();
            return View(adsVM);
        }

        [HttpPost]
        public IActionResult DeleteAds(AdsVM adsVM)
        {
            try
            {
                var adstry = _adx.AdsModel.Find(adsVM.AdsId);
                _adx.AdsModel.Remove(adstry);
                _adx.SaveChanges();

                //var ads = adsVM.ToModel();
                //if (ads != null)
                //{
                //    _adx.AdsModel.Remove(ads);
                //    _adx.SaveChanges();
                //}

            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index");
        }

    }
}

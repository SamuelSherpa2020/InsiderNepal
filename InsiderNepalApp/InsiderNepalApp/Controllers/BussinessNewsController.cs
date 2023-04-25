using InsiderNepalApp.Data;
using InsiderNepalApp.Extensions;
using InsiderNepalApp.Mapper;
using InsiderNepalApp.Models;
using InsiderNepalApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsiderNepalApp.Controllers;

[Authorize(Roles ="Admin")]
public class BussinessNewsController : Controller
{

    private readonly InsiderNepalDbContext _bdx;
    public BussinessNewsController(InsiderNepalDbContext bdx)
    {
        _bdx = bdx;
    }
    public IActionResult Index()
    {
        var bnews = _bdx.BussinessNews.ToList();
        bnews.Reverse();
        var bnewsVM = bnews.ToViewModel();
        return View(bnewsVM);
    }

    //Add BussinessNews 
    public IActionResult AddBussinessNews()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddBussinessNews(BussinessNewsVM bnewsVM)
    {
        if (bnewsVM == null || !ModelState.IsValid)
        {
            return View();
        }

        string avatarPath = bnewsVM.Avatar.SaveBussinessImage();
        var bNews = bnewsVM.ToModel();
        bNews.ImageUrl = avatarPath;
        try
        {
            _bdx.Add(bNews);
            _bdx.SaveChanges();
            TempData["msg"] = "Added Successfully";
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            TempData["msg"] = "could not be added !!!";

        }
        return View();
    }

    //For editing the news
    public IActionResult EditBussinessNews(int id)
    {
        var bNews = _bdx.BussinessNews.Find(id);
        var bNewsVM = bNews.ToViewModel();
        return View(bNewsVM);
    }

    [HttpPost]
    public IActionResult EditBussinessNews(BussinessNewsVM bNewsVM)
    {
        if (bNewsVM == null || !ModelState.IsValid)
        {
            return View();
        }
        var bNews = bNewsVM.ToModel();
        if (bNewsVM.Avatar is not null)
        {
            var path = bNewsVM.Avatar.SaveBussinessImage();
            bNews.ImageUrl = path;
        }
        try
        {
            _bdx.BussinessNews.Update(bNews);
            _bdx.SaveChanges();
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            TempData["msg"] = "Could not be added";
            return View();
        }
    }

    //For Delete confirm

    public IActionResult DeleteConfirmBN(int id)
    {
        var bNews = _bdx.BussinessNews.Find(id);
        var bNewsVM = bNews.ToViewModel();
        return View(bNewsVM);
    }

    [HttpPost]
    public IActionResult DeleteBN(BussinessNewsVM bNewsVM)

    {
        try
        {
            var bnews = bNewsVM.ToModel();
            if (bnews != null)
            {
                _bdx.Remove(bnews);
                _bdx.SaveChanges();

            }
        }
        catch (Exception ex)
        {
        }
        return RedirectToAction("Index");
    }


    [AllowAnonymous]
    public IActionResult ReadBussinessNews()
    {
        var gnews = _bdx.BussinessNews.ToList();
        gnews.Reverse();

        var gnewsVM = gnews.ToViewModel();

        var ads = _bdx.AdsModel.ToList();
        var adsVM = ads.ToViewModel();
        BussinessAdsVM gav = new()
        {
            BussinessNewsVM = gnewsVM,
            AdsVM = adsVM,
        };

        return View(gav);
    }

    [AllowAnonymous]
    public IActionResult ShowBussinessInDetail(int id)
    {
        var gnews = _bdx.BussinessNews.Where(x => x.BussinessNewsId == id).ToList();
        var gnewsVM = gnews.ToViewModel();

        var ads = _bdx.AdsModel.ToList();
        var adsVM = ads.ToViewModel();

        BussinessAdsVM gav = new()
        {
            BussinessNewsVM = gnewsVM,
            AdsVM = adsVM
        };

        return View(gav);
    }
}

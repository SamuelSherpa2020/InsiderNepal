using InsiderNepalApp.Data;
using InsiderNepalApp.Extensions;
using InsiderNepalApp.Mapper;
using InsiderNepalApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace InsiderNepalApp.Controllers;

public class CultureController : Controller
{
    private readonly InsiderNepalDbContext _cdx;

    public CultureController(InsiderNepalDbContext cdx)
    {
        _cdx = cdx;
    }

    public IActionResult Index()
    {
        var cNews = _cdx.CultureNews.ToList();
        cNews.Reverse();
        var cNewsVM = cNews.ToViewModel();
        return View(cNewsVM);
    }

    // Add Culture News 
    public IActionResult AddCultureNews()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddCultureNews(CultureNewsVM cNewsVM)

    {
        if(cNewsVM == null || !ModelState.IsValid)
        {
            return View();
        }
        string avatarPath = cNewsVM.Avatar.SaveCulutreAndLifestyleImage();
        var cNews = cNewsVM.ToModel();
        cNews.ImageUrl = avatarPath;
        try
        {
            _cdx.Add(cNews);
            _cdx.SaveChanges();
            TempData["msg"] = "Added Successfully";
            return RedirectToAction("index");
        }
        catch(Exception ex)
        {
            TempData["msg"] = "could not be added !!";
        }
        return View();
    }

    //Editing
    public IActionResult EditCultureNews(int id)
    {
        var cNews = _cdx.CultureNews.Find(id);
        var cNewsVM = cNews.ToViewModel();
        return View(cNewsVM);
    }

    [HttpPost]
    public IActionResult EditCultureNews(CultureNewsVM cNewsVM)
    {
        if(cNewsVM == null || !ModelState.IsValid)
        {
            return View();
        }
        
        var cNews = cNewsVM.ToModel();
        
        if(cNewsVM.Avatar is not null)
        {
            var path = cNewsVM.Avatar.SaveCulutreAndLifestyleImage();
            cNews.ImageUrl = path;
        }
        try
        {
            _cdx.CultureNews.Update(cNews);
            _cdx.SaveChanges();
            return RedirectToAction("index");
        }
        catch(Exception ex)
        {
            TempData["msg"] = "Could not be updated";
            return View();
        }
        return View();
    }

    // For Deleting

    public IActionResult DeleteConfirmCN(int id)
    {
        var cNews = _cdx.CultureNews.Find(id);
        var cNewsVM = cNews.ToViewModel();
        return View(cNewsVM);
    }

    [HttpPost]
    public IActionResult DeleteCN(CultureNewsVM cNewsVM)
    {
        try
        {
            var cNews = cNewsVM.ToModel();
            if(cNews !=null)
            {
                _cdx.Remove(cNews);
                _cdx.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            TempData["msg"] = "Could not be deleted";
            return View();
        }
        return RedirectToAction("Index");
    }
}

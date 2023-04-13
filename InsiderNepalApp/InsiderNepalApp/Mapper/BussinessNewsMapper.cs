using InsiderNepalApp.Models;
using InsiderNepalApp.ViewModel;

namespace InsiderNepalApp.Mapper;

public static class BussinessNewsMapper
{
    public static BussinessNews ToModel(this BussinessNewsVM gnVM)
    {
        return new BussinessNews
        {
            BussinessNewsId = gnVM.BussinessNewsVMId,
            Title = gnVM.Title,
            Author = gnVM.Author,
            ImageUrl = gnVM.ImageUrl,
            PublishDateTime = gnVM.PublishDateTime,
            Content = gnVM.Content,
        };
    }

    public static BussinessNewsVM ToViewModel(this BussinessNews bNews)
    {
        return new BussinessNewsVM
        {
            BussinessNewsVMId= bNews.BussinessNewsId,
            Title = bNews.Title,
            Author = bNews.Author,
            ImageUrl = bNews.ImageUrl,
            PublishDateTime = bNews.PublishDateTime,
            Content = bNews.Content,
        };
    }

    public static List<BussinessNewsVM> ToViewModel(this List<BussinessNews> bNews)
    {
        return bNews.Select(xnews => xnews.ToViewModel()).ToList();
    }

}

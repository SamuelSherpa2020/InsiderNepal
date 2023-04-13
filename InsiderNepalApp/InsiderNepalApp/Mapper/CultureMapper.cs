using InsiderNepalApp.Models;
using InsiderNepalApp.ViewModel;

namespace InsiderNepalApp.Mapper;

public static class CultureMapper
{
    public static CultureNews ToModel(this CultureNewsVM cNewsVM) =>
    new()
    {
        CultureNewsId = cNewsVM.CultureNewsVMId,
        Title = cNewsVM.Title,
        Author = cNewsVM.Author,
        ImageUrl = cNewsVM.ImageUrl,
        PublishDateTime = cNewsVM.PublishDateTime,
        Content = cNewsVM.Content,
    };

    public static CultureNewsVM ToViewModel(this CultureNews cNews) =>
        new()
        {

            CultureNewsVMId = cNews.CultureNewsId,
            Title = cNews.Title,
            Author = cNews.Author,
            ImageUrl = cNews.ImageUrl,
            PublishDateTime = cNews.PublishDateTime,
            Content = cNews.Content,
        };

    public static List<CultureNewsVM> ToViewModel(this List<CultureNews> cNews)
    {
        return cNews.Select(news => news.ToViewModel()).ToList();
    }
}

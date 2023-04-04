using InsiderNepalApp.Models;
using InsiderNepalApp.ViewModel;

namespace InsiderNepalApp.Mapper
{
    public static class NationalNewsMapper
    {
        public static NationalNews ToModel(this NationalNewsVM nationalNewsVM)=>
        new()
        { 
            NationalNewsId = nationalNewsVM.NationalNewsId,
            Title = nationalNewsVM.Title,
            Author = nationalNewsVM.Author, 
            ImageUrl = nationalNewsVM.ImageUrl,
            PublishDateTime = nationalNewsVM.PublishDateTime,
            Content = nationalNewsVM.Content,
        };

        public static NationalNewsVM ToViewModel(this NationalNews nationalNews) =>
            new ()
            {
                
                NationalNewsId = nationalNews.NationalNewsId,
                Title = nationalNews.Title,
                Author = nationalNews.Author,
                ImageUrl = nationalNews.ImageUrl,
                PublishDateTime = nationalNews.PublishDateTime,
                Content = nationalNews.Content,
            };

        public static List<NationalNewsVM> ToViewModel(this List<NationalNews> nnews)
        {
            return nnews.Select(news => news.ToViewModel()).ToList();   
        }

    }
}

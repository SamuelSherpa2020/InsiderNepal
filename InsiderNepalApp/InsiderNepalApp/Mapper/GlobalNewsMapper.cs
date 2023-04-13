using InsiderNepalApp.Models;
using InsiderNepalApp.ViewModel;

namespace InsiderNepalApp.Mapper
{
    public static class GlobalNewsMapper
    {
        public static GlobalNews ToModel(this GlobalNewsVM gnVM)
        {
            return new GlobalNews
            {
                GlobalId = gnVM.GlobalNewsId,
                Title = gnVM.Title,
                Author = gnVM.Author,
                ImageUrl = gnVM.ImageUrl,
                PublishDateTime = gnVM.PublishDateTime,
                Content = gnVM.Content,
            };
        }

        public static GlobalNewsVM ToViewModel(this GlobalNews gNews)
        {
            return new GlobalNewsVM
            {
                GlobalNewsId = gNews.GlobalId, 
                Title = gNews.Title,
                Author = gNews.Author,
                ImageUrl = gNews.ImageUrl,
                PublishDateTime = gNews.PublishDateTime,
                Content = gNews.Content,
            };
        }

        public  static List<GlobalNewsVM> ToViewModel(this List<GlobalNews> gNews)
        {
            return gNews.Select(xnews => xnews.ToViewModel()).ToList();
        }

    }
}

using InsiderNepalApp.Models;
using InsiderNepalApp.ViewModel;

namespace InsiderNepalApp.Mapper
{
    public static class AdsMapper
    {
        //mapper to translate Model to ViewModel
        public static AdsModel ToModel(this AdsVM ads)
        {
            return new AdsModel
            {
                Id = ads.AdsId,
                Title = ads.Title,
                Description = ads.Description,
                ImageUrl=ads.ImageUrl,
                Price= (float)ads.Price,
                ContactInformation = ads.ContactInformation,
                StartDate= (DateTime)ads.StartDate,
                EndDate= (DateTime)ads.EndDate,
            };
        }


        public static AdsVM ToViewModel(this AdsModel ads)  
        {
            return new AdsVM { 

            AdsId = ads.Id,
            Title = ads.Title,
            Description = ads.Description,
            ImageUrl = ads.ImageUrl,
            Price = ads.Price,
            ContactInformation = ads.ContactInformation,
            StartDate   = ads.StartDate,
            EndDate = ads.EndDate,  
            
            };
        }
        public static List<AdsVM> ToViewModel(this List<AdsModel> adsmodel)
        {
            return adsmodel.Select(adv => adv.ToViewModel()).ToList();
        }

    }
}

using InsiderNepalApp.Models;
using InsiderNepalApp.ViewModel;

namespace InsiderNepalApp.Mapper
{
    public class AdsMapper
    {
        public AdsVM toAdsVM(AdsModel ads)
        {
            return new AdsVM { 
            AdsId = ads.Id,
            Title = ads.Title,
            Description = ads.Description,

            };
        }

        public AdsModel toAdsModelVM(AdsModel ads)
        {
            return new AdsModel();
        }
    }
}

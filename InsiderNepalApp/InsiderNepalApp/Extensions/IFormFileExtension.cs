namespace InsiderNepalApp.Extensions
{
    public static class IFormFileExtension
    {
        public static string SaveNewsImage(this IFormFile image)
        {
            if(image is null)
            {
                return string.Empty;
            }

            var fileName = $"{Guid.NewGuid()}_{image.FileName}";
            var appFolder = Directory.GetCurrentDirectory();
            var imageFolderPathRelative = $"/images/National/{fileName}";
            var imageFolderPathAbsolute = appFolder +"/wwwroot/"+ imageFolderPathRelative;

            var avatar = File.Create(imageFolderPathAbsolute);
            image.CopyTo(avatar);
            avatar.Close();
            return imageFolderPathRelative;
        }

        public static string SaveAdsImage(this IFormFile image)
        {
            if (image is null)
            {
                return string.Empty;
            }

            var fileName = $"{Guid.NewGuid()}_{image.FileName}";
            var appFolder = Directory.GetCurrentDirectory();
            var imageFolderPathRelative = $"/images/Ads/{fileName}";
            var imageFolderPathAbsolute = appFolder + "/wwwroot/" + imageFolderPathRelative;

            var avatar = File.Create(imageFolderPathAbsolute);
            image.CopyTo(avatar);
            avatar.Close();
            return imageFolderPathRelative;
        }
    }
}

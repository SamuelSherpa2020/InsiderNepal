namespace InsiderNepalApp.Extensions
{
    public static class IFormFileExtension
    {
        //code to save ads image in ads folder
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

        public static string SaveGlobalImage(this IFormFile image)
        {
            if (image is null)
            {
                return string.Empty;
            }

            var fileName = $"{Guid.NewGuid()}_{image.FileName}";
            var appFolder = Directory.GetCurrentDirectory();
            var imageFolderPathRelative = $"/images/Global/{fileName}";
            var imageFolderPathAbsolute = appFolder + "/wwwroot/" + imageFolderPathRelative;

            var avatar = File.Create(imageFolderPathAbsolute);
            image.CopyTo(avatar);
            avatar.Close();
            return imageFolderPathRelative;
        }
        public static string SaveBussinessImage(this IFormFile image)
        {
            if (image is null)
            {
                return string.Empty;
            }

            var fileName = $"{Guid.NewGuid()}_{image.FileName}";
            var appFolder = Directory.GetCurrentDirectory();
            var imageFolderPathRelative = $"/images/Bussiness/{fileName}";
            var imageFolderPathAbsolute = appFolder + "/wwwroot/" + imageFolderPathRelative;

            var avatar = File.Create(imageFolderPathAbsolute);
            image.CopyTo(avatar);
            avatar.Close();
            return imageFolderPathRelative;
        }
        public static string SaveCulutreAndLifestyleImage(this IFormFile image)
        {
            if (image is null)
            {
                return string.Empty;
            }

            var fileName = $"{Guid.NewGuid()}_{image.FileName}";
            var appFolder = Directory.GetCurrentDirectory();
            var imageFolderPathRelative = $"/images/Culture/{fileName}";
            var imageFolderPathAbsolute = appFolder + "/wwwroot/" + imageFolderPathRelative;

            var avatar = File.Create(imageFolderPathAbsolute);
            image.CopyTo(avatar);
            avatar.Close();
            return imageFolderPathRelative;
        }

        public static string SaveJournalImage(this IFormFile image)
        {
            if (image is null)
            {
                return string.Empty;
            }

            var fileName = $"{Guid.NewGuid()}_{image.FileName}";
            var appFolder = Directory.GetCurrentDirectory();
            var imageFolderPathRelative = $"/images/Journal/{fileName}";
            var imageFolderPathAbsolute = appFolder + "/wwwroot/" + imageFolderPathRelative;

            var avatar = File.Create(imageFolderPathAbsolute);
            image.CopyTo(avatar);
            avatar.Close();
            return imageFolderPathRelative;
        }

    }
}

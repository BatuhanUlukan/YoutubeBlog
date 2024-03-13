using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using YoutubeBlog.Entity.DTOs.Images;
using YoutubeBlog.Entity.Enums;


namespace YoutubeBlog.Service.Helpers.Images
{
    public class ImageHelper : IImageHelper
    {
        private readonly string wwwroot;
        private readonly IWebHostEnvironment env;
        private const string imgFolder = "Assets/Images";
        private const string articleImagesFolder = "article-images";
        private const string userImagesFolder = "user-images";
        private const string portfolioImagesFolder = "portfolio-images";
        private const string clientImagesFolder = "client-images";
        private const string logoImagesFolder = "logo-images";
        private const string sliderImageFolder = "slider-images";
        private const string aboutImageFolder = "about-images";

        public ImageHelper(IWebHostEnvironment env)
        {
            this.env = env;
            wwwroot = env.WebRootPath;
        }


        private string ReplaceInvalidChars(string fileName)
        {
            return fileName.Replace("İ", "I")
                 .Replace("ı", "i")
                 .Replace("Ğ", "G")
                 .Replace("ğ", "g")
                 .Replace("Ü", "U")
                 .Replace("ü", "u")
                 .Replace("ş", "s")
                 .Replace("Ş", "S")
                 .Replace("Ö", "O")
                 .Replace("ö", "o")
                 .Replace("Ç", "C")
                 .Replace("ç", "c")
                 .Replace("é", "")
                 .Replace("!", "")
                 .Replace("'", "")
                 .Replace("^", "")
                 .Replace("+", "")
                 .Replace("%", "")
                 .Replace("/", "")
                 .Replace("(", "")
                 .Replace(")", "")
                 .Replace("=", "")
                 .Replace("?", "")
                 .Replace("_", "")
                 .Replace("*", "")
                 .Replace("æ", "")
                 .Replace("ß", "")
                 .Replace("@", "")
                 .Replace("€", "")
                 .Replace("<", "")
                 .Replace(">", "")
                 .Replace("#", "")
                 .Replace("$", "")
                 .Replace("½", "")
                 .Replace("{", "")
                 .Replace("[", "")
                 .Replace("]", "")
                 .Replace("}", "")
                 .Replace(@"\", "")
                 .Replace("|", "")
                 .Replace("~", "")
                 .Replace("¨", "")
                 .Replace(",", "")
                 .Replace(";", "")
                 .Replace("`", "")
                 .Replace(".", "")
                 .Replace(":", "")
                 .Replace(" ", "");
        }



        public async Task<ImageUploadedDto> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null)
        {
            folderName = string.IsNullOrWhiteSpace(folderName)
                ? imageType switch
                {
                    ImageType.User => userImagesFolder,
                    ImageType.Post => articleImagesFolder,
                    ImageType.Work => portfolioImagesFolder,
                    ImageType.Client => clientImagesFolder,
                    ImageType.Logo => logoImagesFolder,
                    ImageType.Slider => sliderImageFolder,
                    ImageType.About => aboutImageFolder,
                    _ => imgFolder,
                }
                : ReplaceInvalidChars(folderName);

            if (!Directory.Exists(Path.Combine(wwwroot, imgFolder, folderName)))
                Directory.CreateDirectory(Path.Combine(wwwroot, imgFolder, folderName));

            string oldFileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string fileExtension = Path.GetExtension(imageFile.FileName);

            name = ReplaceInvalidChars(name);

            DateTime dateTime = DateTime.Now;

            string newFileName;
            if (imageType != ImageType.Logo)
            {
                // Check if the uploaded image is a GIF
                if (imageFile.ContentType == "image/gif")
                {
                    newFileName = $"{name}_{dateTime.Millisecond}.gif";
                }
                else
                {
                    newFileName = $"{name}_{dateTime.Millisecond}.webp"; // .webp uzantısını kullanarak kaydet
                }
            }
            else
            {
                // If the image type is Logo, use the original file extension
                newFileName = $"{name}_{dateTime.Millisecond}{fileExtension}";
            }

            var path = Path.Combine(wwwroot, imgFolder, folderName, newFileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                if (imageFile != null)
                {
                    // Convert and save the IFormFile as SVG
                    if (imageType == ImageType.Logo)
                    {
                        using var memoryStream = new MemoryStream();
                        await imageFile.CopyToAsync(memoryStream);
                        var byteArray = memoryStream.ToArray();
                        await stream.WriteAsync(byteArray, 0, byteArray.Length);
                    }
                    else
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                }
            }

            string message = imageType switch
            {
                ImageType.User => $"{newFileName} isimli kullanıcı resmi başarı ile eklenmiştir.",
                ImageType.Post => $"{newFileName} isimli makale resmi başarı ile eklenmiştir.",
                ImageType.Work => $"{newFileName} isimli portföy resmi başarı ile eklenmiştir.",
                ImageType.Client => $"{newFileName} isimli client resmi başarı ile eklenmiştir.",
                ImageType.Logo => $"{newFileName} isimli logo resmi başarı ile eklenmiştir.",
                ImageType.Slider => $"{newFileName} isimli slider resmi başarı ile eklenmiştir.",
                ImageType.About => $"{newFileName} isimli about resmi başarı ile eklenmiştir.",
                _ => "Resim eklendi."
            };

            return new ImageUploadedDto
            {
                FullName = Path.Combine(folderName, newFileName)
            };
        }



        public void Delete(string imageName)
        {
            var fileToDelete = Path.Combine(wwwroot, imgFolder, imageName);
            if (File.Exists(fileToDelete))
            {
                File.Delete(fileToDelete);
            }
        }
    }
}

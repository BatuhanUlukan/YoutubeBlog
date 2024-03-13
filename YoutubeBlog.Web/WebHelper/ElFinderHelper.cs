using elFinder.NetCore;
using elFinder.NetCore.Drivers.FileSystem;
using Microsoft.AspNetCore.Http.Extensions;

namespace YoutubeBlog.Web.WebHelper
{
    public static class ElFinderHelper
    {
        public static string RootPath = "wwwroot\\Assets\\Images";
        public static string RootUrlPath = "Assets/Images";
        public static string ThumbUrl = "/elfinder/thumb/";

        public static Connector GetConnector(HttpRequest request)
        {
            var driver = new FileSystemDriver();

            var absoluteUrl = UriHelper.BuildAbsolute(request.Scheme, request.Host);
            var uri = new Uri(absoluteUrl);

            var appRoot = Directory.GetCurrentDirectory();
            var rootDirectory = Path.Combine(appRoot, RootPath);

            var url = $"{uri.Scheme}://{uri.Authority}/{RootUrlPath}/";
            var urlThumb = $"{uri.Scheme}://{uri.Authority}{ThumbUrl}";

            var root = new RootVolume(rootDirectory, url, urlThumb)
            {
                IsReadOnly = false, //Bu alan true olursa dosyalar sadece okunabilir olur
                IsLocked = false, // Bu alan true ise dosyalar ve klasörler silinemez, yeniden adlandırılamaz veya taşınamaz
                Alias = "Dosyalarım", //Elfinder penceresinde görünen klasör adı
                                      //MaxUploadSizeInKb = 2048, //Kullanıcı tarafından yüklenen dosyaya uygulanan sınır <= 2048 KB
                                      //LockedFolders = new List<string>(new string[] { "Folder1" } //Kilitlenecek klasötlerin isimleri
                ThumbnailSize = 100
            };

            driver.AddRoot(root);

            return new Connector(driver)
            {
                MimeDetect = MimeDetectOption.Internal
            };
        }
    }
}

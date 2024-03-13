using Microsoft.AspNetCore.Http;
using YoutubeBlog.Entity.DTOs.Images;
using YoutubeBlog.Entity.Enums;

namespace YoutubeBlog.Service.Helpers.Images
{
    public interface IImageHelper
    {
        Task<ImageUploadedDto> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null);

        void Delete(string imageName);
    }
}

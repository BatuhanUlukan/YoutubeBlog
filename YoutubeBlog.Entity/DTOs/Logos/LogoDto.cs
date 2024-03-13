using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTOs.Logos
{
    public class LogoDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public ICollection<LogoImage> LogoImages { get; set; }
        public IList<IFormFile> Photos { get; set; }

        // Define an implicit conversion operator
        public static implicit operator LogoDto(Logo logo)
        {
            if (logo == null)
                return null;

            return new LogoDto
            {
                Id = logo.Id,
                Title = logo.Title,
                Slug = logo.Slug,
                LogoImages = logo.LogoImages,
                // You might want to map the Photos property if needed
                // Photos = logo.Photos
            };
        }
    }
}

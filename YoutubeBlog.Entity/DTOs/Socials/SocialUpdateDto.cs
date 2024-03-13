namespace YoutubeBlog.Entity.DTOs.Socials
{
    public class SocialUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? SecName { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public bool IsMaın { get; set; }
        public bool IsActive { get; set; }


    }
}

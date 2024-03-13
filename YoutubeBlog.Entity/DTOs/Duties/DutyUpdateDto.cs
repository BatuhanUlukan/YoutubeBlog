namespace YoutubeBlog.Entity.DTOs.Duties
{
    public class DutyUpdateDto
    {
        public Guid Id { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string SecName { get; set; }
        public string Content { get; set; }
        public bool IsMaın { get; set; }
        public bool IsActive { get; set; }

    }
}
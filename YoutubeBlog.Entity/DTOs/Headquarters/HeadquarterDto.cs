namespace YoutubeBlog.Entity.DTOs.Headquarters
{
    public class HeadquarterDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string AddressLink { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public bool Choosen { get; set; }
        public bool IsActive { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }


    }
}

using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class Headquarter : EntityBase
    {


        public Headquarter()
        {
        }

        public Headquarter(string name, string address, string location, string addressLink, string phoneNumber, string email, bool choosen)
        {
            Name = name;
            Address = address;
            Location = location;
            AddressLink = addressLink;
            PhoneNumber = phoneNumber;
            Email = email;
            Choosen = choosen;

        }

        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Location { get; set; }
        public string? AddressLink { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public bool Choosen { get; set; }

    }
}

using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class Fact : EntityBase
    {


        public Fact()
        {
        }

        public Fact(string name, string value, string ıcon, string createdBy)
        {
            Name = name;
            Value = value;
            Icon = ıcon;
            CreatedBy = createdBy;

        }

        public string Name { get; set; }
        public string Value { get; set; }
        public string Icon { get; set; }

    }
}

using YoutubeBlog.Core.Entities;
using YoutubeBlog.Entity.Enums;

namespace YoutubeBlog.Entity.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {
            Articles = new List<Article>();
        }

        public Category(string name, string createdBy, CategoryType type)
        {
            Name = name;
            CreatedBy = createdBy;
            Type = type; // Type alanı eklendi
            Articles = new List<Article>();
        }


        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
        public CategoryType Type { get; set; } // Ana veya Alt Kategori olduğunu belirtmek için

    }
}

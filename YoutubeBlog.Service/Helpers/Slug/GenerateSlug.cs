namespace YoutubeBlog.Service.Helpers.Slug
{
    public static class StringHelper
    {
        public static string GenerateSlug(string title)
        {
            // Küçük harfe dönüştürme ve özel karakterleri kaldırma
            string slug = title.ToLower().Replace('ı', 'i');
            char[] invalidChars = Path.GetInvalidFileNameChars();
            foreach (char c in invalidChars)
            {
                slug = slug.Replace(c.ToString(), "");
            }

            // Boşlukları tire ile değiştirme
            slug = slug.Replace(' ', '-');

            // Cümlenin sonundaki boşlukları kaldırma
            slug = slug.TrimEnd();



            return slug;
        }


        public static char GetRandomLetter()
        {
            Random random = new Random();
            const string chars = "ABCDabcdeEFxyz!@#$%^&*";
            return chars[random.Next(chars.Length)];
        }

    }
}

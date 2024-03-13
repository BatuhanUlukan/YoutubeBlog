using System;

namespace YoutubeBlog.Service.Helpers.Slug
{
    public static class UniqStr
    {
        public static string Giving(Guid Id)
        {
            string idString = Id.ToString(); // Guid'ı stringe çevirin

            // Rastgele bir isim oluşturun (4 ila 8 karakter uzunluğunda)
            string randomName = GuidToRandomName(idString, 6, 8);

            return randomName;
        }

        public static string GuidToRandomName(string guid, int minLength, int maxLength)
        {
            // Rastgele bir isim uzunluğu seçin (4 ila 8 karakter uzunluğunda)
            int nameLength = new Random().Next(minLength, maxLength + 1);

            // Rastgele bir isim oluşturun
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] nameArray = new char[nameLength];

            for (int i = 0; i < nameLength; i++)
            {
                nameArray[i] = chars[random.Next(chars.Length)];
            }

            string randomName = new string(nameArray);

            return randomName;
        }
    }
}

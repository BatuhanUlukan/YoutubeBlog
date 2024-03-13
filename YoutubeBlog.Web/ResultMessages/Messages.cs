namespace YoutubeBlog.Web.ResultMessages
{
    public static class Messages
    {
        public static class Article
        {
            public static string Add(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla eklenmiştir.";
            }
            public static string Update(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla güncellenmiştir.";
            }
            public static string Delete(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla silinmiştir.";
            }
            public static string UndoDelete(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla geri alınmıştır.";
            }
            public static string Approve(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla onaylanmıştır.";
            }
            public static string Reject(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla reddeilmiştir.";
            }
        }
        public static class Category
        {
            public static string Add(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla eklenmiştir.";
            }
            public static string Update(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla güncellenmiştir.";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla silinmiştir.";
            }
            public static string UndoDelete(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla geri alınmıştır.";
            }
        }
        public static class SmtpSetting
        {

            public static string Update(string smtpName)
            {
                return $"{smtpName} smtp ayarları başarıyla güncellenmiştir.";
            }

        }
        public static class Email
        {

            public static string Sended(string toEmail)
            {
                return $"{toEmail} kişisine email başarıyla gönderilmiştir.";
            }

        }
        public static class Client
        {
            public static string Add(string clientName)
            {
                return $"{clientName} başlıklı refarans başarıyla eklenmiştir.";
            }
            public static string Update(string clientName)
            {
                return $"{clientName} başlıklı refarans başarıyla güncellenmiştir.";
            }
            public static string Delete(string clientName)
            {
                return $"{clientName} başlıklı refarans başarıyla silinmiştir.";
            }
            public static string UndoDelete(string clientName)
            {
                return $"{clientName} başlıklı refarans başarıyla geri alınmıştır.";
            }
        }
        public static class Slider
        {
            public static string Add(string sliderName)
            {
                return $"{sliderName} başlıklı slider başarıyla eklenmiştir.";
            }
            public static string Update(string sliderName)
            {
                return $"{sliderName} başlıklı slider başarıyla güncellenmiştir.";
            }
            public static string Delete(string sliderName)
            {
                return $"{sliderName} başlıklı slider başarıyla silinmiştir.";
            }
            public static string UndoDelete(string sliderName)
            {
                return $"{sliderName} başlıklı slider başarıyla geri alınmıştır.";
            }
        }
        public static class About
        {
            public static string Update(string aboutName)
            {
                return $"{aboutName} başlıklı about başarıyla güncellenmiştir.";
            }
        }
        public static class Fact
        {
            public static string Add(string factName)
            {
                return $"{factName} başlıklı fact başarıyla eklenmiştir.";
            }
            public static string Update(string factName)
            {
                return $"{factName} başlıklı fact başarıyla güncellenmiştir.";
            }
            public static string Delete(string factName)
            {
                return $"{factName} başlıklı fact başarıyla silinmiştir.";
            }
            public static string UndoDelete(string factName)
            {
                return $"{factName} başlıklı fact başarıyla geri alınmıştır.";
            }
        }
        public static class User
        {
            public static string Add(string userName)
            {
                return $"{userName} email adresli kullanıcı başarıyla eklenmiştir.";
            }
            public static string Update(string userName)
            {
                return $"{userName} email adresli kullanıcı başarıyla güncellenmiştir.";
            }
            public static string Delete(string userName)
            {
                return $"{userName} email adresli kullanıcı başarıyla silinmiştir.";
            }
        }
        public static class Portfolio
        {
            public static string Add(string portfolioTitle)
            {
                return $"{portfolioTitle} başlıklı makale başarıyla eklenmiştir.";
            }
            public static string Update(string portfolioTitle)
            {
                return $"{portfolioTitle} başlıklı makale başarıyla güncellenmiştir.";
            }
            public static string Delete(string portfolioTitle)
            {
                return $"{portfolioTitle} başlıklı makale başarıyla silinmiştir.";
            }
            public static string UndoDelete(string portfolioTitle)
            {
                return $"{portfolioTitle} başlıklı makale başarıyla geri alınmıştır.";
            }
        }
        public static class Headquarter

        {
            public static string Add(string headquarterName)
            {
                return $"{headquarterName} başlıklı iletişim alanı başarıyla eklenmiştir.";
            }
            public static string Update(string headquarterName)
            {
                return $"{headquarterName} başlıklı iletişim alanı  başarıyla güncellenmiştir.";
            }
            public static string Delete(string headquarterName)
            {
                return $"{headquarterName} başlıklı iletişim alanı  başarıyla silinmiştir.";
            }
            public static string UndoDelete(string headquarterName)
            {
                return $"{headquarterName} başlıklı iletişim alanı  başarıyla geri alınmıştır.";
            }
        }
        public static class Message

        {
            public static string Add(string messageName)
            {
                return $"{messageName} kişiye ait başarıyla gönderilmiştir.";
            }
            public static string Delete(string messageName)
            {
                return $"{messageName} kişiye ait mesaj  başarıyla silinmiştir.";
            }

        }
        public static class PageSeo

        {
            public static string Update(string pageName)
            {
                return $"{pageName} adlı sayfanın ıcerıgı güncellenmiştir.";
            }

        }

        public static class Logos

        {
            public static string Update(string logoName)
            {
                return $"{logoName} adlı logo güncellenmiştir.";
            }

        }
        public static class Comment

        {
            public static string Add(string commentName)
            {
                return $"{commentName} yorumunuz admin onayına başarıyla gönderilmiştir.";
            }
            public static string Update(string commentName)
            {
                return $"{commentName} kullanıcı adlı kişinin yorumu güncellenmiştir.";
            }
            public static string Approve(string commentName)
            {
                return $"{commentName} kişinin yorumu başarıyla onaylanmıştır.";
            }
            public static string Reject(string commentName)
            {
                return $"{commentName} kişinin yorumu başarıyla reddedilmiştir.";
            }

        }

        public static class Social
        {
            public static string Add(string socialName)
            {
                return $"{socialName} başlıklı sosyal medya başarıyla eklenmiştir.";
            }
            public static string Update(string socialName)
            {
                return $"{socialName} başlıklı sosyal medya başarıyla güncellenmiştir.";
            }
            public static string Delete(string socialName)
            {
                return $"{socialName}  başlıklı sosyal medya başarıyla silinmiştir.";
            }
            public static string UndoDelete(string socialName)
            {
                return $"{socialName} başlıklı sosyal medya başarıyla geri alınmıştır.";
            }
        }

        public static class Duty
        {
            public static string Add(string dutyName)
            {
                return $"{dutyName} isimli servis başarıyla eklenmiştir.";
            }
            public static string Update(string dutyName)
            {
                return $"{dutyName} isimli servis başarıyla güncellenmiştir.";
            }
            public static string Delete(string dutyName)
            {
                return $"{dutyName} isimli servis başarıyla silinmiştir.";
            }
            public static string UndoDelete(string dutyName)
            {
                return $"{dutyName} isimli servis başarıyla silinmiştir.";
            }
        }
    }
}

using WebApplication1.EF;

namespace WebApplication1.Models
{
    public class YabancıTRSarkı
    {
        public void Sarkılarr()
        {
            MusicContext context = new MusicContext();
            context.Sarkı.Add(new Models.Sarkılar
            {
                Id = Guid.NewGuid(),
                Baslik = "Yabancı Şarkılar",
                SarkıAd = "Cupid - Twin ver.",
                Sure = 2.54 ,
                Sarkıcı = "FIFTY FIFTY",
                FotoUrl = "cupid.jfif",
                

            });
            context.Sarkı.Add(new Models.Sarkılar
            {
                Id = Guid.NewGuid(),
                Baslik = "Yabancı Şarkılar",
                SarkıAd = "Borderline",
                Sure = 3.58,
                Sarkıcı = "Tame Impala",
                FotoUrl = "borderline.png",


            });
            context.Sarkı.Add(new Models.Sarkılar
            {
                Id = Guid.NewGuid(),
                Baslik = "Yabancı Şarkılar",
                SarkıAd = "OTONABLUE",
                Sure = 3.06,
                Sarkıcı = "ATARASHI GAKKO!",
                FotoUrl = "otonablue.jpg",


            });
            context.Sarkı.Add(new Models.Sarkılar
            {
                Id = Guid.NewGuid(),
                Baslik = "Yabancı Şarkılar",
                SarkıAd = "Veridis Quo",
                Sure = 5.45,
                Sarkıcı = "Daft Punk",
                FotoUrl = "veridisquo.jfif",


            });
            context.Sarkı.Add(new Models.Sarkılar
            {
                Id = Guid.NewGuid(),
                Baslik = "Yabancı Şarkılar",
                SarkıAd = "Sofia",
                Sure = 3.08,
                Sarkıcı = "Clairo",
                FotoUrl = "sofia.jfif",


            });
            context.Sarkı.Add(new Models.Sarkılar
            {
                Id = Guid.NewGuid(),
                Baslik = "Yabancı Şarkılar",
                SarkıAd = "Lovers Rock",
                Sure = 3.34,
                Sarkıcı = "TV Girl",
                FotoUrl = "loversrock.jfif",


            });
            context.Sarkı.Add(new Models.Sarkılar
            {
                Id = Guid.NewGuid(),
                Baslik = "Yabancı Şarkılar",
                SarkıAd = "Gimme Love",
                Sure = 3.35,
                Sarkıcı = "Joji",
                FotoUrl = "joji.png",


            });
            context.Sarkı.Add(new Models.Sarkılar
            {
                Id = Guid.NewGuid(),
                Baslik = "Türkçe Şarkılar",
                SarkıAd = "Affet",
                Sure = 4.39,
                Sarkıcı = "Müslüm Gürses",
                FotoUrl = "affet.jpg",


            });
            context.Sarkı.Add(new Models.Sarkılar
            {
                Id = Guid.NewGuid(),
                Baslik = "Türkçe Şarkılar",
                SarkıAd = "Aşkın Olayım",
                Sure = 4.11,
                Sarkıcı = "Simge",
                FotoUrl = "askinolayim.jpg",


            });
            context.Sarkı.Add(new Models.Sarkılar
            {
                Id = Guid.NewGuid(),
                Baslik = "Türkçe Şarkılar",
                SarkıAd = "Karam",
                Sure = 3.33,
                Sarkıcı = "Hakan Peker",
                FotoUrl = "karam.jpg",


            });
            context.Sarkı.Add(new Models.Sarkılar
            {
                Id = Guid.NewGuid(),
                Baslik = "Türkçe Şarkılar",
                SarkıAd = "Mesafe",
                Sure = 5.01,
                Sarkıcı = "Serdar Ortaç",
                FotoUrl = "mesafe.jpg",


            });
            context.Sarkı.Add(new Models.Sarkılar
            {
                Id = Guid.NewGuid(),
                Baslik = "Türkçe Şarkılar",
                SarkıAd = "NKBİ",
                Sure = 2.57,
                Sarkıcı = "Güneş",
                FotoUrl = "nkbi.jfif",


            });
            context.Sarkı.Add(new Models.Sarkılar
            {
                Id = Guid.NewGuid(),
                Baslik = "Türkçe Şarkılar",
                SarkıAd = "Ölebilirim",
                Sure = 3.52,
                Sarkıcı = "Pera",
                FotoUrl = "pera.jfif",


            });
            context.Sarkı.Add(new Models.Sarkılar
            {
                Id = Guid.NewGuid(),
                Baslik = "Türkçe Şarkılar",
                SarkıAd = "Unuttun mu Beni",
                Sure = 4.10,
                Sarkıcı = "Sezen Aksu",
                FotoUrl = "sezenaksu.jfif",


            });
            context.SaveChanges();
        }
    }
}

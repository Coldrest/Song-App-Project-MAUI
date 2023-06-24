using WebApplication1.EF;

namespace Veri.Models
{
    public class Uye
    {
        public void Kisi()
        {
            MusicContext context = new MusicContext();
            context.Person.Add(new Models.Kullanıcılar
            {
                Id = Guid.NewGuid(),
                KullanıcıAdi = "enes",
                Sifre = "0359",
                Cinsiyet = "Erkek",
                DogumTarihi = new DateTime(2002,11,24),
            });
            context.SaveChanges();
        }

    }
}

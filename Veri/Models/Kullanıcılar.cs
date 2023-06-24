namespace Veri.Models
{
    public class Kullanıcılar
    {
        public Guid Id { get; set; }
        public string KullanıcıAdi { get; set; }
        public string Sifre { get; set; }
        public string Cinsiyet { get; set; }
        public DateTime DogumTarihi { get; set; }
    }
}

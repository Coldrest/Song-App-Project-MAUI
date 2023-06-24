using Spotify.Model;
using Spotify.Service;

namespace Spotify.Page;

public partial class Profil : ContentPage
{
    private readonly ISarkiService sarkýService;
    public Profil()
    {
        InitializeComponent();
        sarkýService = new SarkiService();
        string ad = Login.ad;
        string sifre = Login.parola;
        kullanýcýAdi.Text = ad;
        Sifre.Text = sifre;
        LoadBilgi();


    }
    private async void LoadBilgi()
    {


        List<KullanýcýM> kullanýcýlar = await sarkýService.GetKullanýcýMs();

        
        KullanýcýM kullanici = kullanýcýlar.FirstOrDefault(k => k.KullanýcýAdi == kullanýcýAdi.Text && k.Sifre == Sifre.Text);

        if (kullanici != null)
        {
            
            string dogum = kullanici.DogumTarihi.ToString("dd/MM/yyyy");
            string cins = kullanici.Cinsiyet;
            
            dogumTarihi.Text = dogum;
            cinsiyet.Text = cins;
        }

    }
    private async void ParolaDegistir(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Page.Parola());

    }
    private async void HesapSil(object sender, EventArgs e)
    {
        List<KullanýcýM> kullanýcýlar = await sarkýService.GetKullanýcýMs();

        KullanýcýM kullanici = kullanýcýlar.FirstOrDefault(k => k.KullanýcýAdi == kullanýcýAdi.Text && k.Sifre == Sifre.Text);

        if (kullanici != null)
        {
            bool confirmed = await DisplayAlert("Onay", "Hesabýnýz Silinsin Mi?", "Evet", "Hay?r");

            if (confirmed)
            {
                await sarkýService.Sil(kullanici.Id);
                Login mainPage = new Login();
                await Navigation.PushModalAsync(new NavigationPage(mainPage) { BarBackgroundColor = Colors.Transparent, BarTextColor = Colors.White });
            }
        }
    }

    private async void geriButton(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}
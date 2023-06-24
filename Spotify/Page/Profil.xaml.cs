using Spotify.Model;
using Spotify.Service;

namespace Spotify.Page;

public partial class Profil : ContentPage
{
    private readonly ISarkiService sark�Service;
    public Profil()
    {
        InitializeComponent();
        sark�Service = new SarkiService();
        string ad = Login.ad;
        string sifre = Login.parola;
        kullan�c�Adi.Text = ad;
        Sifre.Text = sifre;
        LoadBilgi();


    }
    private async void LoadBilgi()
    {


        List<Kullan�c�M> kullan�c�lar = await sark�Service.GetKullan�c�Ms();

        
        Kullan�c�M kullanici = kullan�c�lar.FirstOrDefault(k => k.Kullan�c�Adi == kullan�c�Adi.Text && k.Sifre == Sifre.Text);

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
        List<Kullan�c�M> kullan�c�lar = await sark�Service.GetKullan�c�Ms();

        Kullan�c�M kullanici = kullan�c�lar.FirstOrDefault(k => k.Kullan�c�Adi == kullan�c�Adi.Text && k.Sifre == Sifre.Text);

        if (kullanici != null)
        {
            bool confirmed = await DisplayAlert("Onay", "Hesab�n�z Silinsin Mi?", "Evet", "Hay?r");

            if (confirmed)
            {
                await sark�Service.Sil(kullanici.Id);
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
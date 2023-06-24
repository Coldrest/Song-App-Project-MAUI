using Spotify.Model;
using Spotify.Service;

namespace Spotify;

public partial class Login : ContentPage
{
    private readonly ISarkiService sarkiService;
    public static string ad { get; set; }
    public static string parola { get; set; }

    public Login()
    {
        InitializeComponent();
        sarkiService = new SarkiService();

    }

    private async void GirisYapButton_Clicked(object sender, EventArgs e)
    {
        ad = KullaniciAdiEntry.Text;
        parola = SifreEntry.Text;

        List<Kullan�c�M> kullan�c�lar = await sarkiService.GetKullan�c�Ms();

        Kullan�c�M kullanici = kullan�c�lar.FirstOrDefault(k => k.Kullan�c�Adi == ad && k.Sifre == parola);

        if (kullanici != null)
        {
            await Navigation.PushAsync(new Page.Anasayfa());
        }
        else
        {
            await DisplayAlert("Hata", "Ge�ersiz kullan�c� ad� veya �ifre", "Tamam");
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Page.Kay�t());
    }


}

using Spotify.Model;
using Spotify.Service;

namespace Spotify.Page;

public partial class Parola : ContentPage
{
    private readonly ISarkiService sark�Service;

    public Parola()
    {
        InitializeComponent();

        sark�Service = new SarkiService();
    }
    
    private async void Degistir(object sender, EventArgs e)
    {
        string ad = Login.ad;
        string eskisifre = Login.parola;
        string sifre = SifreEntry.Text;
        if(eskisifre == sifre)
        {
            await DisplayAlert("Hata", "Yeni �ifreniz Eskisiyle Ayn� Olamaz.","Tamam");
            return;
        }

        if (sifre.Length < 4)
        {
            await DisplayAlert("Hata", "�ifre en az 4 karakter olmal�d�r.", "Tamam");
            return;
        }
        List<Kullan�c�M> kullan�c�lar = await sark�Service.GetKullan�c�Ms();
        Kullan�c�M kullanici = kullan�c�lar.FirstOrDefault(k => k.Sifre == eskisifre && k.Kullan�c�Adi == ad);

        if (kullanici != null)
        {
            kullanici.Sifre = sifre; 

            await sark�Service.Guncelle(kullanici);
            await DisplayAlert("Ba�ar�l�", "�ifre de�i�tirme i�lemi ba�ar�yla tamamland�.", "Tamam");
            Login mainPage = new Login();
            await Navigation.PushModalAsync(new NavigationPage(mainPage) { BarBackgroundColor = Colors.Transparent, BarTextColor = Colors.White });
        }
    }

    private async void geriButton(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
using Spotify.Model;
using Spotify.Service;

namespace Spotify.Page;

public partial class Parola : ContentPage
{
    private readonly ISarkiService sarkýService;

    public Parola()
    {
        InitializeComponent();

        sarkýService = new SarkiService();
    }
    
    private async void Degistir(object sender, EventArgs e)
    {
        string ad = Login.ad;
        string eskisifre = Login.parola;
        string sifre = SifreEntry.Text;
        if(eskisifre == sifre)
        {
            await DisplayAlert("Hata", "Yeni Þifreniz Eskisiyle Ayný Olamaz.","Tamam");
            return;
        }

        if (sifre.Length < 4)
        {
            await DisplayAlert("Hata", "Þifre en az 4 karakter olmalýdýr.", "Tamam");
            return;
        }
        List<KullanýcýM> kullanýcýlar = await sarkýService.GetKullanýcýMs();
        KullanýcýM kullanici = kullanýcýlar.FirstOrDefault(k => k.Sifre == eskisifre && k.KullanýcýAdi == ad);

        if (kullanici != null)
        {
            kullanici.Sifre = sifre; 

            await sarkýService.Guncelle(kullanici);
            await DisplayAlert("Baþarýlý", "Þifre deðiþtirme iþlemi baþarýyla tamamlandý.", "Tamam");
            Login mainPage = new Login();
            await Navigation.PushModalAsync(new NavigationPage(mainPage) { BarBackgroundColor = Colors.Transparent, BarTextColor = Colors.White });
        }
    }

    private async void geriButton(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
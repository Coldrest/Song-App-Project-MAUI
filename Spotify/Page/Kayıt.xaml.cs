using Spotify.Model;
using Spotify.Service;

namespace Spotify.Page;

public partial class Kayıt : ContentPage
{
    private readonly ISarkiService _service;
    private bool selectedGender;

    public Kayıt()
    {
        InitializeComponent();
        _service = new SarkiService();


    }

    private async void GirisYap(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Spotify.Login());
    }

    private async void Kayit(object sender, EventArgs e)
    {
        string kullaniciAdi = KullaniciAdiEntry.Text;
        string sifre = SifreEntry.Text;
        string cinsiyet = genderPicker.SelectedItem?.ToString();

        DateTime selectedDate = datePicker.Date;

        if (await _service.KullaniciAdiVarMi(kullaniciAdi))
        {
            await DisplayAlert("Hata", "Kullanıcı adı zaten mevcut.", "Tamam");
            return;
        }

        if (kullaniciAdi.Length < 4)
        {
            await DisplayAlert("Hata", "Kullanıcı adı en az 4 karakter olmalıdır.", "Tamam");
            return;
        }

        if (sifre.Length < 4)
        {
            await DisplayAlert("Hata", "Şifre en az 4 karakter olmalıdır.", "Tamam");
            return;
        }

        KullanıcıM yeniKullanici = new KullanıcıM()
        {
            Id = Guid.NewGuid(),
            KullanıcıAdi = kullaniciAdi,
            Sifre = sifre,
            Cinsiyet = cinsiyet,
            DogumTarihi = selectedDate,
        };

        

            await _service.Ekle(yeniKullanici);
            await Navigation.PushAsync(new Login());
        
    } 

}
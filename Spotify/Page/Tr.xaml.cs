namespace Spotify.Page;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Spotify.Model;
using Spotify.Sarkýlar;
using Spotify.Service;
using System.Collections.ObjectModel;

public partial class Tr : ContentPage
{
    private readonly ISarkiService sarkýService;

    public ObservableCollection<SarkýM> main { get; set; }


    public Tr()
    {
        sarkýService = new SarkiService();
        main = new ObservableCollection<SarkýM>();
        InitializeComponent();
        LoadBilgi();
    }
    private async void LoadBilgi()
    {
        var music = await sarkýService.GetSarkýM();
        main = new ObservableCollection<SarkýM>(music.Where(x => x.Baslik.Contains("Türkçe Þarkýlar")));
        musiccollection.ItemsSource = main;
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        var buton = (Button)sender;
        var sarkýlar = (SarkýM)buton.BindingContext;
        Dictionary<string, Type> songPages = new Dictionary<string, Type>
{
    { "Mesafe", typeof(Sarkýlar.mesafe) },
    { "Ölebilirim", typeof(Sarkýlar.Olebilirim) },
    { "NKBÝ", typeof(Sarkýlar.NKBÝ) },
    { "Karam", typeof(Sarkýlar.Karam) },
    { "Unuttun mu Beni", typeof(Sarkýlar.Sezenaksu) },
    { "Affet", typeof(Sarkýlar.Affet) },
    { "Aþkýn Olayým", typeof(Sarkýlar.Askinolayim) }
};

        if (songPages.ContainsKey(sarkýlar.SarkýAd))
        {
            await Navigation.PushAsync((Page)Activator.CreateInstance(songPages[sarkýlar.SarkýAd]));
        }
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Anasayfa());
    }
    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Yabanci());
    }
    private async void Button_Clicked_3(object sender, EventArgs e)
    {
        Login girisPage = new Login();
        await Navigation.PushModalAsync(new NavigationPage(girisPage) { BarBackgroundColor = Colors.Transparent, BarTextColor = Colors.White });
    }
    private async void Button_Clicked_4(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Profil());
    }
}


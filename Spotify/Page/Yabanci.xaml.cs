namespace Spotify.Page;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Spotify.Model;
using Spotify.Sarkýlar;
using Spotify.Service;
using System.Collections.ObjectModel;

public partial class Yabanci : ContentPage
{
    private readonly ISarkiService sarkýService;

    public ObservableCollection<SarkýM> main { get; set; }


    public Yabanci()
    {
        sarkýService = new SarkiService();
        main = new ObservableCollection<SarkýM>();
        InitializeComponent();
        LoadBilgi();
    }
    private async void LoadBilgi()
    {
        var music = await sarkýService.GetSarkýM();
        main = new ObservableCollection<SarkýM>(music.Where(x => x.Baslik.Contains("Yabancý Þarkýlar")));
        musiccollection.ItemsSource = main;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var buton = (Button)sender;
        var sarkýlar = (SarkýM)buton.BindingContext;
        Dictionary<string, Type> songPages = new Dictionary<string, Type>
{
    { "Lovers Rock", typeof(Sarkýlar.LoversRock) },
    { "Cupid - Twin ver.", typeof(Sarkýlar.Cupid) },
    { "Borderline", typeof(Sarkýlar.Borderline) },
    { "Veridis Quo", typeof(Sarkýlar.Veridisquo) },
    { "Sofia", typeof(Sarkýlar.Sofia) },
    { "Gimme Love", typeof(Sarkýlar.Joji) },
    { "OTONABLUE", typeof(Sarkýlar.Otonablue) },
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
        await Navigation.PushAsync(new Tr());
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
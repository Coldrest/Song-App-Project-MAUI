namespace Spotify.Page;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Spotify.Model;
using Spotify.Sark�lar;
using Spotify.Service;
using System.Collections.ObjectModel;

public partial class Yabanci : ContentPage
{
    private readonly ISarkiService sark�Service;

    public ObservableCollection<Sark�M> main { get; set; }


    public Yabanci()
    {
        sark�Service = new SarkiService();
        main = new ObservableCollection<Sark�M>();
        InitializeComponent();
        LoadBilgi();
    }
    private async void LoadBilgi()
    {
        var music = await sark�Service.GetSark�M();
        main = new ObservableCollection<Sark�M>(music.Where(x => x.Baslik.Contains("Yabanc� �ark�lar")));
        musiccollection.ItemsSource = main;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var buton = (Button)sender;
        var sark�lar = (Sark�M)buton.BindingContext;
        Dictionary<string, Type> songPages = new Dictionary<string, Type>
{
    { "Lovers Rock", typeof(Sark�lar.LoversRock) },
    { "Cupid - Twin ver.", typeof(Sark�lar.Cupid) },
    { "Borderline", typeof(Sark�lar.Borderline) },
    { "Veridis Quo", typeof(Sark�lar.Veridisquo) },
    { "Sofia", typeof(Sark�lar.Sofia) },
    { "Gimme Love", typeof(Sark�lar.Joji) },
    { "OTONABLUE", typeof(Sark�lar.Otonablue) },
};

        if (songPages.ContainsKey(sark�lar.Sark�Ad))
        {
            await Navigation.PushAsync((Page)Activator.CreateInstance(songPages[sark�lar.Sark�Ad]));
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
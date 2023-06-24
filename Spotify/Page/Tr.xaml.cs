namespace Spotify.Page;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Spotify.Model;
using Spotify.Sark�lar;
using Spotify.Service;
using System.Collections.ObjectModel;

public partial class Tr : ContentPage
{
    private readonly ISarkiService sark�Service;

    public ObservableCollection<Sark�M> main { get; set; }


    public Tr()
    {
        sark�Service = new SarkiService();
        main = new ObservableCollection<Sark�M>();
        InitializeComponent();
        LoadBilgi();
    }
    private async void LoadBilgi()
    {
        var music = await sark�Service.GetSark�M();
        main = new ObservableCollection<Sark�M>(music.Where(x => x.Baslik.Contains("T�rk�e �ark�lar")));
        musiccollection.ItemsSource = main;
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        var buton = (Button)sender;
        var sark�lar = (Sark�M)buton.BindingContext;
        Dictionary<string, Type> songPages = new Dictionary<string, Type>
{
    { "Mesafe", typeof(Sark�lar.mesafe) },
    { "�lebilirim", typeof(Sark�lar.Olebilirim) },
    { "NKB�", typeof(Sark�lar.NKB�) },
    { "Karam", typeof(Sark�lar.Karam) },
    { "Unuttun mu Beni", typeof(Sark�lar.Sezenaksu) },
    { "Affet", typeof(Sark�lar.Affet) },
    { "A�k�n Olay�m", typeof(Sark�lar.Askinolayim) }
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


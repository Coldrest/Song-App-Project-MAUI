using Plugin.Maui.Audio;
using Spotify.Model;
using Spotify.Service;
using System.Collections.ObjectModel;

namespace Spotify.Sarkılar;

public partial class Borderline : ContentPage
{
    private readonly ISarkiService sarkıService;

    public ObservableCollection<SarkıM> main { get; set; }
    public Borderline()
    {
        sarkıService = new SarkiService();
        main = new ObservableCollection<SarkıM>();
        InitializeComponent();
        LoadBilgi();


    }
    private async void LoadBilgi()
    {
        var music = await sarkıService.GetSarkıM();
        main = new ObservableCollection<SarkıM>(music.Where(x => x.SarkıAd.Contains("Borderline")));
        musiccollection.ItemsSource = main;
    }
    private AudioPlayer audioPlayer;

    private async void PlayButtonClicked(object sender, EventArgs e)
    {
        var audioFile = await FileSystem.OpenAppPackageFileAsync("Sound/borderline2.mp3");
        audioPlayer = (AudioPlayer)AudioManager.Current.CreatePlayer(audioFile);
        audioPlayer.Play();
    }

    private void StopButtonClicked(object sender, EventArgs e)
    {
        if (audioPlayer != null)
        {
            audioPlayer.Stop();
        }
    }
}
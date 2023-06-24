using Spotify.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Spotify.Service
{
    internal interface ISarkiService
    {
        Task<List<SarkıM>> GetSarkıM();
        Task<List<KullanıcıM>> GetKullanıcıMs();
        Task Ekle(KullanıcıM kullanıcılarM);
        Task Guncelle(KullanıcıM kullanıcılarM);
        Task Sil(Guid kullanıcıId);

        Task<bool> KullaniciAdiVarMi(string kullaniciAdi);
    }
    public class UrlHelper
    {
        public static string BaseAddress =
            DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7000" : "https://localhost:7000";

        public static string SarkıUrl = $"{BaseAddress}/şarkılar";
        public static string KullanıcıUrl = $"{BaseAddress}/kullanıcılar";

    }
    public class SarkiService : ISarkiService
    {

        HttpClient httpClient;
        JsonSerializerOptions jsonSerializerOptions;
        public SarkiService()
        {
            httpClient = new HttpClient();

            jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

        }

        public async Task Ekle(KullanıcıM kullanıcılarM)
        {
            var json = JsonSerializer.Serialize(kullanıcılarM);

            JsonContent jsonContent = JsonContent.Create(kullanıcılarM);
            var response = await httpClient.PostAsync(UrlHelper.KullanıcıUrl, jsonContent);
            if (response.IsSuccessStatusCode)
            {

            }
        }
        public async Task Guncelle(KullanıcıM kullanıcılarM)
        {
            var jsonContent = JsonContent.Create(kullanıcılarM);
            var response = await httpClient.PostAsync(UrlHelper.KullanıcıUrl + "/guncelle", jsonContent);

        }
        public async Task<List<SarkıM>> GetSarkiM()
        {
            var sonuc = await httpClient.GetFromJsonAsync<List<SarkıM>>(UrlHelper.SarkıUrl);

            return sonuc;
        }
        public async Task<List<KullanıcıM>> GetKullanıcıMs()
        {
            var kullanıcıGetir = await httpClient.GetFromJsonAsync<List<KullanıcıM>>(UrlHelper.KullanıcıUrl);
            return kullanıcıGetir;
        }
        
        public async Task<List<SarkıM>> GetSarkıM()
        {

            var sonuc = await httpClient.GetFromJsonAsync<List<SarkıM>>(UrlHelper.SarkıUrl);

            return sonuc;
            throw new NotImplementedException();
        }



        public async Task Sil(Guid kullanıcıId)
        {

            var url = UrlHelper.KullanıcıUrl + $"/{kullanıcıId}";
            await httpClient.DeleteAsync(url);
        }

        public async Task<bool> KullaniciAdiVarMi(string kullaniciAdi)
        {
            var kullanıcılar = await httpClient.GetFromJsonAsync<List<KullanıcıM>>(UrlHelper.KullanıcıUrl);
            return kullanıcılar.Any(k => k.KullanıcıAdi == kullaniciAdi);
        }
    }
}
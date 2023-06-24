using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Veri.Models;
using WebApplication1.EF;
using WebApplication1.Models;

namespace Veri
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.MapGet("/�ark�lar", () =>
            {
                MusicContext context = new MusicContext();
                return context.Sark�.ToList();
            });
            app.MapGet("/kullan�c�lar", () =>
            {
                MusicContext context1 = new MusicContext();
                return context1.Person.ToList();
            });
            app.MapDelete("/kullan�c�lar/{id}", (string id) =>
            {
                MusicContext context = new MusicContext();
                var silinecek = context.Person.FirstOrDefault(x => x.Id == Guid.Parse(id));
                if (silinecek != null)
                {
                    context.Person.Remove(silinecek);
                    context.SaveChanges();
                }
            });
            app.MapPost("/kullan�c�lar", (Kullan�c�lar kullan�c�lar) =>
            {
                MusicContext context = new MusicContext();
                context.Person.Add(kullan�c�lar);
                context.SaveChanges();
            });

            app.MapPost("/kullan�c�lar/guncelle", (Kullan�c�lar kullan�c�lar) =>
            {
                MusicContext context = new MusicContext();
                var guncellenecek = context.Person.Find(kullan�c�lar.Id);
                guncellenecek.Sifre = kullan�c�lar.Sifre;
                context.SaveChanges();
            });
            app.Run();
        }
    }
}
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

            app.MapGet("/þarkýlar", () =>
            {
                MusicContext context = new MusicContext();
                return context.Sarký.ToList();
            });
            app.MapGet("/kullanýcýlar", () =>
            {
                MusicContext context1 = new MusicContext();
                return context1.Person.ToList();
            });
            app.MapDelete("/kullanýcýlar/{id}", (string id) =>
            {
                MusicContext context = new MusicContext();
                var silinecek = context.Person.FirstOrDefault(x => x.Id == Guid.Parse(id));
                if (silinecek != null)
                {
                    context.Person.Remove(silinecek);
                    context.SaveChanges();
                }
            });
            app.MapPost("/kullanýcýlar", (Kullanýcýlar kullanýcýlar) =>
            {
                MusicContext context = new MusicContext();
                context.Person.Add(kullanýcýlar);
                context.SaveChanges();
            });

            app.MapPost("/kullanýcýlar/guncelle", (Kullanýcýlar kullanýcýlar) =>
            {
                MusicContext context = new MusicContext();
                var guncellenecek = context.Person.Find(kullanýcýlar.Id);
                guncellenecek.Sifre = kullanýcýlar.Sifre;
                context.SaveChanges();
            });
            app.Run();
        }
    }
}
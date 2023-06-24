using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Veri.Models;
using WebApplication1.Models;

namespace WebApplication1.EF
{
    public class MusicContext : DbContext
    {
        public DbSet<Sarkılar> Sarkı { get; set; }
        public DbSet<Kullanıcılar> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=Test;User Id=enes;Password=0359;TrustServerCertificate=true");
        }
    }
}

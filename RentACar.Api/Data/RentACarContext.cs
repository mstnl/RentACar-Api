using Microsoft.EntityFrameworkCore;
using RentACarAPI.Models;

namespace RentACarAPI.Data
{
    public class RentACarContext : DbContext
    {
        public RentACarContext(DbContextOptions<RentACarContext> options) : base(options)
        {
        }

        public DbSet<Arac> Araclar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Rezervasyon> Rezervasyonlar { get; set; }
    }
}

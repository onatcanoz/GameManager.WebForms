using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Contexts
{
    public class OyunYoneticisiContext : DbContext
    {
        public DbSet<Oyun> Oyunlar { get; set; }
        public DbSet<OyunTur> OyunlarTurler { get; set; }
        public DbSet<Tur> Turler { get; set; }
        public DbSet<Yapimci> Yapimcilar { get; set; }
        public DbSet<Ulke> Ulkeler { get; set; }

        public OyunYoneticisiContext() : base("OyunYoneticisiContext")  // app.configin altındakı bu db'yi kullan.
        {
            //this.Configuration.LazyLoadingEnabled = false; //bununla lazyloading'i devre dışı bırakabiliriz.
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Oyun>().ToTable("Oyunlar");
            modelBuilder.Entity<OyunTur>().ToTable("OyunlarTurler");
            modelBuilder.Entity<Tur>().ToTable("Turler");
            modelBuilder.Entity<Yapimci>().ToTable("Yapimcilar");
            modelBuilder.Entity<Ulke>().ToTable("Ulkeler");
        }
    }
}

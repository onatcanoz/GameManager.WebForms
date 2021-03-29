using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Backend.EntityModel
{
    public partial class OyunlarContext : DbContext
    {
        public OyunlarContext()
            : base("name=OyunlarContext")
        {
        }

        public virtual DbSet<Oyunlar> Oyunlar { get; set; }
        public virtual DbSet<OyunlarTurler> OyunlarTurler { get; set; }
        public virtual DbSet<Turler> Turler { get; set; }
        public virtual DbSet<Ulkeler> Ulkeler { get; set; }
        public virtual DbSet<Yapimcilar> Yapimcilar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Oyunlar>()
                .Property(e => e.Adi)
                .IsUnicode(false);

            modelBuilder.Entity<Oyunlar>()
                .HasMany(e => e.OyunlarTurler)
                .WithRequired(e => e.Oyunlar)
                .HasForeignKey(e => e.OyunId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Turler>()
                .Property(e => e.Adi)
                .IsUnicode(false);

            modelBuilder.Entity<Turler>()
                .HasMany(e => e.OyunlarTurler)
                .WithRequired(e => e.Turler)
                .HasForeignKey(e => e.TurId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ulkeler>()
                .Property(e => e.Adi)
                .IsUnicode(false);

            modelBuilder.Entity<Ulkeler>()
                .HasMany(e => e.Yapimcilar)
                .WithRequired(e => e.Ulkeler)
                .HasForeignKey(e => e.UlkeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Yapimcilar>()
                .Property(e => e.Adi)
                .IsUnicode(false);

            modelBuilder.Entity<Yapimcilar>()
                .HasMany(e => e.Oyunlar)
                .WithOptional(e => e.Yapimcilar)
                .HasForeignKey(e => e.YapimciId);
        }
    }
}

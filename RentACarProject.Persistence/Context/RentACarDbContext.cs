using Microsoft.EntityFrameworkCore;
using RentACarProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.Context
{
    public class RentACarDbContext : DbContext
    {
        public DbSet<Arac> Araclar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<Sube> Subeler { get; set; }
        public DbSet<KullaniciSiparis> KullaniciSiparis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rentCar;Integrated Security=True;";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connStr);
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            modelBuilder.Entity<KullaniciSiparis>().HasKey(i => new { i.SiparisId, i.KullaniciId });
            modelBuilder.Entity<KullaniciSiparis>().HasOne(i => i.Siparis).WithMany(i => i.KullaniciSiparis).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<KullaniciSiparis>().HasOne(i => i.Kullanici).WithMany(i => i.KullaniciSiparis).OnDelete(DeleteBehavior.Restrict);

        }
    }
}

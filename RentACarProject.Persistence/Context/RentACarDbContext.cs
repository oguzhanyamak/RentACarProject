using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentACarProject.Domain.Entites;
using RentACarProject.Domain.Entites.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.Context
{
    public class RentACarDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public RentACarDbContext(DbContextOptions<RentACarDbContext> options):base(options)
        {
        }

        public DbSet<Arac> Araclar { get; set; }
        public DbSet<UserBio> UserBios { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<Sube> Subeler { get; set; }
        public DbSet<KullaniciSiparis> KullaniciSiparis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            modelBuilder.Entity<KullaniciSiparis>().HasKey(i => new { i.SiparisId, i.KullaniciId });
            modelBuilder.Entity<KullaniciSiparis>().HasOne(i => i.Siparis).WithMany(i => i.KullaniciSiparis).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<KullaniciSiparis>().HasOne(i => i.AppUser).WithMany(i => i.KullaniciSiparis).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AppUser>().HasOne(i => i.UserBio).WithOne(i => i.AppUser).HasForeignKey<UserBio>(i => i.AppUserId);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rentCar;Integrated Security=True;");
        }
    }
}

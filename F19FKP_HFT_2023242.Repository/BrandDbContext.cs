using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Humanizer.In;
using F19FKP_HFT_2023242.Models;

namespace F19FKP_HFT_2023242.Repository
{
    internal class BrandDbContext : DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Repair> Repairs { get; set; }

        public BrandDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase("Brand");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(car => car
            .HasOne(c => c.Brand)
            .WithMany(brand => brand.Cars)
            .HasForeignKey(c => c.BrandId)
            .OnDelete(DeleteBehavior.Cascade)); //delete all associated cars when a brand is deleted

            modelBuilder.Entity<Repair>(repair => repair
            .HasOne(r => r.Car)
            .WithMany(c => c.Repairs)
            .HasForeignKey(r => r.CarId)
            .OnDelete(DeleteBehavior.Cascade)); //delete all associated repairs when a car is deleted
        
        
            
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F19FKP_HFT_2023242.Models;
using System.Threading;

namespace F19FKP_HFT_2023242.Repository
{
    public class BrandDbContext : DbContext
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


            var brands = new List<Brand>();

            brands.Add(new Brand() { BrandId = 1, Name = "Toyota", CountryOfOrigin = "Japan" });
            brands.Add(new Brand() { BrandId = 2, Name = "Volkswagen", CountryOfOrigin = "Germany" });
            brands.Add(new Brand() { BrandId = 3, Name = "Ford", CountryOfOrigin = "United States" });
            brands.Add(new Brand() { BrandId = 4, Name = "Honda", CountryOfOrigin = "Japan" });


            var cars = new List<Car>();

            cars.Add(new Car() { CarId = 1, Name = "Supra", BrandId = 1, Color = "Red", WheelDrive = "RWD" });
            cars.Add(new Car() { CarId = 2, Name = "Corolla", BrandId = 1, Color = "Blue", WheelDrive = "FWD" });
            cars.Add(new Car() { CarId = 3, Name = "Rav4", BrandId = 1, Color = "Silver", WheelDrive = "AWD" });

            cars.Add(new Car() { CarId = 4, Name = "Golf", BrandId = 2, Color = "Black", WheelDrive = "FWD" });
            cars.Add(new Car() { CarId = 5, Name = "Passat", BrandId = 2, Color = "White", WheelDrive = "FWD" });
            cars.Add(new Car() { CarId = 6, Name = "Tiguan", BrandId = 2, Color = "Gray", WheelDrive = "AWD" });

            cars.Add(new Car() { CarId = 7, Name = "F-150", BrandId = 3, Color = "Blue", WheelDrive = "4WD" });
            cars.Add(new Car() { CarId = 8, Name = "Mustang", BrandId = 3, Color = "Yellow", WheelDrive = "RWD" });

            cars.Add(new Car() { CarId = 9, Name = "Civic", BrandId = 4, Color = "Red", WheelDrive = "FWD" });
            cars.Add(new Car() { CarId = 10, Name = "CR-V", BrandId = 4, Color = "Green", WheelDrive = "AWD" });



            var repairs = new List<Repair>();

            repairs.Add(new Repair() { RepairId = 1, Date = new DateTime(2023, 1, 15), Description = "Oil Change", Cost = 50.00, CarId = 1 });

            repairs.Add(new Repair() { RepairId = 2, Date = new DateTime(2023, 6, 20), Description = "Brake Pad Replacement", Cost = 150.00, CarId = 2 });
            repairs.Add(new Repair() { RepairId = 3, Date = new DateTime(2023, 3, 10), Description = "Tire Rotation", Cost = 30.00, CarId = 2 });

            repairs.Add(new Repair() { RepairId = 4, Date = new DateTime(2023, 8, 5), Description = "Battery Replacement", Cost = 100.00, CarId = 3 });
            repairs.Add(new Repair() { RepairId = 5, Date = new DateTime(2023, 1, 18), Description = "Air Filter Replacement", Cost = 20.00, CarId = 3 });
            repairs.Add(new Repair() { RepairId = 6, Date = new DateTime(2023, 10, 22), Description = "Spark Plug Change", Cost = 50.00, CarId = 3 });

            repairs.Add(new Repair() { RepairId = 7, Date = new DateTime(2023, 4, 18), Description = "Engine Tune-Up", Cost = 20.00, CarId = 4 });
            repairs.Add(new Repair() { RepairId = 8, Date = new DateTime(2023, 5, 2), Description = "Coolant Flush", Cost = 50.00, CarId = 4 });

            repairs.Add(new Repair() { RepairId = 9, Date = new DateTime(2023, 2, 12), Description = "Transmission Fluid Change", Cost = 20.00, CarId = 5 });
            repairs.Add(new Repair() { RepairId = 10, Date = new DateTime(2023, 3, 1), Description = "Wheel Alignment", Cost = 50.00, CarId = 5 });

            repairs.Add(new Repair() { RepairId = 11, Date = new DateTime(2023, 4, 11), Description = "Brake Fluid Flush", Cost = 20.00, CarId = 6 });
            repairs.Add(new Repair() { RepairId = 12, Date = new DateTime(2023, 6, 5), Description = "Timing Belt Replacement", Cost = 50.00, CarId = 6 });

            repairs.Add(new Repair() { RepairId = 13, Date = new DateTime(2023, 7, 15), Description = "Suspension Repair", Cost = 20.00, CarId = 7 });
            repairs.Add(new Repair() { RepairId = 14, Date = new DateTime(2023, 9, 28), Description = "Exhaust System Repair", Cost = 50.00, CarId = 7 });

            repairs.Add(new Repair() { RepairId = 15, Date = new DateTime(2023, 10, 20), Description = "Wheel Bearing Replacement", Cost = 20.00, CarId = 8 });
            repairs.Add(new Repair() { RepairId = 16, Date = new DateTime(2023, 11, 23), Description = "Fuel Injector Cleaning", Cost = 50.00, CarId = 8 });

            repairs.Add(new Repair() { RepairId = 17, Date = new DateTime(2023, 2, 26), Description = "Ignition Coil Replacement", Cost = 20.00, CarId = 9 });
            repairs.Add(new Repair() { RepairId = 18, Date = new DateTime(2023, 6, 19), Description = "Power Steering Fluid Flush", Cost = 50.00, CarId = 9 });

            repairs.Add(new Repair() { RepairId = 19, Date = new DateTime(2023, 3, 18), Description = "Serpentine Belt Replacement", Cost = 20.00, CarId = 10 });
            repairs.Add(new Repair() { RepairId = 20, Date = new DateTime(2023, 8, 12), Description = "Headlight Bulb Replacement", Cost = 50.00, CarId = 10 });


            modelBuilder.Entity<Brand>().HasData(brands);
            modelBuilder.Entity<Car>().HasData(cars);
            modelBuilder.Entity<Repair>().HasData(repairs);

            base.OnModelCreating(modelBuilder);
        }
    }
}

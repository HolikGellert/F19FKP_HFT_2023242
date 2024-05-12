using F19FKP_HFT_2023242.Logic.Interfaces;
using F19FKP_HFT_2023242.Models;
using F19FKP_HFT_2023242.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace F19FKP_HFT_2023242.Logic
{
    public class BrandLogic : IBrandLogic
    {
        IRepository<Brand> repository;

        public BrandLogic(IRepository<Brand> repository)
        {
            this.repository = repository;
        }

        public void Create(Brand brand)
        {
            if (brand.Name.Length > 99 || brand.Name.Length < 0)
            {
                throw new ArgumentException();
            }

            if (brand.CountryOfOrigin == null || brand.CountryOfOrigin == "")
            {
                throw new Exception();
            }

            if (brand.Name == null || brand.Name == "")
            {
                throw new Exception();
            }
            this.repository.Create(brand);
        }

        public void Delete(int id)
        {
            if (repository.Read(id) == null)
            {
                throw new Exception();
            }
            this.repository.Delete(id);
        }

        public Brand Read(int id)
        {
            return this.repository.Read(id);
        }

        public IQueryable<Brand> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Brand brand)
        {
            this.repository.Update(brand);
        }




        public IQueryable<Repair> RepairsFromYear(int year)
        {
            var repairlist = from brand in repository.ReadAll()
                           from car in brand.Cars
                           from repair in car.Repairs
                           where repair.Date.Substring(0, Math.Min(repair.Date.Length, 4)) == year.ToString()
                           select repair;
            return repairlist;
        }

        public IQueryable<Car> AllCarsFromBrand(string brandName)
        {
            var cars = from brand in repository.ReadAll()
                         where brand.Name == brandName
                         from car in brand.Cars
                         select car;
            return cars;
        }

        public IQueryable<Car> CarsByColor(string color)
        {
            var cars = from brand in repository.ReadAll()
                       from car in brand.Cars
                       where string.Equals(car.Color, color, StringComparison.OrdinalIgnoreCase)
                       select car;
            return cars;
        }

        public Repair MostExpensiveRepair()
        {
            var mostExpensiveRepairs = from brand in repository.ReadAll()
                                from car in brand.Cars
                                from repair in car.Repairs
                                orderby repair.Cost descending
                                select repair; 
            return mostExpensiveRepairs.FirstOrDefault();
        }

        public IQueryable<Car> SameWheelDriveCars(string wheelDriveName)
        {
            var sameWD = from brand in repository.ReadAll()
                                     from car in brand.Cars
                                     where string.Equals(
                                         car.WheelDrive,
                                         wheelDriveName,
                                         StringComparison.OrdinalIgnoreCase)
                                     select car;
            return sameWD;
        }
    }
}

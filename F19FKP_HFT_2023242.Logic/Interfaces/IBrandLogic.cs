using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using F19FKP_HFT_2023242.Models;

namespace F19FKP_HFT_2023242.Logic.Interfaces
{
    public interface IBrandLogic
    {
        void Create(Brand item);
        Brand Read(int id);
        void Update(Brand brand);
        void Delete(int id);
        IQueryable<Brand> ReadAll();

        public IQueryable<Repair> RepairsFromYear(int year);
        public IQueryable<Car> AllCarsFromBrand(string brandName);
        public IQueryable<Car> CarsByColor(string color);
        public Repair MostExpensiveRepair();
        public IQueryable<Car> SameWheelDriveCars(string wheelDriveName);
    }
}

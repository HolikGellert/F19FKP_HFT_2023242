﻿using F19FKP_HFT_2023242.Logic;
using F19FKP_HFT_2023242.Repository;
using F19FKP_HFT_2023242.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace F19FKP_HFT_2023242.Test
{
    [TestFixture]
    public class Tests
    {
        BrandLogic brandLogic;
        CarLogic carLogic;
        RepairLogic repairLogic;
        Mock<IRepository<Brand>> mockBrandRepository;
        Mock<IRepository<Car>> mockCarRepository;
        Mock<IRepository<Repair>> mockRepairRepository;
        Brand brand;
        Car car;
        Repair repair;

        [SetUp]
        public void Setup()
        {
            mockBrandRepository = new Mock<IRepository<Brand>>();
            mockCarRepository = new Mock<IRepository<Car>>();
            mockRepairRepository = new Mock<IRepository<Repair>>();

            brand = new Brand();
            brand.Name = "Nissan";
            brand.CountryOfOrigin = "Japan";
            brand.Cars = new List<Car>();

            car = new Car();
            car.Name = "Skyline";
            car.Color = "Blue";
            car.WheelDrive = "4WD";
            car.Repairs = new List<Repair>();
            car.BrandId = 2;

            repair = new Repair();
            repair.Date = new DateTime(2018, 11, 21);
            repair.Description = "New rear wheels";
            repair.Cost = 10000;
            repair.CarId = 2;

            repair.Car = car;
            car.Repairs.Add(repair);
            brand.Cars.Add(car);

            Car car2 = new Car();
            car2.Name = "Altima";
            car2.Color = "Green";
            car2.WheelDrive = "FWD";
            car2.Repairs = new List<Repair>();
            car2.BrandId = 4;

            Brand brand2 = new Brand();
            brand2.Name = "Mazda";
            brand2.CountryOfOrigin = "Japan";
            brand2.Cars = new List<Car>();

            Repair repair2 = new Repair();
            repair2.Date = new DateTime(2020, 01, 22);
            repair2.Description = "Engine fine tuning";
            repair2.Cost = 5500;
            repair2.CarId = 1;

            repair2.Car = car2;
            car2.Repairs.Add(repair2);
            brand2.Cars.Add(car2);

            List<Car> cars = new List<Car> { car, car2 };
            List<Brand> bakeries = new List<Brand> { brand, brand2 };
            List<Repair> repairs = new List<Repair> { repair, repair2 };

            mockCarRepository.Setup(w => w.ReadAll()).Returns(cars.AsQueryable);
            mockBrandRepository.Setup(w => w.ReadAll()).Returns(bakeries.AsQueryable);
            mockRepairRepository.Setup(b => b.ReadAll()).Returns(repairs.AsQueryable);

            carLogic = new CarLogic(mockCarRepository.Object);
            brandLogic = new BrandLogic(mockBrandRepository.Object);
            repairLogic = new RepairLogic(mockRepairRepository.Object);
        }

        //Create tests
        [Test]
        public void BrandCreateTest()
        {
            Brand testbrand = new Brand() { BrandId = 1, Name = "Mercedes", CountryOfOrigin = "Germany" };
            brandLogic.Create(testbrand);
            mockBrandRepository.Verify(w => w.Create(testbrand), Times.Once);
            Assert.IsNotNull(testbrand);
        }
        [Test]
        public void CarCreateTest()
        {
            Car testcar = new Car() { CarId = 1, Name = "GLC SUV", Color="White", WheelDrive="AWD" };
            carLogic.Create(testcar);
            mockCarRepository.Verify(w => w.Create(testcar), Times.Once);
            Assert.IsNotNull(testcar);
        }
        [Test]
        public void RepairCreateTest()
        {
            Repair testrepair = new Repair() { Date = new DateTime(2021,11,21), Cost=1000, Description="New engine block" };
            repairLogic.Create(testrepair);
            mockRepairRepository.Verify(w => w.Create(testrepair), Times.Once);
            Assert.IsNotNull(testrepair);
        }
    }
}

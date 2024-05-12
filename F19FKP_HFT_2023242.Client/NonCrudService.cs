using F19FKP_HFT_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace F19FKP_HFT_2023242.Client
{
    class NonCrudService
    {
        private RestService restService;

        public NonCrudService(RestService restService)
        {
            this.restService = restService;
        }

        public void RepairsFromYear()
        {
            try
            {
                Console.WriteLine("Please enter a year:");
                string year = Console.ReadLine();
                var items = restService.Get<Repair>($"/NonCrud/RepairsFromYear/{year}");
                foreach (var item in items)
                {
                    Console.WriteLine(item.Date.ToString() + "\t" + item.Description);
                }
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Error! Invalid year!");
            }
            Console.WriteLine("\nPress any button to return");
            Console.ReadKey();
        }
        public void AllCarsFromBrand()
        {
            try
            {
                Console.WriteLine("Please enter a brand from the following list:\n" +
                    "[Toyota, Volkswagen, Honda, Ford]");
                string brand = Console.ReadLine();
                var items = restService.Get<Car>($"/NonCrud/AllCarsFromBrand/{brand}");
                foreach (var item in items)
                {
                    Console.WriteLine(item.Brand + "\t" + item.Name + "\t" + item.Color);
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Error! Brand not found!");
            }
            Console.WriteLine("\nPress any button to return");
            Console.ReadKey();
        }
        public void CarsByColor()
        {
            try
            {
                Console.WriteLine("Please enter a color:");
                string color = Console.ReadLine();
                var items = restService.Get<Car>($"/NonCrud/CarsByColor/{color}");
                foreach (var item in items)
                {
                    Console.WriteLine(item.Brand + "\t" + item.Name + "\t" + item.Color);
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Error! Color not found!");
            }
            Console.WriteLine("\nPress any button to return");
            Console.ReadKey();
        }
        public void MostExpensiveRepairFromBrand()
        {
            try
            {
                Console.WriteLine("Please enter a brand from the following list:\n" +
                    "[Toyota, Volkswagen, Honda, Ford]");
                string brand = Console.ReadLine();
                var items = restService.Get<Car>($"/NonCrud/MostExpensiveRepairFromBrand/{brand}");
                foreach (var item in items)
                {
                    Console.WriteLine(item.Brand + "\t" + item.Name + "\t" + item.Color);
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Error! Brand not found!");
            }
            Console.WriteLine("\nPress any button to return");
            Console.ReadKey();
        }
        public void SameWheelDriveCars()
        {
            try
            {
                Console.WriteLine("Please enter a wheel drive option from the following list:\n" +
                    "[AWD, 4WD, FWD, RWD]");
                string wd = Console.ReadLine();
                var items = restService.Get<Car>($"/NonCrud/SameWheelDriveCars/{wd}");
                foreach (var item in items)
                {
                    Console.WriteLine(item.Brand + "\t" + item.Name + "\t" + item.Color + "\t" + item.WheelDrive);
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Error! Wheel Drive not found!");
            }
            Console.WriteLine("\nPress any button to return");
            Console.ReadKey();
        }
    }
}
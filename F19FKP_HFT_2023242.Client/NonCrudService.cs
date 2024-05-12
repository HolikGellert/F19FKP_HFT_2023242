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
                int year = Int32.Parse(Console.ReadLine());
                var items = restService.Get<Repair>($"/NonCrud/RepairsFromYear/{year}");
                foreach (var item in items)
                {
                    Console.WriteLine(item.Date + "\t" + item.Description);
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
                    Console.WriteLine(brand.ToString()+ "\t" + item.Name + "\t" + item.Color);
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
        public void MostExpensiveRepair()
        {
            try
            {
                Console.WriteLine("Most expensive repair in the brand:");
                var item = restService.GetSingle<Repair>($"/NonCrud/MostExpensiveRepair/");
                Console.WriteLine("Repair: " + item.RepairId + "\t" + item.Cost + "\t" + item.Description);
            }
            catch (Exception)
            {
                Console.WriteLine("Error!");
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
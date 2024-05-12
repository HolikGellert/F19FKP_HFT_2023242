using F19FKP_HFT_2023242.Logic.Interfaces;
using F19FKP_HFT_2023242.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace F19FKP_HFT_2023242.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    public class NonCrudController : ControllerBase
    {
        IBrandLogic logic;

        [HttpGet]
        public IQueryable<Repair> RepairsFromYear(int year)
        {
            return logic.RepairsFromYear(year);
        }
        [HttpGet]
        public IQueryable<Car> AllCarsFromBrand(string brandName)
        {
            return logic.AllCarsFromBrand(brandName);
        }
        [HttpGet]
        public IQueryable<Car> CarsByColor(string color)
        {
            return logic.CarsByColor(color);
        }
        [HttpGet]
        public Repair MostExpensiveRepairFromBrand(string brandName)
        {
            return logic.MostExpensiveRepairFromBrand(brandName);
        }
        [HttpGet]
        public IQueryable<Car> SameWheelDriveCars(string wheelDriveName)
        {
            return logic.SameWheelDriveCars(wheelDriveName);
        }

    }
}

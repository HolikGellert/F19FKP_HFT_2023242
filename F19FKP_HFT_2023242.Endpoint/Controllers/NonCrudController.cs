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

        public NonCrudController(IBrandLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet("{year}")]
        public IQueryable<Repair> RepairsFromYear(int year)
        {
            return logic.RepairsFromYear(year);
        }
        [HttpGet("{brandName}")]
        public IQueryable<Car> AllCarsFromBrand(string brandName)
        {
            return logic.AllCarsFromBrand(brandName);
        }
        [HttpGet("{color}")]
        public IQueryable<Car> CarsByColor(string color)
        {
            return logic.CarsByColor(color);
        }
        [HttpGet("{brandName}")]
        public Repair MostExpensiveRepairFromBrand(string brandName)
        {
            return logic.MostExpensiveRepairFromBrand(brandName);
        }
        [HttpGet("{wheelDriveName}")]
        public IQueryable<Car> SameWheelDriveCars(string wheelDriveName)
        {
            return logic.SameWheelDriveCars(wheelDriveName);
        }

    }
}

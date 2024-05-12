using F19FKP_HFT_2023242.Logic.Interfaces;
using F19FKP_HFT_2023242.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace F19FKP_HFT_2023242.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RepairController : ControllerBase
    {
        IRepairLogic logic;

        public RepairController(IRepairLogic logic)
        {
            this.logic = logic;
        }

        [HttpPost]
        public void Create([FromBody] Repair value)
        {
            this.logic.Create(value);
        }
        [HttpGet]
        public IEnumerable<Repair> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Repair Read(int id)
        {
            return this.logic.Read(id);
        }



        [HttpPut]
        public void Put([FromBody] Repair value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
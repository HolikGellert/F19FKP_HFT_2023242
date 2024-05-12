using F19FKP_HFT_2023242.Logic.Interfaces;
using F19FKP_HFT_2023242.Models;
using F19FKP_HFT_2023242.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F19FKP_HFT_2023242.Logic
{
    public class CarLogic : ICarLogic
    {
        IRepository<Car> repository;

        public CarLogic(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public void Create(Car item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Car Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Car> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}

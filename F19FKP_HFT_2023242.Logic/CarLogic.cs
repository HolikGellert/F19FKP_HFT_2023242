using F19FKP_HFT_2023242.Logic.Interfaces;
using F19FKP_HFT_2023242.Models;
using F19FKP_HFT_2023242.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public void Create(Car car)
        {
            if (car.Name == null)
            {
                throw new Exception();
            }
            this.repository.Create(car);
        }

        public void Delete(int id)
        {
            if (repository.Read(id) == null)
            {
                throw new Exception();
            }
            this.repository.Delete(id);
        }

        public Car Read(int id)
        {
            return this.repository.Read(id);
        }

        public IQueryable<Car> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Car car)
        {
            this.repository.Update(car);
        }
    }
}

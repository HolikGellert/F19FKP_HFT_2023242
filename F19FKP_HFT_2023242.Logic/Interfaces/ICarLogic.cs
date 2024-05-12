using F19FKP_HFT_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F19FKP_HFT_2023242.Logic.Interfaces
{
    public interface ICarLogic
    {
        void Create(Car item);
        Car Read(int id);
        void Update(Car car);
        void Delete(int id);
        IQueryable<Car> ReadAll();
    }
}

using F19FKP_HFT_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace F19FKP_HFT_2023242.Repository
{
    public class CarRepository : Repository<Car>, IRepository<Car>
    {
        public CarRepository(BrandDbContext ctx) : base(ctx)
        {
        }

        public override Car Read(int id)
        {
            return ctx.Cars.FirstOrDefault(p => p.CarId == id);
        }

        public override void Update(Car obj)
        {
            var old = Read(obj.CarId);
            foreach (var item in obj.GetType().GetProperties())
            {
                item.SetValue(old, item.GetValue(obj));
            }
            ctx.SaveChanges();
        }
    }
}

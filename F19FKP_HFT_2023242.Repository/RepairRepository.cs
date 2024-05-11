using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F19FKP_HFT_2023242.Models;
using Microsoft.EntityFrameworkCore;


namespace F19FKP_HFT_2023242.Repository
{
    public class RepairRepository : Repository<Repair>
    {
        public RepairRepository(BrandDbContext ctx) : base(ctx)
        {
        }

        public override Repair Read(int id)
        {
            return ctx.Repairs.FirstOrDefault(x => x.RepairId == id);
        }

        public override void Update(Repair obj)
        {
            var old = Read(obj.RepairId);
            foreach (var item in obj.GetType().GetProperties())
            {
                item.SetValue(old, item.GetValue(obj));
            }
            ctx.SaveChanges();
        }
    }
}

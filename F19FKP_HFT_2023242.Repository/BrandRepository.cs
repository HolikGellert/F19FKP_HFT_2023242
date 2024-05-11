using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F19FKP_HFT_2023242.Models;

namespace F19FKP_HFT_2023242.Repository
{
    public class BrandRepository : Repository<Brand>
    {
        public BrandRepository(BrandDbContext ctx) : base(ctx)
        {
        }

        public override Brand Read(int id)
        {
            return ctx.Brands.FirstOrDefault(p => p.BrandId == id);
        }

        public override void Update(Brand obj)
        {
            var old = Read(obj.BrandId);
            foreach (var item in obj.GetType().GetProperties())
            {
                item.SetValue(old, item.GetValue(obj));
            }
            ctx.SaveChanges();
        }
    }
}

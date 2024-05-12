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
    public class BrandLogic : IBrandLogic
    {
        IRepository<Brand> repository;

        public BrandLogic(IRepository<Brand> repository)
        {
            this.repository = repository;
        }

        public void Create(Brand brand)
        {
            if (brand.Name.Length > 99 || brand.Name.Length < 0)
            {
                throw new ArgumentException();
            }
            else if (brand.CountryOfOrigin == null || brand.CountryOfOrigin == "")
            {
                throw new Exception();
            }
            this.repository.Create(brand);
        }

        public void Delete(int id)
        {
            if (repository.Read(id) == null)
            {
                throw new Exception();
            }
            this.repository.Delete(id);
        }

        public Brand Read(int id)
        {
            return this.repository.Read(id);
        }

        public IQueryable<Brand> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Brand brand)
        {
            this.repository.Update(brand);
        }
    }
}

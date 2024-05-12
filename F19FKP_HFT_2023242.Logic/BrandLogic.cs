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

        public void Create(Brand item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Brand Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Brand> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class RepairLogic : IRepairLogic
    {
        IRepository<Repair> repository;

        public RepairLogic(IRepository<Repair> repository)
        {
            this.repository = repository;
        }

        public void Create(Repair item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Repair Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Repair> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Repair repair)
        {
            throw new NotImplementedException();
        }
    }
}

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

        public void Create(Repair repair)
        {
            if (repair.Cost < 0 || repair.Date <= DateTime.MinValue || repair.Date >= DateTime.MaxValue || repair.Description.Length <= 0)
            {
                throw new ArgumentException();
            }
            this.repository.Create(repair);
        }

        public void Delete(int id)
        {
            if (repository.Read(id) == null)
            {
                throw new Exception();
            }
            this.repository.Delete(id);
        }

        public Repair Read(int id)
        {
            return this.repository.Read(id);
        }

        public IQueryable<Repair> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Repair repair)
        {
            this.repository.Update(repair);
        }
    }
}

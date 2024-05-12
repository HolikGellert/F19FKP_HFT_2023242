using F19FKP_HFT_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F19FKP_HFT_2023242.Logic.Interfaces
{
    public interface IRepairLogic
    {
        void Create(Repair item);
        Repair Read(int id);
        void Update(Repair repair);
        void Delete(int id);
        IQueryable<Repair> ReadAll();
    }
}

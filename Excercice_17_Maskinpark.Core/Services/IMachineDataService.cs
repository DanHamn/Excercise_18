using Excercice_17_Maskinpark.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excercice_17_Maskinpark.Core.Services
{
    public interface IMachineDataService
    {
        Task<IEnumerable<Machine>> GetAllMachines();
        Task<Machine> GetMachine(Guid id);
        Task<Machine> AddMachine(Machine machine);
        Task UpdateMachine(string machineId, Machine machine);
        Task DeleteMachine(Guid id);
    }
}

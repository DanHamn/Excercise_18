using Excercice_17_Maskinpark.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercice_17_Maskinpark.Core.Repositories
{
    public interface IMachineRepository
    {
        Task<IEnumerable<Machine>> GetAllCoursesAsync();
        Task<Machine> GetCourseAsync(Guid? id);
        Task<Machine> FindAsync(Guid? id);
        Task<bool> AnyAsync(Guid? id);
        void Add(Machine machine);
        void Update(Machine machine);
        void Remove(Machine machine);
    }
}

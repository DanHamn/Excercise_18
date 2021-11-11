using Excercice_17_Maskinpark.Core.Entities;
using Excercice_17_Maskinpark.Core.Repositories;
using Excercice_17_Maskinpark.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Excercice_17_Maskinpark.Data.Repositories
{
    class MachineRepository : IMachineRepository
    {
        private readonly Excercice_17_MaskinparkApiContext _context;
        public MachineRepository(Excercice_17_MaskinparkApiContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(Machine machine)
        {
            _context.Add(machine);
        }

        public async Task<bool> AnyAsync(Guid? id)
        {
            return await _context.Machine.AnyAsync(m=> m.Id == id);
        }

        public async Task<Machine> FindAsync(Guid? id)
        {
            return await _context.Machine.FindAsync(id);
        }

        public async Task<IEnumerable<Machine>> GetAllCoursesAsync()
        {
            return await _context.Machine.ToListAsync();
        }

        public async Task<Machine> GetCourseAsync(Guid? id)
        {
            return await _context.Machine.FirstOrDefaultAsync(m => m.Id == id);
        }

        public void Remove(Machine machine)
        {
            _context.Machine.Remove(machine);
        }

        public void Update(Machine machine)
        {
            //_context.Entry(machine).State = EntityState.Modified;
            _context.Machine.Update(machine);
        }
    }
}

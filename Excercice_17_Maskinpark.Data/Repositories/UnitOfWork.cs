using Excercice_17_Maskinpark.Core.Repositories;
using Excercice_17_Maskinpark.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercice_17_Maskinpark.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IMachineRepository MachineRepository { get; }

        private readonly Excercice_17_MaskinparkApiContext _context;

        public UnitOfWork(Excercice_17_MaskinparkApiContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            MachineRepository = new MachineRepository(context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

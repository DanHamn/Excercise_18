using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercice_17_Maskinpark.Core.Repositories
{
    public interface IUnitOfWork
    {
        IMachineRepository MachineRepository { get; }

        Task CompleteAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercice_17_Maskinpark.Core.Dto
{
    public class MachineDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool OnlineStatus { get; set; }
        public string Data { get; set; }
    }
}

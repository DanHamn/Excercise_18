using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excercice_17_Maskinpark.Core.Entities
{
    public class Machine
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool OnlineStatus { get; set; }
        public string Data { get; set; }
    }
}

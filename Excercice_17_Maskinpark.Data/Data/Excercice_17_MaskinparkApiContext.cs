using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Excercice_17_Maskinpark.Core.Entities;

namespace Excercice_17_Maskinpark.Data.Data
{
    public class Excercice_17_MaskinparkApiContext : DbContext
    {
        public Excercice_17_MaskinparkApiContext (DbContextOptions<Excercice_17_MaskinparkApiContext> options)
            : base(options)
        {
        }
            
        public DbSet<Excercice_17_Maskinpark.Core.Entities.Machine> Machine { get; set; }
    }
}

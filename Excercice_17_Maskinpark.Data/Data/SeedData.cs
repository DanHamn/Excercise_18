using Bogus;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Excercice_17_Maskinpark.Core.Models;
using Excercice_17_Maskinpark.Core.Entities;

namespace Excercice_17_Maskinpark.Data.Data
{
    public class SeedData
    {
        private static readonly Faker faker = new("sv");
        private static readonly TextInfo ti = new CultureInfo("sv-SE", false).TextInfo;
        public static async Task InitAsync(Excercice_17_MaskinparkApiContext context)
        {
            if (context is null) throw new NullReferenceException(nameof(Excercice_17_MaskinparkApiContext));

            context.Machine.RemoveRange(context.Machine);
            await context.SaveChangesAsync();

            var machines = InitializeMachines();
            await context.AddRangeAsync(machines);

            await context.SaveChangesAsync();
        }

        private static IEnumerable<Machine> InitializeMachines()
        {
            string data = "Initialization";

            return new List<Machine>()
            {
                new Machine{Name ="Page Cutter", OnlineStatus=true, Data=data},
                new Machine{Name ="Page Printer", OnlineStatus=false, Data=data},
                new Machine{Name ="Page Stacker", OnlineStatus=true, Data=data},
                new Machine{Name ="Cover Cutter", OnlineStatus=true, Data=data},
                new Machine{Name ="Cover Printer", OnlineStatus=true, Data=data},
                new Machine{Name ="Binder", OnlineStatus=true, Data=data},
                new Machine{Name ="Packaging", OnlineStatus=true, Data=data}
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


namespace Servicelifetimes
{
    internal   class tempclass
    {


        public static void tempfun(IServiceProvider serviceprovider)
        {
            using (var scope = serviceprovider.CreateScope())
            {
                Console.WriteLine(Random.Shared.Next(1, 1001));
                Console.WriteLine(serviceprovider.GetService<TransientServiceLifetime>());
                Console.WriteLine(serviceprovider.GetService<ScopedServiceLifetime>());
                Console.WriteLine(serviceprovider.GetService<SingletonServiceLifetime>());

            }
        }
    }
}

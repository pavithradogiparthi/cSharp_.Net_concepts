using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicelifetimes
{
    internal class ScopedServiceLifetime
    {
        public int value1 { get; set; }
        public int value2 { get; set; }
        public ScopedServiceLifetime()
        {
            value1 = Random.Shared.Next(1, 1001);
            value2 = Random.Shared.Next(1, 1001);
        }
        public override string ToString()
        {
            return $"value1:{value1} ,value2:{value2}";

        }
    }
}

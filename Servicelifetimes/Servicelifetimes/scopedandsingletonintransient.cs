using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicelifetimes
{
    internal class scopedandsingletonintransient
    {
        private readonly SingletonServiceLifetime single;
        private readonly ScopedServiceLifetime scope;

     
        public scopedandsingletonintransient(SingletonServiceLifetime Single,ScopedServiceLifetime Scope)
        {
            single = Single;
            scope = Scope;
            

        }
        public override string ToString()
        {
            return $"singleton value {single.ToString()} scoped value {scope.ToString()} ";
        }
    }
}

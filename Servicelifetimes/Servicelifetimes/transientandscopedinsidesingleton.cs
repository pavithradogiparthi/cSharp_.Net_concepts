using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicelifetimes
{
    internal class transientandscopedinsidesingleton
    {
        private readonly TransientServiceLifetime trans;
        private readonly ScopedServiceLifetime scope;

  
        public transientandscopedinsidesingleton(TransientServiceLifetime Trans, ScopedServiceLifetime Scope)
        {
            trans = Trans;
            scope = Scope;


        }
        public override string ToString()
        {
            return $"transient value {trans.ToString()} scoped value {scope.ToString()} ";
        }
    }
}

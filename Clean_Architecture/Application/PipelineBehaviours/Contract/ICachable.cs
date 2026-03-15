using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PipelineBehaviours.Contract
{
public interface ICachable
    {
        public string CacheKey { get; set; }
        public bool BypassCache { get; set; }
        public TimeSpan SlidingExpiration { get; set; } 
    }
}

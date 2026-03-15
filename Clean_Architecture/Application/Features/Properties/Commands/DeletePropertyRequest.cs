using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.PipelineBehaviours.Contract;
using Application.Repository;
using Domain;
using MediatR;

namespace Application.Features.Properties.Commands
{
   public class DeletePropertyRequest:IRequest<bool>,ICacheRemoval
    {
       
        public int PropertyId { get; set; }
        public List<string> CacheKeys { get; set; }

        public DeletePropertyRequest(int propertyid)
        {
            PropertyId = propertyid;
            CacheKeys = new() { "GetProperties", $"GetpropertyById:{PropertyId}" };
        }
    
    }
    public class DeletePropertyRequestHandler : IRequestHandler<DeletePropertyRequest, bool>
    {
        private readonly IPropertyRepo _propertyrepo;
        public DeletePropertyRequestHandler(IPropertyRepo propertyrepo)
        {
            _propertyrepo = propertyrepo;
            
        }

        public async Task<bool> Handle(DeletePropertyRequest request, CancellationToken cancellationToken)
        {
            Property propertyinDb=await _propertyrepo.GetByIdAsync(request.PropertyId);
            if (propertyinDb != null)
            {
                await _propertyrepo.DeleteAsync(propertyinDb);
                return true;
            }
            return false;
        }
    }

}

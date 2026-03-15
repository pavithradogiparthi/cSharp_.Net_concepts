using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.PipelineBehaviours.Contract;
using Application.Repository;
using Domain;
using MediatR;

namespace Application.Features.Properties.Commands
{
    public class UpdatePropertyRequest : IRequest<bool>,Ivalidatable,ICacheRemoval
    {
        public UpdateProperty UpdateProperty { get; set; }
        public int PropertyId { get; set; }
        public List<string> CacheKeys { get; set; }
        public UpdatePropertyRequest(UpdateProperty updateproperty)
        {

            UpdateProperty = updateproperty;
            CacheKeys = new() { "GetProperties", $"GetpropertyById:{PropertyId}" };
        }
    }
        public class UpdatePropertyRequestHandler : IRequestHandler<UpdatePropertyRequest, bool>
        {
            private readonly IPropertyRepo _propertyRepo;
            public UpdatePropertyRequestHandler(IPropertyRepo propertyRepo)
            {
                _propertyRepo = propertyRepo;
            }
            public  async Task<bool> Handle(UpdatePropertyRequest request, CancellationToken cancellationToken)
            {//check if data in db
                Property propertyIndb = await _propertyRepo.GetByIdAsync(request.UpdateProperty.Id);
                if(propertyIndb != null)
                {
                    propertyIndb.Name = request.UpdateProperty.Name;
                    propertyIndb.Lounge = request.UpdateProperty.Lounge;
                    propertyIndb.Dining=request.UpdateProperty.Dining;
                    propertyIndb.PetsAllowed = request.UpdateProperty.PetsAllowed;
                    propertyIndb.Price=request.UpdateProperty.Price;
                    propertyIndb.Bedrooms=request.UpdateProperty.Bedrooms;
                    propertyIndb.BathRooms=request.UpdateProperty.BathRooms;
                    propertyIndb.Description=request.UpdateProperty.Description;
                    propertyIndb.MyProperty=request.UpdateProperty.MyProperty;
                    propertyIndb.FloorSize=request.UpdateProperty.FloorSize;
                    propertyIndb.ErfSize=request.UpdateProperty.ErfSize;
                    propertyIndb.Address=request.UpdateProperty.Address;
                    propertyIndb.Levie=request.UpdateProperty.Levie;
                    propertyIndb.Type=request.UpdateProperty.Type;
                    propertyIndb.Rates=request.UpdateProperty.Rates;
                    propertyIndb.Kitchens=request.UpdateProperty.Kitchens;
                    
                    await _propertyRepo.UpdateAsync(propertyIndb);
                    return true;
                }
              return false;
            }
        }

    
}

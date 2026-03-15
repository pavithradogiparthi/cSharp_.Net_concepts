using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.PipelineBehaviours.Contract;
using Application.Repository;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Properties.Queries
{
  public  class GetPropertyById:IRequest<PropertyDto>,ICachable
    {
        public int PropertyId { get; set; }
        public string CacheKey { get; set; }
        public bool BypassCache { get; set; }
        public TimeSpan SlidingExpiration { get; set; }
        public GetPropertyById(int propertyId)
        {
            PropertyId = propertyId;
            CacheKey = $"GetpropertyById:{PropertyId}";
        }

    }
    public class GetPropertyByIdRequestHandler : IRequestHandler<GetPropertyById, PropertyDto>
    {
        private readonly IPropertyRepo _propertyrepo;
        private readonly IMapper _mapper;
        public GetPropertyByIdRequestHandler(IPropertyRepo propertyrepo,IMapper mapper)
        {
            _propertyrepo = propertyrepo;
            _mapper = mapper;

        }
        public async Task<PropertyDto> Handle(GetPropertyById request, CancellationToken cancellationToken)
        {
            Property propertyInDb = await _propertyrepo.GetByIdAsync(request.PropertyId);
            if(propertyInDb!=null)
            {
                PropertyDto propertyDto=_mapper.Map<PropertyDto>(propertyInDb);
                return propertyDto;
            }
            return null;
        }
    }

}

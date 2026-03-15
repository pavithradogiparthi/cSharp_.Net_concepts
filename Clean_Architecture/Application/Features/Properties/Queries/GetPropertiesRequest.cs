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
    public class GetPropertiesRequest : IRequest<List<PropertyDto>>, ICachable,ILogMe
    {
        //private readonly IPropertyRepo _propertyRepo;
        //public GetPropertiesRequest(IPropertyRepo propertyrepo)
        //{
        //    _propertyRepo = propertyrepo;
        //}
        public string CacheKey { get ; set ; }
        public bool BypassCache { get ; set ; }
        public TimeSpan SlidingExpiration { get ; set ; }
        public GetPropertiesRequest()
        {
            CacheKey = "GetProperties";
        }
    }
    public class GetPropertiesRequestHandler : IRequestHandler<GetPropertiesRequest, List<PropertyDto>>
    {
        private readonly IPropertyRepo _propertyRepo;
        private readonly IMapper _mapper;
        public GetPropertiesRequestHandler(IPropertyRepo propertyRepo,IMapper mapper)
        {
            _propertyRepo = propertyRepo;
            _mapper = mapper;
        }
        public async Task<List<PropertyDto>> Handle(GetPropertiesRequest request, CancellationToken cancellationToken)
        {
            List<Property> properties = await _propertyRepo.GetAllAsync();
            if(properties != null)
            {
               List<PropertyDto> propertyDtos = _mapper.Map<List<PropertyDto>>(properties);
                return propertyDtos;
            }
            return null;
        }
    }

}

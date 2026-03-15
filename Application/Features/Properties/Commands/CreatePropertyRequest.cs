using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.Repository;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Properties.Commands
{
public  class CreatePropertyRequest:IRequest<bool>
    {
          public NewProperty PropertyRequest { get;set; }
        public CreatePropertyRequest(NewProperty newproperty)
        {
            PropertyRequest = newproperty;
        }
    }
    public class CreatePropertyRequestHandler : IRequestHandler<CreatePropertyRequest, bool>
    {
        private readonly IPropertyRepo _propertyRepo;
        private readonly IMapper _mapper;

        public CreatePropertyRequestHandler(IPropertyRepo propertyRepo, IMapper mapper = null)
        {
            _propertyRepo = propertyRepo;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreatePropertyRequest request, CancellationToken cancellationtoken)
        {
          
            Property property = _mapper.Map<Property>(request.PropertyRequest);
            property.ListDate = DateTime.Now;
            await _propertyRepo.AddNewAsync(property);
            return true;
        }
    }
}

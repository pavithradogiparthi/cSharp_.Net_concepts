using AutoMapper;
using BusinessLogicLayer;
using DataAccessLayer.Entities;

namespace PresentationLayer
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
       { CreateMap<CustomerDTO, Customer>().ReverseMap();

            CreateMap<Customer, CreateCustomerDTO>().ReverseMap();
        
       }
    }
}

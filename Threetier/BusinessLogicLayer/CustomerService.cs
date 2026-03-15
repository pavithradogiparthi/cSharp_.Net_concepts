using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer
{
    public  class CustomerService:ICustomerService
    {
        private readonly ICustomerRepository _customerrepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerrepository, IMapper mapper)
        {
            _customerrepository = customerrepository;
            _mapper = mapper;

        }
        public async Task<List<CustomerDTO>> GetCustomersAsync()
        {
            List<Customer> customer = await _customerrepository.GetCustomersAsync();
            return _mapper.Map<List<CustomerDTO>>(customer);
        }
        public async Task AddCustomerAsync(CreateCustomerDTO entity)
        {
             var temp=_mapper.Map<Customer>(entity);
            await _customerrepository.AddCustomerAsync(temp);
        }

    }
}

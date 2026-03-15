using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Interfaces
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _dbcontext.Customers.ToListAsync();
        }
        public async Task AddCustomerAsync(Customer entity)
        {
            await _dbcontext.AddAsync(entity);
             await _dbcontext.SaveChangesAsync();

        }

    }
}

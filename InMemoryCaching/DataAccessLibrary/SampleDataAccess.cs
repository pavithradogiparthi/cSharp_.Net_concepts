using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Extensions.Caching.Memory;

namespace DataAccessLibrary
{
    public class SampleDataAccess
    {
        private readonly IMemoryCache _memoryCache;
        public SampleDataAccess(IMemoryCache memorycache) {
            _memoryCache = memorycache;
        }
        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> output = new();
            output.Add(new EmployeeModel() { FirstName = "afreen", LastName = "sahik" });
            output.Add(new EmployeeModel() { FirstName = "madhu", LastName = "vonna" });
            Thread.Sleep(3000);
            return output;
        }
        public  async Task<List<EmployeeModel>> GetEmployeesAsync()
        {
            List<EmployeeModel> output = new();
            output.Add(new EmployeeModel() { FirstName = "afreen", LastName = "sahik" });
            output.Add(new EmployeeModel() { FirstName = "madhu", LastName = "vonna" });
            await Task.Delay(3000); 
            return output;
        }
        public async Task<List<EmployeeModel>>GetEmployeesCache()
        {
            List<EmployeeModel> output;
            output=_memoryCache.Get<List<EmployeeModel>>("employees");
            if(output is null)
            {
                output = new();
                output.Add(new EmployeeModel() { FirstName = "afreen", LastName = "sahik" });
                output.Add(new EmployeeModel() { FirstName = "madhu", LastName = "vonna" });
                await Task.Delay(3000);
                _memoryCache.Set("employees", output, TimeSpan.FromMinutes(1));

            }
            return output;
        }
    }
}

using Employee_Api_23_12.Data;
using Employee_Api_23_12.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Api_23_12.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddEmployee(Employee employee)
        {
            var result = await _appDbContext.Set<Employee>().AddAsync(employee);
            await _appDbContext.SaveChangesAsync();
            //return  result.Entity;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var result = await _appDbContext.Employees.FirstOrDefaultAsync(a => a.Id == id);
            if (result != null)
            {
                _appDbContext.Employees.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null; 
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
           return  await _appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _appDbContext.Employees.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            var result = await _appDbContext.Employees.FirstOrDefaultAsync(a => a.Id == employee.Id);
            if (result != null)
            {
                result.Name = employee.Name;
                result.Address = employee.Address;
                result.City = employee.City;
                await _appDbContext.SaveChangesAsync();
               
            }
        }

      
    }
}

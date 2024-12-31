using Employee_Api_23_12.Models;

namespace Employee_Api_23_12.Repository
{
    public interface IEmployeeRepository
    {
       public  Task<Employee> GetById(int id);
        public  Task<IEnumerable<Employee>> GetAll();
        public Task AddEmployee(Employee employee);
        public Task UpdateEmployee(Employee employee);
        public Task<Employee> DeleteEmployee(int id);
  
    }
}

using Employee_Api_23_12.Models;
using Employee_Api_23_12.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Api_23_12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody]Employee employee)
        {
            await _employeeRepository.AddEmployee(employee);
            return Ok(employee);
        }
        [HttpGet]
        public async Task<ActionResult> GetEmployee()
        {
            return Ok(await _employeeRepository.GetAll());  
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetEmployeeById([FromRoute] int Id)
        {
            var result = await _employeeRepository.GetById(Id);
            if (result != null)
            {
                return Ok(result);  
            }
            else
            {
                return NotFound(); 
            }
        }

       
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateEmployee([FromRoute] int Id, [FromBody] Employee employee)
        {
            var existingEmployee = await _employeeRepository.GetById(Id);
            if (existingEmployee == null)
            {
                return NotFound(); 
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Address = employee.Address;
            existingEmployee.City = employee.City;

            await _employeeRepository.UpdateEmployee(existingEmployee);

            return Ok(existingEmployee);  
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteEmployee([FromRoute] int Id)
        {
            var result = await _employeeRepository.DeleteEmployee(Id);
            if (result == null)
            {
                return NotFound();  
            }
            return Ok(result);  
        }


    }
}

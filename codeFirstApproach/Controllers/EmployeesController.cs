using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using codeFirstApproach.Data;
using codeFirstApproach.model;
using codeFirstApproach.IRepository;

namespace codeFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;

        private  IEmployeeRepo employeeRepo;

        public EmployeesController(IEmployeeRepo _employeeRepo)
        {
            employeeRepo = _employeeRepo;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            await Task.Delay(5000);
            return await employeeRepo.GetEmployees();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            // Simulate a delay of 5 seconds
            await Task.Delay(150000);

            try
            {
                // Your existing code to fetch the employee
                return Ok(employeeRepo.GetEmployeeByID(id));
            }
            catch (Exception ex)
            {
                // Properly handle exceptions
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public  IActionResult PutEmployee(int id, Employee employee)
        {
            try
            {
                return Ok(employeeRepo.UpdateEmployee(employee));
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public  ActionResult<Employee> PostEmployee(Employee employee)
        {
            try
            {
                return Ok(employeeRepo.AddEmployee(employee));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public  IActionResult DeleteEmployee(int id)
        {
            try
            {
                return Ok(employeeRepo.DeleteEmployee(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}

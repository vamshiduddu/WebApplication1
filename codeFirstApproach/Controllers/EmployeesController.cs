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
using codeFirstApproach.helpers;
using NuGet.Protocol;
using Microsoft.AspNetCore.Authorization;

namespace codeFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;

        private  IEmployeeRepo employeeRepo;
        private readonly IConfiguration _config;
        public EmployeesController(IEmployeeRepo _employeeRepo)
        {
            employeeRepo = _employeeRepo;
        }

        // GET: api/Employees
        [HttpGet]
        //[Authorize(Roles = "Admin")]
         [UsernameAuthorizeAttributeFilter("HR")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
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

        [HttpGet("/token")]
        public IActionResult GetToken(int id,string name,string role)
        {
            // Assuming the user has been authenticated
            var authHelpers = new AuthHelpers();
            var token = authHelpers.GenerateJWTToken(id,name,role);

            return Ok(new { token });
        }


    }
}

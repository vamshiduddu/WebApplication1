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
            return await employeeRepo.GetEmployees();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            try
            {
                return Ok(employeeRepo.GetEmployeeByID(id));
            }
            catch(Exception ex)
            {
                throw ex;
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

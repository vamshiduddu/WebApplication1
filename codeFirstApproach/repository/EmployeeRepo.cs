using codeFirstApproach.Data;
using codeFirstApproach.IRepository;
using codeFirstApproach.model;
using Microsoft.EntityFrameworkCore;

namespace codeFirstApproach.repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepo(ApplicationDbContext context) {
            
            this._context = context;
        
        }

        public Employee AddEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                int rowsAffected = _context.SaveChanges();

                if (rowsAffected > 0)
                {
                    return employee; // Or perform other actions after successful insertion
                }
                else
                {
                    // Handle insertion failure (e.g., logging errors)
                    return null; // Or throw an exception
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions during database operations
                throw; // Or rethrow a more specific exception
            }
        }


        public dynamic DeleteEmployee(int id)
        {
            try
            {
                _context.Employees.Remove(GetEmployeeByID(id));
                int rowsAffected = _context.SaveChanges();

                if (rowsAffected > 0)
                {
                    return "employee with"+id+"has deleted"; // Or perform other actions after successful insertion
                }
                else
                {
                    // Handle insertion failure (e.g., logging errors)
                    return "No emplyee found"; // Or throw an exception
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions during database operations
                throw; // Or rethrow a more specific exception
            }
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync(); ;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Update(employee);
                int rowsAffected = _context.SaveChanges();

                if (rowsAffected > 0)
                {
                    return employee; // Or perform other actions after successful insertion
                }
                else
                {
                    return null;
                }


                
            }
            catch (Exception ex)
            {
                // Handle exceptions during database operations
                throw ex; // Or rethrow a more specific exception
            }
        }

 
        public Employee GetEmployeeByID(int id)
        {
            return _context.Employees.FirstOrDefault(emp => emp.EmployeeID == id);
        }

       
    }
}

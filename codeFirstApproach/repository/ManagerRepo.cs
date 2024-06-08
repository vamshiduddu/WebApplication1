using codeFirstApproach.Data;
using codeFirstApproach.IRepository;
using codeFirstApproach.model;
using Microsoft.EntityFrameworkCore;

namespace codeFirstApproach.repository
{
    public class ManagerRepo : IManagerRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmployeeRepo employeeRepo;


        public ManagerRepo(ApplicationDbContext context , IEmployeeRepo _employeeRepo) {

            this._context = context;
            employeeRepo = _employeeRepo;
        }
        public Manager AddNewEmployeeToManager(int employeeId, int managerId)
        {
            try
            {
                var manaager = _context.Managers.FirstOrDefault(manager => manager.Id == managerId);
                var employee = _context.Employees.FirstOrDefault(emp => emp.EmployeeID == employeeId);
                List<Employee> employees = manaager.Employees;
                employees.Add(employee);

                _context.Managers.Update(manaager);
                employeeRepo.UpdateEmployee(employee);
                int rowsAffected = _context.SaveChanges();

                if (rowsAffected > 0)
                {
                    return manaager; // Or perform other actions after successful insertion
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
                throw ex; // Or rethrow a more specific exception
            }
        }

        public Manager AddNewManager(Manager manager)
        {

            try
            {
                _context.Managers.Add(manager);
                int rowsAffected = _context.SaveChanges();

                if (rowsAffected > 0)
                {
                    return manager; // Or perform other actions after successful insertion
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
                throw ex; // Or rethrow a more specific exception
            }
        }

        public Manager GetManager(int id)
        {
            try
            {
               var manaager=  _context.Managers.FirstOrDefault(manager => manager.Id== id);
                int rowsAffected = _context.SaveChanges();

                if (rowsAffected > 0)
                {
                    return manaager; // Or perform other actions after successful insertion
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
                throw ex; // Or rethrow a more specific exception
            }
        }

        public List<Manager> GetManagers()
        {
            var allManagers = _context.Managers.ToList();
            var allEmployees = employeeRepo.GetEmployees().Result;

            foreach (var manager in allManagers)
            {
                manager.Employees = allEmployees.Where(emp => emp.ManagerId == manager.Id).ToList();
            }

            return allManagers;
        }

        public string RemoveManager(int id)
        {
            try
            {
                var allemployees = employeeRepo.GetEmployees().Result;

                foreach(var emp in allemployees)
                {
                    if(emp.ManagerId == id)
                    {
                        emp.ManagerId = null;
                        employeeRepo.UpdateEmployee(emp);
                    }
                }


                var manaager = _context.Managers.FirstOrDefault(manager => manager.Id == id);
                _context.Managers.Remove(manaager);
                int rowsAffected = _context.SaveChanges();

                if (rowsAffected > 0)
                {
                    return "deleted"; // Or perform other actions after successful insertion
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
                throw ex; // Or rethrow a more specific exception
            }
            throw new NotImplementedException();
        }

        public Manager UpdateManager(Manager manager)
        {
            try
            {
                 _context.Managers.Update(manager);
                int rowsAffected = _context.SaveChanges();

                if (rowsAffected > 0)
                {
                    return manager; // Or perform other actions after successful insertion
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
                throw ex; // Or rethrow a more specific exception
            }
        }
    }
}

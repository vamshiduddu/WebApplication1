using codeFirstApproach.model;

namespace codeFirstApproach.IRepository
{
    public interface IEmployeeRepo
    {
        public Task<List<Employee>> GetEmployees ();

        public Employee GetEmployeeByID(int id);
        
        public Employee AddEmployee(Employee employee);

        public Employee UpdateEmployee(Employee employee);

        public dynamic DeleteEmployee(int id);


        
    }
}

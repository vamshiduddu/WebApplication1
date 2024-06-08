using codeFirstApproach.model;

namespace codeFirstApproach.IRepository
{
    public interface IManagerRepo
    {
        public Manager GetManager(int id);
        public List<Manager> GetManagers();


        public Manager AddNewManager(Manager manager);

        public Manager UpdateManager(Manager manager);

        public Manager AddNewEmployeeToManager(int employeeId,int managerId);

        public string RemoveManager(int id);
    }
}

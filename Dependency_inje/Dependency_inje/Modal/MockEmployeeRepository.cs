namespace Dependency_inje.Modal
{
    public class MockEmployeeRepository
    {

        private List<Employee> employeeslist;

        public MockEmployeeRepository()
        {
            employeeslist = new List<Employee>()
            {
                new Employee() {Id = 1, Name= "vijay kumar", Designation="Manager", MobileNo = 123456789, Salary = 1200 },
                new Employee() {Id = 2, Name= "Nana Gaitonde", Designation="Devloper", MobileNo = 993456789, Salary = 5800 },
                new Employee() {Id = 3, Name= "Ashish yadav", Designation="HR", MobileNo = 72346789, Salary = 3200 }
            };
        }
        public Employee GetEmployee(int id)
        {
            return 
        }
    }
}

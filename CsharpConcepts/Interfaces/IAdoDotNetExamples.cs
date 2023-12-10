using CsharpConcepts.Classes.Models;

namespace CsharpConcepts.Interfaces
{
    internal interface IAdoDotNetExamples
    {
        public Employee GetEmployeeById(int EmpId);

        public List<Employee> GetEmployees();

        public void InsertEmployee(Employee employee);

        public void AddEmployeeUsingStoredProcedure(Employee employee);

        public void DeleteEmployeeUsingStoredProcedure(int employeeId);
    }
}
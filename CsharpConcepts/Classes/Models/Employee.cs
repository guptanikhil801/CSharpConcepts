namespace CsharpConcepts.Classes.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        //public int Salary { get; set; }
        private int EmployeeSalary;

        public int Salary
        {
            get => EmployeeSalary;
            set { EmployeeSalary = value < 10000 ? 10000 : value; } // encapsulation example
        }

        public string[]? SkillSet { get; set; }
    }
}
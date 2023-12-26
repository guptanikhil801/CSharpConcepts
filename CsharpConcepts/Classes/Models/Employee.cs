namespace CsharpConcepts.Classes.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Salary { get; set; }
        public string[] SkillSet { get; set; }
    }
}
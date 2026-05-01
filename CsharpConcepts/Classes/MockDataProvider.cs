using CsharpConcepts.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpConcepts.Classes
{
    public class MockDataProvider
    {
        public static List<Student> GetMockStudents()
        {
            return new List<Student>
            {
                new Student { StudentId = 1, FirstName = "Amit", LastName = "Sharma", Class = 10, Percentage = 91.5, Subjects = ["Math", "Science", "English"] },
                new Student { StudentId = 2, FirstName = "Priya", LastName = "Singh", Class = 10, Percentage = 88.2, Subjects = ["History", "English", "Geography"] },
                new Student { StudentId = 3, FirstName = "Rahul", LastName = "Verma", Class = 9,  Percentage = 84.7, Subjects = ["Physics", "Chemistry", "Math"] },
                new Student { StudentId = 4, FirstName = "Sneha", LastName = "Patel", Class = 9,  Percentage = 89.9, Subjects = ["Biology", "Chemistry", "English"] },
                new Student { StudentId = 5, FirstName = "Karan", LastName = "Mehta", Class = 10, Percentage = 93.3, Subjects = ["Computer", "Math", "Physics"] }
            };
        }

        public static List<Order> GetMockOrders()
        {
            return new List<Order>
            {
                new Order { CustomerId = 1, OrderDate = new DateTime(2023, 1, 1) },
                new Order { CustomerId = 1, OrderDate = new DateTime(2023, 5, 1) },
                new Order { CustomerId = 2, OrderDate = new DateTime(2024, 1, 1) }
            };
        }

        public static List<Employee> GetMockEmployees()
        {
            return new List<Employee>
            {
                new Employee { EmployeeId = 1, FirstName = "Amit", LastName = "Sharma", Department = "IT", Role = "Developer", Salary = 60000, SkillSet = new[] { "C#", "SQL", "ASP.NET" } },
                new Employee { EmployeeId = 2, FirstName = "Priya", LastName = "Singh", Department = "HR", Role = "Manager", Salary = 55000, SkillSet = new[] { "Recruitment", "Communication", "Leadership" } },
                new Employee { EmployeeId = 3, FirstName = "Rahul", LastName = "Verma", Department = "Finance", Role = "Analyst", Salary = 45000, SkillSet = new[] { "Excel", "Accounting", "Analysis" } },
                new Employee { EmployeeId = 4, FirstName = "Sneha", LastName = "Patel", Department = "IT", Role = "Tester", Salary = 40000, SkillSet = new[] { "Manual Testing", "Automation", "Selenium" } },
                new Employee { EmployeeId = 5, FirstName = "Karan", LastName = "Mehta", Department = "Support", Role = "Executive", Salary = 30000, SkillSet = new[] { "Customer Support", "Communication", "Problem Solving" } },
                new Employee { EmployeeId = 6, FirstName = "Viki", LastName = "Joshi", Department = "IT", Role = "Developer", Salary = 65000, SkillSet = new[] { "Java", "Spring Boot", "Microservices" } },
                new Employee { EmployeeId = 7, FirstName = "Neha", LastName = "Gupta", Department = "IT", Role = "Tester", Salary = 42000, SkillSet = new[] { "Selenium", "API Testing", "Postman" } }
            };
        }
    }
}


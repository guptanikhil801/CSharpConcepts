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
                new () { EmployeeId = 1, FirstName = "Kai", LastName = "Gray", Salary = 50000, SkillSet = new[] { "C#", "ASP.NET", "SQL" } },
                new () { EmployeeId = 2, FirstName = "Ava", LastName = "Dean", Salary = 60000, SkillSet = new[] { "Java", "Spring", "Hibernate" } },
                new () { EmployeeId = 3, FirstName = "Bob", LastName = "Reed", Salary = 55000, SkillSet = new[] { "JavaScript", "React", "Node.js" } },
                new () { EmployeeId = 4, FirstName = "Max", LastName = "Hale", Salary = 70000, SkillSet = new[] { "Python", "Django", "MongoDB" } },
                new () { EmployeeId = 5, FirstName = "Leo", LastName = "Ross", Salary = 48000, SkillSet = new[] { "HTML", "CSS", "Angular" } },
                new () { EmployeeId = 6, FirstName = "Max", LastName = "Hale", Salary = 18000, SkillSet = new[] { "Python", "Django", "MongoDB" } },
            };
        }
    }
}


using CsharpConcepts.Classes.Models;
using CsharpConcepts.Interfaces;
using System.Data.SqlClient;

namespace CsharpConcepts.Classes
{
    internal class AdoDotNetExamples : IAdoDotNetExamples
    {
        private readonly string ConnString = "server=(localdb)\\MSSQLLocalDB; database=PracticeDb; Integrated Security=true";

        public Employee GetEmployeeById(int EmpId)
        {
            Employee emp = new Employee();
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                SqlCommand cmd = connection.CreateCommand();
                var sql = "select * from Employee where EmployeeId = @EmpId;";
                cmd.CommandText = sql.Replace("@EmpId", EmpId.ToString());
                connection.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"].ToString());
                    emp.FirstName = reader["Name"].ToString().Split(' ')[0];
                    emp.Salary = Convert.ToInt32(reader["Salary"]);
                }
                connection.Close();
            }
            return emp;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnString))
            {
                SqlCommand command = sqlConnection.CreateCommand();
                command.CommandText = "select * from employee";
                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var employee = new Employee();
                    employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"].ToString());
                    employee.FirstName = reader["Name"].ToString().Split(' ')[0];
                    employee.Salary = Convert.ToInt32(reader["Salary"].ToString());
                    employees.Add(employee);
                }
                sqlConnection.Close();
            }
            return employees;
        }

        public void InsertEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                SqlCommand command = connection.CreateCommand();
                string sql = "insert into Employee values(@EmpId, '@Name', @Salary);";
                sql = sql.Replace("@EmpId", employee.EmployeeId.ToString());
                sql = sql.Replace("@Name", employee.FirstName + " " + employee.LastName);
                sql = sql.Replace("@Salary", employee.Salary.ToString());
                command.CommandText = sql;
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void AddEmployeeUsingStoredProcedure(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                SqlCommand command = new SqlCommand("spAddEmployee", connection);
                connection.Open();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@empId", employee.EmployeeId);
                command.Parameters.AddWithValue("@name", employee.FirstName + " " + employee.LastName);
                command.Parameters.AddWithValue("@salary", employee.Salary);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteEmployeeUsingStoredProcedure(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                SqlCommand command = new SqlCommand("spDeleteEmployeeById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@empId", employeeId);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
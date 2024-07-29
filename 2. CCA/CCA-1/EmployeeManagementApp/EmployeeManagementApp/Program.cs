using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EmployeeManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=ICS-LT-JMDM473\\SQLEXPRESS;Database=EmployeeManagement;Integrated Security=True;";

            //Inserting Data As Input -- using Stored Procedure..
            Console.Write("Enter Employee Name :  ");
            string empName = Console.ReadLine();

            Console.Write("Enter Employee Salary : ");
            decimal empSal;
            while (!decimal.TryParse(Console.ReadLine(), out empSal) || empSal < 25000)
            {
                Console.Write("Invalid input. Enter a valid salary (>=25000): ");
            }

            Console.Write("Enter Employee Type (F/P) :  ");
            char empType;
            while (!char.TryParse(Console.ReadLine().ToUpper(), out empType) || (empType != 'F' && empType != 'P'))
            {
                Console.Write("Invalid input. Enter a valid employee type (F/P): ");
            }

            InsertEmployee(connectionString, empName, empSal, empType);

            //Display 
            Console.WriteLine();
            List<Employee> employees = GetAllEmployees(connectionString);
            DisplayEmployees(employees);

            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Press Any Key To Exit...!!");
        }

        static void InsertEmployee(string connectionString, string empName, decimal empSal, char empType)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("AddEmployee", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@EmpName", empName);
                command.Parameters.AddWithValue("@Empsal", empSal);
                command.Parameters.AddWithValue("@Emptype", empType);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        static List<Employee> GetAllEmployees(string connectionString)
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Employee_Details";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = new Employee
                    {
                        Empno = reader.GetInt32(reader.GetOrdinal("Empno")),
                        EmpName = reader.GetString(reader.GetOrdinal("EmpName")),
                        Empsal = reader.GetDecimal(reader.GetOrdinal("Empsal")),
                        Emptype = reader.GetString(reader.GetOrdinal("Emptype"))[0]   //This will get first char.
                    };
                    employees.Add(employee);
                }
            }

            return employees;
        }

        static void DisplayEmployees(List<Employee> employees)
        {
            Console.WriteLine("Employee Details:");
            foreach (var emp in employees)
            {
                Console.WriteLine($"Empno: {emp.Empno}, EmpName: {emp.EmpName}, Empsal: {emp.Empsal}, Emptype: {emp.Emptype}");
            }
        }
    }
}

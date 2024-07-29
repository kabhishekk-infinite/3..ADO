using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

//AOD Assignment-1

namespace EmployeeApp_A1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = GetEmployeesFromDatabase();
            PerformQueries(empList);

            Console.ReadKey();

            Console.WriteLine("\n\nPress Any Key To Exit");
        }

        static List<Employee> GetEmployeesFromDatabase()
        {
            string connectionString  = "Server=ICS-LT-JMDM473\\SQLEXPRESS;Database=EmployeeDB_A1;Integrated Security=True";
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Employees";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = new Employee
                    {
                        EmployeeID = (int)reader["EmployeeID"],
                        FirstName  = (string)reader["FirstName"],
                        LastName   = (string)reader["LastName"],
                        Title      = (string)reader["Title"],
                        DOB        = (DateTime)reader["DOB"],
                        DOJ        = (DateTime)reader["DOJ"],
                        City       = (string)reader["City"]
                    };

                    employees.Add(employee);
                }
            }

            return employees;
        }

        static void PerformQueries(List<Employee> empList)
        {
            //Q_1.>
            var before2015 = empList.Where(emp => emp.DOJ < new DateTime(2015, 1, 1));
            Console.WriteLine("Employees who joined before 1/1/2015:");
            foreach (var emp in before2015)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName}");
            }

            //Q_2.>
            var after1990 = empList.Where(emp => emp.DOB > new DateTime(1990, 1, 1));
            Console.WriteLine("\nEmployees born after 1/1/1990:");
            foreach (var emp in after1990)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName}");
            }

            //Q_3.>
            var consultantsAndAssociates = empList.Where(emp => emp.Title == "Consultant" || emp.Title == "Associate");
            Console.WriteLine("\nConsultants and Associates:");
            foreach (var emp in consultantsAndAssociates)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName}");
            }

            //Q_4.>
            Console.WriteLine($"\nTotal number of employees: {empList.Count}");

            //Q_5.>
            var inChennai = empList.Count(emp => emp.City == "Chennai");
            Console.WriteLine($"\nTotal number of employees in Chennai: {inChennai}");

            //Q_6.>
            var highestID = empList.Max(emp => emp.EmployeeID);
            Console.WriteLine($"\nHighest Employee ID: {highestID}");

            //Q_7.>
            var after2015 = empList.Count(emp => emp.DOJ > new DateTime(2015, 1, 1));
            Console.WriteLine($"\nTotal number of employees who joined after 1/1/2015: {after2015}");

            //Q_8.>
            var notAssociates = empList.Count(emp => emp.Title != "Associate");
            Console.WriteLine($"\nTotal number of employees whose designation is not Associate: {notAssociates}");

            //Q_9.>
            var byCity = empList.GroupBy(emp => emp.City)
                                .Select(g => new { City = g.Key, Count = g.Count() });
            Console.WriteLine("\nTotal number of employees based on City:");
            foreach (var group in byCity)
            {
                Console.WriteLine($"{group.City}: {group.Count}");
            }

            //Q_10.>
            var byCityAndTitle = empList.GroupBy(emp => new { emp.City, emp.Title })
                                        .Select(g => new { g.Key.City, g.Key.Title, Count = g.Count() });
            Console.WriteLine("\nTotal number of employees based on City and Title:");
            foreach (var group in byCityAndTitle)
            {
                Console.WriteLine($"{group.City}, {group.Title}: {group.Count}");
            }

            //Q_11.>
            var youngestDOB = empList.Min(emp => emp.DOB);
            var youngestEmployee = empList.First(emp => emp.DOB == youngestDOB);
            Console.WriteLine($"\nYoungest employee: {youngestEmployee.FirstName} {youngestEmployee.LastName}");
        }
    }
}

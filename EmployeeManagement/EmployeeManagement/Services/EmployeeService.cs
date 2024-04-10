using MySqlConnector;
using System.Collections.Generic;
using EmployeeManagement.Data;
using Microsoft.Maui.Controls;
// Employee service to interact with the database
public class EmployeeService
{
    private readonly string connectionString; // Connection string to database

    public EmployeeService()
    {
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder()
        {
            Server = "localhost",
            Database = "employeemanagement",
            UserID = "root",
            Password = "password",
        };

        connectionString = builder.ConnectionString;
    }

    public async Task<List<Employee>> GetEmployeesAsync()
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            await connection.OpenAsync();
            var command = new MySqlCommand("SELECT * FROM Employees", connection);
            using (var reader = await command.ExecuteReaderAsync())
            {
                var employees = new List<Employee>();
                while (await reader.ReadAsync())
                {
                    employees.Add(new Employee
                    {
                        EmployeeId = reader.GetInt32("employee_id"),
                        FirstName = reader.GetString("first_name"),
                        LastName = reader.GetString("last_name"),
                        DepartmentId = reader.GetInt32("department_id"),
                        PositionTitle = reader.GetString("position_title"),
                        BaseSalary = reader.GetDecimal("base_salary")
                    });
                }
                return employees;
            }
        }
    }

    
}

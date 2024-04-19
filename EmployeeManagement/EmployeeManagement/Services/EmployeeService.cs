using Oracle.ManagedDataAccess.Client;
using EmployeeManagement.Models;
using System.Data;

namespace EmployeeManagement.Services
{
    public class EmployeeService
    {
        private string connectionString;

        public EmployeeService(string user, string pwd, string db)
        {
            connectionString = $"User ID={user};Password={pwd};Data Source={db};";
        }



        public bool AddEmployee(Employee employee)
        {
            string query = "INSERT INTO employee (first_name, last_name, department_id, position_id, base_salary) VALUES (:firstName, :lastName, :department, :position, :baseSalary)";
            using (OracleConnection con = new OracleConnection(connectionString))
            {
                OracleCommand cmd = new OracleCommand(query, con);
                cmd.Parameters.Add("firstName", OracleDbType.Varchar2).Value = employee.FirstName;
                cmd.Parameters.Add("lastName", OracleDbType.Varchar2).Value = employee.LastName;
                cmd.Parameters.Add("department", OracleDbType.Int32).Value = int.Parse(employee.Department); 
                cmd.Parameters.Add("position", OracleDbType.Int32).Value = int.Parse(employee.Position);    
                cmd.Parameters.Add("baseSalary", OracleDbType.Decimal).Value = employee.BaseSalary;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery(); 
                    return true;
                }
                catch (Exception ex)
                {
                    
                    System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        public string GetConnectionString()
        {
            return connectionString;
        }
    }
}

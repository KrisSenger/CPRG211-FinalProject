using Oracle.ManagedDataAccess.Client;
using EmployeeManagement.Models;

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
            string query = "INSERT INTO employee (first_name, last_name, department, position, base_salary) VALUES (:firstName, :lastName, :department, :position, :baseSalary)";
            using (OracleConnection con = new OracleConnection(connectionString))
            {
                OracleCommand cmd = new OracleCommand(query, con);
                cmd.Parameters.Add("firstName", OracleDbType.Varchar2).Value = employee.FirstName;
                cmd.Parameters.Add("lastName", OracleDbType.Varchar2).Value = employee.LastName;
                cmd.Parameters.Add("department", OracleDbType.Varchar2).Value = employee.Department;
                cmd.Parameters.Add("position", OracleDbType.Varchar2).Value = employee.Position;
                cmd.Parameters.Add("baseSalary", OracleDbType.Decimal).Value = employee.BaseSalary;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    // Log exception or handle it appropriately
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

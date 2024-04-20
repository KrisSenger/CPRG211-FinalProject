using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class EditEmployee
    {
        public static string user = "cprg211";
        public static string pwd = "password";
        public static string db = "localhost/XE";

        public class Employee
        {
            public int EmployeeID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string DeptName { get; set; }
            public string PositionTitle { get; set; }
            public double BaseSalary { get; set; }
        }

        public Employee GetEmployeeByID(int employeeID)
        {
            string query = "SELECT first_name, last_name, dept_name, position_title, base_salary FROM EMPLOYEE NATURAL JOIN department NATURAL JOIN position WHERE employee_id = :employeeID";
            string connectUser = "User ID=" + user + ";Password=" + pwd + ";Data Source=" + db + ";";
            Employee employee = null;

            using (OracleConnection con = new OracleConnection(connectUser))
            {
                OracleCommand cmd = new OracleCommand(query, con);
                cmd.Parameters.Add(":employeeID", OracleDbType.Int32).Value = employeeID;
                con.Open();

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        employee = new Employee();
                        employee.EmployeeID = employeeID;
                        employee.FirstName = reader.GetString(0);
                        employee.LastName = reader.GetString(1);
                        employee.DeptName = reader.GetString(2);
                        employee.PositionTitle = reader.GetString(3);
                        employee.BaseSalary = reader.GetDouble(4);
                    }
                }
            }
            return employee;
        }

        public void UpdateEmployee(Employee employee)
        {
            string query = "UPDATE EMPLOYEE " +
               "SET first_name = :firstName, last_name = :lastName, " +
               "department_id = (SELECT department_id FROM department WHERE dept_name = :deptName), " +
               "position_id = (SELECT position_id FROM position WHERE position_title = :positionTitle), " +
               "base_salary = :baseSalary " +
               "WHERE employee_id = :employeeID";
            string connectUser = "User ID=" + user + ";Password=" + pwd + ";Data Source=" + db + ";";

            using (OracleConnection con = new OracleConnection(connectUser))
            {
                OracleCommand cmd = new OracleCommand(query, con);
                cmd.Parameters.Add(":firstName", OracleDbType.Varchar2).Value = employee.FirstName;
                cmd.Parameters.Add(":lastName", OracleDbType.Varchar2).Value = employee.LastName;
                cmd.Parameters.Add(":deptName", OracleDbType.Varchar2).Value = employee.DeptName;
                cmd.Parameters.Add(":positionTitle", OracleDbType.Varchar2).Value = employee.PositionTitle;
                cmd.Parameters.Add(":baseSalary", OracleDbType.Double).Value = employee.BaseSalary;
                cmd.Parameters.Add(":employeeID", OracleDbType.Int32).Value = employee.EmployeeID;

                con.Open();
                // prevents program from crashing
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Execution of database command failed!");
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void DeleteEmployee(int employeeID)
        {
            string query = "DELETE FROM EMPLOYEE WHERE employee_id = :employeeID";
            string connectUser = "User ID=" + user + ";Password=" + pwd + ";Data Source=" + db + ";";

            using (OracleConnection con = new OracleConnection(connectUser))
            {
                OracleCommand cmd = new OracleCommand(query, con);
                cmd.Parameters.Add(":employeeID", OracleDbType.Int32).Value = employeeID;

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
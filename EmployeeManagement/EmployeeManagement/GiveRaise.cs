using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class GiveRaiseBonus
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
            public double Bonus { get; set; }
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
        public void NewSalaryBonus(Employee employee)
        {
            string query = "UPDATE EMPLOYEE " +
               "SET base_salary = :baseSalary, " +
               "bonuses = :bonus " +
               "WHERE employee_id = :employeeID";
            string connectUser = "User ID=" + user + ";Password=" + pwd + ";Data Source=" + db + ";";

            using (OracleConnection con = new OracleConnection(connectUser))
            {
                OracleCommand cmd = new OracleCommand(query, con);
                cmd.Parameters.Add(":baseSalary", OracleDbType.Double).Value = employee.BaseSalary;
                cmd.Parameters.Add(":bonus", OracleDbType.Double).Value = employee.Bonus;
                cmd.Parameters.Add(":employeeID", OracleDbType.Int32).Value = employee.EmployeeID;

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
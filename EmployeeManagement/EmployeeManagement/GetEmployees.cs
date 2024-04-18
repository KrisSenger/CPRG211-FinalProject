using Oracle.ManagedDataAccess.Client;

namespace EmployeeManagement
{
    public class GetEmployee
    {

        public static string user = "cprg211";
        public static string pwd = "password";
        public static string db = "localhost/XE";


        public class Employee
        {
            public int EmployeeID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public double BaseSalary { get; set; }
            public double Bonuses { get; set; }
            public double TotalComp { get; set; }
            public int DepartmentID { get; set; }
            public string DeptName { get; set; }
            public int PositionID { get; set; }
            public string PositionTitle { get; set; }
        }


        public List<Employee> GetEmployees()
        {
            string query = "SELECT employee_id, first_name, last_name, base_salary, bonuses, SUM(base_salary + bonuses) AS \"Total Comp\", department_id, dept_name, position_id, position_title FROM EMPLOYEE NATURAL JOIN department NATURAL JOIN position  GROUP BY employee_id, first_name, last_name, base_salary, bonuses, department_id, dept_name, position_id, position_title ORDER BY employee_id";
            string connectUser = "User ID=" + user + ";Password=" + pwd + ";Data Source=" + db + ";";
            List<Employee> empList = new List<Employee>();

            using (OracleConnection con = new OracleConnection(connectUser))
            {
                OracleCommand cmd = new OracleCommand(query, con);
                cmd.Connection.Open();
                using (OracleDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmployeeID = reader.GetInt32(0);
                        employee.FirstName = reader.GetString(1);
                        employee.LastName = reader.GetString(2);
                        employee.BaseSalary = reader.GetDouble(3);
                        employee.Bonuses = reader.GetDouble(4);
                        employee.TotalComp = reader.GetDouble(5);
                        employee.DepartmentID = reader.GetInt32(6);
                        employee.DeptName = reader.GetString(7);
                        employee.PositionID = reader.GetInt32(8);
                        employee.PositionTitle = reader.GetString(9);

                        empList.Add(employee);
                    }
                    reader.Close();
                }
                cmd.Connection.Close();
            }
            return empList;
        }
    }
}
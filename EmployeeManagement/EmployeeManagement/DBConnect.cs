using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;


namespace EmployeeManagement
{
    class DatabaseConnect
    {
        public static string user = "cprg211";
        public static string pwd = "password";
        public static string db = "localhost/XE";

        public bool DBConnect()
        {
            string connectUser = "User ID=" + user + ";Password=" + pwd + ";Data Source=" + db + ";";
            
            using (OracleConnection con = new OracleConnection(connectUser))
            {
                using (OracleCommand cmd = con.CreateCommand()) 
                { 
                    try
                    {
                        con.Open();
                        return true;
                    }
                    catch (Exception ex)  
                    {
                        Application.Current.MainPage.DisplayAlert("Cannot connect", "Please Try again later", "OK");
                        return false;
                    }
                }
            }
        }
        
        public void Update()
        {
            string query = "UPDATE employee SET base_salary = 1.99 WHERE first_name = 'Roger' AND last_name = 'Rabbit'";
            string connectUser = "User ID=" + user + ";Password=" + pwd + ";Data Source=" + db + ";";

            using (OracleConnection con = new OracleConnection(connectUser))
            {
                OracleCommand cmd = new OracleCommand(query, con);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }
    }
}



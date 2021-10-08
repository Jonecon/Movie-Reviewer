using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace TeamMCJ
{
    class OSQL
    {
        //connecting to database
        private static string oradb = "Data Source=TeamMCJ;User Id=SYSTEM;Password=YOURPW;";
        public static OracleConnection conn = new OracleConnection(oradb);
        public static OracleCommand cmd = new OracleCommand();
        public static OracleDataReader reader;

        public static void selectQuery(string query)
        {
            try
            {
                //Setup Connection
                conn.Close();
                conn.Open();
                cmd.Connection = conn;
                
                //Set and execute the query
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                reader = cmd.ExecuteReader();

                //conn.Dispose();
            }
            catch (Exception eOSQLSQ)
            {
                //Show error
                MessageBox.Show("Error: " + eOSQLSQ.Message, "Error");
                return;
            }
        }

        public static void executeQuery(string query)
        {
            //try catch to catch any unforseen errors gracefully
            try
            {
                //Setup connection
                conn.Close();
                conn.Open();
                cmd.Connection = conn;

                //Set and execute the query
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception eOSQLEQ)
            {
                //Show error
                MessageBox.Show("Error: " + eOSQLEQ.Message, "Error");
                return;
            }
        }
    }
}

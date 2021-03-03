using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OneFile_AMRCheck
{
    class DataBaseCommClass
    {
    }
    public static class Utilities
    {
        #region Check For Null String

        public static string CheckForNullString(string s)
        {
            string str = (s == null) ? string.Empty : s;
            return str;
        }

        public static T CheckForNull<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return default(T); // returns the default value for the type
            }
            else
            {
                return (T)obj;
            }
        }

        public static string CheckForNull(object obj)
        {
            if (!DBNull.Value.Equals(obj))
                return (string)obj;
            else return string.Empty;
        }


        #endregion Check For Null String

        #region Execute Query

        public static DataTable ExecuteQuery(string query, string connectionString)
        {
            DataTable table = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        conn.Open();

                        adapter.Fill(table);

                        conn.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message + Environment.NewLine + ex.Source + Environment.NewLine + ex.StackTrace,
                    "Program Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return table;
        }

        #endregion Execute Query
    }
    public class Program_SQL
    {
        public int number = 0;
        string MessageFromDatabase;


        private const string dbUsername = "power";              //make the database changes her and they will be reflected in all function
        private const string dbPassword = "power";
        private const string dbNetworkServerName = @"Netserver3;";
        //public string dbNameofDatabase;


        public string ConnectionStringBuilder(string Database)
        {
            string dbNameOfDatabase;
            //Form F1 = new Form();
            //dbNameOfDatabase = DatabaseChange ? "ReturnsVision" : "LoraVision";
            dbNameOfDatabase = Database;
            string connectionstring = "Server=" + dbNetworkServerName + " Database=" + dbNameOfDatabase + "; User=" + dbUsername + "; Password=" + dbPassword + ";";
            return connectionstring;
        }

        #region GrabWithMeterID
        public string GrabADatabaseWithMeterID(string Database, string MeterID, string columnToAccessFromDB) // meterId to check the MAr already exists or not
        {

            string query = "select dbo.Meter." + columnToAccessFromDB + " from dbo.Meter where dbo.Meter.MeterID =" + "'" + MeterID + "'"; //Batch, MeterID

            DataTable dt = Utilities.ExecuteQuery(query, ConnectionStringBuilder(Database));

            if (dt.Rows.Count <= 0)
                return "NODATA";

            foreach (DataRow dr in dt.Rows)
            {
                MessageFromDatabase = Utilities.CheckForNullString(Utilities.CheckForNull<string>(dr[columnToAccessFromDB]));
            }
            return MessageFromDatabase;
        }
        #endregion GrabWithMeterID

        #region PostDataToAMRCheck

        public string PostDataToAMRCheck(string MeterId, DateTime date, string initialofUser, string IPaddress, string Database)//for AMR check
        {
            try
            {
                string query = "UPDATE dbo.Meter set AMRchkBy = " + "'" + "" + "'" + ",AMRchkDate = " + "'" + "" + "'" + ",IPaddress = " + "'" + "" + "'"+ ",SimCardRegDate = " + "'" + "" + "'" + " where MeterID =" + "'" + MeterId + "'";


                DataTable dt = Utilities.ExecuteQuery(query, ConnectionStringBuilder(Database));

                query = "UPDATE dbo.Meter set AMRchkBy = " + "'" + initialofUser + "'" + ",AMRchkDate = " + "'" + date + "'" + ",IPaddress = " + "'" + IPaddress+ "'" + ",SimCardregDate = " + "'" + date + "'" + " where MeterID =" + "'" + MeterId + "'";


                dt = Utilities.ExecuteQuery(query, ConnectionStringBuilder(Database));

                foreach (DataRow dr in dt.Rows)
                {
                    MessageFromDatabase = Utilities.CheckForNullString(Utilities.CheckForNull<string>(dr[MeterId]));
                }
                return MessageFromDatabase;

            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message + Environment.NewLine + Environment.NewLine +
                    e.StackTrace + Environment.NewLine + Environment.NewLine +
                    e.Source,
                    "Program Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }

        #endregion PostDataToAMRCheck
    }
}

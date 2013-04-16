using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
/*
Done by Asbjørn Birch 
 */
namespace itn0912_2DBLayer.DBLayer
{
    class DBConnection
    {

        public static readonly string connectingString = @"Data Source=W-SQL\SQLEXPRESS;Initial Catalog=Warehouse;Integrated Security=True";
        //public static readonly string connectingString = @"Server=balder.ucn.dk;Database=itn0912_2;User id=itn0912_2;Password=IsAllowed;";
        //public static readonly string connectingString = @"Data Source=Koen-win7\SQLEXPRESS;Initial Catalog=Warehouse;Integrated Security=True";
        public static readonly SqlConnection dbconn = new SqlConnection(connectingString);

        private static SqlCommand dbCmd;
        //private static SqlCommand command = null;

        private static void Open()
        {
            if (dbconn.State.ToString().CompareTo("Open") != 0)
                try
                {
                    dbconn.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine("problem with open");
                    Console.WriteLine(e);

                }
        }

        public static void Close()
        {
            dbconn.Close();
        }
        public static SqlConnection getConnection()
        {
            if (dbconn.State.ToString().CompareTo("Open") != 0)
                Open();
            return dbconn;
        }

        public static SqlCommand GetDbCommand(string sql)
        {
            if (dbconn.State.ToString().CompareTo("Open") != 0)
                Open();
            if (dbCmd == null)
            {
                dbCmd = new SqlCommand(sql, dbconn);
            }
            dbCmd.CommandText = sql;
            return dbCmd;
        }

       

    }
}

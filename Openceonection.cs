using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace BSSAPI
{
    public class Openceonection
    {
        public static string _connectionString = "User Id=ltc;Password=ltc$123;Data Source=10.30.5.24:1521/bssdb";
        public static OracleConnection conn;

        public static void connectString()
        {
            conn = new OracleConnection();
            if (conn.State == ConnectionState.Open)
            {
                conn.Clone();
            }
            else
            {
                try
                {
                    conn.ConnectionString = _connectionString;
                    conn.Open();
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Connection failed: " + conn.ConnectionString);
                    throw;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace lab6
{
    public class DBConnection
    {
        private DBConnection() { }

        private static DBConnection m_connection = null;

        public static DBConnection Instance()
        {
            if (m_connection == null)
                m_connection = new DBConnection();
            return m_connection;
        }

        private SqlConnection connection =
            new SqlConnection(@"Server=127.0.0.1,1433;
                                Database=UniversityDB_Dormanchuk;
                                User Id=sa;Password=94Aguher;
                                TrustServerCertificate=True;
                                Connect Timeout=30");

        public void Open()
        {
            connection.Open();
        }

        public void Close()
        {
            connection.Close();
        }

        public SqlConnection Connection
        {
            get { return connection; }
        }
    }
}
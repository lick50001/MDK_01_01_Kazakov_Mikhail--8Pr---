using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Kazakov.Classes.Common
{
    public class DBConnection
    {
        public static readonly string Path = @"";

        public static OleDbConnection Conn()
        {
            OleDbConnection oleConn = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Sourse=" + Path);
            oleConn.Open();

            return oleConn;
        }

        public static OleDbDataReader Query(string Query, OleDbConnection conn) { 
            // Создать команду
            return new OleDbCommand(Query, conn).ExecuteReader();    
        }

        public static void CloseConnection(OleDbConnection conn)
        {
            conn.Close();
        }
    }
}

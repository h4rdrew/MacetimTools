using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace MacetimTools.Class
{
    class Banco
    {
        public static void newdb()
        {
            string curFile = @"C:\Program Files\Macetim\iplist.db";

            if(File.Exists(curFile) == false)
            {
                string cs = @"URI=file:C:\Program Files\Macetim\iplist.db";
                using var con = new SQLiteConnection(cs);
                con.Open();

                using var cmd = new SQLiteCommand(con);

                cmd.CommandText = "DROP TABLE IF EXISTS iplist";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"CREATE TABLE iplist(ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    IP STRING (15), NAME STRING)";
                cmd.ExecuteNonQuery();

                //cmd.CommandText = "INSERT INTO iplist(IP, NAME) VALUES('192.168.0.1','h4rdrew')";
                //cmd.ExecuteNonQuery();
            }
        }

        public static void dbInsert(string IP, string NAME)
        {
            string cs = @"URI=file:C:\Program Files\Macetim\iplist.db";

            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = $"INSERT INTO iplist(IP, NAME) VALUES('{IP}','{NAME}')";
            cmd.ExecuteNonQuery();
        }
    }
}

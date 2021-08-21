using Simple.DatabaseWrapper.Attributes;
using Simple.Sqlite;
using System.Collections.Generic;
using System.Linq;

namespace MacetimTools.Class
{
    class Banco
    {
        static SqliteDB db;
        public static void initializeDb()
        {
            string curFile = @"C:\Program Files\Macetim\iplist.db";
            db = new SqliteDB(curFile);
            var result = db.CreateTables()
                           .Add<iplist>()
                           .Commit();
        }

        public static void dbInsert(string IP, string NAME)
        {
            //string cs = @"URI=file:C:\Program Files\Macetim\iplist.db";

            //using var con = new SQLiteConnection(cs);
            //con.Open();

            //using var cmd = new SQLiteCommand(con);

            //cmd.CommandText = $"INSERT INTO iplist(IP, NAME) VALUES('{IP}','{NAME}')";
            //cmd.ExecuteNonQuery();

            db.Insert(new iplist()
            {
                IP = IP,
                NAME = NAME,
            });
        }

        public static void dbDelete(string IP)
        {
            db.Execute("delete from iplist where IP = @IP", new { IP });
        }

        public static IEnumerable<iplist> ObterIps()
        {
            return db.GetAll<iplist>();
        }
    }
    public class iplist
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string IP { get; set; }
        public string NAME { get; set; }

        public string IpSort()
        {
            var partes = IP.Split('.');
            var numeros = partes.Select(p => int.Parse(p));
            var numeros3 = numeros.Select(p => p.ToString("000"));
            return string.Join(".", numeros3);
        }

    }
}

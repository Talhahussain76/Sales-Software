using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TALHA_PROJECTS_PRACTICE
{
    internal class ConnectDatabasePos
    {
        public static void MainTalha()
        {
            TalhaConnectionstring.connect();
        }
    }
    public class TalhaConnectionstring
    {
        public static SqlConnection conn;

        public static void connect()
        {
            String constr = "Data Source=DESKTOP-5THQGM6\\SQLEXPRESS;Initial Catalog=POSTalha;Integrated Security=True";
            conn = new SqlConnection(constr);
            conn.Open();
        }

    }

   

}

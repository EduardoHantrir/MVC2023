using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace MVC2023.DAL
{
    internal class utilsDAL
    {

        public static MySqlConnection GetConnection()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                Database = "cad_alunos",
                UserID = "root",
                Password = "",
            };
            
            MySqlConnection connection = new MySqlConnection (builder.ConnectionString);
            connection.Open ();

            return connection;
        }
    }
}

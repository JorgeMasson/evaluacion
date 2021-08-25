using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConfigEval
{
    class clsManejador
    {
        string stringConnection = "DataSource=localhost;port=3306;username=root;password=hcpk8546;database=db_test;";
        public void Ejecutar(string sql)
        {
            MySqlConnection conexion = new MySqlConnection(stringConnection);
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.ExecuteNonQuery();
        }
    }
}

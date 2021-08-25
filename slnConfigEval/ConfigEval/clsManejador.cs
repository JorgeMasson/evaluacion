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
        string cadenaConexion = "DataSource=localhost;port=3306;username=root;password=hcpk8546;database=db_test;";
        
        //Se conecta a la base de datos
        private MySqlConnection ConectarBD()
        {
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            return conexion;
        }

        //Cierra la conexion
        private void CerrarConexion(MySqlConnection conexion)
        {
            conexion.Close();
        }
        
        public void Ejecutar(string sql)
        {
            //Llamando al método conectarBD
            MySqlConnection conexion = ConectarBD();            
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.ExecuteNonQuery();
            CerrarConexion(conexion);
        }
    }
}

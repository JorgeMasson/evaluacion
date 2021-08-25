using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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

        //Crea el archivo xml
        public void GeneraXML()
        {
            XmlWriter xmlWritter = XmlWriter.Create("test.xml");

            MySqlConnection conexion = ConectarBD();
            string sql = "select * from Employees";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int numeroRows = dt.Rows.Count;
            DataRow row;

            xmlWritter.WriteStartDocument();

            xmlWritter.WriteStartElement("Employees");

            for (int i = 0; i < numeroRows; i++)
            {
                row = dt.Rows[i];
                xmlWritter.WriteStartElement("Employee");
                xmlWritter.WriteAttributeString("ID", row["EmployeeID"].ToString());
                xmlWritter.WriteStartElement("LastName");
                xmlWritter.WriteString(row["LastName"].ToString());
                xmlWritter.WriteEndElement();
                xmlWritter.WriteStartElement("FirstName");
                xmlWritter.WriteString(row["FirstName"].ToString());
                xmlWritter.WriteEndElement();
                xmlWritter.WriteStartElement("DateOfBirth");
                xmlWritter.WriteString(row["DateOfBirth"].ToString());
                xmlWritter.WriteEndElement();
                xmlWritter.WriteEndElement();
            }

            xmlWritter.WriteEndDocument();
            xmlWritter.Close();
        }
    }
}

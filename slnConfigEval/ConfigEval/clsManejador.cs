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
                string id = row["EmployeeID"].ToString();
                string dob = row["DateOfBirth"].ToString();
                if (id.Length < 8 | dob.Length < 8)
                {
                    id = id.PadLeft(8, '0');
                    dob = dob.PadLeft(8, '0');
                }
                string primerDiagonal = dob.Insert(2, "/");
                string formatoFecha = primerDiagonal.Insert(5, "/");

                xmlWritter.WriteStartElement("Employee");
                xmlWritter.WriteAttributeString("ID", id);
                xmlWritter.WriteStartElement("LastName");
                xmlWritter.WriteString(row["LastName"].ToString());
                xmlWritter.WriteEndElement();
                xmlWritter.WriteStartElement("FirstName");
                xmlWritter.WriteString(row["FirstName"].ToString());
                xmlWritter.WriteEndElement();
                xmlWritter.WriteStartElement("DateOfBirth");
                xmlWritter.WriteString(formatoFecha);
                xmlWritter.WriteEndElement();
                xmlWritter.WriteEndElement();
            }

            xmlWritter.WriteEndDocument();
            xmlWritter.Close();
        }
    }
}

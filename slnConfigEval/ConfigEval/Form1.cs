using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ConfigEval
{
    public partial class Form1 : Form
    {
        clsManejador manejador = new clsManejador();
        public Form1()
        {
            InitializeComponent();
        }

        private void BorrarCampos(Control control)
        {
            foreach (var txt in control.Controls)
            {
                if (txt is TextBox)
                {
                    ((TextBox)txt).Clear();
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string sql = "insert into Employees values('" + txtEmployeeId.Text + "', '" + txtLastName.Text + "', '" + txtFirstName.Text + "', '" + txtDateOfBirth.Text + "')";
            manejador.Ejecutar(sql);
            MessageBox.Show("Empleado agregado con éxito");
            BorrarCampos(this);
        }

        private void btnCreateXmlFile_Click(object sender, EventArgs e)
        {
            try
            {
                manejador.GeneraXML();
                System.Diagnostics.Process.Start(@"..\Debug\test.xml");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex);
            }
        }

        private void btnCreateTextFile_Click(object sender, EventArgs e)
        {
            try
            {
                manejador.GeneraTXT();
                System.Diagnostics.Process.Start(@"..\Debug\test.txt");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex);
            }
        }
    }
}

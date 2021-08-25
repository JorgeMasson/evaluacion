using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into Employees values('" + txtEmployeeId.Text + "', '" + txtLastName.Text + "', '" + txtFirstName.Text + "', '" + txtDateOfBirth.Text + "')";
                manejador.Ejecutar(sql);
                MessageBox.Show("Empleado agregado con éxito");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex);
            }
        }
    }
}

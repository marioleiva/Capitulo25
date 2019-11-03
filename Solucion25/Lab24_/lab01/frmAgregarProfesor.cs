using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyWin_Lab24
{
    public partial class frmAgregarProfesor : Form
    {
        public frmAgregarProfesor()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Profesor objProfesor = new Profesor();
                objProfesor.Nombre = txtNombreProfesor.Text;
                objProfesor.Apellidos = txtApellidos.Text;

                conexion objConexion = new conexion();
                int resultado = objConexion.ProfesorInsertarSP(objProfesor);
                if (resultado == 1)
                    MessageBox.Show("Insertado Correctamente");
                else
                    MessageBox.Show("Ocurrió un error");
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

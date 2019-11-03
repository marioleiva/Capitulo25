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
    public partial class FrmEditarProfesor : Form
    {
        public FrmEditarProfesor()
        {
            InitializeComponent();
        }

        public void Cargar(Profesor objProfesor)
        {
            txtId.Text = objProfesor.Id.ToString();
            txtNombre.Text = objProfesor.Nombre;
            txtApellidoProfesor.Text = objProfesor.Apellidos;
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //txtApellidoProfesor
            Profesor objProfesor = new Profesor();
            objProfesor.Id = int.Parse(txtId.Text);
            objProfesor.Nombre = txtNombre.Text;
            objProfesor.Apellidos = txtApellidoProfesor.Text;
            //objCurso.Duracion = Convert.ToInt32(txtDuracion.Text);

            conexion objConexion = new conexion();
            int resultado = objConexion.ProfesorEditarSP(objProfesor);
            if (resultado == 1)
                MessageBox.Show("Editado correctamente");
            else
                MessageBox.Show("Ocurrió un error");
            this.Close();


        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

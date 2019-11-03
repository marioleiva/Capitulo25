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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar();
            CargarProfesor();
        }
        
        private void Cargar()
        {
            conexion objConexion = new conexion();
            dataGridView1.DataSource = objConexion.CursoListarSP();
        }

        private void CargarProfesor()
        {
            conexion objConexion = new conexion();
            dataGridView2.DataSource = objConexion.ProfesorListarSP();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmAgregar frm = new frmAgregar();
            frm.ShowDialog();
            Cargar();
            CargarProfesor();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            curso objCurso = new curso();
            objCurso.Nombre = dataGridView1.SelectedRows[0].Cells["nombre"].Value.ToString();
            objCurso.Duracion = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["duracion"].Value.ToString());
            objCurso.Descripcion = dataGridView1.SelectedRows[0].Cells["descripcion"].Value.ToString();
            
            frmEditar frm = new frmEditar();
            frm.Cargar(objCurso);
            frm.ShowDialog();
            Cargar();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                String nombre = dataGridView1.SelectedRows[0].Cells["Nombre"].Value.ToString();
                conexion objConexion = new conexion();
                int resultado = objConexion.CursoEliminarSP(nombre);
                if (resultado == 1)
                    MessageBox.Show("Curso eliminado satisfactoriamente");
                else
                    MessageBox.Show("Ocurrió un error");
                Cargar();
                CargarProfesor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion objConexion = new conexion();
                dataGridView1.DataSource = objConexion.CursoBUscarSP(txtNombre.Text);

                dataGridView2.DataSource = objConexion.ProfesorBuscarSP(txtNombre.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmAgregarProfesor frm = new frmAgregarProfesor();
            frm.ShowDialog();
            Cargar();
            CargarProfesor();


        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            try
            {
                String nombre = dataGridView2.SelectedRows[0].Cells["Id"].Value.ToString();
                conexion objConexion = new conexion();
                int resultado = objConexion.ProfesorEliminarSP(nombre);
                if (resultado == 1)
                    MessageBox.Show("Profesor eliminado satisfactoriamente");
                else
                    MessageBox.Show("Ocurrió un error");
                Cargar();
                CargarProfesor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Profesor objProfesor = new Profesor();
            objProfesor.Id = int.Parse(dataGridView2.SelectedRows[0].Cells["Id"].Value.ToString());
            objProfesor.Nombre = dataGridView2.SelectedRows[0].Cells["nombre"].Value.ToString();
            objProfesor.Apellidos = dataGridView2.SelectedRows[0].Cells["apellidos"].Value.ToString();

            FrmEditarProfesor frm = new FrmEditarProfesor();
            frm.Cargar(objProfesor);
            frm.ShowDialog();
            Cargar();
            CargarProfesor();
        }
    }
}

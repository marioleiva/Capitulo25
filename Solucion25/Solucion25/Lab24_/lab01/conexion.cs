using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace ProyWin_Lab24
{
    public class conexion
    {
        private String cadena = "Data Source=(local); Initial Catalog = BD_ESCUELA; Integrated Security = true ";
        //SqlConnection conexion = new SqlConnection("server=DIEGO-PC ; database=base1 ; integrated security = true");

        public List<curso> CursoListarSP()
        {
            List<curso> lstCursos = new List<curso>();
            try
            {
                SqlConnection conn = new SqlConnection(cadena);
                SqlDataAdapter da = new SqlDataAdapter("SP_Listar_cursos", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                da.Fill(ds, "cursos");
                for (int i = 0; i < (int)ds.Tables[0].Rows.Count; i++)
                {
                    curso objCurso = new curso();
                    objCurso.Nombre = ds.Tables[0].Rows[i]["nombre"].ToString();
                    objCurso.Duracion = Convert.ToInt32(ds.Tables[0].Rows[i]["duracion"].ToString());
                    objCurso.Descripcion = ds.Tables[0].Rows[i]["descripcion"].ToString();
                    lstCursos.Add(objCurso);
                }
                ds.Dispose();
                da.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCursos;
        }

        public int CursoInsertarSP(curso objCurso)
        {
            try
            {
                SqlConnection conn = new SqlConnection(cadena);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertarCurso", conn);
                //cmd.CommandType = CommandType.Text;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", objCurso.Nombre);
                cmd.Parameters.AddWithValue("@Duracion", objCurso.Duracion);
                cmd.Parameters.AddWithValue("@Descripcion", objCurso.Descripcion);
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Insertado Exitosamente");
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }
        public int CursoEliminarSP(String nombre)
        {
            try
            {
                SqlConnection conn = new SqlConnection(cadena);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_Eliminar_curso", conn);
                //cmd.CommandType = CommandType.Text;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Curso eliminado exitosamente");
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }
        public int CursoEditarSP(curso objCurso)
        {
            try
            {
                SqlConnection conn = new SqlConnection(cadena);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update_curso", conn);
                //cmd.CommandType = CommandType.Text;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", objCurso.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", objCurso.Descripcion);
                cmd.Parameters.AddWithValue("@Duracion", objCurso.Duracion);
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Curso editado satisfactoriamente");
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }
        //  CursoBUscarSP

        public int ProfesorEditarSP(Profesor objProfesor)
        {
            try
            {
                SqlConnection conn = new SqlConnection(cadena);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update_Profesor", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", objProfesor.Id);
                cmd.Parameters.AddWithValue("@nombre", objProfesor.Nombre);
                cmd.Parameters.AddWithValue("@apellidos", objProfesor.Apellidos);

                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Profesor editado satisfactoriamente");
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }

        public List<curso> CursoBUscarSP(String nombre)
        {
            List<curso> lstCursos = new List<curso>();
            try
            {
                SqlConnection conn = new SqlConnection(cadena);
                SqlDataAdapter da = new SqlDataAdapter("SP_Buscar", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Nombre", nombre);
             

                //da.SelectCommand.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                da.Fill(ds, "cursos");
                for (int i = 0; i < (int)ds.Tables[0].Rows.Count; i++)
                {
                    curso objCurso = new curso();
                    objCurso.Nombre = ds.Tables[0].Rows[i]["nombre"].ToString();
                    objCurso.Duracion = Convert.ToInt32(ds.Tables[0].Rows[i]["duracion"].ToString());
                    objCurso.Descripcion = ds.Tables[0].Rows[i]["descripcion"].ToString();
                    lstCursos.Add(objCurso);
                }
                ds.Dispose();
                da.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCursos;
        }
        public List<Profesor> ProfesorBuscarSP(String nombre)
        {
            List<Profesor> lstProfesor = new List<Profesor>();
            try
            {
                SqlConnection conn = new SqlConnection(cadena);
                SqlDataAdapter da = new SqlDataAdapter("SP_Buscar_Profesor", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Nombre", nombre);


                //da.SelectCommand.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                da.Fill(ds, "cursos");
                for (int i = 0; i < (int)ds.Tables[0].Rows.Count; i++)
                {
                    Profesor objProfesor = new Profesor();
                    objProfesor.Nombre = ds.Tables[0].Rows[i]["nombre"].ToString();
                    objProfesor.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    objProfesor.Apellidos = ds.Tables[0].Rows[i]["apellidos"].ToString();
                    lstProfesor.Add(objProfesor);
                }
                ds.Dispose();
                da.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProfesor;
        }

        public int ProfesorEliminarSP(String nombre)
        {
            try
            {
                SqlConnection conn = new SqlConnection(cadena);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_Eliminar_Profesor", conn);
                //cmd.CommandType = CommandType.Text;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", nombre);
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Curso eliminado exitosamente");
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }


        //public List<Profesor> ProfesorBUscarSP(String nombre)
        //{
        //    List<curso> lstCursos = new List<curso>();
        //    try
        //    {
        //        SqlConnection conn = new SqlConnection(cadena);
        //        SqlDataAdapter da = new SqlDataAdapter("SP_Buscar", conn);
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        da.SelectCommand.Parameters.AddWithValue("@Nombre", nombre);


        //        //da.SelectCommand.CommandType = CommandType.Text;
        //        DataSet ds = new DataSet();
        //        da.Fill(ds, "cursos");
        //        for (int i = 0; i < (int)ds.Tables[0].Rows.Count; i++)
        //        {
        //            curso objCurso = new curso();
        //            objCurso.Nombre = ds.Tables[0].Rows[i]["nombre"].ToString();
        //            objCurso.Duracion = Convert.ToInt32(ds.Tables[0].Rows[i]["duracion"].ToString());
        //            objCurso.Descripcion = ds.Tables[0].Rows[i]["descripcion"].ToString();
        //            lstCursos.Add(objCurso);
        //        }
        //        ds.Dispose();
        //        da.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lstCursos;
        //}

        public List<Profesor> ProfesorListarSP()
        {
            List<Profesor> lstProfesor = new List<Profesor>();
            try
            {
                SqlConnection conn = new SqlConnection(cadena);
                SqlDataAdapter da = new SqlDataAdapter("SP_Listar_Profesor", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "cursos");
                for (int i = 0; i < (int)ds.Tables[0].Rows.Count; i++)
                {
                    Profesor objProfesor = new Profesor();
                    objProfesor.Id = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                    objProfesor.Nombre = ds.Tables[0].Rows[i]["nombre"].ToString();
                    objProfesor.Apellidos = ds.Tables[0].Rows[i]["apellidos"].ToString();
                    lstProfesor.Add(objProfesor);
                }
                ds.Dispose();
                da.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProfesor;
        }

        public int ProfesorInsertarSP(Profesor objProfesor)
        {
            try
            {
                SqlConnection conn = new SqlConnection(cadena);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertarProfesor", conn);
                //cmd.CommandType = CommandType.Text;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", objProfesor.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", objProfesor.Apellidos);

                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Insertado Exitosamente");
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }

        //public int ProfesorEliminarSP(String nombre)
        //{
        //    try
        //    {
        //        SqlConnection conn = new SqlConnection(cadena);
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("SP_Eliminar_Profesor", conn);
        //        //cmd.CommandType = CommandType.Text;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@nombre", nombre);
        //        cmd.ExecuteNonQuery();
        //        conn.Close();
        //        Console.WriteLine("Curso eliminado exitosamente");
        //    }
        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }
        //    return 1;
        //}



















        public List<curso> CursoListar()
        {
            List<curso> lstCursos = new List<curso>();
            try
            {
                SqlConnection conn = new SqlConnection(cadena);
                SqlDataAdapter da = new SqlDataAdapter("select * from cursos", conn);
                da.SelectCommand.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                da.Fill(ds, "cursos");
                for (int i = 0; i < (int)ds.Tables[0].Rows.Count; i++)
                {
                    curso objCurso = new curso();
                    objCurso.Nombre = ds.Tables[0].Rows[i]["nombre"].ToString();
                    objCurso.Duracion = Convert.ToInt32(ds.Tables[0].Rows[i]["duracion"].ToString());
                    objCurso.Descripcion = ds.Tables[0].Rows[i]["descripcion"].ToString();
                    lstCursos.Add(objCurso);
                }
                ds.Dispose();
                da.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCursos;
        }

        public int CursoInsertar(curso objCurso)
        {
            try
            {
                SqlConnection conn = new SqlConnection(cadena);
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into cursos (nombre, duracion, descripcion) values(@Nombre, @Duracion, @Descripcion)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Nombre", objCurso.Nombre);
                cmd.Parameters.AddWithValue("@Duracion", objCurso.Duracion);
                cmd.Parameters.AddWithValue("@Descripcion", objCurso.Descripcion);
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Insertado Exitosamente");
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }
        public int CursoEliminar(String nombre)
        {
            try
            {
                SqlConnection conn = new SqlConnection(cadena);
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from cursos where nombre = @Nombre", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Curso eliminado exitosamente");
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }
        public int CursoEditar(curso objCurso)
        {
            try
            {
                SqlConnection conn = new SqlConnection(cadena);
                conn.Open();
                SqlCommand cmd = new SqlCommand("update cursos set Descripcion = @Descripcion, Duracion = @Duracion where Nombre = @Nombre", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Nombre", objCurso.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", objCurso.Descripcion);
                cmd.Parameters.AddWithValue("@Duracion", objCurso.Duracion);
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Curso editado satisfactoriamente");
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }
    }
}

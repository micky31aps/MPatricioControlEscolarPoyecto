using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        //public static ML.Result GetAll()
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            string query = "AlumnoGetAll";
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = query;
        //                cmd.Connection = context;
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        //                {
        //                    DataTable tableUsuario = new DataTable();
        //                    da.Fill(tableUsuario);
        //                    cmd.Connection.Open();
        //                    if (tableUsuario.Rows.Count > 0)
        //                    {
        //                        result.Objects = new List<object>();
        //                        foreach (DataRow row in tableUsuario.Rows)
        //                        {
        //                            ML.Alumno alumno = new ML.Alumno();
        //                            alumno.IdAlumno = int.Parse(row[0].ToString());
        //                            alumno.Nombre = row[1].ToString();
        //                            alumno.ApellidoPaterno = row[2].ToString();
        //                            alumno.ApellidoMaterno = row[3].ToString();
        //                            result.Objects.Add(alumno);
        //                        }
        //                        result.Correct = true;
        //                    }
        //                    else
        //                    {
        //                        result.Correct = false;
        //                        result.ErrorMessage = "No se encontraron registros en la tabla de Alumno";
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}
        //public static ML.Result GetById(int IdAlumno)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            string query = "AlumnoGetById";

        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = query;
        //                cmd.Connection = context;
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                SqlParameter[] collection = new SqlParameter[1];

        //                collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
        //                collection[0].Value = IdAlumno;

        //                cmd.Parameters.AddRange(collection);


        //                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        //                {
        //                    DataTable tableAlumno = new DataTable();

        //                    da.Fill(tableAlumno);

        //                    cmd.Connection.Open();

        //                    if (tableAlumno.Rows.Count > 0)
        //                    {
        //                        result.Objects = new List<object>();

        //                        DataRow row = tableAlumno.Rows[0];

        //                        ML.Alumno alumno = new ML.Alumno();
        //                        alumno.IdAlumno = int.Parse(row[0].ToString());
        //                        alumno.Nombre = (row[1].ToString());
        //                        alumno.ApellidoPaterno = row[2].ToString();
        //                        alumno.ApellidoMaterno = row[3].ToString();
        //                        result.Object = alumno;  //boxing    --unboxing
        //                        result.Correct = true;
        //                    }
        //                    else
        //                    {
        //                        result.Correct = false;
        //                        result.ErrorMessage = "No se encontraron registros en la tabla Alumnos";
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }

        //    return result;

        //}
        //public static ML.Result Add(ML.Alumno alumno)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            string query = "AlumnoAdd";
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = query;
        //                cmd.Connection = context;
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                SqlParameter[] collection = new SqlParameter[3];

        //                collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
        //                collection[0].Value = alumno.Nombre;

        //                collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
        //                collection[1].Value = alumno.ApellidoPaterno;

        //                collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
        //                collection[2].Value = alumno.ApellidoMaterno;

        //                cmd.Parameters.AddRange(collection);

        //                cmd.Connection.Open();

        //                int RowsAffected = cmd.ExecuteNonQuery();
        //                if (RowsAffected > 0)
        //                {
        //                    result.Correct = true;
        //                }
        //                else
        //                {
        //                    result.Correct = false;
        //                    result.ErrorMessage = "Ocurrio un error al momento de ingresar el Alumno";
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}
        //public static ML.Result Update(ML.Alumno alumno)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            string query = "AlumnoUpdate";
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = query;
        //                cmd.Connection = context;
        //                cmd.CommandType = CommandType.StoredProcedure;


        //                SqlParameter[] collection = new SqlParameter[4];
        //                collection[0] = new SqlParameter("IdAlumno", SqlDbType.VarChar);
        //                collection[0].Value = alumno.IdAlumno;

        //                collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
        //                collection[1].Value = alumno.Nombre;

        //                collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
        //                collection[2].Value = alumno.ApellidoPaterno;

        //                collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
        //                collection[3].Value = alumno.ApellidoMaterno;

        //                cmd.Parameters.AddRange(collection);

        //                cmd.Connection.Open();

        //                int RowsAffected = cmd.ExecuteNonQuery();
        //                if (RowsAffected > 0)
        //                {
        //                    result.Correct = true;
        //                }
        //                else
        //                {
        //                    result.Correct = false;
        //                    result.ErrorMessage = "Ocurrio un error al momento de modificar el Alumno";
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}
        //public static ML.Result Delete(ML.Alumno alumno)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            string query = "AlumnoDelete";
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = query; 
        //                cmd.Connection = context;
        //                cmd.CommandType = CommandType.StoredProcedure;


        //                SqlParameter[] collection = new SqlParameter[1];

        //                collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
        //                collection[0].Value = alumno.IdAlumno;

        //                cmd.Parameters.AddRange(collection);

        //                cmd.Connection.Open();

        //                int RowsAffected = cmd.ExecuteNonQuery();
        //                if (RowsAffected > 0)
        //                {
        //                    result.Correct = true;
        //                }
        //                else
        //                {
        //                    result.Correct = false;
        //                    result.ErrorMessage = "Ocurrio un error al momento de Eliminar el Alumno";
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var GetAllResult = context.AlumnoGetAll().ToList();
                    result.Objects = new List<object>();
                    if (GetAllResult != null)
                    {
                        foreach (var obj in GetAllResult)
                        {
                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = obj.IdAlumno;
                            alumno.Nombre = obj.Nombre;
                            alumno.ApellidoPaterno= obj.ApellidoPaterno;
                            alumno.ApellidoMaterno = obj.ApellidoMaterno;
                            alumno.CURP = obj.CURP;
                            alumno.Email = obj.Email;
                            alumno.FechaNacimiento = obj.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                            alumno.Telefono = obj.Telefono;
                            alumno.Imagen = obj.Imagen;

                            alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            result.Objects.Add(alumno);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encuentran registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var GetByIdResult = context.AlumnoGetById(IdAlumno).FirstOrDefault();

                    result.Object = new List<object>();

                    if (GetByIdResult != null)
                    {

                        ML.Alumno alumno = new ML.Alumno();
                        alumno.IdAlumno = GetByIdResult.IdAlumno;
                        alumno.Nombre = GetByIdResult.Nombre;
                        alumno.ApellidoPaterno = GetByIdResult.ApellidoPaterno;
                        alumno.ApellidoMaterno = GetByIdResult.ApellidoMaterno;
                        alumno.CURP = GetByIdResult.CURP;
                        alumno.Email = GetByIdResult.Email;
                        alumno.FechaNacimiento = GetByIdResult.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                        alumno.Telefono = GetByIdResult.Telefono;
                        alumno.Imagen = GetByIdResult.Imagen;
                        result.Object = alumno;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var AddResult = context.AlumnoAdd(alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno, alumno.CURP, alumno.Email, alumno.FechaNacimiento, alumno.Telefono, alumno.Imagen);
                    if (AddResult >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se inserto el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Update(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var updateResult = context.AlumnoUpdate(alumno.IdAlumno, alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno, alumno.CURP, alumno.Email, alumno.FechaNacimiento, alumno.Telefono, alumno.Imagen);
                    if (updateResult >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó los datos ingresados";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
        public static ML.Result Delete(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var DeleteResult = context.AlumnoDelete(alumno.IdAlumno);
                    if (DeleteResult >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se Elimino los datos ingresados";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}

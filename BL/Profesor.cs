using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Profesor
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var GetAllResult = context.ProfesorGetAll().ToList();
                    result.Objects = new List<object>();
                    if (GetAllResult != null)
                    {
                        foreach (var obj in GetAllResult)
                        {
                            ML.Profesor profesor = new ML.Profesor();
                            profesor.IdProfesor = obj.IdProfesor;
                            profesor.Nombre = obj.Nombre;
                            profesor.ApellidoPaterno = obj.ApellidoPaterno;
                            profesor.ApellidoMaterno = obj.ApellidoMaterno;
                            result.Objects.Add(profesor);
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
        public static ML.Result GetByIdEF(int IdProfesor)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var GetByIdResult = context.ProfesorGetById(IdProfesor).ToList();

                    result.Object = new List<object>();
                    if (GetByIdResult != null)
                    {
                        foreach (var obj in GetByIdResult)
                        {

                        ML.Profesor profesor = new ML.Profesor();
                        profesor.IdProfesor = obj.IdProfesor;
                        profesor.Nombre = obj.Nombre;
                        profesor.ApellidoPaterno = obj.ApellidoPaterno;
                        profesor.ApellidoMaterno = obj.ApellidoMaterno;
                        result.Object = profesor;
                        result.Correct = true;
                        }

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
        public static ML.Result AddEF(ML.Profesor profesor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var AddResult = context.ProfesorAdd(profesor.Nombre, profesor.ApellidoPaterno, profesor.ApellidoMaterno);
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
        public static ML.Result UpdateEF(ML.Profesor profesor)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var updateResult = context.ProfesorUpdate(profesor.IdProfesor, profesor.Nombre, profesor.ApellidoPaterno, profesor.ApellidoMaterno);
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
        public static ML.Result DeleteEF(ML.Profesor profesor)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var DeleteResult = context.ProfesorDelete(profesor.IdProfesor);
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

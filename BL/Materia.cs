using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var GetAllResult = context.MateriaGetAll().ToList();
                    result.Objects = new List<object>();
                    if (GetAllResult != null)
                    {
                        foreach (var obj in GetAllResult)
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.IdMateria = obj.IdMateria;
                            materia.Nombre = obj.Nombre;
                            materia.Costo = obj.Costo.Value;
                            result.Objects.Add(materia);
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
        public static ML.Result GetByIdEF(int IdMateria)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var GetByIdResult = context.MateriaGetById(IdMateria).FirstOrDefault();

                    result.Object = new List<object>();

                    if (GetByIdResult != null)
                    {

                        ML.Materia materia = new ML.Materia();
                        materia.IdMateria = GetByIdResult.IdMateria;
                        materia.Nombre = GetByIdResult.Nombre;
                        materia.Costo = GetByIdResult.Costo.Value;
                        result.Object = materia;
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
        public static ML.Result AddEF(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var AddResult = context.MateriaAdd(materia.Nombre, materia.Costo);
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
        public static ML.Result UpdateEF(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var updateResult = context.MateriaUpdate(materia.IdMateria, materia.Nombre, materia.Costo);
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
        public static ML.Result DeleteEF(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var DeleteResult = context.MateriaDelete(materia.IdMateria);
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

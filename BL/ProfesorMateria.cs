using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProfesorMateria
    {
        public static ML.Result MateriaGetAsignada(ML.ProfesorMateria profesorMateria)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var GetByIdResult = context.MateriaGetByIdProfesor(profesorMateria.Profesor.IdProfesor).ToList();

                    result.Objects = new List<object>();

                    if (GetByIdResult != null)
                    {
                        foreach (var obj in GetByIdResult)
                        {
                            ML.ProfesorMateria profesormateria = new ML.ProfesorMateria();
                            profesormateria.IdProfesorMateria = obj.IdProfesorMateria;
                            profesormateria.Materia = new ML.Materia();
                            profesormateria.Materia.Nombre = obj.MateriaNombre;
                            profesormateria.Materia.Costo = obj.Costo;
                            result.Objects.Add(profesormateria);
                            result.Correct = true;
                        }

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
        public static ML.Result MateriaGetNoAsignada(ML.ProfesorMateria profesorMateria)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var GetByIdResult = context.MateriasGetNoAsignadasProfesor(profesorMateria.Profesor.IdProfesor);

                    result.Objects = new List<object>();

                    if (GetByIdResult != null)
                    {
                        foreach (var obj in GetByIdResult)
                        {
                            ML.ProfesorMateria profesormateria = new ML.ProfesorMateria();
                            profesormateria.Materia = new ML.Materia();
                            profesormateria.Materia.IdMateria = obj.IdMateria;
                            profesormateria.Materia.Nombre = obj.Nombre;
                            profesormateria.Materia.Costo = obj.Costo;
                            result.Objects.Add(profesormateria);
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
        public static ML.Result Add(ML.ProfesorMateria profesormateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var query = context.ProfesorMateriaAdd(profesormateria.Profesor.IdProfesor, profesormateria.Materia.IdMateria);

                    result.Object = profesormateria;

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
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
        public static ML.Result Delete(ML.ProfesorMateria profesormateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var query = context.ProfesorMateriaDelete(profesormateria.IdProfesorMateria);
                    result.Object = profesormateria;

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encntraron registros";
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
    }
}

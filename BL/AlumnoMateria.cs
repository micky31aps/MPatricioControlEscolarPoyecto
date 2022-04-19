using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMateria
    {
        public static ML.Result MateriaGetAsignada(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var GetByIdResult = context.MateriaGetByIdAlumno(alumnoMateria.Alumno.IdAlumno).ToList();

                    result.Object = new List<object>();

                    if (GetByIdResult != null)
                    {
                        foreach (var obj in GetByIdResult)
                        {
                            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();
                            alumnomateria.IdAlumnoMateria = obj.IdAlumnoMateria;
                            alumnomateria.Materia = new ML.Materia();
                            alumnomateria.Materia.Nombre = obj.MateriaNombre;
                            alumnomateria.Materia.Costo = obj.Costo;
                            result.Object = alumnomateria;
                            
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
        public static ML.Result MateriaGetNoAsignada(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var GetByIdResult = context.MateriasGetNoAsignadas(alumnoMateria.Alumno.IdAlumno);

                    result.Objects = new List<object>();

                    if (GetByIdResult != null)
                    {
                        foreach (var obj in GetByIdResult)
                        {
                            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();
                            alumnomateria.Materia = new ML.Materia();
                            alumnomateria.Materia.IdMateria = obj.IdMateria;
                            alumnomateria.Materia.Nombre = obj.Nombre;
                            alumnomateria.Materia.Costo = obj.Costo;
                            result.Objects.Add(alumnomateria);
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
        public static ML.Result Add(ML.AlumnoMateria alumnomateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var query = context.AlumnoMateriaAdd(alumnomateria.Alumno.IdAlumno, alumnomateria.Materia.IdMateria);

                    result.Object = alumnomateria;

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
        public static ML.Result Delete(ML.AlumnoMateria alumnomateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MPatricioControlEscolarEntities context = new DL_EF.MPatricioControlEscolarEntities())
                {
                    var query = context.AlumnoMateriaDelete(alumnomateria.IdAlumnoMateria);
                    result.Object = alumnomateria;

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

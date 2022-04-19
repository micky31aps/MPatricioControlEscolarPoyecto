using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        //
        // GET: /AlumnoMateria/
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Alumno.GetAll();
            ML.Alumno alumno = new ML.Alumno();
            if (result.Correct)
            {
                alumno.Alumnos = result.Objects.ToList();
                
            }
            else
            {

            }
            return View(alumno);
        }
        [HttpGet]
        public ActionResult MateriaGetAsignada(int IdAlumno)
        {
            
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            ML.Result result = new ML.Result();
            alumnoMateria.Alumno = new ML.Alumno();
            alumnoMateria.Alumno.IdAlumno = IdAlumno;

            result = BL.Alumno.GetById(alumnoMateria.Alumno.IdAlumno);

            if (result.Object != null)
            {
                alumnoMateria.Alumno.IdAlumno = ((ML.Alumno)result.Object).IdAlumno;
                alumnoMateria.Alumno.Nombre = ((ML.Alumno)result.Object).Nombre;
                alumnoMateria.Alumno.ApellidoPaterno = ((ML.Alumno)result.Object).ApellidoPaterno;
                alumnoMateria.Alumno.ApellidoMaterno = ((ML.Alumno)result.Object).ApellidoMaterno;
                result = BL.AlumnoMateria.MateriaGetAsignada(alumnoMateria);
                alumnoMateria.AlumnoMaterias = result.Objects;

                return View(alumnoMateria);
            }
            else
            {
                ViewBag.Message ="No existen registros" +result.ErrorMessage;
                return PartialView("Modal");
            }
        }
        [HttpGet]
        public ActionResult MateriaGetNoAsignada(int IdAlumno)
        {
             ML.AlumnoMateria alumnomateriaItem = new ML.AlumnoMateria();

            ML.Result result = new ML.Result();

            alumnomateriaItem.Alumno = new ML.Alumno();
            alumnomateriaItem.Alumno.IdAlumno = IdAlumno;

            result = BL.Alumno.GetById(alumnomateriaItem.Alumno.IdAlumno);
            if(result.Object != null)
            {

                alumnomateriaItem.Alumno.IdAlumno = ((ML.Alumno)result.Object).IdAlumno;
                alumnomateriaItem.Alumno.Nombre = ((ML.Alumno)result.Object).Nombre;
                alumnomateriaItem.Alumno.ApellidoPaterno = ((ML.Alumno)result.Object).ApellidoPaterno;
                alumnomateriaItem.Alumno.ApellidoMaterno = ((ML.Alumno)result.Object).ApellidoMaterno;
                
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return PartialView("Modal");
            }
            result = BL.AlumnoMateria.MateriaGetNoAsignada(alumnomateriaItem);
            alumnomateriaItem.AlumnoMaterias = result.Objects;
            return View(alumnomateriaItem);
        }
        [HttpPost]
        public ActionResult GetMateriasNoAsignadas(ML.AlumnoMateria alumnomateria)
        {
            if (alumnomateria.AlumnoMaterias != null)
            {
                foreach (string IdMateria in alumnomateria.AlumnoMaterias)
                {
                    ML.AlumnoMateria alumnomateriaItem = new ML.AlumnoMateria();

                    alumnomateriaItem.Alumno = new ML.Alumno();
                    alumnomateriaItem.Alumno.IdAlumno = alumnomateria.Alumno.IdAlumno;

                    alumnomateriaItem.Materia = new ML.Materia();
                    alumnomateriaItem.Materia.IdMateria = int.Parse(IdMateria);
                    ML.Result resul = BL.AlumnoMateria.Add(alumnomateriaItem);
                }
            }
            else
            {

            }
            return RedirectToAction("MateriaGetAsignada", alumnomateria.Alumno);
        }
        [HttpGet]

        public ActionResult Delete(int IdAlumnoMateria, int IdAlumno)
        {
            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();
            alumnomateria.IdAlumnoMateria = IdAlumnoMateria;
            ML.Result result = BL.AlumnoMateria.Delete(alumnomateria);
            ViewBag.MateriasAsignadas = true;
            ViewBag.IdAlumno = IdAlumno;
            if (result.Correct)
            {
                ViewBag.Message = "Se ha eliminado correctamente el registro";
                //return RedirectToAction("MateriaGetAsignada", alumnomateria.Alumno.IdAlumno);
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al eliminar la materia";
                //return RedirectToAction("MateriaGetAsignada");
                
            }
            return PartialView("Modal");
        }
	}
}


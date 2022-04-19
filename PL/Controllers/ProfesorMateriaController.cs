using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ProfesorMateriaController : Controller
    {
        //
        // GET: /ProfesorMateria/
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Profesor.GetAllEF();
            ML.Profesor profesor = new ML.Profesor();
            if (result.Correct)
            {
                profesor.Profesores = result.Objects.ToList();

            }
            else
            {

            }
            return View(profesor);
        }
        [HttpGet]
        public ActionResult MateriaGetAsignada(int IdProfesor)
        {

            ML.ProfesorMateria profesorMateria = new ML.ProfesorMateria();
            ML.Result result = new ML.Result();
            profesorMateria.Profesor = new ML.Profesor();
            profesorMateria.Profesor.IdProfesor = IdProfesor;

            result = BL.Profesor.GetByIdEF(profesorMateria.Profesor.IdProfesor);

            if (result.Object != null)
            {
                profesorMateria.Profesor.IdProfesor = ((ML.Profesor)result.Object).IdProfesor;
                profesorMateria.Profesor.Nombre = ((ML.Profesor)result.Object).Nombre;
                profesorMateria.Profesor.ApellidoPaterno = ((ML.Profesor)result.Object).ApellidoPaterno;
                profesorMateria.Profesor.ApellidoMaterno = ((ML.Profesor)result.Object).ApellidoMaterno;
                result = BL.ProfesorMateria.MateriaGetAsignada(profesorMateria);
                profesorMateria.ProfesorMaterias = result.Objects;

                return View(profesorMateria);
            }
            else
            {
                ViewBag.Message = "No existen registros" + result.ErrorMessage;
                return PartialView("Modal");
            }
        }
        [HttpGet]
        public ActionResult MateriaGetNoAsignada(int IdProfesor)
        {
            ML.ProfesorMateria profesormateriaItem = new ML.ProfesorMateria();

            ML.Result result = new ML.Result();

            profesormateriaItem.Profesor = new ML.Profesor();
            profesormateriaItem.Profesor.IdProfesor = IdProfesor;

            result = BL.Profesor.GetByIdEF(profesormateriaItem.Profesor.IdProfesor);
            if (result.Object != null)
            {

                profesormateriaItem.Profesor.IdProfesor = ((ML.Profesor)result.Object).IdProfesor;
                profesormateriaItem.Profesor.Nombre = ((ML.Profesor)result.Object).Nombre;
                profesormateriaItem.Profesor.ApellidoPaterno = ((ML.Profesor)result.Object).ApellidoPaterno;
                profesormateriaItem.Profesor.ApellidoMaterno = ((ML.Profesor)result.Object).ApellidoMaterno;

            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return PartialView("Modal");
            }
            result = BL.ProfesorMateria.MateriaGetNoAsignada(profesormateriaItem);
            profesormateriaItem.ProfesorMaterias = result.Objects;
            return View(profesormateriaItem);
        }
        [HttpPost]
        public ActionResult GetMateriasNoAsignadas(ML.ProfesorMateria profesormateria)
        {
            if (profesormateria.ProfesorMaterias != null)
            {
                foreach (string IdMateria in profesormateria.ProfesorMaterias)
                {
                    ML.ProfesorMateria profesormateriaItem = new ML.ProfesorMateria();

                    profesormateriaItem.Profesor = new ML.Profesor();
                    profesormateriaItem.Profesor.IdProfesor = profesormateria.Profesor.IdProfesor;

                    profesormateriaItem.Materia = new ML.Materia();
                    profesormateriaItem.Materia.IdMateria = int.Parse(IdMateria);
                    ML.Result resul = BL.ProfesorMateria.Add(profesormateriaItem);
                }
            }
            else
            {

            }
            return RedirectToAction("MateriaGetAsignada", profesormateria.Profesor);
        }
        public ActionResult Delete(int IdProfesorMateria, int IdProfesor)
        {
            ML.ProfesorMateria profesormateria = new ML.ProfesorMateria();
            profesormateria.IdProfesorMateria = IdProfesorMateria;
            ML.Result result = BL.ProfesorMateria.Delete(profesormateria);
            ViewBag.MateriasAsignadas = true;
            ViewBag.IdProfesor = IdProfesor;
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
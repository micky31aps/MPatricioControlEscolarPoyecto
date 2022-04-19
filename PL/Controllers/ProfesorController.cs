using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ProfesorController : Controller
    {
        //
        // GET: /Profesor/
        [HttpGet]
        public ActionResult GetAll()
        {

            ML.Profesor profesor = new ML.Profesor();
            ML.Result result = BL.Profesor.GetAllEF();

            if (result.Correct)
            {
                profesor.Profesores = result.Objects;
            }
            else
            {

            }
            return View(profesor);
        }
        public ActionResult Form(int? IdProfesor)
        {
            ML.Profesor profesor = new ML.Profesor();
            //ML.Result result = BL.Empleado.GetAll();
            if (IdProfesor == null)
            {
                return View(profesor);
            }
            else
            {
                ML.Result result = BL.Profesor.GetByIdEF(IdProfesor.Value);
                if (result.Correct)
                {

                    profesor = ((ML.Profesor)result.Object);
                    profesor.Profesores = result.Objects;
                    return View(profesor);
                }
                else
                {

                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.Profesor profesor)
        {
            ML.Result result = new ML.Result();
            if (profesor.IdProfesor == 0)
            {
                result = BL.Profesor.AddEF(profesor);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "El Profesor se ha registrado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "El Profesor no se ha registrado correctamente" + result.ErrorMessage;
                }
            }
            else
            {
                result = BL.Profesor.UpdateEF(profesor);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "El Profesor se ha modificado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "El Profesor no se ha modificado correctamente" + result.ErrorMessage;
                }
            }
            return PartialView("Modal");
        }
        public ActionResult Delete(int IdProfesor)
        {
            ML.Profesor profesor = new ML.Profesor();
            profesor.IdProfesor = IdProfesor;
            ML.Result result = BL.Profesor.DeleteEF(profesor);
            if (result.Correct)
            {
                ViewBag.Mensaje = "El Profesor se ha eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "El Profesor no se ha eliminado correctamente" + result.ErrorMessage;
            }

            return PartialView("Modal");
        }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoController : Controller
    {
        //
        // GET: /Alumno/
        [HttpGet]
        public ActionResult GetAll()
        {
            ServiceAlumno1.AlumnoClient serviceAlumno = new ServiceAlumno1.AlumnoClient();
            //ServiceAlumno.AlumnoClient serviceAlumno1 = new ServiceAlumno.AlumnoClient();
            var resultAlumno = serviceAlumno.GetAll();
            ML.Alumno alumno = new ML.Alumno();
            if (resultAlumno.Correct)
            {
                alumno.Alumnos = resultAlumno.Objects.ToList();
            }
            else
            {
                ViewBag.Mensaje = "Error al buscar los Productos  " + resultAlumno.ErrorMessage;
            }

            return View(alumno);
        }//Fin GetAll
        public ActionResult Form(int? IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            if (IdAlumno == null)
            {
                return View(alumno);
            }
            else
            {
                //ML.Result result = new ML.Result();
                ServiceAlumno1.AlumnoClient serviceAlumno = new ServiceAlumno1.AlumnoClient();
                var resultAlumno = serviceAlumno.GetById(IdAlumno.Value);
                //result = BL.Producto.GetByIdEF(IdProducto.Value);
                if (resultAlumno.Correct)
                {
                    alumno = ((ML.Alumno)resultAlumno.Object);
                    return View(alumno);
                }
                else
                {

                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            ServiceAlumno1.AlumnoClient serviceAlumno = new ServiceAlumno1.AlumnoClient();
            ML.Result result = new ML.Result();
            if (alumno.IdAlumno == 0)
            {
                var resultAlumno = serviceAlumno.Add(alumno);
                //result = BL.Producto.AddEF(producto);
                if (resultAlumno.Correct)
                {
                    ViewBag.Mensaje = "El Alumno se ha registrado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "El Alumno no se ha registrado correctamente";
                }
            }
            else
            {
                var resultProducto = serviceAlumno.Update(alumno);
                //result = BL.Producto.UpdateEF(producto);

                if (resultProducto.Correct)
                {
                    ViewBag.Mensaje = "El Alumno se ha actualizado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "El Alumno no se ha actualizado correctamente " + result.ErrorMessage;
                }
            }
            return PartialView("Modal");
        }
        public ActionResult Delete(int IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            alumno.IdAlumno= IdAlumno;
            ServiceAlumno1.AlumnoClient serviceAlumno = new ServiceAlumno1.AlumnoClient();
            var resultAlumno = serviceAlumno.Detele(alumno);
            //ML.Result result = BL.Producto.DeleteEF(producto);
            if (resultAlumno.Correct)
            {
                ViewBag.Mensaje = "El Alumno se ha eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "El Alumno no se ha eliminado correctamente " + resultAlumno.ErrorMessage;
            }

            return PartialView("Modal");
        }
	}
}
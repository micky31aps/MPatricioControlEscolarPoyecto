using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net.Mime;
using System.Net.Http;

namespace PL.Controllers
{
    public class ControlEscolarController : Controller
    {
        //
        // GET: /ControlEscolar/
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();
            materia.Materias = new List<object>();
            using (HttpClient client = new HttpClient())
            {
                string UrlApi = System.Configuration.ConfigurationManager.AppSettings["WebApi"].ToString();
                client.BaseAddress = new Uri(UrlApi);
                var responseTask = client.GetAsync("ControlEscolar/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Materia materiaList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultItem.ToString());
                        materia.Materias.Add(materiaList);
                    }
                }
            }
            return View(materia);
        }
        [HttpGet]
        public ActionResult Form(int? IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            string UrlApi = System.Configuration.ConfigurationManager.AppSettings["WebApi"].ToString();
            if (IdMateria == null)
            {
                return View(materia);
            }
            else
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(UrlApi);
                    var responseTask = client.GetAsync("ControlEscolar/GetById/" + IdMateria);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Materia resultItemList = new ML.Materia();
                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(readTask.Result.Object.ToString());
                        materia = resultItemList;
                    }
                }
            }
            return View(materia);
        }
        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            string UrlApi = System.Configuration.ConfigurationManager.AppSettings["WebApi"].ToString();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(UrlApi);
                if (materia.IdMateria == 0)
                {
                    var postTask = client.PostAsJsonAsync<ML.Materia>("ControlEscolar/Add", materia);
                    postTask.Wait();

                    if (postTask.Result.IsSuccessStatusCode == true)
                    {
                        ViewBag.Message = "La materia se ha registrado correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "La materia no se ha registrado correctamente" + result.ErrorMessage;
                    }
                }
                else
                {
                    var postTask = client.PutAsJsonAsync<ML.Materia>("ControlEscolar/Update/" + materia.IdMateria, materia);
                    if (postTask.Result.IsSuccessStatusCode == true)
                    {
                        ViewBag.Message = "La materia se ha modificado correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "La materia no se midifico correctamente" + result.ErrorMessage;
                    }
                }

            }

            return PartialView("Modal");
        }
        public ActionResult Delete(int IdMateria)
        {
            ML.Result result = new ML.Result();
            ML.Materia materia = new ML.Materia();
            materia.IdMateria = IdMateria;
            string UrlApi = System.Configuration.ConfigurationManager.AppSettings["WebApi"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UrlApi);
                var postTask = client.DeleteAsync("ControlEscolar/Delete/" + IdMateria);
                postTask.Wait();
                var resultItem = postTask.Result;
                if (resultItem.IsSuccessStatusCode)
                {
                    //resultItem = BL.Materia.GetAllEF();
                    ViewBag.Message = "La materia se elimino correctamente";
                }
                else
                {
                    ViewBag.Message = "La materia no se elimino correctamente" + result.ErrorMessage;
                }
                //resultItem = BL.Materia.GetAllEF();
                //return RedirectToAction("GetAll", resultItem);
            }
            return PartialView("Modal");
        }



    }
}
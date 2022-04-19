using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebAPI.Controllers
{
    public class ControlEscolarController : ApiController
    {
        [Route("api/ControlEscolar/GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAllEF();
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        [HttpGet]
        [Route("api/ControlEscolar/GetById/{IdMateria}")]
        public IHttpActionResult GetById(int IdMateria)
        {
            ML.Result result = BL.Materia.GetByIdEF(IdMateria);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }

        }
        [HttpPost]
        [Route("api/ControlEscolar/Add")]
        public IHttpActionResult Add([FromBody] ML.Materia materia)
        {
            ML.Result result = BL.Materia.AddEF(materia);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpPut]
        [Route("api/ControlEscolar/Update/{IdMateria}")]
        public IHttpActionResult Update(int IdMateria, [FromBody] ML.Materia materia)
        {
            materia.IdMateria = IdMateria;
            ML.Result result = BL.Materia.UpdateEF(materia);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        [HttpDelete]
        [Route("api/ControlEscolar/Delete/{IdMateria}")]

        public IHttpActionResult Delete(int IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            materia.IdMateria = IdMateria;
            ML.Result result = BL.Materia.DeleteEF(materia);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}

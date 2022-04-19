﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Alumno" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Alumno.svc or Alumno.svc.cs at the Solution Explorer and start debugging.
    public class Alumno : IAlumno
    {
        public SL_WCF.Result GetAll()
        {
            ML.Result resultAlumno = BL.Alumno.GetAll();
            return new Result { Correct = resultAlumno.Correct, Object = resultAlumno.Object, Objects = resultAlumno.Objects, ErrorMessage = resultAlumno.ErrorMessage, Ex = resultAlumno.Ex };
        }
        public SL_WCF.Result GetById(int IdAlumno)
        {
            ML.Result resultAlumno = BL.Alumno.GetById(IdAlumno);
            return new Result { Correct = resultAlumno.Correct, Object = resultAlumno.Object, Objects = resultAlumno.Objects, ErrorMessage = resultAlumno.ErrorMessage, Ex = resultAlumno.Ex };
        }
        public SL_WCF.Result Add(ML.Alumno alumno)
        {
            ML.Result resultAlumno = BL.Alumno.Add(alumno);
            return new Result { Correct = resultAlumno.Correct, Object = resultAlumno.Object, Objects = resultAlumno.Objects, ErrorMessage = resultAlumno.ErrorMessage, Ex = resultAlumno.Ex };
        }
        public SL_WCF.Result Update(ML.Alumno alumno)
        {
            ML.Result resultAlumno = BL.Alumno.Update(alumno);
            return new Result { Correct = resultAlumno.Correct, Object = resultAlumno.Object, Objects = resultAlumno.Objects, ErrorMessage = resultAlumno.ErrorMessage, Ex = resultAlumno.Ex };
        }
        public SL_WCF.Result Detele(ML.Alumno alumno)
        {
            ML.Result resultAlumno = BL.Alumno.Delete(alumno);
            return new Result { Correct = resultAlumno.Correct, Object = resultAlumno.Object, Objects = resultAlumno.Objects, ErrorMessage = resultAlumno.ErrorMessage, Ex = resultAlumno.Ex };
        }
    }
}

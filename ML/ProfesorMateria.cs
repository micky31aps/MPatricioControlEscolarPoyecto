using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class ProfesorMateria
    {
        public int IdProfesorMateria { get; set; }
        public ML.Profesor Profesor { get; set; }
        public ML.Materia Materia { get; set; }
        public List<object> ProfesorMaterias { get; set; }
    }
}

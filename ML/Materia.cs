using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Materia
    {
        
        public int IdMateria { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Costo es requerido")]
        public decimal? Costo { get; set; }
        public List<object> Materias { get; set; }
    }
}

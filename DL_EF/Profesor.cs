//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL_EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Profesor
    {
        public Profesor()
        {
            this.ProfesorMaterias = new HashSet<ProfesorMateria>();
            this.ProfesorMaterias1 = new HashSet<ProfesorMateria1>();
        }
    
        public int IdProfesor { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
    
        public virtual ICollection<ProfesorMateria> ProfesorMaterias { get; set; }
        public virtual ICollection<ProfesorMateria1> ProfesorMaterias1 { get; set; }
    }
}
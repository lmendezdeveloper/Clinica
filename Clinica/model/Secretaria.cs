//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clinica.model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Secretaria
    {
        public Secretaria()
        {
            this.CitaMedica = new HashSet<CitaMedica>();
        }
    
        public int id_Secretaria { get; set; }
        public string rut_Secretaria { get; set; }
        public string nombre_Secretaria { get; set; }
        public string apellidos_Secretaria { get; set; }
        public string direccion_Secretaria { get; set; }
        public string nTelefono_Secretaria { get; set; }
        public string clave_Secretaria { get; set; }
        public string estado_Secretaria { get; set; }
    
        public virtual ICollection<CitaMedica> CitaMedica { get; set; }
    }
}
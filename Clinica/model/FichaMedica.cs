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
    
    public partial class FichaMedica
    {
        public FichaMedica()
        {
            this.ExamenXFicha = new HashSet<ExamenXFicha>();
        }
    
        public int id_FichaMedica { get; set; }
        public System.DateTime fechaConsulta_FichaMedica { get; set; }
        public string diagnostico_FichaMedica { get; set; }
        public string tratamiento_FichaMedica { get; set; }
        public string medicamento_FichaMedica { get; set; }
        public string estado_FichaMedica { get; set; }
        public Nullable<int> Paciente_idPaciente_FichaMedica { get; set; }
        public Nullable<int> Doctor_idDoctor_FichaMedica { get; set; }
    
        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<ExamenXFicha> ExamenXFicha { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class clinicaEntities1 : DbContext
    {
        public clinicaEntities1()
            : base("name=clinicaEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<CitaMedica> CitaMedica { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Examen> Examen { get; set; }
        public DbSet<ExamenXFicha> ExamenXFicha { get; set; }
        public DbSet<FichaMedica> FichaMedica { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Secretaria> Secretaria { get; set; }
    }
}

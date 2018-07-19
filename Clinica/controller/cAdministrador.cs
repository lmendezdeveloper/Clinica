using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clinica.model;

namespace Clinica.controller
{
    public class cAdministrador
    {
        clinicaEntities1 context = new clinicaEntities1();

        public List<model.Administrador> listAdministrador()
        {
            return context.Administrador.ToList();
        }


        public bool addAdministrador(Administrador Admin)
        {
            try
            {
                context.Administrador.Add(Admin);

                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditAdministrador(Administrador Admin)
        {
            try
            {
                Administrador Edit = context.Administrador.Find(Admin.id_Administrador);

                Edit.id_Administrador = Admin.id_Administrador;
                Edit.rut_Administrador = Admin.rut_Administrador;
                Edit.nombre_Administrador = Admin.nombre_Administrador;
                Edit.apellidos_Administrador = Admin.apellidos_Administrador;
                Edit.clave_Administrador = Admin.clave_Administrador;
                Edit.estado_Administrador = Admin.estado_Administrador;

                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteAdministrador(int id_Administrador)
        {
            try
            {
                Administrador Delete = context.Administrador.Find(id_Administrador);
                context.Administrador.Remove(Delete);
                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
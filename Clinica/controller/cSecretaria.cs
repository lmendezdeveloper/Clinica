using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clinica.model;

namespace Clinica.controller
{
    public class cSecretaria
    {
        clinicaEntities1 context = new clinicaEntities1();

        public List<model.Secretaria> listSecretaria()
        {
            return context.Secretaria.ToList();
        }


        public bool addSecretaria(Secretaria sec)
        {
            try
            {
                context.Secretaria.Add(sec);

                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool editSecretaria(Secretaria sec)
        {
            try
            {
                Secretaria Edit = context.Secretaria.Find(sec.id_Secretaria);

                Edit.id_Secretaria = sec.id_Secretaria;
                Edit.rut_Secretaria = sec.rut_Secretaria;
                Edit.nombre_Secretaria = sec.nombre_Secretaria;
                Edit.apellidos_Secretaria = sec.apellidos_Secretaria;
                Edit.direccion_Secretaria = sec.direccion_Secretaria;
                Edit.nTelefono_Secretaria = sec.nTelefono_Secretaria;
                Edit.clave_Secretaria = sec.clave_Secretaria;
                Edit.estado_Secretaria = sec.estado_Secretaria;

                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool deleteSecretaria(int id_Secretaria)
        {
            try
            {
                Secretaria Delete = context.Secretaria.Find(id_Secretaria);
                context.Secretaria.Remove(Delete);
                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
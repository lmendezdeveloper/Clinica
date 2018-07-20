using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clinica.model;

namespace Clinica.controller
{
    public class cPaciente
    {
        clinicaEntities1 context = new clinicaEntities1();

        public List<model.Paciente> listPaciente()
        {
            return context.Paciente.ToList();
        }

        
        public bool addPaciente(Paciente pac)
        {
            try
            {
                context.Paciente.Add(pac);

                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool editPaciente (Paciente pac)
        {
            try
            {
                Paciente Edit = context.Paciente.Find(pac.id_Paciente);

                Edit.id_Paciente = pac.id_Paciente;
                Edit.rut_Paciente = pac.rut_Paciente;
                Edit.nombres_Paciente = pac.nombres_Paciente;
                Edit.apellidos_Paciente = pac.apellidos_Paciente;
                Edit.fechaNac_Paciente = pac.fechaNac_Paciente;
                Edit.nTelefono_Paciente = pac.nTelefono_Paciente;
                Edit.direccion_Paciente = pac.direccion_Paciente;
                Edit.clave_Paciente = pac.clave_Paciente;
                Edit.estado_Paciente = pac.estado_Paciente;

                return context.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool deletePaciente(int id_Paciente)
        {
            try
            {
                Paciente Delete = context.Paciente.Find(id_Paciente);
                context.Paciente.Remove(Delete);

                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
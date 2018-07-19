using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clinica.model;


namespace Clinica.controller
{
    public class cCitaMedica
    {
        clinicaEntities1 context = new clinicaEntities1();

        public List<model.CitaMedica> listCitaMedica()
        {
            return context.CitaMedica.ToList();
        }


        public bool addCitaMedica(CitaMedica cit)
        {
            try
            {
                context.CitaMedica.Add(cit);

                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditCitaMedica(CitaMedica cit)
        {
            try
            {
                CitaMedica Edit = context.CitaMedica.Find(cit.id_CitaMedica);

                Edit.id_CitaMedica = cit.id_CitaMedica;
                Edit.fechaCita_CitaMedica = cit.fechaCita_CitaMedica;
                Edit.fechaSol_CitaMedica = cit.fechaSol_CitaMedica;
                Edit.hora_CitaMedica = cit.hora_CitaMedica;
                Edit.estado_CitaMedica = cit.estado_CitaMedica;
                Edit.Paciente_idPaciente_CitaMedica = cit.Paciente_idPaciente_CitaMedica;
                Edit.Secretario_idSecretaria_CitaMedica = cit.Secretario_idSecretaria_CitaMedica;
                Edit.Doctor_idDoctor_CitaMedica = cit.Doctor_idDoctor_CitaMedica;

                return context.SaveChanges() != 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteCitaMedica(int id_CitaMedica)
        {
            try
            {
                CitaMedica Delete = context.CitaMedica.Find(id_CitaMedica);
                context.CitaMedica.Remove(Delete);
                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
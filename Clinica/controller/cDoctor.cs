using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clinica.model;

namespace Clinica.controller
{
    public class cDoctor
    {
        clinicaEntities1 context = new clinicaEntities1();

        public List<model.Doctor> listDoctor()
        {
            return context.Doctor.ToList();
        }


        public bool addDoctor(Doctor doc)
        {
            try
            {
                context.Doctor.Add(doc);

                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditDoctor(Doctor doc)
        {
            try
            {
                Doctor Edit = context.Doctor.Find(doc.id_Doctor);

                Edit.id_Doctor = doc.id_Doctor;
                Edit.rut_Doctor = doc.rut_Doctor;
                Edit.nombres_Doctor = doc.nombres_Doctor;
                Edit.apellidos_Doctor = doc.apellidos_Doctor;
                Edit.direccion_Doctor = doc.direccion_Doctor;
                Edit.nTelefono_Doctor = doc.nTelefono_Doctor;
                Edit.fechaNac_Doctor = doc.fechaNac_Doctor;
                Edit.clave_Doctor = doc.clave_Doctor;
                Edit.estado_Doctor = doc.estado_Doctor;

                return context.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteDoctor(int id_Doctor)
        {
            try
            {
                Doctor Delete = context.Doctor.Find(id_Doctor);
                context.Doctor.Remove(Delete);
                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
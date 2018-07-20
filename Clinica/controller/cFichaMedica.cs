using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clinica.model;

namespace Clinica.controller
{
    public class cFichaMedica
    {
        clinicaEntities1 context = new clinicaEntities1();

        public List<model.FichaMedica> listFichaMedica()
        {
            return context.FichaMedica.ToList();
        }


        public bool addFichaMedica(FichaMedica fc)
        {
            try
            {
                context.FichaMedica.Add(fc);

                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
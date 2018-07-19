using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica.view.administrador
{
    public partial class master_administrador : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string perfil = (string)Session["perfilUsuario"];
            switch (perfil)
            {
                case null:
                    Response.Redirect("../login.aspx");
                    break;
                case "1":
                    Response.Redirect("../paciente/inicio.aspx");
                    break;
                case "2":
                    Response.Redirect("../secretaria/inicio.aspx");
                    break;
                case "3":
                    Response.Redirect("../doctor/inicio.aspx");
                    break;
                case "4":
                    break;
                default:
                    Response.Redirect("Inicio.aspx");
                    break;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clinica.controller;

namespace Clinica.view
{
    public partial class login : System.Web.UI.Page
    {
        method metodo = new method();
        cPaciente paciente = new cPaciente();
        cSecretaria secretaria = new cSecretaria();
        cDoctor doctor = new cDoctor();
        cAdministrador administrador = new cAdministrador();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Abandon();
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            int perfil = Int32.Parse(list_perfil.Text);

            if (txt_user.Text == "" || txt_pass.Text == "")
            {
                lbl_red.Text = "Debe llenar todos los campos";
            }
            else if (metodo.validarRut(txt_user.Text) == true)
            {
                if (perfil == 1)
                {
                    var query = from p in paciente.listPaciente()
                                where p.rut_Paciente == txt_user.Text && p.clave_Paciente == txt_pass.Text
                                select p;
                    if (query.Count() > 0)
                    {
                        foreach (var item in query.ToList())
                        {
                            Session["idUsuario"] = item.id_Paciente.ToString();
                            Session["nombreUsuario"] = item.nombres_Paciente.ToString() + " " + item.apellidos_Paciente.ToString();
                            Session["perfilUsuario"] = 1.ToString();
                            Response.Redirect("paciente/inicio.aspx");
                        }
                    }
                    else
                    {
                        lbl_red.Text = "Usuario o contraseña incorrectos";
                    }
                }
                else if (perfil == 2)
                {
                    var query = from s in secretaria.listSecretaria()
                                where s.rut_Secretaria == txt_user.Text && s.clave_Secretaria == txt_pass.Text
                                select s;
                    if (query.Count() > 0)
                    {
                        foreach (var item in query.ToList())
                        {
                            Session["idUsuario"] = item.id_Secretaria.ToString();
                            Session["nombreUsuario"] = item.nombre_Secretaria.ToString() + " " + item.apellidos_Secretaria.ToString();
                            Session["perfilUsuario"] = 2.ToString();
                            Response.Redirect("secretaria/inicio.aspx");
                        }
                    }
                    else
                    {
                        lbl_red.Text = "Usuario o contraseña incorrectos";
                    }
                }
                else if (perfil == 3)
                {
                    var query = from d in doctor.listDoctor()
                                where d.rut_Doctor == txt_user.Text && d.clave_Doctor == txt_pass.Text
                                select d;
                    if (query.Count() > 0)
                    {
                        foreach (var item in query.ToList())
                        {
                            Session["idUsuario"] = item.id_Doctor.ToString();
                            Session["nombreUsuario"] = item.nombres_Doctor.ToString() + " " + item.apellidos_Doctor.ToString();
                            Session["perfilUsuario"] = 3.ToString();
                            Response.Redirect("doctor/inicio.aspx");
                        }
                    }
                    else
                    {
                        lbl_red.Text = "Usuario o contraseña incorrectos";
                    }
                }
                else
                {
                    var query = from a in administrador.listAdministrador()
                                where a.rut_Administrador == txt_user.Text && a.clave_Administrador == txt_pass.Text
                                select a;
                    if (query.Count() > 0)
                    {
                        foreach (var item in query.ToList())
                        {
                            Session["idUsuario"] = item.id_Administrador.ToString();
                            Session["nombreUsuario"] = item.nombre_Administrador.ToString() + " " + item.apellidos_Administrador.ToString();
                            Session["perfilUsuario"] = 4.ToString();
                            Response.Redirect("administrador/inicio.aspx");
                        }
                    }
                    else
                    {
                        lbl_red.Text = "Usuario o contraseña incorrectos";
                    }
                }
            }
            else
            {
                lbl_red.Text = "Rut invalido";
            }
        }
    }
}
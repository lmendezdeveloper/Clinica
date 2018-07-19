using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clinica.controller;
using Clinica.model;

namespace Clinica.view.secretaria
{
    public partial class gestion_pacientes : System.Web.UI.Page
    {

        method metodo = new method();
        cPaciente paciente = new cPaciente();

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarGridView();
        }

        protected void btn_addClick(object sender, EventArgs e)
        {
            if (txt_rut.Text == "" || txt_nombre.Text == "" || txt_apellido.Text == "" || txt_fechanacimiento.Text == "" || txt_telefono.Text == "" || txt_direccion.Text == "")
            {
                lbl_green.Text = "";
                lbl_red.Text = "Debe llenar todos los campos";
            }
            else if (metodo.validarRut(txt_rut.Text) == true)
            {
                string rut = metodo.formatRut(txt_rut.Text);
                var queryPaciente = from pac in paciente.listPaciente()
                                    select pac;
                string id_paciente = null;
                foreach (var item in queryPaciente)
                {
                    if (item.rut_Paciente == rut)
                    {
                        id_paciente = item.id_Paciente.ToString();
                    }
                }
                if (id_paciente == null)
                {
                    string nombre = txt_nombre.Text;
                    string apellidos = txt_apellido.Text;
                    DateTime fechaCita = DateTime.ParseExact(txt_fechanacimiento.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    string telefono = txt_telefono.Text;
                    string direccion = txt_direccion.Text;
                    string estado = "Activo";

                    Paciente pac = new Paciente();
                    pac.rut_Paciente = rut;
                    pac.nombres_Paciente = nombre;
                    pac.apellidos_Paciente = apellidos;
                    pac.fechaNac_Paciente = fechaCita;
                    pac.nTelefono_Paciente = telefono;
                    pac.direccion_Paciente = direccion;
                    pac.clave_Paciente = "123";
                    pac.estado_Paciente = estado;

                    if (paciente.addPaciente(pac))
                    {
                        txt_rut.Text = "";
                        txt_nombre.Text = "";
                        txt_apellido.Text = "";
                        txt_fechanacimiento.Text = "";
                        txt_telefono.Text = "";
                        txt_direccion.Text = "";
                        lbl_red.Text = "";
                        lbl_green.Text = "Paciente agendado con exito";
                        cargarGridView();
                    }
                    else
                    {
                        lbl_green.Text = "";
                        lbl_red.Text = "No se ha podido agregar al paciente";
                    }
                }
                else
                {
                    lbl_green.Text = "";
                    lbl_red.Text = "Paciente ya registrado";
                }
            }
            else
            {
                lbl_green.Text = "";
                lbl_red.Text = "Rut invalido";
            }
        }

        public void cargarGridView()
        {
            var queryTable = from pac in paciente.listPaciente()
                             select pac;
            gv_pacientes.DataSource = queryTable.ToList();
            gv_pacientes.DataBind();
        }
    }
}
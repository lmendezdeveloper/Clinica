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
            if (txt_rut.Text == "" || txt_nombre.Text == "" || txt_apellido.Text == "" || txt_fecha.Text == "" || txt_telefono.Text == "" || txt_direccion.Text == "")
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
                    string nombres = txt_nombre.Text;
                    string apellidos = txt_apellido.Text;
                    DateTime fecha_nacimiento = DateTime.ParseExact(txt_fecha.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    string telefono = txt_telefono.Text;
                    string direccion = txt_direccion.Text;
                    string clave = "123";
                    string estado = dp_estado.Text;

                    Paciente pac = new Paciente();
                    pac.rut_Paciente = rut;
                    pac.nombres_Paciente = nombres;
                    pac.apellidos_Paciente = apellidos;
                    pac.fechaNac_Paciente = fecha_nacimiento;
                    pac.nTelefono_Paciente = telefono;
                    pac.direccion_Paciente = direccion;
                    pac.clave_Paciente = clave;
                    pac.estado_Paciente = estado;

                    if (paciente.addPaciente(pac))
                    {
                        txt_rut.Text = "";
                        txt_nombre.Text = "";
                        txt_apellido.Text = "";
                        txt_fecha.Text = "";
                        txt_telefono.Text = "";
                        txt_direccion.Text = "";
                        dp_estado.SelectedValue = "Activo";
                        lbl_red.Text = "";
                        lbl_green.Text = "Paciente agendado con exito";
                        cargarGridView();
                    }
                    else
                    {
                        lbl_green.Text = "";
                        lbl_red.Text = "No se ha podido agregar la cita";
                    }
                }
                else
                {
                    lbl_green.Text = "";
                    lbl_red.Text = "Rut registrado";
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

            gv_data.DataSource = queryTable.ToList();
            gv_data.DataBind();
        }
    }
}
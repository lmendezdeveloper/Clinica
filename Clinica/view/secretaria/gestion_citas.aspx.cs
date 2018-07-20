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
    public partial class gestion_citas : System.Web.UI.Page
    {
        method metodo = new method();
        cCitaMedica citaMedica = new cCitaMedica();
        cPaciente paciente = new cPaciente();
        cSecretaria secretaria = new cSecretaria();
        cDoctor doctor = new cDoctor();

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarGridView();
            cargarDropDownListDoctor();
        }

        protected void btn_addClick(object sender, EventArgs e)
        {
            if (txt_rut.Text == "" || txt_fechaAtencion.Text == "" || txt_horaAtencion.Text == "")
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
                    lbl_green.Text = "";
                    lbl_red.Text = "Paciente no registrado";
                }
                else
                {
                    DateTime fechaCita = DateTime.ParseExact(txt_fechaAtencion.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime fechaSolicitud = DateTime.Now;
                    string horaCita = txt_horaAtencion.Text;
                    string estado = "Activa";
                    string id_doctor = dp_doctor.Text;
                    string id_secretaria = (string)Session["idUsuario"];

                    CitaMedica cit = new CitaMedica();
                    cit.fechaCita_CitaMedica = fechaCita;
                    cit.fechaSol_CitaMedica = fechaSolicitud;
                    cit.hora_CitaMedica = horaCita;
                    cit.estado_CitaMedica = estado;
                    cit.Paciente_idPaciente_CitaMedica = Int32.Parse(id_paciente);
                    cit.Doctor_idDoctor_CitaMedica = Int32.Parse(id_doctor);
                    cit.Secretario_idSecretaria_CitaMedica = Int32.Parse(id_secretaria);

                    if (citaMedica.addCitaMedica(cit))
                    {
                        txt_fechaAtencion.Text = "";
                        txt_horaAtencion.Text = "";
                        txt_rut.Text = "";
                        lbl_red.Text = "";
                        lbl_green.Text = "Cita agendada con exito";
                        cargarGridView();
                        cargarDropDownListDoctor();
                    }
                    else
                    {
                        lbl_green.Text = "";
                        lbl_red.Text = "No se ha podido agregar la cita";
                    }
                }
            }
            else
            {
                lbl_green.Text = "";
                lbl_red.Text = "Rut invalido";
            }
        }

        protected void btn_editClick(object sender, EventArgs e)
        {
        }


        protected void gv_citas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "btnEdit")
            {
                CitaMedica cit = new CitaMedica();

                var queryCitaMedica = from c in citaMedica.listCitaMedica()
                                      select c;
                foreach (var item in queryCitaMedica)
                {
                    if (item.id_CitaMedica == Int32.Parse(gv_citas.Rows[fila].Cells[0].Text))
                    {
                        cit.id_CitaMedica = item.id_CitaMedica;
                        cit.fechaCita_CitaMedica = item.fechaCita_CitaMedica;
                        cit.fechaSol_CitaMedica = item.fechaSol_CitaMedica;
                        cit.hora_CitaMedica = item.hora_CitaMedica;
                        cit.estado_CitaMedica = "Activa";
                        cit.Paciente_idPaciente_CitaMedica = item.Paciente_idPaciente_CitaMedica;
                        cit.Doctor_idDoctor_CitaMedica = item.Doctor_idDoctor_CitaMedica;
                        cit.Secretario_idSecretaria_CitaMedica = item.Secretario_idSecretaria_CitaMedica;
                    }
                }

                if (citaMedica.EditCitaMedica(cit))
                {
                    lbl_red.Text = "";
                    lbl_green.Text = "Cita anulada con exito";
                    cargarGridView();
                }
                else
                {
                    lbl_red.Text = "No se ha podido anular la cita";
                    lbl_green.Text = "";
                    cargarGridView();
                }
            }

            if (e.CommandName == "btnAbort")
            {
                CitaMedica cit = new CitaMedica();

                var queryCitaMedica = from c in citaMedica.listCitaMedica()
                                      select c;
                foreach (var item in queryCitaMedica)
                {
                    if (item.id_CitaMedica == Int32.Parse(gv_citas.Rows[fila].Cells[0].Text))
                    {
                        cit.id_CitaMedica = item.id_CitaMedica;
                        cit.fechaCita_CitaMedica = item.fechaCita_CitaMedica;
                        cit.fechaSol_CitaMedica = item.fechaSol_CitaMedica;
                        cit.hora_CitaMedica = item.hora_CitaMedica;
                        cit.estado_CitaMedica = "Anulada";
                        cit.Paciente_idPaciente_CitaMedica = item.Paciente_idPaciente_CitaMedica;
                        cit.Doctor_idDoctor_CitaMedica = item.Doctor_idDoctor_CitaMedica;
                        cit.Secretario_idSecretaria_CitaMedica = item.Secretario_idSecretaria_CitaMedica;
                    }
                }

                if (citaMedica.EditCitaMedica(cit))
                {
                    lbl_red.Text = "";
                    lbl_green.Text = "Cita anulada con exito";
                    cargarGridView();
                }
                else
                {
                    lbl_red.Text = "No se ha podido anular la cita";
                    lbl_green.Text = "";
                    cargarGridView();
                }
            }
        }

        public void cargarGridView()
        {
            var queryTable = from cit in citaMedica.listCitaMedica()
                             join pac in paciente.listPaciente() on cit.Paciente_idPaciente_CitaMedica equals pac.id_Paciente
                             join doc in doctor.listDoctor() on cit.Doctor_idDoctor_CitaMedica equals doc.id_Doctor
                             join sec in secretaria.listSecretaria() on cit.Secretario_idSecretaria_CitaMedica equals sec.id_Secretaria
                             select new
                             {
                                 cit.id_CitaMedica,
                                 cit.fechaCita_CitaMedica,
                                 cit.fechaSol_CitaMedica,
                                 cit.hora_CitaMedica,
                                 cit.estado_CitaMedica,
                                 pac.nombres_Paciente,
                                 doc.nombres_Doctor,
                                 sec.nombre_Secretaria
                             };
            gv_citas.DataSource = queryTable.ToList();
            gv_citas.DataBind();
        }

        public void cargarDropDownListDoctor()
        {
            dp_doctor.DataSource = from doc in doctor.listDoctor()
                                   select new
                                   {
                                       Doctor_value = doc.id_Doctor,
                                       Doctor_text = doc.nombres_Doctor + " " + doc.apellidos_Doctor
                                   };

            dp_doctor.DataTextField = "Doctor_text";
            dp_doctor.DataValueField = "Doctor_value";
            dp_doctor.DataBind();
        }
    }
}
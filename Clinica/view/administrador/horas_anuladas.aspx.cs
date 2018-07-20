using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clinica.controller;
using Clinica.model;

namespace Clinica.view.administrador
{
    public partial class horas_anuladas : System.Web.UI.Page
    {
        method metodo = new method();
        cPaciente paciente = new cPaciente();
        cCitaMedica citaMedica = new cCitaMedica();
        cDoctor doctor = new cDoctor();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGridView();
            }
        }

        protected void btn_excelClick(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Pacientes.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Charset = "";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                gv_data.AllowPaging = false;

                this.cargarGridView();

                foreach (TableCell cell in gv_data.HeaderRow.Cells)
                {
                    cell.BackColor = gv_data.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gv_data.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gv_data.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gv_data.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gv_data.RenderControl(hw);

                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }

        public void cargarGridView()
        {
            var queryTable = from cit in citaMedica.listCitaMedica()
                             where cit.estado_CitaMedica == "Anulada"
                             select new
                             {
                                 cit.fechaSol_CitaMedica,
                                 cit.fechaCita_CitaMedica,
                                 cit.hora_CitaMedica,
                                 cit.estado_CitaMedica,
                                 nPaciente = cit.Paciente.nombres_Paciente + " " + cit.Paciente.apellidos_Paciente,
                                 nDoctor = cit.Doctor.nombres_Doctor + " " + cit.Doctor.apellidos_Doctor,
                                 nSecretaria = cit.Secretaria.nombre_Secretaria + " " + cit.Secretaria.apellidos_Secretaria
                             };

            gv_data.DataSource = queryTable;
            gv_data.DataBind();
        }
    }
}
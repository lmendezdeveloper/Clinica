using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clinica.controller;
using Clinica.model;

namespace Clinica.view.doctor
{
    public partial class historial_clinico : System.Web.UI.Page
    {
        method metodo = new method();
        cPaciente paciente = new cPaciente();
        cCitaMedica citaMedica = new cCitaMedica();
        cFichaMedica fichaMedica = new cFichaMedica();

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarGridView(null);
        }

        protected void btn_buscarClick(object sender, EventArgs e)
        {
            cargarGridView(txt_rut.Text);
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
                this.cargarGridView(txt_rut.Text);

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

        public void cargarGridView(string rut)
        {
            var queryTable = from fc in fichaMedica.listFichaMedica()
                             where fc.Paciente.rut_Paciente == rut
                             select new
                             {
                                 fc.fechaConsulta_FichaMedica,
                                 nombre_doctor = fc.Doctor.nombres_Doctor + " " + fc.Doctor.apellidos_Doctor,
                                 fc.diagnostico_FichaMedica,
                                 fc.tratamiento_FichaMedica,
                                 fc.medicamento_FichaMedica
                             };
            
            gv_data.DataSource = queryTable.ToList();
            gv_data.DataBind();
        }
    }
}
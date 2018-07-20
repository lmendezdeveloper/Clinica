using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clinica.controller;
using Clinica.model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.html.simpleparser;

namespace Clinica.view.doctor
{
    public partial class ficha_virtual : System.Web.UI.Page
    {
        method metodo = new method();
        cCitaMedica citaMedica = new cCitaMedica();
        cFichaMedica fichaMedica = new cFichaMedica();
        private readonly object DialogResult;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string fecha = DateTime.Now.Date.ToString();
                cargarDropDownListCita(DateTime.Now.Date);
                txt_fechaCitado.Text = fecha.Substring(6, 4) + fecha.Substring(2, 3) + "-" + fecha.Substring(0, 2);
            }
        }

        protected void btn_addClick(object sender, EventArgs e)
        {            
            if(txt_diagnostico.Text == "" || txt_tratamiento.Text == "" || txt_medicamento.Text == "")
            {
                lbl_green.Text = "Debe completar todos los campos";
            } else
            {
                int id_cita = Int32.Parse(dp_citado.Text);

                var queryCitaMedica = from cit in citaMedica.listCitaMedica()
                                         select cit;

                int id_paciente = 0;
                int id_doctor = 0;
                string nombre_paciente = "";
                string nombre_doctor = "";

                foreach (var item in queryCitaMedica)
                {
                    if (item.id_CitaMedica == id_cita)
                    {
                        id_paciente = item.Paciente.id_Paciente;
                        id_doctor = item.Doctor.id_Doctor;
                        nombre_paciente = item.Paciente.nombres_Paciente + " " + item.Paciente.apellidos_Paciente;
                        nombre_doctor = item.Doctor.nombres_Doctor + " " + item.Doctor.apellidos_Doctor;
                    }
                }

                string diagnostico = txt_diagnostico.Text;
                string tratamiento = txt_tratamiento.Text;
                string medicamento = txt_medicamento.Text;
                string estado = "Activo";
                DateTime fecha = DateTime.ParseExact(txt_fechaCitado.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);

                FichaMedica fc = new FichaMedica();
                fc.fechaConsulta_FichaMedica = fecha;
                fc.diagnostico_FichaMedica = diagnostico;
                fc.tratamiento_FichaMedica = tratamiento;
                fc.medicamento_FichaMedica = medicamento;
                fc.estado_FichaMedica = estado;
                fc.Paciente_idPaciente_FichaMedica = id_paciente;
                fc.Doctor_idDoctor_FichaMedica = id_doctor;

                if (fichaMedica.addFichaMedica(fc))
                {
                    To_pdf(nombre_paciente, nombre_doctor, fecha.ToString(), diagnostico, tratamiento, medicamento );
                    lbl_green.Text = "Registro exitoso";
                    txt_diagnostico.Text = "";
                    txt_medicamento.Text = "";
                    txt_tratamiento.Text = "";
                } else
                {
                    lbl_green.Text = "No se ha podido registrar";
                }
            }
        }
        
        public void cargarDropDownListCita(DateTime fecha)
        {
            dp_citado.DataSource = from cit in citaMedica.listCitaMedica()
                                   where cit.fechaCita_CitaMedica == fecha
                                   select new
                                   {
                                       Cita_value = cit.id_CitaMedica,
                                       Cita_text = cit.hora_CitaMedica + " " + cit.Paciente.nombres_Paciente + " " + cit.Paciente.apellidos_Paciente
                                   };

            dp_citado.DataTextField = "Cita_text";
            dp_citado.DataValueField = "Cita_value";
            dp_citado.DataBind();
        }

        protected void onChangeDate (object sender, EventArgs e)
        {
            DateTime fecha = DateTime.ParseExact(txt_fechaCitado.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);

            cargarDropDownListCita(fecha);
        }

        #region crearPDF
        private void To_pdf(string paciente, string doctor, string fecha, string diagnostico, string tratamiento, string medicamento)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=print.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 10f);
            HTMLWorker htmlParser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            pdfDoc.Open();
            string remito = "Autorizo: OSVALDO SANTIAGO ESTRADA";
            string envio = "Fecha:" + DateTime.Now.ToString();

            Chunk chunk = new Chunk("INFORME DE ATENCION", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD));
            pdfDoc.Add(new Paragraph(chunk));
            pdfDoc.Add(new Paragraph("                       "));
            pdfDoc.Add(new Paragraph("                       "));
            pdfDoc.Add(new Paragraph("------------------------------------------------------------------------------------------"));
            pdfDoc.Add(new Paragraph("Paciente: "+ paciente));
            pdfDoc.Add(new Paragraph("Doctor: " + doctor));
            pdfDoc.Add(new Paragraph("Fecha Atención: " + fecha));
            pdfDoc.Add(new Paragraph("------------------------------------------------------------------------------------------"));
            pdfDoc.Add(new Paragraph("DIAGNOSTICO            ", FontFactory.GetFont("ARIAL", 16, iTextSharp.text.Font.BOLD)));
            pdfDoc.Add(new Paragraph(diagnostico));
            pdfDoc.Add(new Paragraph("                       "));
            pdfDoc.Add(new Paragraph("                       "));
            pdfDoc.Add(new Paragraph("------------------------------------------------------------------------------------------"));
            pdfDoc.Add(new Paragraph("TRATAMIENTO            ", FontFactory.GetFont("ARIAL", 16, iTextSharp.text.Font.BOLD)));
            pdfDoc.Add(new Paragraph(tratamiento));
            pdfDoc.Add(new Paragraph("                       "));
            pdfDoc.Add(new Paragraph("                       "));
            pdfDoc.Add(new Paragraph("------------------------------------------------------------------------------------------"));
            pdfDoc.Add(new Paragraph("MEDICAMENTO            ", FontFactory.GetFont("ARIAL", 16, iTextSharp.text.Font.BOLD)));
            pdfDoc.Add(new Paragraph(medicamento));
            pdfDoc.Add(new Paragraph("                       "));
            pdfDoc.Add(new Paragraph("                       "));
            pdfDoc.Add(new Paragraph("------------------------------------------------------------------------------------------"));
            pdfDoc.AddCreationDate();
            pdfDoc.Add(new Paragraph("                       "));
            pdfDoc.Add(new Paragraph("                       "));
            pdfDoc.Add(new Paragraph("                       "));
            pdfDoc.Add(new Paragraph("                       "));
            pdfDoc.Add(new Paragraph("                       "));
            pdfDoc.Add(new Paragraph("                       "));
            pdfDoc.Add(new Paragraph("_______________________", FontFactory.GetFont("ARIAL", 16, iTextSharp.text.Font.BOLD)));
            pdfDoc.Add(new Paragraph("Firma", FontFactory.GetFont("ARIAL", 16, iTextSharp.text.Font.BOLD)));
            pdfDoc.Close();

            Response.Write(pdfDoc);
            Response.End();
        }
        #endregion
    }
}
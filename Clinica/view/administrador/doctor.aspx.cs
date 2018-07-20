using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Clinica.controller;
using Clinica.model;

namespace Clinica.view.administrador
{
    public partial class doctor : System.Web.UI.Page
    {
        method metodo = new method();
        cDoctor doctores = new cDoctor();

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
                var queryDoctor = from doc in doctores.listDoctor()
                                    select doc;
                string id_paciente = null;
                foreach (var item in queryDoctor)
                {
                    if (item.rut_Doctor == rut)
                    {
                        id_paciente = item.id_Doctor.ToString();
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

                    Doctor doc = new Doctor();
                    doc.rut_Doctor = rut;
                    doc.nombres_Doctor = nombres;
                    doc.apellidos_Doctor = apellidos;
                    doc.fechaNac_Doctor = fecha_nacimiento;
                    doc.nTelefono_Doctor = telefono;
                    doc.direccion_Doctor = direccion;
                    doc.clave_Doctor = clave;
                    doc.estado_Doctor = estado;

                    if (doctores.addDoctor(doc))
                    {
                        txt_rut.Text = "";
                        txt_nombre.Text = "";
                        txt_apellido.Text = "";
                        txt_fecha.Text = "";
                        txt_telefono.Text = "";
                        txt_direccion.Text = "";
                        dp_estado.SelectedValue = "Activo";
                        lbl_red.Text = "";
                        lbl_green.Text = "Doctor agendado con exito";
                        cargarGridView();
                    }
                    else
                    {
                        lbl_green.Text = "";
                        lbl_red.Text = "No se ha podido agregar al Doctor";
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

        protected void btn_addEditClick(object sender, EventArgs e)
        {
            if (txt_rut.Text == "" || txt_nombre.Text == "" || txt_apellido.Text == "" || txt_fecha.Text == "" || txt_telefono.Text == "" || txt_direccion.Text == "")
            {
                lbl_green.Text = "";
                lbl_red.Text = "Debe llenar todos los campos";
            }
            else if (metodo.validarRut(txt_rut.Text) == true)
            {
                string rut = metodo.formatRut(txt_rut.Text);
                var queryDoctor = from doc in doctores.listDoctor()
                                  select doc;
                int id_doctor = 0;
                foreach (var item in queryDoctor)
                {
                    if (item.rut_Doctor == rut)
                    {
                        id_doctor = item.id_Doctor;
                    }
                }
                if (id_doctor != 0)
                {
                    string nombres = txt_nombre.Text;
                    string apellidos = txt_apellido.Text;
                    DateTime fecha_nacimiento = DateTime.ParseExact(txt_fecha.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    string telefono = txt_telefono.Text;
                    string direccion = txt_direccion.Text;
                    string clave = "123";
                    string estado = dp_estado.Text;

                    Doctor doc = new Doctor();
                    doc.id_Doctor = id_doctor;
                    doc.rut_Doctor = rut;
                    doc.nombres_Doctor = nombres;
                    doc.apellidos_Doctor = apellidos;
                    doc.fechaNac_Doctor = fecha_nacimiento;
                    doc.nTelefono_Doctor = telefono;
                    doc.direccion_Doctor = direccion;
                    doc.clave_Doctor = clave;
                    doc.estado_Doctor = estado;

                    if (doctores.EditDoctor(doc))
                    {
                        txt_rut.Text = "";
                        txt_nombre.Text = "";
                        txt_apellido.Text = "";
                        txt_fecha.Text = "";
                        txt_telefono.Text = "";
                        txt_direccion.Text = "";
                        dp_estado.SelectedValue = "Activo";
                        txt_rut.ReadOnly = false;
                        btn_add.Visible = true;
                        btn_edit.Visible = false;
                        lbl_red.Text = "";
                        lbl_green.Text = "Doctor editado con exito";
                        cargarGridView();
                    }
                    else
                    {
                        txt_rut.Text = "";
                        txt_nombre.Text = "";
                        txt_apellido.Text = "";
                        txt_fecha.Text = "";
                        txt_telefono.Text = "";
                        txt_direccion.Text = "";
                        dp_estado.SelectedValue = "Activo";
                        txt_rut.ReadOnly = false;
                        btn_add.Visible = true;
                        btn_edit.Visible = false;
                        lbl_red.Text = "";
                        lbl_green.Text = "";
                        lbl_red.Text = "No se han realizado cambios";
                        cargarGridView();
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

        protected void btn_excelClick(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Doctores.xls");
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

        protected void gv_data_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "btnEdit")
            {
                txt_rut.Text = gv_data.Rows[fila].Cells[1].Text;
                txt_nombre.Text = gv_data.Rows[fila].Cells[2].Text;
                txt_apellido.Text = gv_data.Rows[fila].Cells[3].Text;
                txt_fecha.Text = gv_data.Rows[fila].Cells[4].Text.Substring(6, 4) + gv_data.Rows[fila].Cells[4].Text.Substring(2, 3) + "-" + gv_data.Rows[fila].Cells[4].Text.Substring(0, 2);
                txt_telefono.Text = gv_data.Rows[fila].Cells[5].Text;
                txt_direccion.Text = gv_data.Rows[fila].Cells[6].Text;
                dp_estado.SelectedValue = gv_data.Rows[fila].Cells[7].Text;
                btn_add.Visible = false;
                btn_edit.Visible = true;
                lbl_green.Text = "";
                lbl_red.Text = "";
                txt_rut.ReadOnly = true;
            }
            if (e.CommandName == "btnDelete")
            {
                int id_doctor = Int32.Parse(gv_data.Rows[fila].Cells[0].Text);

                if (doctores.DeleteDoctor(id_doctor))
                {
                    lbl_red.Text = "";
                    lbl_green.Text = "Doctor eliminado con exito";
                    cargarGridView();
                }
                else
                {
                    lbl_green.Text = "";
                    lbl_red.Text = "No se ha podido eliminar";
                }
            }
        }


        public void cargarGridView()
        {
            var queryTable = from doc in doctores.listDoctor()
                             select doc;

            gv_data.DataSource = queryTable.ToList();
            gv_data.DataBind();
        }
    }
}
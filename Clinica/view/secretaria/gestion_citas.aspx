<%@ Page Title="" Language="C#" MasterPageFile="~/view/secretaria/master_secretaria.Master" AutoEventWireup="true" CodeBehind="gestion_citas.aspx.cs" Inherits="Clinica.view.secretaria.gestion_citas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card-margin">
        <div class="container h-100">
            <div class="row h-100 justify-content-center align-items-center">
                <div class="card card-color mb-3 col-md-12 h-100 d-inline-block">
                    <div class="card-body">
                        <div class="form-row">
                            <div class="col-12">
                                <h3 class="card-title">Gestión Citas Medicas</h3>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-2">
                                <br>
                                <asp:Label Text="Fecha Atención: " runat="server" />
                                <asp:TextBox ID="txt_fechaAtencion" runat="server" TextMode="Date" CssClass="form-control" PlaceHolder="dd/mm/aaaa"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <br>
                                <asp:Label Text="Hora Atención: " runat="server" />
                                <asp:TextBox ID="txt_horaAtencion" runat="server" TextMode="Time" CssClass="form-control" PlaceHolder="dd/mm/aaaa"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <br>
                                <asp:Label Text="Rut Paciente: " runat="server" />
                                <asp:TextBox ID="txt_rut" runat="server" Placeholder="12345678-9" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-4">
                                <br>
                                <asp:Label Text="Seleccione un Doctor(a): " runat="server" />
                                <asp:DropDownList ID="dp_doctor" runat="server" CssClass="form-control" DataTextField="descripcion" DataValueField="idtipoPrestamo"></asp:DropDownList>
                            </div>
                            <div class="col-2">
                                <br>
                                <br>
                                <asp:Button ID="btn_edit" runat="server" Text="Actualizar Cita" Visible="false" CssClass="btn btn-success btn-block" OnClick="btn_editClick" />
                                <asp:Button ID="btn_add" runat="server" Text="Agregar Cita" CssClass="btn btn-primary btn-block" OnClick="btn_addClick" />
                            </div>
                        </div>
                        <br>
                        <div class="text-center text-danger">
                            <asp:Label ID="lbl_red" runat="server"></asp:Label>
                        </div>
                        <div class="text-center text-success">
                            <asp:Label ID="lbl_green" runat="server"></asp:Label>
                        </div>
                        <asp:GridView ID="gv_citas" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" OnRowCommand="gv_citas_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="id_CitaMedica" HeaderText="ID" Visible="true" />
                                <asp:BoundField DataField="fechaSol_CitaMedica" HeaderText="Fecha Solicitud" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="fechaCita_CitaMedica" HeaderText="Fecha Cita" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="hora_CitaMedica" HeaderText="Hora Cita" />
                                <asp:BoundField DataField="nombre_Secretaria" HeaderText="Secretario(a)" />
                                <asp:BoundField DataField="nombres_Doctor" HeaderText="Doctor(a)" />
                                <asp:BoundField DataField="nombres_Paciente" HeaderText="Paciente" />
                                <asp:BoundField DataField="estado_CitaMedica" HeaderText="Estado" />
                                <asp:ButtonField CommandName="btnEdit" runat="server" Text="Editar" ControlStyle-CssClass="btn btn-sm btn-info" />
                                <asp:ButtonField CommandName="btnAbort" runat="server" Text="Anular" ControlStyle-CssClass="btn btn-sm btn-danger" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

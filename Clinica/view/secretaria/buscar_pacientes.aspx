<%@ Page Title="" Language="C#" MasterPageFile="~/view/secretaria/master_secretaria.Master" AutoEventWireup="true" CodeBehind="buscar_pacientes.aspx.cs" Inherits="Clinica.view.secretaria.buscar_pacientes" %>

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
                                <h3 class="card-title">Mis Pacientes</h3>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-2">
                                <br>
                                <asp:label text="Rut: " runat="server" />
                                <asp:textbox id="txt_rut" runat="server" placeholder="12345678-9" cssclass="form-control"></asp:textbox>
                            </div>
                            <div class="col-md-4">
                                <br>
                                <asp:label text="Nombres: " runat="server" />
                                <asp:textbox id="txt_nombre" runat="server" placeholder="Nicolás Ignacio" cssclass="form-control"></asp:textbox>
                            </div>
                        </div>
                        <br>
                        <div class="text-center text-danger">
                            <asp:label id="lbl_red" runat="server"></asp:label>
                        </div>
                        <div class="text-center text-success">
                            <asp:label id="lbl_green" runat="server"></asp:label>
                        </div>
                        <asp:gridview id="gv_data" runat="server" autogeneratecolumns="False" cssclass="table table-bordered table-striped">
                            <Columns>
                                <asp:BoundField DataField="rut_Paciente" HeaderText="Rut" />
                                <asp:BoundField DataField="nombres_Paciente" HeaderText="Nombres" />
                                <asp:BoundField DataField="apellidos_Paciente" HeaderText="Apellidos" />
                                <asp:BoundField DataField="fechaNac_Paciente" HeaderText="Fecha Nac." DataFormatString="{0:d}" />
                                <asp:BoundField DataField="nTelefono_Paciente" HeaderText="Telefono" />
                                <asp:BoundField DataField="direccion_Paciente" HeaderText="Dirección" />
                            </Columns>
                        </asp:gridview>
                        <div class="form-row">
                            <div class="col-10">
                            </div>
                            <div class="col-2">
                                <asp:button id="btn_excel" runat="server" text="Exportar a excel" cssclass="btn btn-success btn-block" onclick="btn_excelClick" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/view/doctor/master_doctor.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="mis_pacientes.aspx.cs" Inherits="Clinica.view.doctor.mis_pacientes" %>
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
                                <asp:Label Text="Rut: " runat="server" />
                                <asp:TextBox ID="txt_rut" runat="server" Placeholder="12345678-9" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <br>
                                <asp:Label Text="Nombres: " runat="server" />
                                <asp:TextBox ID="txt_nombre" runat="server" Placeholder="Nicolás Ignacio" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <br>
                        <div class="text-center text-danger">
                            <asp:Label ID="lbl_red" runat="server"></asp:Label>
                        </div>
                        <div class="text-center text-success">
                            <asp:Label ID="lbl_green" runat="server"></asp:Label>
                        </div>
                        <asp:GridView ID="gv_data" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" >
                            <Columns>
                                <asp:BoundField DataField="rut_Paciente" HeaderText="Rut" />
                                <asp:BoundField DataField="nombres_Paciente" HeaderText="Nombres" />
                                <asp:BoundField DataField="apellidos_Paciente" HeaderText="Apellidos" />
                                <asp:BoundField DataField="fechaNac_Paciente" HeaderText="Fecha Nac." DataFormatString="{0:d}" />
                                <asp:BoundField DataField="nTelefono_Paciente" HeaderText="Telefono" />
                                <asp:BoundField DataField="direccion_Paciente" HeaderText="Dirección" />
                            </Columns>
                        </asp:GridView>
                        <div class="form-row">
                            <div class="col-10">
                            </div>
                            <div class="col-2">
                                <asp:Button ID="btn_excel" runat="server" Text="Exportar a excel" CssClass="btn btn-success btn-block" OnClick="btn_excelClick" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

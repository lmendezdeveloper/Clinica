﻿<%@ Page Title="" Language="C#" MasterPageFile="~/view/administrador/master_administrador.Master" AutoEventWireup="true" CodeBehind="horas_anuladas.aspx.cs" Inherits="Clinica.view.administrador.horas_anuladas" %>

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
                                <br />
                                <h3 class="card-title">Atenciones anuladas</h3>
                            </div>
                        </div>
                        <br>
                        <div class="text-center text-danger">
                            <asp:Label ID="lbl_red" runat="server"></asp:Label>
                        </div>
                        <div class="text-center text-success">
                            <asp:Label ID="lbl_green" runat="server"></asp:Label>
                        </div>
                        <asp:GridView ID="gv_data" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped">
                            <Columns>
                                <asp:BoundField DataField="fechaSol_CitaMedica" HeaderText="Fecha Sol." DataFormatString="{0:d}" />
                                <asp:BoundField DataField="fechaCita_CitaMedica" HeaderText="Fecha Cita" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="hora_CitaMedica" HeaderText="Hora Cita" />
                                <asp:BoundField DataField="estado_CitaMedica" HeaderText="Estado" />
                                <asp:BoundField DataField="nPaciente" HeaderText="Paciente" />
                                <asp:BoundField DataField="nDoctor" HeaderText="Doctor" />
                                <asp:BoundField DataField="nSecretaria" HeaderText="Secretaria" />
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

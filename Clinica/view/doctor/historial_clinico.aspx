<%@ Page Title="" Language="C#" MasterPageFile="~/view/doctor/master_doctor.Master" AutoEventWireup="true" CodeBehind="historial_clinico.aspx.cs" Inherits="Clinica.view.doctor.historial_clinico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card-margin">
        <div class="container h-100">
            <div class="row h-100 justify-content-center align-items-center">
                <div class="card card-color mb-3 col-md-12 h-100 d-inline-block">
                    <div class="card-body">
                        <div class="form-row">
                            <div class="col-8">
                                <br />
                                <h3 class="card-title">Historial Clinico</h3>
                            </div>
                            <div class="col-md-2">
                                <asp:Label Text="Rut: " runat="server" />
                                <asp:TextBox ID="txt_rut" runat="server" Placeholder="12345678-9" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <br />
                                <asp:Button ID="btn_buscar" runat="server" Text="Buscar" CssClass="btn btn-primary btn-block" OnClick="btn_buscarClick" />
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
                                <asp:BoundField DataField="fechaConsulta_FichaMedica" HeaderText="Fecha Atenciòn" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="nombre_doctor" HeaderText="Doctor" />
                                <asp:BoundField DataField="diagnostico_FichaMedica" HeaderText="Diagnostico" />
                                <asp:BoundField DataField="tratamiento_FichaMedica" HeaderText="Tratamiento" />
                                <asp:BoundField DataField="medicamento_FichaMedica" HeaderText="Medicamento" />
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

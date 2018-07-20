<%@ Page Title="" Language="C#" MasterPageFile="~/view/doctor/master_doctor.Master" AutoEventWireup="true"  EnableEventValidation="false" CodeBehind="ficha_virtual.aspx.cs" Inherits="Clinica.view.doctor.ficha_virtual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card-margin">
        <div class="container h-100">
            <div class="row h-100 justify-content-center align-items-center">
                <div class="card card-color mb-3 col-md-12 h-100 d-inline-block">
                    <div class="card-body">
                        <div class="form-row">
                            <div class="col-6">
                                <br />
                                <h3 class="card-title">Ficha Virtual</h3>
                            </div>
                            <div class="col-md-2">
                                <asp:Label Text="Fecha citación: " runat="server" />
                                <asp:TextBox OnTextChanged="onChangeDate" AutoPostBack="true" ID="txt_fechaCitado" runat="server" TextMode="Date" CssClass="form-control" PlaceHolder="dd/mm/aaaa"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:Label Text="Seleccione citado: " runat="server" />
                                <asp:DropDownList ID="dp_citado" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-12">
                                <br>
                                <asp:Label Text="Diagnostico: " runat="server" />
                                <asp:TextBox ID="txt_diagnostico" TextMode="multiline" Columns="50" Rows="2" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-md-12">
                                <br>
                                <asp:Label Text="Tratamiento: " runat="server" />
                                <asp:TextBox ID="txt_tratamiento" TextMode="multiline" Columns="50" Rows="2" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-md-12">
                                <br>
                                <asp:Label Text="Medicamento: " runat="server" />
                                <asp:TextBox ID="txt_medicamento" TextMode="multiline" Columns="50" Rows="2" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-10 text-center text-success">
                                <asp:Label ID="lbl_green" runat="server"></asp:Label>
                            </div>
                            <div class="col-2">
                                <br />
                                <asp:Button ID="btn_add" runat="server" Text="Guardar" CssClass="btn btn-primary btn-block" OnClick="btn_addClick" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

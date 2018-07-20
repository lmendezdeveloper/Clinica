<%@ Page Title="" Language="C#" MasterPageFile="~/view/administrador/master_administrador.Master" AutoEventWireup="true" EnableEventValidation = "false" CodeBehind="secretaria.aspx.cs" Inherits="Clinica.view.administrador.secretaria" %>
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
                                <h3 class="card-title">Mantenedor Secretaria</h3>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-2">
                                <br>
                                <asp:Label Text="Rut: " runat="server" />
                                <asp:TextBox ID="txt_rut" runat="server" Placeholder="12345678-9" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-5">
                                <br>
                                <asp:Label Text="Nombres: " runat="server" />
                                <asp:TextBox ID="txt_nombre" runat="server" Placeholder="Nicolás Ignacio" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-5">
                                <br>
                                <asp:Label Text="Apellidos: " runat="server" />
                                <asp:TextBox ID="txt_apellido" runat="server" Placeholder="Luco Palomino" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <br>
                                <asp:Label Text="Estado: " runat="server" />
                                <asp:DropDownList ID="dp_estado" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="Activo" Text="Activo"></asp:ListItem>
                                    <asp:ListItem Value="Inactivo" Text="Inactivo"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <br>
                                <asp:Label Text="Telefono: " runat="server" />
                                <asp:TextBox ID="txt_telefono" runat="server" Placeholder="987654321" TextMode="Phone" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <br>
                                <asp:Label Text="Direccion: " runat="server" />
                                <asp:TextBox ID="txt_direccion" runat="server" Placeholder="Psj. 4 Norte 1540, Talca" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-2">
                                <br>
                                <br>
                                <asp:Button ID="btn_edit" runat="server" Text="Actualizar" Visible="false" CssClass="btn btn-success btn-block" OnClick="btn_addEditClick"/>
                                <asp:Button ID="btn_add" runat="server" Text="Agregar" CssClass="btn btn-primary btn-block" OnClick="btn_addClick" />
                            </div>
                        </div>
                        <br>
                        <div class="text-center text-danger">
                            <asp:Label ID="lbl_red" runat="server"></asp:Label>
                        </div>
                        <div class="text-center text-success">
                            <asp:Label ID="lbl_green" runat="server"></asp:Label>
                        </div>
                        <asp:GridView ID="gv_data" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" OnRowCommand="gv_data_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="id_Secretaria" HeaderText="ID" Visible="true" />
                                <asp:BoundField DataField="rut_Secretaria" HeaderText="Rut" />
                                <asp:BoundField DataField="nombre_Secretaria" HeaderText="Nombres" />
                                <asp:BoundField DataField="apellidos_Secretaria" HeaderText="Apellidos" />
                                <asp:BoundField DataField="nTelefono_Secretaria" HeaderText="Telefono" />
                                <asp:BoundField DataField="direccion_Secretaria" HeaderText="Dirección" />
                                <asp:BoundField DataField="estado_Secretaria" HeaderText="Estado" />
                                <asp:ButtonField CommandName="btnEdit" runat="server" Text="Editar" ControlStyle-CssClass="btn btn-sm btn-info" />
                                <asp:ButtonField CommandName="btnDelete" runat="server" Text="Borrar" ControlStyle-CssClass="btn btn-sm btn-danger" />
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

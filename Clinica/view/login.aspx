<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Clinica.view.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>MiClinica</title>
    <link href="../assets/css/bootstrap.css" rel="stylesheet" />
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assets/css/dashboard.css" rel="stylesheet" />
    <link href="../assets/css/custom.css" rel="stylesheet" />
    <script src="../assets/js/bootstrap.js"></script>
    <script src="../assets/js/bootstrap.min.js"></script>
</head>

<body class="text-center login-body">
    <form class="container h-100" runat="server">
        <div class="row h-100 justify-content-center align-items-center">
            <div class="card card-opacity mb-3 col-md-4 ">
                <div class="card-body">
                    <p class="card-text">
                        <h1 class="h3 mb-3 font-weight-normal">Bienvenido a MiClinica</h1>
                        <br />
                        <asp:DropDownList ID="list_perfil" runat="server" CssClass="form-control">
                            <%--<asp:ListItem Value="1" Text="Paciente"></asp:ListItem>--%>
                            <asp:ListItem Value="2" Text="Secretaria"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Doctor"></asp:ListItem>
                            <asp:ListItem Value="4" Text="Administrador"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:TextBox ID="txt_user" runat="server" placeholder="Rut" CssClass="form-control"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="txt_pass" runat="server" TextMode="Password" placeholder="Contraseña" CssClass="form-control"></asp:TextBox>
                        <br />
                        <asp:Button ID="btn_ingresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" CssClass="btn-lg btn-primary btn-block" />
                        <br />
                        <span class="mt-5 mb-3 text-muted">&copy; Luis Méndez - Rodrigo Manriquez</span>
                    </p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

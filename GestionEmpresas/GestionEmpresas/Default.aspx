<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GestionEmpresas.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inicio Sesion</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <nav class="navbar navbar-default navbar-static-top" role="navigation">
                <img src="images/almerimatik.png" />
            </nav>
        </header>
        <section class="col-md-8 col-md-offset-2">
            <asp:Login ID="Login1" runat="server" FailureText="Usuario o contraseña incorrecto. Inténtelo de nuevo." RenderOuterTable="False"
                 UserNameLabelText="Usuario:" UserNameRequiredErrorMessage="El usuario es obligatorio." OnAuthenticate="Entrar">
            <LayoutTemplate>
                <h1 class="text-center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Inicio de Sesión</h1>
                     <p class="validation-sumary-errors">
                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                     </p> 
                    <hr class="col-md-12 alert-success"/>
                         <div class="col-md-7 col-md-offset-3">
                            <asp:Label CssClass="col-md-offset-5" ID="UserNameLabel" runat="server" AssociatedControlID="UserName">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Login</asp:Label>
                            <asp:TextBox CssClass="form-control text-center" ID="UserName" runat="server" TabIndex="1" placeholder="Login"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="text-danger" ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="El usuario electrónico es obligatorio." ToolTip="El correo electrónico es obligatorio." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                         </div>

                        <div class="col-md-7 col-md-offset-3">
                            <asp:Label CssClass="col-md-offset-5" ID="PasswordLabel" runat="server" AssociatedControlID="Password">&nbsp;Contraseña</asp:Label>
                            <asp:TextBox CssClass="form-control text-center" ID="Password" runat="server" TextMode="Password" placeholder="Contraseña" TabIndex="2"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="text-danger" ID="PasswordRequired" runat="server" ControlToValidate="Password"  ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="Login1" >*</asp:RequiredFieldValidator>
                        </div>
                    
                    <div class="col-md-6 col-md-offset-6">
                            <div class="checkbox" tabindex="3">
                                <asp:CheckBox ID="RememberMe" runat="server" /> Recuerdeme                              
                            </div>
                     </div>    
                     <hr class="col-md-12 alert-success"/>
                     <div class="col-md-6 col-md-offset-3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button CssClass="btn btn-success btn-lg col-md-offset-5" ID="LoginButton" runat="server" CommandName="Login" Text="Entrar" ValidationGroup="Login1" TabIndex="4" />
                     </div>        
                </LayoutTemplate>
            </asp:Login>
        </section>
        <hr class="col-md-6 col-md-offset-3 alert-link"/>
        <footer class="col-md-8 col-md-offset-2 text-center"> © 2009 - 2014 ALMERIMATIK RESERVADOS TODOS LOS DERECHOS </footer>
    </form>
</body>
</html>

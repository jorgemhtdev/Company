<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addEmail.aspx.cs" Inherits="GestionEmpresas.Privada.addEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Añadir email</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid">
        <div class="row"> <br /><br />
            <div class="panel panel-primary text-center col-md-8 col-md-offset-2">
                <div class="panel-heading"> 
                      <h1> Añadir email </h1>
                      - <asp:Label ID="labelmail" runat="server" Text=""></asp:Label> - 
                </div> 
                <div class="panel-body"> <br /><br /><br />
                    <article class="col-md-10 col-md-offset-2"> 
                        <section class="col-md-2 col-md-offset-1">
                            <asp:Label ID="email" runat="server">Mail</asp:Label>   
                         </section>                       
                         <section class="col-md-4">
                            <asp:TextBox id="mail" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="Debes rellenar el correo electronico" ControlToValidate="mail" CssClass="glyphicon glyphicon-asterisk alert-danger"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpression" runat="server" ErrorMessage="Solo se admiten un correo valido(nombreempresa@corroempresa.(extension))" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$" CssClass="glyphicon glyphicon-remove alert-danger" ControlToValidate="mail"></asp:RegularExpressionValidator>
                          </section>
                     </article>  <br /><br />
                    <asp:Label ID="lblError" runat="server" CssClass="label label-danger" Text="Label"></asp:Label>
                    <br /><br /><br />
                     <footer class="col-md-12 col-md-offset-1">
                            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-danger col-md-4" OnClick="Volver" CausesValidation="False" />
                            <asp:Button ID="btnEnviar" runat="server" Text="Añadir" CssClass="btn btn-success col-md-4 col-md-offset-2" OnClick="addMail" OnClientClick="return confirm('¿Estas seguro de guardar estos cambios?');" />                  
                     </footer> <br /><br /><br />
              </div> <!-- panel-heading -->
            </div> <!-- panel panel-primary -->
        </div> <!-- Fin del row -->
    </div> <!-- Fin del container -->
    </form>
</body>
</html>

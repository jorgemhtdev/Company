<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addEmpresa.aspx.cs" Inherits="GestionEmpresas.Privada.addEmpresa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Añadir empresa</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid">
        <div class="row">
             <br /><br />
            <div class="panel panel-primary text-center col-md-8 col-md-offset-2">
                <div class="panel-heading">  <h1> Añadir Empresa  </h1> </div> 
                    <div class="panel-body">
                       <br /><br />

                       <article class="col-md-12 col-md-offset-2"> 
                            <section class="col-md-2 col-md-offset-1">
                                <asp:Label ID="nombre" runat="server">Nombre</asp:Label>   
                            </section>                       
                            <section class="col-md-4">
                                     <asp:TextBox id="nombreEmpresa" runat="server" CssClass="form-control"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidatornombreEmpresa" runat="server"
                                             ErrorMessage="Debes rellenar nombre comercial" ControlToValidate="nombreEmpresa" CssClass="glyphicon glyphicon-asterisk alert-danger"></asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpressionnombreEmpresa" runat="server"
                                             ErrorMessage="Solo se admiten letras y numeros" ValidationExpression="[A-Za-z0-9 ]*" CssClass="glyphicon glyphicon-remove alert-danger" ControlToValidate="nombreEmpresa"></asp:RegularExpressionValidator>
                            </section>
                        </article>

                        <article class="col-md-12 col-md-offset-2"> 
                            <section class="col-md-2 col-md-offset-1">
                                <asp:Label ID="RasonSocial" runat="server">Razon Social</asp:Label>   
                            </section>                       
                            <section class="col-md-4">
                                <asp:TextBox ID="RazonSocial" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                         ErrorMessage="Debes rellenar el campo razon social" ControlToValidate="RazonSocial" CssClass="glyphicon glyphicon-asterisk alert-danger"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                         ErrorMessage="Solo se admiten letras y numeros" ValidationExpression="[A-Za-z0-9. ]*" CssClass="glyphicon glyphicon-remove alert-danger" ControlToValidate="RazonSocial"></asp:RegularExpressionValidator>         
                            </section>
                        </article>

                        <article class="col-md-12 col-md-offset-2"> 
                            <section class="col-md-2 col-md-offset-1">
                                <asp:Label ID="zif" runat="server">CIF</asp:Label>                        
                            </section>
                            <section class="col-md-4">
                                <asp:TextBox ID="CIF" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                         ErrorMessage="Debes rellenar el campo CIF" ControlToValidate="CIF" CssClass="glyphicon glyphicon-asterisk alert-danger"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                         ErrorMessage="Solo se admite el siguiente formato --> (ABCDEFGHKLMNPQS)8numeros" ValidationExpression="[ABCDEFGHKLMNPQS]{1}[0-9]{8}" CssClass="glyphicon glyphicon-remove alert-danger" ControlToValidate="CIF"></asp:RegularExpressionValidator>      
                            </section>
                        </article>

                        <article class="col-md-12 col-md-offset-2"> 
                            <section class="col-md-2 col-md-offset-1">
                                <asp:Label ID="url" runat="server" >Pagina web</asp:Label>                        
                            </section>
                            <section class="col-md-4">
                                <asp:TextBox ID="paginaWeb" runat="server"  CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                         ErrorMessage="Debes rellenar el campo de pagina web" ControlToValidate="paginaWeb" CssClass="glyphicon glyphicon-asterisk alert-danger"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                         ErrorMessage="Solo se admite el siguiente formato --> http(s)://laweb.com " ValidationExpression="^http(s)?://[a-z0-9-]+(.[a-z0-9-]+)*(:[0-9]+)?(/.*)?$|i" CssClass="glyphicon glyphicon-remove alert-danger" ControlToValidate="paginaWeb"></asp:RegularExpressionValidator>      
                            </section>
                        </article>

                        <article class="col-md-12 col-md-offset-2"> 
                            <section class="col-md-2 col-md-offset-1">
                                <asp:Label ID="zector" runat="server">Sector</asp:Label>                        
                            </section>
                            <section class="col-md-4">
                                <asp:DropDownList ID="sector" runat="server" CssClass="form-control"></asp:DropDownList>
                            </section>
                        </article> <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                        <asp:Label ID="lblError" runat="server" CssClass="label label-danger" Text="Label"></asp:Label>
                        <br /><br /><br /><br /><br /><br />

                        <footer class="col-md-12 col-md-offset-1">
                           
                            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-danger col-md-4" OnClick="Volver" CausesValidation="False" />
                            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-success col-md-4 col-md-offset-2" OnClick="addEmpr" OnClientClick="return confirm('¿Estas seguro?');" /> 
                            
                        </footer>
                        <br /><br /><br />
              </div> <!-- panel-heading -->
            </div> <!-- panel panel-primary -->
        </div> <!-- Fin del row -->
    </div> <!-- Fin del container -->
    </form>
</body>
</html>
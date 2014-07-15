<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editContacto.aspx.cs" Inherits="GestionEmpresas.Privada.editContacto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar contacto</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid">
        <div class="row">
             <br /><br />
            <div class="panel panel-primary text-center col-md-8 col-md-offset-2">
                <div class="panel-heading"> <h1> Editar contacto <span class="glyphicon glyphicon-pencil"></span></h1></div>
                    <div class="panel-body">
                       <br /><br />

                       <article class="col-md-12 col-md-offset-2"> 
                            <section class="col-md-2 col-md-offset-1">
                                <asp:Label ID="nm" runat="server"><h4>Nombre</h4></asp:Label>   
                            </section>                       
                            <section class="col-md-4">
                                     <asp:TextBox id="nomb" runat="server" CssClass="form-control"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidatornombreEmpresa" runat="server"
                                             ErrorMessage="Debes rellenar nombre comercial" ControlToValidate="nomb" CssClass="glyphicon glyphicon-asterisk alert-danger"></asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpressionnombreEmpresa" runat="server"
                                             ErrorMessage="Solo se admiten letras" ValidationExpression="[A-Za-z ]*" CssClass="glyphicon glyphicon-remove alert-danger" ControlToValidate="nomb"></asp:RegularExpressionValidator>
                            </section>
                        </article>

                        <!-- NECESITA UN METODO QUE VALIDE CORRECTAMENTE EL DNI -->

                        <article class="col-md-12 col-md-offset-2"> 
                            <section class="col-md-2 col-md-offset-1">
                                <asp:Label ID="nnif" runat="server"><h4>NIF</h4></asp:Label>   
                            </section>                       
                            <section class="col-md-4">
                                <asp:TextBox ID="nf" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                         ErrorMessage="Debes rellenar el campo de población" ControlToValidate="nf" CssClass="glyphicon glyphicon-asterisk alert-danger"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                         ErrorMessage="El nif no es valido" ValidationExpression="(\d{8})([-]?)([A-Z]{1})" CssClass="glyphicon glyphicon-remove alert-danger" ControlToValidate="nf"></asp:RegularExpressionValidator>         
                            </section>
                        </article><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />

                        <footer class="col-md-12 col-md-offset-1">
                           
                            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-danger col-md-4" OnClick="Volver" />
                            <asp:Button ID="btnEnviar" runat="server" Text="Guardar cambios" CssClass="btn btn-success col-md-4 col-md-offset-2" OnClick="addEmpr" OnClientClick="return confirm('¿Estas seguro?');" /> 
                            
                        </footer>
                        <br /><br /><br />
              </div> <!-- panel-heading -->
            </div> <!-- panel panel-primary -->
        </div> <!-- Fin del row -->
    </div> <!-- Fin del container -->
    </form>
</body>
</html>


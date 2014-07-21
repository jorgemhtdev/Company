<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="500.aspx.cs" Inherits="GestionEmpresas.Privada.errores._500" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error interno del servidor</title>
    <script src="../../Scripts/jquery-1.9.1.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/bootstrap-theme.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
            <h1 class="text-center">Error 500. Error interno.</h1>
            <p class="text-center">¡Ups! Ha ocurrido un error interno en el servidor. Si le aparece este error, contacte con los administradores administracion@almerimatik.es e intentaremos solucionar el problema lo antes posible.</p>
            <p class="text-center"><a href="../../Default.aspx" class="btn btn-primary btn-lg" role="button"><span class="glyphicon glyphicon-home"></span> Volver a inicio.</a></p>
        </div>
    </form>
</body>
</html>

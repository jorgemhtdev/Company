<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="401.aspx.cs" Inherits="GestionEmpresas.Privada.errores._401" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>No autorizado</title>
    <script src="../../Scripts/jquery-1.9.1.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/bootstrap-theme.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
            <h1 class="text-center">Error 401. No autorizado.</h1>
            <p class="text-center">Usted no está autorizado para acceder a este recurso.</p>
            <p class="text-center"><a href="../../Default.aspx" class="btn btn-primary btn-lg" role="button"><span class="glyphicon glyphicon-home"></span>Volver a inicio.</a></p>
        </div>
    </form>
</body>
</html>

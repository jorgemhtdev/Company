<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GestionEmpresas.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Almerimatik</h1>
     <h2> Iniciar sesion </h2>
    
    <asp:Login ID="Login1" runat="server">
    </asp:Login>

    <asp:Button ID="Button1" runat="server" Text="Inciar sesión" />
    <h4>OLVIDÉ MI CONTRASEÑA</h4>
</asp:Content>

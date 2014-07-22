<%@ Page Title="" Language="C#" MasterPageFile="~/Privada/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GestionEmpresas.Privada.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container">
        <h1>Nº Total de:</h1>
        <div class="col-md-2">
            <div class="panel panel-default">
                <div class="panel-heading text-center"><b><a href="gestionEmpresas.aspx">Empresas</a></b></div>
                <div class="panel-body text-center">
                    <h1><asp:Label ID="lblTotalEmpresa" runat="server" Text="Label"></asp:Label></h1>
                </div>
            </div>
        </div>
        <div class="col-md-2">
            <div class="panel panel-default">
                <div class="panel-heading text-center"><b><a href="gestionContacto.aspx">Contactos</a></b></div>
                <div class="panel-body text-center">
                    <h1><asp:Label ID="lblTotalContactos" runat="server" Text="Label"></asp:Label></h1>
                </div>
            </div>
        </div>
        <div class="col-md-2">
            <div class="panel panel-default">
                <div class="panel-heading text-center"><b><a href="gestionContacto.aspx">Acciones</a></b></div>
                <div class="panel-body text-center">
                    <h1><asp:Label ID="lblTotalAccionesComerciales" runat="server" Text="Label"></asp:Label></h1>
                </div>
            </div>
        </div>
        <div class="col-md-2">
            <div class="panel panel-default">
                <div class="panel-heading text-center"><b><a href="gestionUsuarios.aspx">Usuarios</a></b></div>
                <div class="panel-body text-center">
                    <h1><asp:Label ID="lblTotalUsuarios" runat="server" Text="Label"></asp:Label></h1>
                </div>
            </div>
        </div>
        <hr class="col-md-12"/>

    </div>
</asp:Content>